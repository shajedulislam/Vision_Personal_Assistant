using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;



using System.Windows.Navigation;
using System.Device.Location;

namespace Vision
{
    /// <summary>
    /// Interaction logic for Location.xaml
    /// </summary>
    public partial class Location : Window
    {
        private GeoCoordinateWatcher watcher = new GeoCoordinateWatcher(GeoPositionAccuracy.Default);


        public Location()
        {
            InitializeComponent();

            watcher.Start();

            LocationMessage();
        }



        private void LocationMessage()
        {

            GeoCoordinate location =
                watcher.Position.Location;
           

            var whereat = watcher.Position.Location;

            var Lat = location.Latitude.ToString();
            var Lon = location.Longitude.ToString();
            


            //optional parameters for future use
            whereat.Altitude.ToString();
            whereat.HorizontalAccuracy.ToString();
            whereat.VerticalAccuracy.ToString();
            whereat.Course.ToString();
            whereat.Speed.ToString();

            if (watcher.Position.Location.IsUnknown)
            {
                MessageBox.Show("Cannot find location data");
            }
            else
            {

                MessageBox.Show(Lat, Lon);
            }

        }
    }
}
