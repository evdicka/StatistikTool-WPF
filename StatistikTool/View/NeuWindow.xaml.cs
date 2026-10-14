using System.Globalization;
using System.Windows;
using System.Windows.Media;

namespace StatistikTool
{
    public partial class NeuWindow : Window
    {
        public Data NeueDaten { get; set; }

        public NeuWindow()
        {
            InitializeComponent();

            // Startfarbe, damit die Vorschau nicht schwarz ist
            RotSlider.Value = 100;
            GruenSlider.Value = 180;
            BlauSlider.Value = 100;
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Color farbe = Color.FromRgb((byte)RotSlider.Value, (byte)GruenSlider.Value, (byte)BlauSlider.Value);
            FarbVorschau.Background = new SolidColorBrush(farbe);
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            // Komma und Punkt sind beide erlaubt, also 50,2 oder 50.2
            double wert;
            bool istZahl = double.TryParse(WertTextBox.Text.Replace(",", "."), CultureInfo.InvariantCulture, out wert);

            if (BezeichnungTextBox.Text == "" || !istZahl || wert < 0)
            {
                MessageBox.Show("Bitte eine Bezeichnung und einen Wert (Zahl ab 0) eingeben.");
                return;
            }

            NeueDaten = new Data(BezeichnungTextBox.Text, wert, FarbVorschau.Background);
            this.DialogResult = true;
        }

        private void AbbrechButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
