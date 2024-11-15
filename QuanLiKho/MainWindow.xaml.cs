using MaterialDesignThemes.Wpf;
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

namespace QuanLiKho
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			InputWindow inputWindow = new InputWindow();
			inputWindow.Show();
        }

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			OutputWindow outWindow = new OutputWindow();
			outWindow.Show();

		}

		private void Button_Click_2(object sender, RoutedEventArgs e)
		{
			ObjectWindow objectWindow = new ObjectWindow();
			objectWindow.Show();
		}

		private void Button_Click_3(object sender, RoutedEventArgs e)
		{
			UnitWindow unitWindow = new UnitWindow();
			unitWindow.Show();
		}

		private void Button_Click_4(object sender, RoutedEventArgs e)
		{
			SuplierWindow suplierWindow = new SuplierWindow();
			suplierWindow.Show();
		}

		private void Button_Click_5(object sender, RoutedEventArgs e)
		{
			UserWindow userWindow = new UserWindow();
			userWindow.Show();
		}

		private void Button_Click_6(object sender, RoutedEventArgs e)
		{
			UserWindow userWindow = new UserWindow();
			userWindow.Show();
		}
	}
}