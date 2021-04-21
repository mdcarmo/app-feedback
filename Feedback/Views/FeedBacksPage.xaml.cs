using Feedback.Models;
using Feedback.ViewModels;
using Xamarin.Forms;
using System.Linq;

namespace Feedback.Views
{
    public partial class FeedBacksPage : ContentPage
    {
        FeedBacksViewModel viewModel;

        public FeedBacksPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new FeedBacksViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var feedBack = args.SelectedItem as FeedBack;
            if (feedBack == null)
                return;

            await Navigation.PushModalAsync(new NavigationPage(new FeedBackDetailPage(new FeedBackDetailViewModel(feedBack))));

            ItemsListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.FeedBacks.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }

        void Handle_TextChanged(object sender, TextChangedEventArgs e)
        {
            var _container = BindingContext as FeedBacksViewModel;
            ItemsListView.BeginRefresh();

            if (string.IsNullOrWhiteSpace(e.NewTextValue))
                ItemsListView.ItemsSource = _container.FeedBacks;
            else
                ItemsListView.ItemsSource = _container.FeedBacks.Where(i => i.Description.Contains(e.NewTextValue));

            ItemsListView.EndRefresh();
        }
    }
}