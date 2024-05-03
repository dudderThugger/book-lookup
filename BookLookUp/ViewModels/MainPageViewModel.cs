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
using BookLookUp.Sevices;
using Windows.Devices.Printers;

namespace BookLookUp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public ObservableCollection<BookList> BookLists { get; set; } = new ObservableCollection<BookList>();

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            var service = new OpenLibraryService();
            var books = await service.GetBooks("Dune","q");

            
            var BookList = new BookList { Books = books};
            BookLists.Add(BookList);

            await base.OnNavigatedToAsync(parameter, mode, state);

        }
    }
}

