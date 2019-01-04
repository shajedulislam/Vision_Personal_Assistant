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
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();

            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\Users\AnY\Desktop\Vision AI\Vision\loadsound.wav");


            player.Play();



            System.Threading.Thread.Sleep(1000);

           

            Window1 win = new Window1();

            win.Show();

            this.Close();
        }
    }
}
