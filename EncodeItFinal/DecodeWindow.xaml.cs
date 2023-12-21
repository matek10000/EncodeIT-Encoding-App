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
    /// Logika interakcji dla klasy DecodeWindow.xaml
    /// </summary>
    public partial class DecodeWindow : Window
    {
        public DecodeWindow()
        {
            InitializeComponent();
        }

        private void decode_but_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem selectedEncode = (ComboBoxItem)decode_type.SelectedItem;
            string selectedOption = selectedEncode.Content.ToString();

            if (selectedOption == "Szyfr Cezara")
            {
                CezarDecode cezardecode = new CezarDecode();
                cezardecode.Show();
                this.Hide();
            }

            if (selectedOption == "Szyfr Polibiusza")
            {
                PolibDecode polibdecode = new PolibDecode();
                polibdecode.Show();
                this.Hide();
            }

            if (selectedOption == "Szyfr Homofoniczny")
            {
                HomoDecode homodecode = new HomoDecode();
                homodecode.Show();
                this.Hide();
            }

            if (selectedOption == "Szyfr Playfaira")
            {
                PlayDecode playdecode = new PlayDecode();
                playdecode.Show();
                this.Hide();
            }
        }

        private void return_but_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }
    }
}
