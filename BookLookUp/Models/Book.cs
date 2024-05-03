using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BookLookUp.Models
{
    public class Book
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("author_key")]
        public string[] AuthorKey { get; set; }
        [JsonProperty("author_name")]
        public string[] Author { get; set; }
        [JsonProperty("first_publish_year")]
        public int FirstPublishYear { get; set; }
        [JsonProperty("cover_edition_key")]
        public string CoverEditionOLID { get; set; }
        public string Image {  get; set; }
    }
}
