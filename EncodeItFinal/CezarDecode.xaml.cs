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
    /// Logika interakcji dla klasy CezarDecode.xaml
    /// </summary>
    public partial class CezarDecode : Window
    {
        public CezarDecode()
        {
            InitializeComponent();
        }

        private void cezar_but_Click(object sender, RoutedEventArgs e)
        {
            string input = cezar_text.Text.Replace(" ", "");


            if (int.TryParse(cezar_key.Text, out int input2))
            {
                string result = CezarDecoder(input, input2, dict);
                cezar_result.Content = result;
            }
            else
            {
                MessageBox.Show("Błędnie podany klucz!");
                return;
            }
        }

        private string CezarDecoder(string input, int key, Dictionary<int, char> dict)
        {
            char[] inputArray = input.ToCharArray();
            string wynik = "";

            foreach (char letter in inputArray)
            {
                int id = dict.First(para => para.Value == letter).Key;
                int index = (id - key + dict.Count) % dict.Count;
                if (index == 0)
                {
                    wynik += dict[dict.Count];
                }
                else
                {
                    wynik += dict[index];
                }
            }
            return wynik;
        }

        Dictionary<int, char> dict = new Dictionary<int, char>
            {
                {1, 'a'},
                {2, 'ą'},
                {3, 'b'},
                {4, 'c'},
                {5, 'ć'},
                {6, 'd'},
                {7, 'e'},
                {8, 'ę'},
                {9, 'f'},
                {10, 'g'},
                {11, 'h'},
                {12, 'i'},
                {13, 'j'},
                {14, 'k'},
                {15, 'l'},
                {16, 'ł'},
                {17, 'm'},
                {18, 'n'},
                {19, 'ń'},
                {20, 'o'},
                {21, 'ó'},
                {22, 'p'},
                {23, 'r'},
                {24, 's'},
                {25, 'ś'},
                {26, 't'},
                {27, 'u'},
                {28, 'w'},
                {29, 'y'},
                {30, 'z'},
                {31, 'ź'},
                {32, 'ż'},
            };
    }
}
