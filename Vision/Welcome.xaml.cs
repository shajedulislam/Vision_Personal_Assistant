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

namespace Vision
{
  


    public partial class Window1 : Window
    {
        int count = 0;

        bool sound = true;
        public Window1()
        {
            InitializeComponent();

            //Window2 win2 = new Window2();

            // win2.Close();

         

        }

        private void myGif_MediaEnded(object sender, RoutedEventArgs e)
        {
            count++;
            myGif.Position = new TimeSpan(0, 0, 1);
            myGif.Play();
            if(count==3)
            {
                MainWindow main = new MainWindow();
                main.Show();
                this.Close();
            }
        }



    }
}
