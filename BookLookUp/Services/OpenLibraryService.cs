using BookLookUp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BookLookUp.Services
{
    /// <summary>
    /// An API service for the OpenLibrary API
    /// </summary>
    public class OpenLibraryService
    {
        private readonly Uri serverUrl = new Uri("https://openlibrary.org/");
        /// <summary>
        /// Generic method to get a resource from the OpenLibraryAPI.
        /// </summary>
        /// <typeparam name="T">Type of the object to convert the respond JSON to</typeparam>
        /// <param name="uri">The URI of the reource</param>
        /// <returns>The respond object with T type</returns>
        private async Task<T> GetAsync<T>(Uri uri)
        {
            using (var client = new HttpClient())
            {
                var respos = await client.GetAsync(uri);
                var json = await respos.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<T>(json);

                return result;
            }
        }

        /// <summary>
        /// Pulls 20 book resources using the search API of OpenLibraryAPI
        /// </summary>
        /// <param name="searchPhrase">The query string to execute the search for</param>
        /// <param name="searchType">Target of a query viable options are: q, title, author</param>
        /// <returns>A list of Book objects which scheme is specified in BookLookUp.Models.Books</returns>
        public async Task<Book[]> GetBooks(string searchPhrase, string searchType)
        {
            var searchResult = await GetAsync<SearchResult>(new Uri(serverUrl, $"search.json?{searchType}={searchPhrase}&fields=title,key,author_name,author_key,first_publish_year,cover_edition_key&limit=20"));

            foreach (var result in searchResult.Docs)
            {
                result.Image = $"https://covers.openlibrary.org/b/olid/{result.CoverEditionOLID}-M.jpg";

                if (result.Authors != null)
                {
                    result.AuthorStr = string.Join(", ", result.Authors);
                }
            }

            return searchResult.Docs;
        }
        /// <summary>
        /// Pulls a specific work resource, a work represents a book in OpenLibraryAPI
        /// </summary>
        /// <param name="workId">Unique OpenLibrary ID of the resource</param>
        /// <returns>A Work object which is a lighter representation of the API's work resources</returns>
        public async Task<Work> GetWork(string workId)
        {
            var work = await GetAsync<Work>(new Uri(serverUrl, $"{workId}.json"));
            int i = 0;

            work.AuthorNames = new string[work.AuthorObjects.Length];
            work.Authors = new Author[work.AuthorObjects.Length];

            foreach( var authorObject in  work.AuthorObjects)
            {
                Author author = await GetAuthor(authorObject.AuthorRef.Key);
                work.Authors[i] = author;
                work.AuthorNames[i++] = author.Name;
            }

            return work;
        }

        /// <summary>
        /// Pulls a specific author resource from the OpenLibraryAPI
        /// </summary>
        /// <param name="authorId">Unique OpenLibrary ID of the author</param>
        /// <returns>An Author object which is a lighter representation of the API's author resource</returns>
        public async Task<Author> GetAuthor(string authorId)
        {
            return await GetAsync<Author>(new Uri(serverUrl, $"{authorId}.json"));
        }
    }
}
