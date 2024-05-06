using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLookUp.Models
{
    /// <summary>
    /// Abstraction of the OpenLibrary search API's respond, contains informations about the queries result
    /// </summary>
    public class SearchResult
    {
        /// <summary>
        /// The number of books that satisfied the query
        /// </summary>
        [JsonProperty("numFound")]
        public int NumberFound { get; set; }
        /// <summary>
        /// The index that the query started from
        /// </summary>
        [JsonProperty("start")]
        public int Start{ get; set; }
        /// <summary>
        /// Whether the query had an exact match for the query
        /// </summary>
        [JsonProperty("numFoundExact")]
        public bool IsFound { get; set; }
        /// <summary>
        /// The Books that satisfied the query ordered by the best match starting from start index
        /// </summary>
        [JsonProperty("docs")]
        public Book[] Docs { get; set; }
    }
}
