using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using bleak.TaxToolKit.ConsoleApp;
using bleak.TaxToolKit.ConsoleApp.FileOps;
using bleak.Api.Rest;
using bleak.TaxToolKit.ConsoleApp.CoinGecko.DTOs;
using bleak.TaxToolKit.ConsoleApp.Configuration;

namespace bleak.TaxToolKit.ConsoleApp.Apps
{
    [ConsoleAppSettings(Id = 2, Name = "Process Ethereum Transactions App", Description = "Processes Ethereum transactions from a CSV file.")]
    public class ProcessEthereumTransactionsApp : IConsoleApp
    {
        JsonSerializer Serializer { get; set; }
        RestManager RestManager { get; set; }
        public List<CoinDto> Coins { get; private set; }

        public ProcessEthereumTransactionsApp()
        {
            Serializer = new JsonSerializer();
            RestManager = new RestManager(Serializer, Serializer);
            Coins = GetCoins();
        }
        
        public void Run()
        {
            string csvFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "EtherscanTrans.csv");
            if (!File.Exists(csvFilePath))
            {
                Console.WriteLine($"File not found: {csvFilePath}");
                return;
            }

            List<EthereumTransaction> transactions = LoadTransactionsFromCsv(csvFilePath);
            FillInCoinGeckoIds(transactions);

            
            foreach (var transaction in transactions)
            {
                var price = GetHistoricalPrice(transaction.DateTimeUTC, transaction.TokenName);
                if (price != null)
                {
                    Console.WriteLine($"Price {transaction.TokenSymbol} was {price.market_data.current_price["usd"]} at {transaction.DateTimeUTC}");
                }
            }

            WriteCsv(transactions);

        }

        private static void WriteCsv(List<EthereumTransaction> transactions)
        {
            string outputFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "UpdatedEtherscanTrans.csv");
            using (var writer = new StreamWriter(outputFilePath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(transactions);
            }

            Console.WriteLine($"Updated transactions written to: {outputFilePath}");
        }

        private void FillInCoinGeckoIds(List<EthereumTransaction> transactions)
        {
            var uniqueTokenSymbols = transactions
                                                    .Where(t => string.IsNullOrEmpty(t.CoinGeckoId))
                                                    .Select(t => t.TokenSymbol).Distinct();

            if (AppConfiguration.Instance.Debug) { Console.WriteLine($"There are {uniqueTokenSymbols.Count()} with Empty CoinGeckoIds"); }
            foreach (var tokenSymbol in uniqueTokenSymbols)
            {
                Console.WriteLine($"Finding... {tokenSymbol}");
                var coinGeckoId = LoadCoinGeckoId(tokenSymbol);
                foreach (var transaction in transactions.Where(tx => tx.TokenSymbol == tokenSymbol))
                {
                    transaction.CoinGeckoId = coinGeckoId;
                }
            }
        }

        private string LoadCoinGeckoId(string symbol)
        {
            var coins = Coins.Where(c => c.symbol.ToLowerInvariant() == symbol.ToLowerInvariant());
            
            if (coins.Count() == 0)
            {
                Console.WriteLine($"No Coins were found in Coins out of {Coins.Count} matching {symbol}");
                return string.Empty;
            }
            if (coins.Count() > 1)
            {
                Console.WriteLine($"{coins.Count()} Coins were found matching {symbol}!!!! Which one?!");

                int selectedIndex;
                do
                {
                    
                    int index = 1;
                    foreach (var coin in coins)
                    {
                        Console.WriteLine($"{index}: {coin.name} ({coin.symbol})");
                        index++;
                    }

                    Console.WriteLine("Please enter the number of the coin you want to use:");
                } while (!int.TryParse(Console.ReadLine(), out selectedIndex) || selectedIndex <= 0 || selectedIndex > coins.Count());

                var selectedCoin = coins.ElementAt(selectedIndex - 1);
                Console.WriteLine($"You selected: {selectedCoin.name} ({selectedCoin.symbol})");
                return selectedCoin.id;
            }
            return coins.First().id;
        }

        private HistoricalPriceDto? GetHistoricalPrice(DateTime dateTime, string coinGeckoId)
        {
            if (string.IsNullOrEmpty(coinGeckoId))
            {
                return null;
            }

            // API endpoint
            string baseUrl = "https://api.coingecko.com";
            string endpoint = $"/api/v3/coins/wrapped-ether/history/?date={dateTime.ToString("dd-MM-yyyy")}";
            string url = $"{baseUrl}{endpoint}";

            if (AppConfiguration.Instance.Debug) { Console.WriteLine($"Loading... {url}"); }

            var response = RestManager.ExecuteRestMethod<HistoricalPriceDto, string>(
                uri: new Uri(url),
                verb: HttpVerbs.GET
            );
            
            if (response.Error == null)
            {
                Console.WriteLine($"error: {response.Error}");
                return null;
            }
            else if (string.IsNullOrEmpty(response.UnhandledError))
            {
                Console.WriteLine($"Unhandled Error: {response.UnhandledError}");
                return null;
            }
            return response.Results;
        }
        private List<CoinDto> GetCoins()
        {
            // API endpoint
            string baseUrl = "https://api.coingecko.com";
            string endpoint = "/api/v3/coins/list";
            string url = $"{baseUrl}{endpoint}";


            var response = RestManager.ExecuteRestMethod<List<CoinDto>, string>(
                uri: new Uri(url),
                verb: HttpVerbs.GET
            );
            return response.Results;
        }


        private List<EthereumTransaction> LoadTransactionsFromCsv(string csvFilePath)
        {
            var transactions = new List<EthereumTransaction>();

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                HeaderValidated = null,
                MissingFieldFound = null,
            };

            if (AppConfiguration.Instance.Debug) { Console.WriteLine($"transaction count : {transactions.Count}"); }
            using (var reader = new StreamReader(csvFilePath))
            {
                using (var csv = new CsvReader(reader, config))
                {
                    transactions = csv.GetRecords<EthereumTransaction>().ToList();
                    Console.WriteLine($"transaction count : {transactions.Count}");
                }
            }

            return transactions;
        }
    }
}