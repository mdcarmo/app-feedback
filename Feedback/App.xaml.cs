using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Feedback.Services;
using Feedback.Views;

[assembly: ExportFont("SEGOEUI.ttf", Alias = "RegularFont")]
[assembly: ExportFont("SEGOEUIL.ttf", Alias = "LightFont")]
[assembly: ExportFont("SEGUISB.ttf", Alias = "MediumFont")]

namespace Feedback
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
