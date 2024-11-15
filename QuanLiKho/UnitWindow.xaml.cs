using BusinessObject;
using DataAccessLayer.DAO;
using DataAccessLayer.Repository;
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

namespace QuanLiKho
{
    /// <summary>
    /// Interaction logic for UnitWindow.xaml
    /// </summary>
    public partial class UnitWindow : Window
    {
		private readonly IUnitRepository unitRepository;
		private Unit selectedUnit;

        public UnitWindow()
        {
			unitRepository = new UnitRepository();
            InitializeComponent();
			LoadUnitList();

		}
        public void LoadUnitList()
        {
            var units = UnitDAO.Instance.GetAll()
                            .Where(unit => !string.IsNullOrWhiteSpace(unit.UnitName) && unit.UnitName.ToLower() != "(no unit)")
                            .ToList();
            dgUnit.ItemsSource = units;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			LoadUnitList();		
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
            try
            {
                if (string.IsNullOrWhiteSpace(txtUnitName.Text))
                {
                    MessageBox.Show("Tên đơn vị không được để trống.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var newUnit = new Unit
                {
                    UnitName = txtUnitName.Text
                };

                unitRepository.AddUnit(newUnit);
                LoadUnitList();
                ClearFields();
                MessageBox.Show("Thêm mới đơn vị thành công.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
            try
            {
                if (selectedUnit == null)
                {
                    MessageBox.Show("Vui lòng chọn đơn vị để sửa.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtUnitName.Text))
                {
                    MessageBox.Show("Tên đơn vị không được để trống.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                selectedUnit.UnitName = txtUnitName.Text;
                unitRepository.UpdateUnit(selectedUnit);
                LoadUnitList();
                ClearFields();
                MessageBox.Show("Sửa thông tin đơn vị thành công.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

		private void Button_Click_2(object sender, RoutedEventArgs e)
		{
            try
            {
                if (selectedUnit == null)
                {
                    MessageBox.Show("Vui lòng chọn đơn vị để xóa.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (MessageBox.Show("Bạn có chắc chắn muốn xóa đơn vị này?", "Xác nhận xóa", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    unitRepository.DeleteUnit(selectedUnit.UnitId);
                    LoadUnitList();
                    ClearFields();
                    MessageBox.Show("Xóa đơn vị thành công.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Khi chọn một dòng trong DataGrid
        private void dgUnit_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            selectedUnit = dgUnit.SelectedItem as Unit;

            if (selectedUnit != null)
            {
                txtUnitName.Text = selectedUnit.UnitName;
            }
        }

        // Xóa các trường nhập liệu
        private void ClearFields()
        {
            txtUnitName.Clear();
            selectedUnit = null;
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		
	}
}
