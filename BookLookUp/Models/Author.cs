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
    /// Contains Author objects
    /// </summary>
    public class AuthorRefs
    {
        /// <summary>
        /// The authors
        /// </summary>
        public Author[] Authors { get; set; }
    }
    /// <summary>
    /// Contains an Author's OLID
    /// </summary>
    public class AuthorRef
    {
        /// <summary>
        /// The relative URI of the Author resource
        /// </summary>
        [JsonProperty("key")]
        public string Key { get; set; }
    }
    /// <summary>
    /// Object that contains the Author's reference
    /// </summary>
    public class AuthorObject
    {
        /// <summary>
        /// The author's reference
        /// </summary>
        [JsonProperty("author")]
        public AuthorRef AuthorRef { get; set; }
    }
    /// <summary>
    /// Represents an author resoruce in the OpenLibrary API
    /// </summary>
    public class Author
    {
        /// <summary>
        /// Relative URI of the resource
        /// </summary>
        [JsonProperty("key")]
        public string Key { get; set; }
        /// <summary>
        /// Short biography of the author
        /// </summary>
        [JsonProperty("bio")]
        public ObjectJSON Bio { get; set; }
        /// <summary>
        /// Name of the author
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// Full URL of the author, readonly property
        /// </summary>
        public string URL 
        {
            get 
            {
                return $"https://openlibrary.org{Key}"; 
            } 
        }
    }
}
