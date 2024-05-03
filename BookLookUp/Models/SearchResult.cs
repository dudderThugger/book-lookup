using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLookUp.Models
{
    public class SearchResult
    {
        [JsonProperty("numFound")]
        public int NumberFound { get; set; }
        [JsonProperty("start")]
        public int Start{ get; set; }
        [JsonProperty("numFoundExact")]
        public bool IsFound { get; set; }
        [JsonProperty("docs")]
        public Book[] Docs { get; set; }
    }
}
