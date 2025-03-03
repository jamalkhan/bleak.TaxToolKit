namespace bleak.TaxToolKit.ConsoleApp.FileOps
{

    //Transaction Hash,Blockno,UnixTimestamp,DateTime (UTC),From,To,ContractAddress,Value_IN(ETH),Value_OUT(ETH),CurrentValue @ $2611.8517648881/Eth,TxnFee(ETH),TxnFee(USD),Historical ETHUSD,Status,ErrCode,Method,WalletAddress,Platform
    public class EthereumTx
    {
        public string TransactionHash { get; set; }
        public string Blockno { get; set; }
        public string UnixTimestamp { get; set; }
        public string DateTimeUTC { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Value_IN_ETH { get; set; }
        public string Value_OUT_ETH { get; set; }
        public string CurrentValue { get; set; }
        public string TxnFee_ETH { get; set; }
        public string TxnFee_USD { get; set; }
        public string Historical_ETHUSD { get; set; }
        public string Status { get; set; }
        public string ErrCode { get; set; }
        public string Method { get; set; }
        public string WalletAddress { get; set; }
        public string Platform { get; set; }
    }
}