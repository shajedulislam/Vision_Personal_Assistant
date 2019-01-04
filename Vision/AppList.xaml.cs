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
using Microsoft.Win32;

namespace Vision
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class AppList : Window
    {
        public AppList()
        {
            InitializeComponent();

            object line;
             string registry_key = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
             using (var baseKey = Microsoft.Win32.RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
             {
                 using (var key = baseKey.OpenSubKey(registry_key))
                 {
                     foreach (string subkey_name in key.GetSubKeyNames())
                     {
                         using (var subKey = key.OpenSubKey(subkey_name))
                         {
                             line = subKey.GetValue("DisplayName");
                             if (line != null)
                             {
                                 applistview.Items.Add(line);
                             }
                         }
                     }
                 }
             }
            /*foreach (Window window in Application.Current.Windows)
            {
                applistview.Items.Add(window.Title);
            }*/


        }
    }
}
