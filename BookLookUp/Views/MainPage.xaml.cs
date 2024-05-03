using BookLookUp.ViewModels;
using System;
using Windows.UI.Xaml.Controls;

namespace BookLookUp.Views
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void AutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {

        }

        private void AutoSuggestBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {

        }

        private void searchBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
        }

        private void SearchButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {

        }

        private void searchOptions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
