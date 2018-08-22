using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BussKollen.Models;
using BussKollen.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BussKollen.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        private TravelService _service;

        public MainPage()
        {
            _service = new TravelService();
            InitializeComponent();

            StartLocation.TextChanged += StartLocation_TextChanged;
        }

        private async void StartLocation_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (StartLocation.Text.Length > 2)
            {
                var locationList = await GetLocation();

                if (locationList != null)
                {
                    ShowLocationList(locationList);
                }

                return;
            }
        }

        private async Task<List<LocationDTO>> GetLocation()
        {
            return await _service.GetLocation(StartLocation.Text);
        }

        private void ShowLocationList(List<LocationDTO> list)
        {
            Navigation.PushAsync(new LocationListPage(list));
        }
    }
}