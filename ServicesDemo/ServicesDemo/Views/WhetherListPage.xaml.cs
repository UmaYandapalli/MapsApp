using System;
using System.Collections.Generic;
using ServicesDemo.LocalDb;
using Xamarin.Forms;

namespace ServicesDemo.Views
{
    public partial class WhetherListPage : ContentPage
    {
        public WhetherDB _whetherDB;
        public WhetherListPage()
        {
            InitializeComponent();
            _whetherDB = new WhetherDB();
            var whethers = _whetherDB.GetWhethers();
            whetherListView.ItemsSource = whethers;
        }
    }
}
