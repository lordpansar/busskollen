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
        private int startLocationID;
        private int finalLocationID;

        public MainPage()
        {
            _service = new TravelService();
            InitializeComponent();
            
            //Event handlers
            TxtStartLocation.TextChanged += StartLocation_TextChanged;
            StartLocationPicker.SelectedIndexChanged += StartPicker_Selected;
            FinalLocationPicker.SelectedIndexChanged += FinalPicker_Selected;
            BtnSearch.Clicked += BtnSearch_Clicked;
        }

        private async void StartLocation_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TxtStartLocation.Text.Length > 2)
            {
                var locationList = await GetLocation(TxtStartLocation.Text);
                BindLocationPicker(LblWarningStart, StartLocationPicker, locationList);
            }
        }

        private void BindLocationPicker(Label label, Picker picker, List<LocationDTO> locationList)
        {
            if (locationList != null)
            {
                picker.ItemsSource = locationList;
                picker.IsVisible = true;
                label.IsVisible = false;
            }
            else
            {
                label.Text = "Inga träffar :(";
                label.IsVisible = true;
                picker.ItemsSource = null;
                picker.IsVisible = false;
            }
        }

        private void StartPicker_Selected(object sender, EventArgs e)
        {
            TxtStartLocation.Text = "";
            startLocationID = GetLocationID(StartLocationPicker);
            ToggleSearchButton();
        }

        private void FinalPicker_Selected(object sender, EventArgs e)
        {
            TxtFinalLocation.Text = "";
            finalLocationID = GetLocationID(StartLocationPicker);
            ToggleSearchButton();
        }

        private void BtnSearch_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private int GetLocationID(Picker picker)
        {
            var location = (LocationDTO)FinalLocationPicker.SelectedItem;
            return location.Id;
        }

        private async Task<List<LocationDTO>> GetLocation(string query)
        {
            return await _service.GetLocation(query);
        }

        private void ShowResults()
        {
            Navigation.PushAsync(new SearchResultPage());
        }

        private void ToggleSearchButton()
        {
            if (startLocationID > 0 && finalLocationID > 0 && startLocationID != finalLocationID)
            {
                BtnSearch.IsEnabled = true;
            }
            else
            {
                BtnSearch.IsEnabled = false;
            }
        }
    }
}