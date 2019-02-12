using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Plugin.Geolocator;
using ServicesDemo.Common;
using ServicesDemo.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace ServicesDemo.Views
{
    public partial class WhetherPage : ContentPage
    {
        private Plugin.Geolocator.Abstractions.Position _position;
        WhetherViewModel vm;
        public WhetherPage()
        {
            InitializeComponent();
            vm = new WhetherViewModel();
            this.BindingContext = vm;
            getdata();
        }

        void NavigateToWhetherDeatails(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new WhetherListPage());
        }

        public async Task<Plugin.Geolocator.Abstractions.Position> getdata()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;
            if (locator.IsGeolocationAvailable && locator.IsGeolocationEnabled)
            {
                Application.Current.Properties["LocationEnable"] = true;
                _position = await locator.GetPositionAsync(TimeSpan.FromMilliseconds(10000));
                googlemap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(17.412716, 78.395059), Distance.FromKilometers(5)));
                if (_position != null)
                {
                    ObservableCollection<CustomPin> pins = new ObservableCollection<CustomPin>();
                    CustomPin custompin = new CustomPin()
                    {
                        Pin = new Pin()
                        {
                            Position = new Position(Convert.ToDouble("17.412716"), Convert.ToDouble("78.395059"))
                        }
                    };
                    pins.Add(custompin);
                    googlemap.ItemsSource = pins;
                   // googlemap.ItemsSource = pins;
                    return _position;
                }
                else
                    return null;
            }
            else
            {
                Application.Current.Properties["LocationEnable"] = false;
            }
            return null;
        }

    }
}