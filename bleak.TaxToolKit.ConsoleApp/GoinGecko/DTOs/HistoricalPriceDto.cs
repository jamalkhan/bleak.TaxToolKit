namespace bleak.TaxToolKit.ConsoleApp.CoinGecko.DTOs
{
    public class HistoricalPriceDto
    {
        public string id { get; set; } = string.Empty;
        public string symbol { get; set; } = string.Empty;
        public string name { get; set; } = string.Empty;
        public Localization localization { get; set; } = new Localization();
        public Image image { get; set; } = new Image();
        public MarketData market_data { get; set; } = new MarketData();
        public CommunityData community_data { get; set; } = new CommunityData();
        public DeveloperData developer_data { get; set; } = new DeveloperData();
        public PublicInterestStats public_interest_stats { get; set; } = new PublicInterestStats();


        public class Image
        {
            public string thumb { get; set; } = string.Empty;
            public string small { get; set; } = string.Empty;
        }
        public class Localization
        {
            public string en { get; set; } = string.Empty;
            public string de { get; set; } = string.Empty;
            public string es { get; set; } = string.Empty;
            public string fr { get; set; } = string.Empty;
            public string it { get; set; } = string.Empty;
            public string pl { get; set; } = string.Empty;
            public string ro { get; set; } = string.Empty;
            public string hu { get; set; } = string.Empty;
            public string nl { get; set; } = string.Empty;
            public string pt { get; set; } = string.Empty;
            public string sv { get; set; } = string.Empty;
            public string vi { get; set; } = string.Empty;
            public string tr { get; set; } = string.Empty;
            public string ru { get; set; } = string.Empty;
            public string ja { get; set; } = string.Empty;
            public string zh { get; set; } = string.Empty;
            public string zh_tw { get; set; } = string.Empty;
            public string ko { get; set; } = string.Empty;
            public string ar { get; set; } = string.Empty;
            public string th { get; set; } = string.Empty;
            public string id { get; set; } = string.Empty;
            public string cs { get; set; } = string.Empty;
            public string da { get; set; } = string.Empty;
            public string el { get; set; } = string.Empty;
            public string hi { get; set; } = string.Empty;
            public string no { get; set; } = string.Empty;
            public string sk { get; set; } = string.Empty;
            public string uk { get; set; } = string.Empty;
            public string he { get; set; } = string.Empty;
            public string fi { get; set; } = string.Empty;
            public string bg { get; set; } = string.Empty;
            public string hr { get; set; } = string.Empty;
            public string lt { get; set; } = string.Empty;
            public string sl { get; set; } = string.Empty;
        }

        

        public class MarketData
        {
            public Dictionary<string, decimal> current_price { get; set; } = new Dictionary<string, decimal>();
            public Dictionary<string, decimal> market_cap { get; set; } = new Dictionary<string, decimal>();
            public Dictionary<string, decimal> total_volume { get; set; } = new Dictionary<string, decimal>();
        }

        public class CommunityData
        {
            public int? facebook_likes { get; set; }
            public int? twitter_followers { get; set; }
            public decimal reddit_average_posts_48h { get; set; }
            public decimal reddit_average_comments_48h { get; set; }
            public int? reddit_subscribers { get; set; }
            public decimal reddit_accounts_active_48h { get; set; }
        }

        public class DeveloperData
        {
            public int? forks { get; set; }
            public int? stars { get; set; }
            public int? subscribers { get; set; }
            public int? total_issues { get; set; }
            public int? closed_issues { get; set; }
            public int? pull_requests_merged { get; set; }
            public int? pull_request_contributors { get; set; }
            public CodeAdditionsDeletions4Weeks code_additions_deletions_4_weeks { get; set; } = new CodeAdditionsDeletions4Weeks();
            public int? commit_count_4_weeks { get; set; }
        }

        public class CodeAdditionsDeletions4Weeks
        {
            public int? additions { get; set; }
            public int? deletions { get; set; }
        }

        public class PublicInterestStats
        {
            public int? alexa_rank { get; set; } = 0;
            public int? bing_matches { get; set; } = 0;
        }
    }

}