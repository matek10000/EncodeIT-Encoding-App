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
                string result = CezarDecoder(input, input2);
                cezar_result.Content = result;
            }
            else
            {
                MessageBox.Show("Błędnie podany klucz!");
                return;
            }
        }

        private string CezarDecoder(string input, int key)
        {
            char[] inputArray = input.ToCharArray();

            for (int i = 0; i < inputArray.Length; i++)
            {
                char c = inputArray[i];
                char offset = char.IsUpper(c) ? 'A' : 'a';

                if (char.IsLetter(c))
                {
                    int alphabetSize = char.IsUpper(c) ? 26 : 32;
                    int index = (c - offset - key) % alphabetSize;

                    if (index < 0) index += alphabetSize;

                    inputArray[i] = (char)(index + offset);
                }
            }

            return new string(inputArray);
        }

    }
}
