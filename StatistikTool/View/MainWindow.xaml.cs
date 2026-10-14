using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StatistikTool
{
    public partial class MainWindow : Window
    {
        private StatistikTool.ViewModel.MainWindowViewModel vm;
        public MainWindow()
        {
            
            InitializeComponent();
            vm = new StatistikTool.ViewModel.MainWindowViewModel();
            DataContext = vm;
            Loaded += MainWindow_Loaded;

        }

        public void ZeichneDiagramm()
        {
            myCanvas.Children.Clear();

           
            if (vm == null || vm.Datas == null || vm.Datas.Count == 0)
            {
                return;
            }

            double canvasHeight = myCanvas.ActualHeight;
            double canvasWidth = myCanvas.ActualWidth;

            double maxWert = vm.Datas[0].Wert;

            foreach (Data d in vm.Datas)
            {
                if (d.Wert > maxWert)
                {
                    maxWert = d.Wert;
                }
            }

            // Die Balken teilen sich die Breite des Canvas, damit alle reinpassen
            double abstand = 10;
            double balkenBreite = (canvasWidth - abstand) / vm.Datas.Count - abstand;
            if (balkenBreite < 1)
            {
                balkenBreite = 1;
            }

            for (int i = 0; i < vm.Datas.Count; i++)
            {
                Data d = vm.Datas[i];

                double balkenHoehe = d.Wert / maxWert * (canvasHeight - 30);

                Label balken = new Label();
                balken.Width = balkenBreite;
                balken.Height = balkenHoehe;
                balken.Background = d.Farbe;
                balken.Content = d.Bezeichnung + "\n" + d.Wert;
                balken.ToolTip = d.Bezeichnung + ": " + d.Wert;
                balken.HorizontalContentAlignment = HorizontalAlignment.Center;
                balken.VerticalContentAlignment = VerticalAlignment.Top;

                double x = i * (balkenBreite + abstand) + abstand;
                double y = canvasHeight - balkenHoehe;

                Canvas.SetLeft(balken, x);
                Canvas.SetTop(balken, y);

                myCanvas.Children.Add(balken);
            }

        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            ZeichneDiagramm();
        }

        private void myCanvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ZeichneDiagramm();
        }

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            NeuWindow window = new NeuWindow();
            window.Owner = this;

            if (window.ShowDialog() == true)
            {
                vm.Datas.Add(window.NeueDaten);
                ZeichneDiagramm();
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            
            Data selectedData = (Data)DataList.SelectedItem;
            MessageBoxResult result = MessageBox.Show($"Möchten Sie '{selectedData.Bezeichnung}' wirklich löschen?", "Bestätigung", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if(result == MessageBoxResult.Yes)
            {
               
                if (vm != null)
                {
                    vm.Datas.Remove(selectedData);
                    ZeichneDiagramm();
                }
            }

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataList.SelectedItem != null)
            {
                DeleteButton.IsEnabled = true;
            }
            else
            {
                DeleteButton.IsEnabled = false;
            }
        }
    }
}
