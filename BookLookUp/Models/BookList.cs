using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLookUp.Models
{
    /// <summary>
    /// Object to contain books, used with the ObservableCollection and GridView
    /// </summary>
    public class BookList
    {
        /// <summary>
        /// Array of books
        /// </summary>
        public Book[] Books {  get; set; }
    }
}
