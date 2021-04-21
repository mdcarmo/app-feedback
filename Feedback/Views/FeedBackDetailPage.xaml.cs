using Feedback.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Feedback.Views
{
    public partial class FeedBackDetailPage : ContentPage
    {
        FeedBackDetailViewModel viewModel;

        public FeedBackDetailPage(FeedBackDetailViewModel viewModel)
        {
            InitializeComponent();

            this.viewModel = viewModel;
            BindingContext = this.viewModel;
        }

        public FeedBackDetailPage()
        {
            InitializeComponent();

            viewModel = new FeedBackDetailViewModel();
            BindingContext = viewModel;
        }

        private void Cancel_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void Save_Clicked(object sender, EventArgs e)
        {
            //var message = viewModel.IsNewNote ? "SaveNote" : "UpdateNote";
            //MessagingCenter.Send(this, message, viewModel.Note);
            //Navigation.PopModalAsync();
        }

    }
}