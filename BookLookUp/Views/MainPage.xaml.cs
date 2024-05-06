using BookLookUp.Models;
using System;
using Windows.UI.Xaml.Controls;

namespace BookLookUp.Views
{
    /// <summary>
    /// Main page of the application, you can browse for books here
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Subscribed to the search button's click event, executes the query
        /// </summary>
        /// <param name="sender">The button</param>
        /// <param name="e">Event arguments for the click</param>
        private void SearchButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ViewModel.QuerySubmitted(searchBox.Text);
        }
        /// <summary>
        /// Subscribed to the book items' click event
        /// </summary>
        /// <param name="sender">The book item that triggered the event</param>
        /// <param name="e">Event parameters</param>
        private void Book_ItemClick(object sender, ItemClickEventArgs e)
        {
            var book = (Book)e.ClickedItem;
            ViewModel.NavigateToDetails(book);
        }
        /// <summary>
        /// Executes the query
        /// </summary>
        /// <param name="sender">The AutoSuggestBox that triggered the event</param>
        /// <param name="args">Event arguments</param>
        private void AutoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            ViewModel.QuerySubmitted(args.QueryText);
        }
        /// <summary>
        /// Subscribed to the ComboBox's SelectionChanged event, sets the ViewModel's QueryType accordingly
        /// </summary>
        /// <param name="sender">The ComboBox that triggered the event</param>
        /// <param name="e">Event arguments</param>
        private void SearchOptions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;

            if(comboBox != null && comboBox.SelectedItem != null)
            {
                var selectedIndex = comboBox.SelectedIndex;


                switch (selectedIndex)
                {
                    case 0:
                        ViewModel.QueryTypeSelected = ViewModels.MainPageViewModel.QueryType.Title;
                        break;
                    case 1:
                        ViewModel.QueryTypeSelected = ViewModels.MainPageViewModel.QueryType.Author;
                        break;
                    case 2:
                        ViewModel.QueryTypeSelected = ViewModels.MainPageViewModel.QueryType.KeyWords;
                        break;
                }
            }
        }
    }
}
