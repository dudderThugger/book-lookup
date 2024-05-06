using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BookLookUp.Models
{
    /// <summary>
    /// A book that gets displayed on the MainPage, an abstraction of a doc that the OpenLibrary search API returns
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Relative URI of the work
        /// </summary>
        [JsonProperty("key")]
        public string WorkKey { get; set; }
        /// <summary>
        /// Title of the book
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }
        /// <summary>
        /// Name of the authors
        /// </summary>
        [JsonProperty("author_name")]
        public string[] Authors { get; set; }
        /// <summary>
        /// Author string return a joined string value of the authors' names
        /// </summary>
        public string AuthorStr { get; set; }
        /// <summary>
        /// The year of the first publishment
        /// </summary>
        [JsonProperty("first_publish_year")]
        public int FirstPublishYear { get; set; }
        /// <summary>
        /// The relative URI of the edition which cover is displayed
        /// </summary>
        [JsonProperty("cover_edition_key")]
        public string CoverEditionOLID { get; set; }
        /// <summary>
        /// URL of the cover that gets displayed
        /// </summary>
        public string Image {  get; set; }
    }
    /// <summary>
    /// The object that gets passed as a parameter when we navigate to a DetailsPage
    /// </summary>
    public class BookTransferObject
    {
        /// <summary>
        /// The relative URI of the work which details gets displayed
        /// </summary>
        [JsonProperty("key")]
        public string WorkKey { get; set; }
        /// <summary>
        /// The URL of the book's cover
        /// </summary>
        public string Image { get; set; }
    }
}
