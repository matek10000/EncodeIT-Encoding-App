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
    public partial class HomoDecode : Window
    {
        private Dictionary<char, List<string>> homoAlphabet;

        public HomoDecode()
        {
            InitializeComponent();
            InitializeHomophonicMapping();
        }

        private void InitializeHomophonicMapping()
        {

            // Zadeklarowanie słownika wraz z kodami dla każdej litery.
            homoAlphabet = new Dictionary<char, List<string>>();

            homoAlphabet.Add('A', new List<string> { "197", "861", "374", "526", "154", "260", "196", "211", "777" });
            homoAlphabet.Add('Ą', new List<string> { "772" });
            homoAlphabet.Add('B', new List<string> { "010" });
            homoAlphabet.Add('C', new List<string> { "841", "011", "680", "755" });
            homoAlphabet.Add('Ć', new List<string> { "581" });
            homoAlphabet.Add('D', new List<string> { "732", "008", "521" });
            homoAlphabet.Add('E', new List<string> { "943", "312", "467", "643", "516", "921", "668", "252" });
            homoAlphabet.Add('Ę', new List<string> { "829" });
            homoAlphabet.Add('F', new List<string> { "153" });
            homoAlphabet.Add('G', new List<string> { "332" });
            homoAlphabet.Add('H', new List<string> { "525" });
            homoAlphabet.Add('I', new List<string> { "795", "446", "867", "964", "299", "499", "180", "670" });
            homoAlphabet.Add('J', new List<string> { "551", "734" });
            homoAlphabet.Add('K', new List<string> { "039", "136", "307", "364" });
            homoAlphabet.Add('L', new List<string> { "877", "927" });
            homoAlphabet.Add('Ł', new List<string> { "711", "142" });
            homoAlphabet.Add('M', new List<string> { "843", "818", "543" });
            homoAlphabet.Add('N', new List<string> { "291", "490", "450", "924", "410", "994" });
            homoAlphabet.Add('Ń', new List<string> { "349" });
            homoAlphabet.Add('O', new List<string> { "403", "974", "370", "903", "286", "116", "666", "807" });
            homoAlphabet.Add('Ó', new List<string> { "325" });
            homoAlphabet.Add('P', new List<string> { "950", "722", "724" });
            homoAlphabet.Add('Q', new List<string> { "103" });
            homoAlphabet.Add('R', new List<string> { "247", "686", "294", "003", "127" });
            homoAlphabet.Add('S', new List<string> { "018", "036", "945", "088" });
            homoAlphabet.Add('Ś', new List<string> { "132" });
            homoAlphabet.Add('T', new List<string> { "508", "780", "751", "723" });
            homoAlphabet.Add('U', new List<string> { "993", "799", "835" });
            homoAlphabet.Add('W', new List<string> { "134", "936", "246", "485", "901" });
            homoAlphabet.Add('Y', new List<string> { "552", "267", "220", "219" });
            homoAlphabet.Add('Z', new List<string> { "182", "628", "784", "105", "028", "591" });
            homoAlphabet.Add('Ż', new List<string> { "038" });
            homoAlphabet.Add('Ź', new List<string> { "669" });
        }


        private void homo_but_Click(object sender, RoutedEventArgs e)
        {
            string input = homo_text.Text;
            string result = HomoDecoder(input);
            homo_result.Content = result;
        }

        private string HomoDecoder(string input)
        {
            // Funkcja kodująca szyfr Homograficzny
            input = input.Replace(" ", "");
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                char letter = input[i];

                // Sprawdza czy znak należy do kodów podanych w słowniku
                foreach (var codes in homoAlphabet)
                {
                    if (codes.Value.Contains(input.Substring(i, Math.Min(3, input.Length - i))))
                    {
                        result.Append(codes.Key.ToString().ToLower());
                        i++;
                        break;
                    }
                    else if (codes.Key == letter)
                    {
                        result.Append(letter);
                        break;
                    }
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
