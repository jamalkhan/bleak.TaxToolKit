using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using bleak.TaxToolKit.ConsoleApp;
using bleak.TaxToolKit.ConsoleApp.FileOps;

namespace bleak.TaxToolKit.ConsoleApp.Apps
{
    [ConsoleAppSettings(Id = 2, Name = "Process Ethereum Transactions App", Description = "Processes Ethereum transactions from a CSV file.")]
    public class ProcessEthereumTransactionsApp : IConsoleApp
    {
        public void Run()
        {
            string csvFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "EtherscanTrans.csv");
            if (!File.Exists(csvFilePath))
            {
                Console.WriteLine($"File not found: {csvFilePath}");
                return;
            }

            List<EthereumTransaction> transactions = LoadTransactionsFromCsv(csvFilePath);

            foreach (var transaction in transactions)
            {
                Console.WriteLine($"Transaction Hash: {transaction.TransactionHash}, From: {transaction.From}, To: {transaction.To}, Value: {transaction.TokenValue}, DateTimeUTC: {transaction.DateTimeUTC}");
            }
        }

        private List<EthereumTransaction> LoadTransactionsFromCsv(string csvFilePath)
        {
            var transactions = new List<EthereumTransaction>();

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
            };

            using (var reader = new StreamReader(csvFilePath))
            {
                using (var csv = new CsvReader(reader, config))
                {
                    transactions = csv.GetRecords<EthereumTransaction>().ToList();
                }
            }

            return transactions;
        }
    }
}