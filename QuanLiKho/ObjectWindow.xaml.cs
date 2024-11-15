using BusinessObject;
using DataAccessLayer.DAO;
using DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for ObjectWindow.xaml
    /// </summary>
    public partial class ObjectWindow : Window
	{
        private Objectss selectedObject;

        public ObjectWindow()
        {
            InitializeComponent();
            LoadUnits();
            LoadSuppliers();
            LoadObjects();
        }

        // Load danh sách đơn vị đo vào ComboBox
        private void LoadUnits()
        {
            cbUnit.ItemsSource = UnitDAO.Instance.GetAll();
        }

        // Load danh sách nhà cung cấp vào ComboBox
        private void LoadSuppliers()
        {
            cbSupplier.ItemsSource = SupplierDAO.Instance.GetAll();
        }

        // Load danh sách Objectss vào DataGrid
        private void LoadObjects()
        {
            dgObject.ItemsSource = ObjectDAO.Instance.GetAll().ToList();
        }

        // Khi chọn một dòng trong DataGrid
        private void dgData_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            selectedObject = dgObject.SelectedItem as Objectss;

            if (selectedObject != null)
            {
                txtObjectName.Text = selectedObject.ObjectName;
                cbUnit.SelectedValue = selectedObject.UnitId;
                cbSupplier.SelectedValue = selectedObject.SupplierId;
            }
        }

        // Thêm mới Objectss
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Kiểm tra các trường nhập liệu không được để trống hoặc null
                if (string.IsNullOrWhiteSpace(txtObjectName.Text))
                {
                    MessageBox.Show("Tên vật tư không được để trống.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (cbUnit.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn đơn vị đo.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (cbSupplier.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn nhà cung cấp.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Tạo đối tượng mới
                var newObject = new Objectss
                {
                    ObjectName = txtObjectName.Text,
                    UnitId = (int)cbUnit.SelectedValue,
                    SupplierId = (int)cbSupplier.SelectedValue
                };

                // Thêm đối tượng mới vào cơ sở dữ liệu
                ObjectDAO.Instance.Add(newObject);

                // Tải lại danh sách đối tượng và xóa các trường nhập liệu
                LoadObjects();
                ClearFields();

                MessageBox.Show("Thêm mới vật tư thành công.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và hiển thị thông báo cho người dùng
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Sửa thông tin Objectss
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (selectedObject != null)
            {
                selectedObject.ObjectName = txtObjectName.Text;
                selectedObject.UnitId = (int)cbUnit.SelectedValue;
                selectedObject.SupplierId = (int)cbSupplier.SelectedValue;

                ObjectDAO.Instance.Update(selectedObject);
                LoadObjects();
                ClearFields();
            }
        }

        // Xóa Objectss
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (selectedObject != null)
            {
                ObjectDAO.Instance.Delete(selectedObject.ObjectId);
                LoadObjects();
                ClearFields();
            }
        }

        // Xóa các trường nhập liệu sau khi thêm, sửa, hoặc xóa
        private void ClearFields()
        {
            txtObjectName.Clear();
            cbUnit.SelectedIndex = -1;
            cbSupplier.SelectedIndex = -1;
            selectedObject = null;
        }

    }
}
