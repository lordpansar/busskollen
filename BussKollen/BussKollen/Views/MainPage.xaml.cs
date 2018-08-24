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
        private int originLocationID;
        private int destinationLocationID;

        public MainPage()
        {
            _service = new TravelService();
            InitializeComponent();

            //Event handlers
            TxtOriginLocation.TextChanged += StartLocation_TextChanged;
            TxtDestinationLocation.TextChanged += FinalLocation_TextChanged;
            OriginPicker.SelectedIndexChanged += StartPicker_Selected;
            DestinationPicker.SelectedIndexChanged += FinalPicker_Selected;
            BtnSearch.Clicked += BtnSearch_Clicked;
        }

        private async void StartLocation_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TxtOriginLocation.Text.Length > 2)
            {
                originLocationID = 0;
                var locationList = await GetLocation(TxtOriginLocation.Text);
                BindLocationPicker(LblOriginWarning, OriginPicker, locationList);
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
            TxtOriginLocation.Text = "";
            originLocationID = GetLocationID(OriginPicker);

            if(originLocationID > 0)
            {
                TxtOriginLocation.IsVisible = false;
                OriginPicker.IsEnabled = false;
                ToggleSearchButton();
            }
            else
            {
                LblOriginWarning.Text = "Något gick fel. Försök igen.";
            }
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
            var location = (LocationDTO)picker.SelectedItem;
            return location.Id;
        }

        private async Task<List<LocationDTO>> GetLocation(string query)
        {
            return await _service.GetLocation(query);
        }

        private void PresentDepartures()
        {
            Navigation.PushAsync(new SearchResultPage());
        }

        private void ToggleSearchButton()
        {
            if (originLocationID > 0 && destinationLocationID > 0 && originLocationID != destinationLocationID)
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