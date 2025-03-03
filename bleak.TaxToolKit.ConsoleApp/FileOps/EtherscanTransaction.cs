namespace bleak.TaxToolKit.ConsoleApp.FileOps
{
    public class EthereumTransaction
    {
        public string TransactionHash { get; set; } = string.Empty;
        public string Blockno { get; set; } = string.Empty;
        public string UnixTimestamp { get; set; } = string.Empty;
        public DateTime DateTimeUTC { get; set; }
        public string From { get; set; } = string.Empty;
        public string To { get; set; } = string.Empty;
        public string TokenValue { get; set; } = string.Empty;
        public string USDValueDayOfTx { get; set; } = string.Empty;
        public string ContractAddress { get; set; } = string.Empty;
        public string TokenName { get; set; } = string.Empty;
        public string TokenSymbol { get; set; } = string.Empty;
        public string WalletAddress { get; set; } = string.Empty;
        public string Platform { get; set; } = string.Empty;
        public string CoinGeckoId { get;set;} = string.Empty;
        public decimal? HistoricalPrice { get;set;}
    }
}