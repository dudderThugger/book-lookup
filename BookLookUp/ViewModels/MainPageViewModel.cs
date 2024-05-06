using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using Template10.Mvvm;
using Template10.Services.NavigationService;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;
using BookLookUp.Models;
using BookLookUp.Services;
using Windows.Devices.Printers;
using BookLookUp.Views;
using System.Reflection.Metadata;

namespace BookLookUp.ViewModels
{
    /// <summary>
    /// ViewModel of the MainPage contains the logic of the MainPage that represents the queried books
    /// </summary>
    public class MainPageViewModel : ViewModelBase
    {
        /// <summary>
        /// Collection of BookLists which contains the list of Books that satisfied the query
        /// </summary>
        public ObservableCollection<BookList> BookLists { get; set; } = new ObservableCollection<BookList>();
        /// <summary>
        /// The current QueryType selected
        /// </summary>
        public QueryType QueryTypeSelected { get; set; }
        /// <summary>
        /// Asynchronous Override method of Template10.Mvvm.ViewModelBase's OnNavigatedTo method, loads books that satisfy the "Dune" keyword query
        /// </summary>
        /// <param name="parameter">The parameter object that the previous page can pass</param>
        /// <param name="mode">The navigation mode</param>
        /// <param name="state">The navigation state dictionary</param>
        /// <returns></returns>
        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            var service = new OpenLibraryService();
            var books = await service.GetBooks("Dune","q");

            
            var BookList = new BookList { Books = books};
            BookLists.Add(BookList);

            await base.OnNavigatedToAsync(parameter, mode, state);

        }
        /// <summary>
        /// Navigates to a DetailsPage
        /// </summary>
        /// <param name="book">The book/work's DetailsPage to navigate to</param>
        public void NavigateToDetails(Book book)
        {
            NavigationService.Navigate(typeof(DetailsPage), new BookTransferObject { WorkKey = book.WorkKey, Image = book.Image});
        }
        /// <summary>
        /// Executes the query when called and stores it in the BookLists property
        /// </summary>
        /// <param name="searchPhase">The search phrase to query for</param>
        public async void QuerySubmitted(string searchPhase)
        {
            BookLists.Clear();
            var queryString = "q";

            switch (QueryTypeSelected)
            {
                case QueryType.None:
                    break;
                case QueryType.Title:
                    queryString = "title";
                    break;
                case QueryType.Author:
                    queryString = "author";
                    break;
                default:
                    break;
            }

            var service = new OpenLibraryService();

            var books = await service.GetBooks(searchPhase, queryString);

            var BookList = new BookList { Books = books };
            BookLists.Add(BookList);
        }
        /// <summary>
        /// Types of possible queries
        /// </summary>
        public enum QueryType
        {
            None,
            Title,
            Author,
            KeyWords,
        }
    }
}

