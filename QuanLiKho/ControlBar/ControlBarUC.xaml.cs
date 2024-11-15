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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QuanLiKho.ControlBar
{
	/// <summary>
	/// Interaction logic for ControlBarUC.xaml
	/// </summary>
	public partial class ControlBarUC : UserControl
	{
		public ControlBarUC()
		{
			InitializeComponent();
		}


		private void MinimizeButton_Click(object sender, RoutedEventArgs e)
		{
			Window parentWindow = Window.GetWindow(this); // Lấy cửa sổ cha của UserControl
			if (parentWindow != null)
			{
				parentWindow.WindowState = WindowState.Minimized;
			}
		}

		private void MaximizeButton_Click(object sender, RoutedEventArgs e)
		{
			Window parentWindow = Window.GetWindow(this);
			if (parentWindow != null)
			{
				if (parentWindow.WindowState == WindowState.Maximized)
				{
					parentWindow.WindowState = WindowState.Normal; // Khôi phục
				}
				else
				{
					parentWindow.WindowState = WindowState.Maximized; // Phóng to
				}
			}
		}

		private void CloseButton_Click(object sender, RoutedEventArgs e)
		{
			Window parentWindow = Window.GetWindow(this);
			if (parentWindow != null)
			{
				parentWindow.Close();
			}
		}

		private void DockPanel_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (e.LeftButton == MouseButtonState.Pressed) // Kiểm tra chuột trái được nhấn
			{
				Window parentWindow = Window.GetWindow(this); // Lấy cửa sổ cha
				if (parentWindow != null)
				{
					parentWindow.DragMove(); // Kích hoạt di chuyển cửa sổ
				}
			}
		}
	}
}
