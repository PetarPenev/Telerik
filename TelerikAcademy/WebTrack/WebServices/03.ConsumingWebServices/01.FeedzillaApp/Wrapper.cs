using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.FeedzillaApp
{
    public class Wrapper
    {
        [JsonProperty("articles")]
        public List<Article> Articles { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("syndication_url")]
        public string SyndicationUrl { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
