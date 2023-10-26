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

namespace EncodeItFinal
{
    /// <summary>
    /// Logika interakcji dla klasy EncodeWindow.xaml
    /// </summary>
    public partial class EncodeWindow : Window
    {
        public EncodeWindow()
        {
            InitializeComponent();
        }

        private void encode_but_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem selectedEncode = (ComboBoxItem)encode_type.SelectedItem;
            string selectedOption = selectedEncode.Content.ToString();

            if(selectedOption == "Szyfr Cezara")
            {
                CezarEncode cezarencode = new CezarEncode();
                cezarencode.Show();
                this.Hide();
            }
        }
    }
}
