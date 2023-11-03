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
    /// Logika interakcji dla klasy PolibEncode.xaml
    /// </summary>
    public partial class PolibEncode : Window
    {
        public PolibEncode()
        {
            InitializeComponent();
        }

        private void polib_but_Click(object sender, RoutedEventArgs e)
        {
            string input = polib_text.Text;
            string result = PolibEncoder(input);
            polib_result.Content = result;
        }

        private string PolibEncoder(string input)
        {
            char[,] polibiusTable = new char[5, 5]
            {
                { 'A', 'B', 'C', 'D', 'E' },
                { 'F', 'G', 'H', 'I', 'K' },
                { 'L', 'M', 'N', 'O', 'P' },
                { 'Q', 'R', 'S', 'T', 'U' },
                { 'V', 'W', 'X', 'Y', 'Z' }
            };

            input = input.ToUpper();
            string result = "";

            foreach (char letter in input)
            {
                if (char.IsLetter(letter))
                {
                    for (int row = 0; row < 5; row++)
                    {
                        for (int col = 0; col < 5; col++)
                        {
                            if (polibiusTable[row, col] == letter)
                            {
                                result += (row + 1).ToString() + (col + 1).ToString() + " ";
                            }
                        }
                    }
                }
                else
                {
                    result += letter;
                }
            }

            return result.Trim();
        }
    }
}
