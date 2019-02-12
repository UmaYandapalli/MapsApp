using System;
using ServicesDemo.InterFaces;
using ServicesDemo.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ServicesDemo
{
    public partial class App : Application
    {
        public static string locationStatus;
        ILocation loc;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new WhetherPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            loc = DependencyService.Get<ILocation>();
            loc.locationObtained += (object sender,
                ILocationEventArgs e) =>
            {

                //Debug.WriteLine("Start Method");
                var lat = e.lat;
                var lng = e.lng;

                //Debug.WriteLine("latitude:" + lat);
                Application.Current.Properties["Latitude"] = lat.ToString();
                Application.Current.Properties["Longitude"] = lng.ToString();
            };
            loc.ObtainMyLocation();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
