using System;
using System.Text;
using System.Windows;

namespace EncodeItFinal
{
    public partial class PolibDecode : Window
    {
        private readonly char[,] polibiusAlphabet = new char[5, 6]
        {
            { 'A', 'Ą', 'B', 'C', 'Ć', 'D' },
            { 'E', 'Ę', 'F', 'G', 'H', 'I' },
            { 'J', 'K', 'L', 'Ł', 'M', 'N' },
            { 'O', 'Ó', 'P', 'R', 'S', 'Ś' },
            { 'T', 'U', 'W', 'Y', 'Z', 'Ź' }
        };

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
            input = input.Replace(" ", ""); // Usuń spacje, jeśli istnieją
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < input.Length; i += 4)
            {
                string squarePart = input.Substring(i, 2);
                string colPart = input.Substring(i + 2, 2);

                if (int.TryParse(squarePart, out int square) && int.TryParse(colPart, out int col))
                {
                    // Odszyfrowywanie operacji matematycznych
                    // Dzielenie przez pi (3,14)
                    int row = (int)Math.Round(square / 3.14) - 1;
                    col = (int)Math.Round(col / 3.14) - 1;

                    if (row >= 0 && row < 5 && col >= 0 && col < 6)
                    {
                        result.Append(polibiusAlphabet[row, col]);
                    }
                }
                else
                {
                    result.Append(squarePart); // Jeśli nie można odnaleźć w tabeli, dodaj znak niezmieniony
                    result.Append(colPart);
                }
            }

            return result.ToString();
        }

        private void return_but_Click(object sender, RoutedEventArgs e)
        {
            DecodeWindow decodeWindow = new DecodeWindow();
            decodeWindow.Show();
            this.Hide();
        }
    }
}
