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
    /// Logika interakcji dla klasy CezarEncode.xaml
    /// </summary>
    public partial class CezarEncode : Window
    {
        public CezarEncode()
        {
            InitializeComponent();
        }

        private void cezar_but_Click(object sender, RoutedEventArgs e)
        {
            string input = cezar_text.Text.Replace(" ","");
            if(int.TryParse(cezar_key.Text, out int input2))
            {
                string result = CezarEncoder(input, input2);
                cezar_result.Content = result;
            }
            else
            {
                MessageBox.Show("Błędnie podany klucz!");
                return;
            }  
        }

        private string CezarEncoder(string input, int key) 
        {
            char[] inputArray = input.ToCharArray();

            for (int i = 0; i < inputArray.Length; i++)
            {
                char c = inputArray[i];

                if (char.IsLetter(c))
                {
                    char c2 = char.IsUpper(c) ? 'A' : 'a';
                    inputArray[i] = (char)((c - c2 + key) % 26 + c2);
                }
            }
            return new string(inputArray);
        }
    }
}
