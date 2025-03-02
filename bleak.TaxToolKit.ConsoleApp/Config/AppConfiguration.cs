using System;
using System.Text.Json;

namespace bleak.TaxToolKit.ConsoleApp.Configuration
{
    public partial class  AppConfiguration
    {
        public string CoinbaseAPiKey { get;set; } = string.Empty;
        public string CoinbasePrivateKey { get; set; } = string.Empty;
    }
}