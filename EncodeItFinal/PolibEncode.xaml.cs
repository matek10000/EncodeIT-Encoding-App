using System;
using System.Text;
using System.Windows;

namespace EncodeItFinal
{
    public partial class PolibEncode : Window
    {
        private readonly char[,] polibiusAlphabet = new char[5, 6]
        {
            { 'A', 'Ą', 'B', 'C', 'Ć', 'D' },
            { 'E', 'Ę', 'F', 'G', 'H', 'I' },
            { 'J', 'K', 'L', 'Ł', 'M', 'N' },
            { 'O', 'Ó', 'P', 'R', 'S', 'Ś' },
            { 'T', 'U', 'W', 'Y', 'Z', 'Ź' }
        };

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
            input = input.ToUpper();
            StringBuilder result = new StringBuilder();

            foreach (char letter in input)
            {
                if (char.IsLetter(letter))
                {
                    for (int row = 0; row < 5; row++)
                    {
                        for (int col = 0; col < 6; col++)
                        {
                            if (polibiusAlphabet[row, col] == letter)
                            {
                                result.Append((row + 1).ToString() + (col + 1).ToString() + " ");
                            }
                        }
                    }
                }
                else
                {
                    result.Append(letter);
                }
            }

            return result.ToString().Trim();
        }

        private void return_but_Click(object sender, RoutedEventArgs e)
        {
            EncodeWindow encodeWindow = new EncodeWindow();
            encodeWindow.Show();
            this.Hide();
        }
    }
}
