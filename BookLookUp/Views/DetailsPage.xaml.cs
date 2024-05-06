using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace BookLookUp.Views
{
    /// <summary>
    /// An page that displayes details about a book
    /// </summary>
    public sealed partial class DetailsPage : Page
    {
        public DetailsPage()
        {
            this.InitializeComponent();
        }
        /// <summary>
        /// Function subscribed to the Image to showcase higher resolution of the Image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Image_Tapped(object sender, TappedRoutedEventArgs e)
        {
            await ImageDialog.ShowAsync();
        }
    }
}
