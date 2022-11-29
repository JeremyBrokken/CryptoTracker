using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoTracker.Model
{
    public class Token
    {
        public string asset_id { get; set; }
        public string name { get; set; }
        public string price_usd { get; set; }
        public string id_icon { get; set; }
        public string icon_url { get; set; }
        
    }
}
