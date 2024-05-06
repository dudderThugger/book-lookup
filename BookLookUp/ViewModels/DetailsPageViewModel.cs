using BookLookUp.Models;
using BookLookUp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.UI.Xaml.Navigation;

namespace BookLookUp.ViewModels
{
    /// <summary>
    /// The ViewModel that the DeatailsPage refers to
    /// </summary>
    public class DetailsPageViewModel : ViewModelBase
    {
        /// <summary>
        /// Collection of AuthorReferences object which stores the authors of the work
        /// </summary>
        public ObservableCollection<AuthorRefs> AuthorReferences {  get; set; } = new ObservableCollection<AuthorRefs> { new AuthorRefs() };
        private Work _work;
        /// <summary>
        /// The work that's details gets displayed on the page
        /// </summary>
        public Work Work { get { return _work; } set { Set(ref _work, value); } }

        /// <summary>
        /// Overrides the Template10.Mvvm.ViewModelBase method, loads the Work resource's details asyncronious when the application navigates to the page
        /// </summary>
        /// <param name="parameter">The BookLookUp.Models.BookTransferObject type parameter that contains the cover's URI and the work's key</param>
        /// <param name="mode">The mode of the navigation</param>
        /// <param name="state">The state of the pages</param>
        /// <returns></returns>
        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            AuthorReferences.Clear();
            var book = (BookTransferObject)parameter;

            var service = new OpenLibraryService();
            var work = await service.GetWork(book.WorkKey);
            work.SmallImage = book.Image;
            work.LargeImage = book.Image.Replace("-M.jpg", "-L.jpg");

            Work = work;

            AuthorReferences.Add(new AuthorRefs { Authors = work.Authors});

            await base.OnNavigatedToAsync(parameter, mode, state);
        }

    }
}
