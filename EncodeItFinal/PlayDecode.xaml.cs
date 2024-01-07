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
    public partial class PlayDecode : Window
    {
        private readonly char[,] matrix = new char[5, 7]
        {
            {'A', 'Ą', 'B', 'C', 'Ć', 'D', 'E'},
            {'F', 'G', 'H', 'I', 'J', 'K', 'L'},
            {'Ł', 'M', 'N', 'Ń', 'O', 'Ó', 'P'},
            {'R', 'S', 'Ś', 'T', 'U', 'W', 'Y'},
            {'Z', 'Ż', 'Ź', 'X', 'X', 'X', 'X'},
        };

        public PlayDecode()
        {
            InitializeComponent();
        }

        private void play_but_Click(object sender, RoutedEventArgs e)
        {
            string input = play_text.Text.Replace(" ", "");

            if (!string.IsNullOrEmpty(input))
            {
                string result = PlayfairDecipher(input, matrix);
                play_result.Content = result;
            }
            else
            {
                MessageBox.Show("Podaj tekst do odszyfrowania!");
            }
        }

        private string PlayfairDecipher(string input, char[,] matrix)
        {
            input = input.ToUpper();
            string result = "";

            for (int i = 0; i < input.Length; i += 2)
            {
                char char1 = input[i];
                char char2 = (i + 1 < input.Length) ? input[i + 1] : 'X';

                int[] position1 = FindPosition(char1, matrix);
                int[] position2 = FindPosition(char2, matrix);

                if (position1[0] == position2[0])
                {
                    result += matrix[position1[0], (position1[1] - 1 + matrix.GetLength(1)) % matrix.GetLength(1)];
                    result += matrix[position2[0], (position2[1] - 1 + matrix.GetLength(1)) % matrix.GetLength(1)];
                }
                else if (position1[1] == position2[1])
                {
                    result += matrix[(position1[0] - 1 + matrix.GetLength(0)) % matrix.GetLength(0), position1[1]];
                    result += matrix[(position2[0] - 1 + matrix.GetLength(0)) % matrix.GetLength(0), position2[1]];
                }
                else
                {
                    result += matrix[position1[0], position2[1]];
                    result += matrix[position2[0], position1[1]];
                }
            }

            return result;
        }

        private int[] FindPosition(char character, char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == character)
                    {
                        return new int[] { i, j };
                    }
                }
            }
            return new int[] { -1, -1 };
        }

        private void return_but_Click(object sender, RoutedEventArgs e)
        {
            EncodeWindow encodeWindow = new EncodeWindow();
            encodeWindow.Show();
            this.Hide();
        }
    }
}