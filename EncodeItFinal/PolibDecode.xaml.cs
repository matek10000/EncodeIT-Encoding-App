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
    /// Logika interakcji dla klasy PolibDecode.xaml
    /// </summary>
    public partial class PolibDecode : Window
    {
        public PolibDecode()
        {
            InitializeComponent();
        }

            private void polib_but_Click(object sender, RoutedEventArgs e)
            {
                string input = polib_text.Text;
                string result = PolibDecoder(input);
                polib_result.Content = result;
            }

        private string PolibDecoder(string input)
        {
            char[,] polibiusTable = new char[5, 5]
            {
        { 'A', 'B', 'C', 'D', 'E' },
        { 'F', 'G', 'H', 'I', 'K' },
        { 'L', 'M', 'N', 'O', 'P' },
        { 'Q', 'R', 'S', 'T', 'U' },
        { 'V', 'W', 'X', 'Y', 'Z' }
            };

            input = input.Replace(" ", ""); // Usuń spacje, jeśli istnieją
            string result = "";

            for (int i = 0; i < input.Length; i += 2)
            {
                char rowChar = input[i];
                char colChar = input[i + 1];

                if (char.IsDigit(rowChar) && char.IsDigit(colChar))
                {
                    int row = int.Parse(rowChar.ToString()) - 1;
                    int col = int.Parse(colChar.ToString()) - 1;

                    if (row >= 0 && row < 5 && col >= 0 && col < 5)
                    {
                        result += polibiusTable[row, col];
                    }
                }
                else
                {
                    result += rowChar; // Jeśli nie można odnaleźć w tabeli, dodaj znak niezmieniony
                    if (char.IsDigit(colChar)) // Dodaj drugą cyfrę, jeśli jest cyfrą
                    {
                        result += colChar;
                    }
                }
            }

            return result;
        }
    }
}
