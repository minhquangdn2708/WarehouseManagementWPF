using BusinessObject;
using DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        private readonly ICustomerRepository customerRepository;  // Sử dụng repository để tương tác với cơ sở dữ liệu
        private CustomerRepository _customerRepository = new(); // Tạo instance repository
        public Customer EditedOne { get; set; }  // Đối tượng customer đang được chỉnh sửa

        public UserWindow()
        {
            InitializeComponent();
            customerRepository = _customerRepository;
        }

        // Điền dữ liệu vào DataGrid
        public void FillDataGrid(List<Customer> arr)
        {
            // Sử dụng Binding để hiển thị danh sách khách hàng vào DataGrid
            CustomerDataGrid.ItemsSource = arr;
        }

        // Sự kiện khi cửa sổ được tải
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillDataGrid(_customerRepository.GetAllCustomers().ToList());  // Lấy tất cả khách hàng và hiển thị
            DisableInputs();  // Vô hiệu hóa các trường nhập liệu ban đầu
        }

        // Thêm khách hàng mới
        private void AddButton(object sender, RoutedEventArgs e)
        {
            var newCustomer = new Customer
            {
                CustomerName = txtCustomerName.Text,
                Email = txtCustomerEmail.Text,
                Address = txtAddress.Text,
                Phone = txtPhone.Text,
                ContractDate = dateContractDate.SelectedDate.HasValue ? DateOnly.FromDateTime(dateContractDate.SelectedDate.Value) : null
            };

            _customerRepository.AddCustomer(newCustomer);  // Thêm khách hàng mới
            FillDataGrid(_customerRepository.GetAllCustomers().ToList());  // Cập nhật lại DataGrid
            ClearInputs();  // Xóa dữ liệu đã nhập
        }

        // Cập nhật thông tin khách hàng đã chọn
        private void UpdateButton(object sender, RoutedEventArgs e)
        {
            if (EditedOne != null)
            {
                EditedOne.CustomerName = txtCustomerName.Text;
                EditedOne.Email = txtCustomerEmail.Text;
                EditedOne.Address = txtAddress.Text;
                EditedOne.Phone = txtPhone.Text;
                EditedOne.ContractDate = dateContractDate.SelectedDate.HasValue ? DateOnly.FromDateTime(dateContractDate.SelectedDate.Value) : null;

                _customerRepository.UpdateCustomer(EditedOne);  // Cập nhật thông tin khách hàng
                FillDataGrid(_customerRepository.GetAllCustomers().ToList());  // Cập nhật lại DataGrid
                ClearInputs();  // Xóa dữ liệu đã nhập
                DisableInputs();  // Vô hiệu hóa các trường nhập liệu
            }
        }

        // Xóa khách hàng đã chọn
        private void DeleteButton(object sender, RoutedEventArgs e)
        {
            if (EditedOne != null)
            {
                _customerRepository.DeleteCustomer(EditedOne);  // Xóa khách hàng
                FillDataGrid(_customerRepository.GetAllCustomers().ToList());  // Cập nhật lại DataGrid
                ClearInputs();  // Xóa dữ liệu đã nhập
                DisableInputs();  // Vô hiệu hóa các trường nhập liệu
            }
        }

        // Vô hiệu hóa các trường nhập liệu
        private void DisableInputs()
        {
            txtCustomerName.IsEnabled = false;
            txtCustomerEmail.IsEnabled = false;
            txtAddress.IsEnabled = false;
            txtPhone.IsEnabled = false;
            dateContractDate.IsEnabled = false;
        }

        // Kích hoạt các trường nhập liệu
        private void EnableInputs()
        {
            txtCustomerName.IsEnabled = true;
            txtCustomerEmail.IsEnabled = true;
            txtAddress.IsEnabled = true;
            txtPhone.IsEnabled = true;
            dateContractDate.IsEnabled = true;
        }

        // Làm sạch các trường nhập liệu
        private void ClearInputs()
        {
            txtCustomerName.Clear();
            txtCustomerEmail.Clear();
            txtAddress.Clear();
            txtPhone.Clear();
            dateContractDate.SelectedDate = null;
        }

        // Sự kiện khi chọn một dòng trong DataGrid
        private void dgData_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (CustomerDataGrid.SelectedItem != null)
            {
                EditedOne = CustomerDataGrid.SelectedItem as Customer;
                if (EditedOne != null)
                {
                    // Điền các trường nhập liệu với dữ liệu của khách hàng đã chọn
                    txtCustomerName.Text = EditedOne.CustomerName;
                    txtCustomerEmail.Text = EditedOne.Email;
                    txtAddress.Text = EditedOne.Address;
                    txtPhone.Text = EditedOne.Phone;
                    dateContractDate.SelectedDate = EditedOne.ContractDate?.ToDateTime(TimeOnly.MinValue);
                    EnableInputs();  // Kích hoạt các trường nhập liệu
                }
            }
        }

    }
}
