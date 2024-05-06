using BookLookUp.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLookUp.Models
{
    /// <summary>
    /// An abstraction of a work resource in the OpenLibraryAPI, which is basically a book
    /// </summary>
    public class Work
    {
        /// <summary>
        /// The title of the work
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }
        /// <summary>
        /// The authors of the work in an AuthorObject
        /// </summary>
        [JsonProperty("authors")]
        public AuthorObject[] AuthorObjects { get; set; }
        /// <summary>
        /// Short description of the book
        /// </summary>
        [JsonProperty("description")]
        public ObjectJSON Description { get; set; }
        /// <summary>
        /// The date of the first publish
        /// </summary>
        [JsonProperty("first_publish_date")]
        public string FirstPublishDate { get; set; }
        /// <summary>
        /// Subjects of the book
        /// </summary>
        [JsonProperty("subjects")]
        public string[] Subjects { get; set; }
        /// <summary>
        /// Readonly property to get the subjects in string format seperated by a comma
        /// </summary>
        public string SubjectsStr { 
            get 
            {
                if (Subjects == null) { return ""; }
                return string.Join(", ", Subjects);
            }
        }
        /// <summary>
        /// Names of the authors
        /// </summary>
        public string[] AuthorNames { get; set; }
        /// <summary>
        /// String containing the name of the authors separated by a comma
        /// </summary>
        public string AuthorNamesStr
        {
            get
            {
                return string.Join(", ", AuthorNames);
            }
        }
        /// <summary>
        /// URL for the cover with smaller resolution
        /// </summary>
        public string SmallImage {  get; set; }
        /// <summary>
        /// URL for the cover with larger resolution
        /// </summary>
        public string LargeImage { get; set; }
        /// <summary>
        /// Author's of the book
        /// </summary>
        public Author[] Authors { get; set; }
    }

    /// <summary>
    /// Class for the inconsistent fields of the API, it can represent an object with value and type, or a simple string value
    /// </summary>
    [JsonConverter(typeof(ObjectJSONConverter))]
    public class ObjectJSON
    {
        /// <summary>
        /// The string value of the field
        /// </summary>
        [JsonProperty("value")]
        public string Value { get; set; }
        /// <summary>
        /// The type value of the field
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
