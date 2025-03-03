namespace bleak.TaxToolKit.ConsoleApp.FileOps
{

    //Transaction Hash,Blockno,UnixTimestamp,DateTime (UTC),From,To,ContractAddress,Value_IN(ETH),Value_OUT(ETH),CurrentValue @ $2611.8517648881/Eth,TxnFee(ETH),TxnFee(USD),Historical ETHUSD,Status,ErrCode,Method,WalletAddress,Platform
    public class EthereumTx
    {
        public string TransactionHash { get; set; } = string.Empty;
        public string Blockno { get; set; } = string.Empty;
        public string UnixTimestamp { get; set; } = string.Empty;
        public string DateTimeUTC { get; set; } = string.Empty;
        public string From { get; set; } = string.Empty;
        public string To { get; set; } = string.Empty;
        public string Value_IN_ETH { get; set; } = string.Empty;
        public string Value_OUT_ETH { get; set; } = string.Empty;
        public string CurrentValue { get; set; } = string.Empty;
        public string TxnFee_ETH { get; set; } = string.Empty;
        public string TxnFee_USD { get; set; } = string.Empty;
        public string Historical_ETHUSD { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string ErrCode { get; set; } = string.Empty;
        public string Method { get; set; } = string.Empty;
        public string WalletAddress { get; set; } = string.Empty;
        public string Platform { get; set; } = string.Empty;
    }
}