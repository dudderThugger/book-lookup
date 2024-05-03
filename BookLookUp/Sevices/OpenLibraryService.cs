using BookLookUp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BookLookUp.Sevices
{
    public class OpenLibraryService
    {
        private readonly Uri serverUrl = new Uri("https://openlibrary.org/");
        
        private async Task<T> GetAsync<T>(Uri uri)
        {
            using (var client = new HttpClient())
            {
                var respos = await client.GetAsync(uri);
                var json = await respos.Content.ReadAsStringAsync();
                T result = JsonConvert.DeserializeObject<T>(json);

                return result;
            }
        }

        public async Task<Book[]> GetBooks(string title, string searchType)
        {
            var searchResult = await GetAsync<SearchResult>(new Uri(serverUrl, $"search.json?{searchType}={title}&fields=title,author_name,author_key,first_publish_year,cover_edition_key&limit=10"));

            foreach (var result in searchResult.Docs)
            {
                result.Image = $"https://covers.openlibrary.org/b/olid/{result.CoverEditionOLID}-M.jpg";
            }

            return searchResult.Docs;
        }
    }
}
