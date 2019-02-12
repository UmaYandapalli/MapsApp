using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Plugin.Geolocator;
using ServicesDemo.Common;
using ServicesDemo.LocalDb;
using ServicesDemo.Models;
using Xamarin.Forms.Maps;

namespace ServicesDemo.ViewModels
{
    public class WhetherViewModel:BaseVieModel
    {

        private RootObject _rootObject
        {
            get;
            set;
        }
        private Plugin.Geolocator.Abstractions.Position _position;

        private ObservableCollection<CustomPin> _collection;

        public ObservableCollection<CustomPin> DataSource
        {
            get { return _collection; }
            set
            {
                _collection = value;
                OnPropertyChanged("DataSource");
            }
        }

        public RootObject rootObject
        {
            get { return _rootObject; }
            set
            {
                _rootObject = value;
                OnPropertyChanged("rootObject");
            }
        }
        public WhetherDB _whetherDB;
        public WhetherInfo _WhetherInfo;
      
        public WhetherViewModel()
        {
            Task.Run(async () => await getdata());
            Task.Run(async () => await GetWhetherData());
            DataSource = new ObservableCollection<CustomPin>();
            CustomPin custompin = new CustomPin()
            {
                Pin = new Pin()
                {
                    Type = PinType.Place,
                    Position = new Position(Convert.ToDouble("17.412716"), Convert.ToDouble("78.395059")),
                    Label = "Text",
                    Address = "Frisco"

                }
               

            };
            custompin.Pin.Clicked += Pin_Clicked;
            _collection.Add(custompin);
        }


        async void Pin_Clicked(object sender, EventArgs e)
        {
            try
            {
                Pin p = (Pin)sender;

            }
            catch (System.Exception ex)
            {

            }
        }

        public async Task GetWhetherData()
        {
            try
            {
                rootObject = await WebServiceManager<RootObject>.GetData("17.412716","78.395059");
                foreach (var obj in rootObject.list)
                {
                    _whetherDB = new WhetherDB();
                    _WhetherInfo = new WhetherInfo();
                    _WhetherInfo.Name = obj.name;
                    _WhetherInfo.humidity = obj.main.humidity;
                    _WhetherInfo.country = obj.sys.country;
                   
                    _whetherDB.AddEmployee(_WhetherInfo);
                }
               // Student student = new Student();
                //student.id = 10;
               // var data = await WebServiceManager<Response>.PostData(student);
                System.Diagnostics.Debug.Write(rootObject.message);
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.Message);

            }
        }

        public async Task<Plugin.Geolocator.Abstractions.Position> getdata()
        {
            try
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 50;

                if (locator.IsGeolocationAvailable && locator.IsGeolocationEnabled)
                {
                    _position = await locator.GetPositionAsync(TimeSpan.FromMilliseconds(10000));

                    if (_position != null)
                    {

                        return _position;
                    }
                    else
                        return null;
                }
            }
            catch (System.Exception ex)
            {

            }
            return null;
        }



    }
}
