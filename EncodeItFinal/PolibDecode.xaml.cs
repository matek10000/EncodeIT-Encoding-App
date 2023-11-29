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

            for (int i = 0; i < input.Length; i += 2)
            {
                char rowChar = input[i];
                char colChar = input[i + 1];

                if (char.IsDigit(rowChar) && char.IsDigit(colChar))
                {
                    int row = int.Parse(rowChar.ToString()) - 1;
                    int col = int.Parse(colChar.ToString()) - 1;

                    if (row >= 0 && row < 5 && col >= 0 && col < 6)
                    {
                        result.Append(polibiusAlphabet[row, col]);
                    }
                }
                else
                {
                    result.Append(rowChar); // Jeśli nie można odnaleźć w tabeli, dodaj znak niezmieniony
                    if (char.IsDigit(colChar)) // Dodaj drugą cyfrę, jeśli jest cyfrą
                    {
                        result.Append(colChar);
                    }
                }
            }

            return result.ToString();
        }
    }
}
