using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using System.Threading;

namespace Placed
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Debug : ContentPage
	{
        
		public Debug ()
		{
			InitializeComponent ();
            LastKnownLocationAsync();
            CurrentLocationLowestAsync();
            CurrentLocationLowAsync();
            CurrentLocationMediumAsync();
            CurrentLocationHighAsync();
            CurrentLocationBestAsync();

        }

        private async void CurrentLocationLowestAsync()
        {
            try
            {
                lblLowest.Text = "Getting Current location...";
                var request = new GeolocationRequest(GeolocationAccuracy.Lowest);
                var location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    lblLowest.Text = $"Current Latitude: {location.Latitude}, Longitude: {location.Longitude}";

                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                lblLowest.Text = fnsEx.Message;
            }
            catch (PermissionException pEx)
            {
                lblLowest.Text = pEx.Message;
            }
            catch (Exception ex)
            {
                lblLowest.Text = ex.Message;
            }
        }
        private async void CurrentLocationLowAsync()
        {
            try
            {
                lblLow.Text = "Getting Current location...";
                var request = new GeolocationRequest(GeolocationAccuracy.Low);
                var location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    lblLow.Text = $"Current Latitude: {location.Latitude}, Longitude: {location.Longitude}";

                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                lblLow.Text = fnsEx.Message;
            }
            catch (PermissionException pEx)
            {
                lblLow.Text = pEx.Message;
            }
            catch (Exception ex)
            {
                lblLow.Text = ex.Message;
            }
        }
        private async void CurrentLocationMediumAsync()
        {
            try
            {
                lblMedium.Text = "Getting Current location...";
                var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                var location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    lblMedium.Text = $"Current Latitude: {location.Latitude}, Longitude: {location.Longitude}";

                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                lblMedium.Text = fnsEx.Message;
            }
            catch (PermissionException pEx)
            {
                lblMedium.Text = pEx.Message;
            }
            catch (Exception ex)
            {
                lblMedium.Text = ex.Message;
            }
        }
        private async void CurrentLocationHighAsync()
        {
            try
            {
                lblHigh.Text = "Getting Current location...";
                var request = new GeolocationRequest(GeolocationAccuracy.High);
                var location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    lblHigh.Text = $"Current Latitude: {location.Latitude}, Longitude: {location.Longitude}";

                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                lblHigh.Text = fnsEx.Message;
            }
            catch (PermissionException pEx)
            {
                lblHigh.Text = pEx.Message;
            }
            catch (Exception ex)
            {
                lblHigh.Text = ex.Message;
            }
        }
        private async void CurrentLocationBestAsync()
        {
            try
            {
                lblBest.Text = "Getting Current location...";
                var request = new GeolocationRequest(GeolocationAccuracy.Best);
                var location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    lblBest.Text = $"Current Latitude: {location.Latitude}, Longitude: {location.Longitude}";

                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                lblBest.Text = fnsEx.Message;
            }
            catch (PermissionException pEx)
            {
                lblBest.Text = pEx.Message;
            }
            catch (Exception ex)
            {
                lblBest.Text = ex.Message;
            }
        }

        private async void LastKnownLocationAsync()
        {
            try
            {
                lblLastKnown.Text = "Getting last known location...";
                var location = await Geolocation.GetLastKnownLocationAsync();

                if (location != null)
                {
                    lblLastKnown.Text = $"Last known Latitude: {location.Latitude}, Longitude: {location.Longitude}";
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                lblLastKnown.Text = fnsEx.Message;
            }
            catch (PermissionException pEx)
            {
                lblLastKnown.Text = pEx.Message;
            }
            catch (Exception ex)
            {
                lblLastKnown.Text = ex.Message;
            }
        }
    }
}