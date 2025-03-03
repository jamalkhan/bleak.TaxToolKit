using bleak.Api.Rest;
using bleak.TaxToolKit.ConsoleApp.CoinGecko.DTOs;

namespace bleak.TaxToolKit.ConsoleApp.Apps
{

    [ConsoleAppSettingsAttribute(Id = 1, Name = "Get Coins")]
    public class GetCoinsApp : IConsoleApp
    {
        static JsonSerializer _serializer = new JsonSerializer();
        static RestManager _restManager = new RestManager(_serializer, _serializer);

        public GetCoinsApp()
        {
        }

        public void Run()
        {
            var coins = GetCoins();
            foreach (var coin in coins)
            {
                Console.WriteLine($"Id: {coin.id}, Symbol: {coin.symbol}, Name: {coin.name}");
            }
        }

        private List<CoinDto> GetCoins()
        {
            // API endpoint
            string baseUrl = "https://api.coingecko.com";
            string endpoint = "/api/v3/coins/list";
            string url = $"{baseUrl}{endpoint}";


            var response = _restManager.ExecuteRestMethod<List<CoinDto>, string>(
                uri: new Uri(url),
                verb: HttpVerbs.GET
            );
            return response.Results;
        }

    }
}