using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

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
            if (addressField.Text==null)
            {
                return;
            }

            try
            {

                var address = addressField.Text.Trim();
                var locations = await Geocoding.GetLocationsAsync(address);

                var location = locations?.FirstOrDefault();
                if (location != null)
                {
                    Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                    lat.Text ="latitude is: "+ location.Latitude.ToString();
                    longi.Text ="longitude is: "+ location.Longitude.ToString();
                }
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
