using System;
using System.Text;
using System.Windows;

namespace EncodeItFinal
{
    public partial class PolibEncode : Window
    {
        private readonly char[,] polibiusAlphabet = new char[5, 7]
        {
    { 'A', 'Ą', 'B', 'C', 'Ć', 'D', 'E' },
    { 'F', 'G', 'H', 'I', 'J', 'K', 'L' },
    { 'Ł', 'M', 'N', 'Ń', 'O', 'Ó', 'P' },
    { 'R', 'S', 'Ś', 'T', 'U', 'W', 'Y' },
    { 'Z', 'Ż', 'Ź', ' ', ' ', ' ', ' ' }
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
                        for (int col = 0; col < 7; col++)
                        {
                            if (polibiusAlphabet[row, col] == letter)
                            {
                                // Dodatkowe szyfrowanie poprzed obliczenia matematyczne.
                                // Numer kolumny oraz wiersza zostają pomnożone * liczbę pi (3,14).
                                // Jeśli liczba jest < 10 to dopisuje przed nią 0, tak aby każda liczba była dwucyfrowa.
                                double squareResult = Math.Round((row + 1) * 3.14, 0);
                                double colResult = Math.Round((col + 1) * 3.14, 0);

                                result.Append((squareResult < 10 ? "0" : "") + squareResult + (colResult < 10 ? "0" : "") + colResult + " ");
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
