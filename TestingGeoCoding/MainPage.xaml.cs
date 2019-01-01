using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using TestingGeoCoding.Services;

namespace TestingGeoCoding
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

       async void Handle_Clicked(object sender, System.EventArgs e)
        {
            lat.Text = "Loading....";
            longi.Text = "Loading...";
            addressField.Text = "20a Admiralty Way, Eti-Osa, Lagos, Nigeria";
            if (addressField.Text==null)
            {
                return;
            }

            try
            {

                LatLong ll = new LatLong();
                var calculatedLongLat = ll.GetLatLongFromAddress(addressField.Text);
                //var address = addressField.Text.Trim();
                //var locations = await Geocoding.GetLocationsAsync(address);

                //var location = locations?.FirstOrDefault();
                //if (location != null)
                //{
                //    Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                //    lat.Text ="latitude is: "+ location.Latitude.ToString();
                //    longi.Text ="longitude is: "+ location.Longitude.ToString();
                //}
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Feature not supported on device
                var log = fnsEx
;            }
            catch (Exception ex)
            {
                // Handle exception that may have occurred in geocoding
                lat.Text ="error===>"+ ex.ToString();
                lat.TextColor = Color.Red;
             
                var log = ex;
            }
        }
    }
}
