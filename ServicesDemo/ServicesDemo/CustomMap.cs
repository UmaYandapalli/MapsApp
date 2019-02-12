using System;
using System.Collections.ObjectModel;
using ServicesDemo.Common;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
namespace ServicesDemo
{
    public class CustomMap:Map
    {
        public CustomMap()
        {
        }

        public static readonly BindableProperty ItemsSourceProperty =
            BindableProperty.Create(nameof(ItemsSource), typeof(ObservableCollection<CustomPin>), typeof(CustomMap), null,
                                     BindingMode.Default, null, OnItemsSourceChanged);

        public ObservableCollection<CustomPin> ItemsSource
        {
            get
            {
                var collection = (ObservableCollection<CustomPin>)GetValue(ItemsSourceProperty);
                return collection;
            }
            set
            {
                SetValue(ItemsSourceProperty, value);
                var collection = (ObservableCollection<CustomPin>)GetValue(ItemsSourceProperty);
            }
        }

        static void OnItemsSourceChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var customMap = (CustomMap)bindable;

            var resultList = (ObservableCollection<CustomPin>)newvalue;
            resultList.CollectionChanged += (s, e) =>
            {
                var mapPin = (ObservableCollection<CustomPin>)s;
                if (e.Action.ToString() == "Reset")
                {
                    customMap.Pins.Clear();
                }
                else if (e.Action.ToString() == "Add")
                {
                    customMap.Pins.Add(mapPin[e.NewStartingIndex].Pin);
                }
                if (mapPin.Count > 1)
                {
                    customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(mapPin[1].Pin.Position.Latitude, mapPin[1].Pin.Position.Longitude), Distance.FromKilometers(5)));
                }
            };
        }
    }
}
