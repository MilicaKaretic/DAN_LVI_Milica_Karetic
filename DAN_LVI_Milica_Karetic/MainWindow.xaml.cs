using DAN_LVI_Milica_Karetic.ViewModel;
using System.Windows;

namespace DAN_LVI_Milica_Karetic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel();
        }

        /// <summary>
        /// get html file button listener
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetHtmlBtn(object sender, RoutedEventArgs e)
        {
            //call method to generate html file
            MainWindowViewModel.GetHtmlFile(HTMLbox.Text);
            HTMLbox.Text = "";
        }

        /// <summary>
        /// get zip file button listener
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MakeZipFile(object sender, RoutedEventArgs e)
        {
            //call method to generate zip file
            MainWindowViewModel.CreateZip();
        }
    }
}
