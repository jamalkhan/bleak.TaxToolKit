namespace bleak.TaxToolKit.ConsoleApp.FileOps
{
    public class EthereumTransaction
    {
        public string TransactionHash { get; set; }
        public string Blockno { get; set; }
        public string UnixTimestamp { get; set; }
        public string DateTimeUTC { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string TokenValue { get; set; }
        public string USDValueDayOfTx { get; set; }
        public string ContractAddress { get; set; }
        public string TokenName { get; set; }
        public string TokenSymbol { get; set; }
        public string WalletAddress { get; set; }
        public string Platform { get; set; }
    }
}