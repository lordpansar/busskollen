using BussKollen.Models;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BussKollen.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocationListPage : ContentPage
    {
        public LocationListPage(List<LocationDTO> locations)
        {
            InitializeComponent();
            locationList.ItemsSource = locations;
            locationList.ItemTapped += LocationListPage_OnItemTapped;
        }

        private void LocationListPage_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            Navigation.PopToRootAsync();
        }
    }
}