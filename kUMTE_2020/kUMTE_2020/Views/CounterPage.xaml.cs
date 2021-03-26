using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using kUMTE_2020.Services;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace kUMTE_2020.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CounterPage : ContentPage
    {
        private int _counter;
        private AppDataCommonContext _appDataCommonContext;
        public CounterPage()
        {
            InitializeComponent();
            _counter = 0;
            UpdateCounterLabel();
            GetCurrentLocation();

            ButtonRenewGpsCoords.Clicked += delegate(object sender, EventArgs args)
            {
                GetCurrentLocation();
            };

            _appDataCommonContext = DependencyService.Get<AppDataCommonContext>();
            var counterData = _appDataCommonContext.Get("counter");
            if (counterData != null)
            {
                _counter = counterData.Value;
                UpdateCounterLabel();
            }
        }

        private void ButtonIncrement_OnClicked(object sender, EventArgs e)
        {
            _counter++;
            UpdateCounterLabel();
            _appDataCommonContext.SetValue("counter", _counter);
        }

        private void UpdateCounterLabel()
        {
            LblCounter.Text = $"Counter {_counter}";
        }

        CancellationTokenSource cts;
        private async Task GetCurrentLocation()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                cts = new CancellationTokenSource();
                var location = await Geolocation.GetLocationAsync(request, cts.Token);

                if (location != null)
                {
                     LabelCoordinates.Text = $"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}";
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }
        }

        protected override void OnDisappearing()
        {
            if (cts != null && !cts.IsCancellationRequested)
                cts.Cancel();
            base.OnDisappearing();
        }
    }
}