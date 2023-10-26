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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EncodeItFinal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void encode_but_Click(object sender, RoutedEventArgs e)
        {
            EncodeWindow encodewindow = new EncodeWindow();
            encodewindow.Show();
            this.Hide();
        }

        private void decode_but_Click(object sender, RoutedEventArgs e)
        {
            DecodeWindow decodewindow= new DecodeWindow();
            decodewindow.Show();
            this.Hide();
        }
    }
}
