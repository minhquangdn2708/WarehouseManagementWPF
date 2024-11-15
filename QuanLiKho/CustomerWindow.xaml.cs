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
    public partial class CustomerWindow : Window
    {
        private readonly ICustomerRepository customerRepository;
        private CustomerRepository _customerRepository = new();
        public Customer editedOne { get; set; }
        public CustomerWindow()
        {
            InitializeComponent();
        }
        private void DisableInputs()
        {
            txtCustomerEmail.IsEnabled = false;
            txtCustomerName.IsEnabled = false;
            txtAddress.IsEnabled = false;
            txtPhone.IsEnabled = false;
            dateContractDate.IsEnabled = false;
        }

        private void EnableInputs()
        {
            txtCustomerEmail.IsEnabled = true;
            txtCustomerName.IsEnabled = true;
            txtAddress.IsEnabled = true;
            txtPhone.IsEnabled = true;
            dateContractDate.IsEnabled = true;
        }

        public void ClearInputs()
        {
            txtCustomerEmail.Text = string.Empty;
            txtCustomerName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtPhone.Text = string.Empty;
            dateContractDate.SelectedDate = null; // Đặt lại DatePicker về null để xóa ngày
        }


        public void ShowNavigate(Customer editOne)
        {
            txtCustomerEmail.Text = editOne.Email;
            txtCustomerName.Text = editOne.CustomerName;
            txtAddress.Text = editOne.Address;
            txtPhone.Text = editOne.Phone;
            dateContractDate.Text = editOne.ContractDate?.ToString("yyyy-MM-dd");
        }

        public void FillDataGrid(List<Customer> arr)
        {
            CustomerDataGrid.ItemsSource = null;
            CustomerDataGrid.ItemsSource = arr;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillDataGrid(_customerRepository.GetAllCustomers().ToList());
            DisableInputs();
        }


        private void AddButton(object sender, RoutedEventArgs e)
        {
            EnableInputs();
        }

        private void UpdateButton(object sender, RoutedEventArgs e)
        {
            EnableInputs();
            Customer? editOne = CustomerDataGrid.SelectedItem as Customer;
            if (editOne == null)
            {
                MessageBox.Show("Hãy chọn khách hàng", "Select one", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }
            editedOne = editOne;
            ShowNavigate(editOne);

        }

        private void DeleteButton(object sender, RoutedEventArgs e)
        {
            Customer? selected = CustomerDataGrid.SelectedItem as Customer;
            if (selected == null)
            {
                MessageBox.Show("Hãy chọn khách hàng", "Select one", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }

            MessageBoxResult answer = MessageBox.Show("Bạn chắc chắn không?", "Confirm?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (answer == MessageBoxResult.No)
                return;
            _customerRepository.DeleteCustomer(selected);
            FillDataGrid(_customerRepository.GetAllCustomers().ToList());
        }

        private void SaveButton(object sender, RoutedEventArgs e)
        {
            Customer obj;
            if (editedOne != null)
                obj = _customerRepository.GetCustomerById(editedOne.CustomerId);
            else
                obj = new Customer();

            obj.Email = txtCustomerEmail.Text;
            obj.CustomerName = txtCustomerName.Text;
            obj.Address = txtAddress.Text;
            obj.Phone = txtPhone.Text;
            if (dateContractDate.SelectedDate.HasValue)
                obj.ContractDate = DateOnly.FromDateTime(dateContractDate.SelectedDate.Value);

            if (editedOne == null)
                _customerRepository.AddCustomer(obj);
            else
            {
                _customerRepository.UpdateCustomer(obj);
                editedOne = null;
            }
            FillDataGrid(_customerRepository.GetAllCustomers().ToList());
            DisableInputs();
            ClearInputs();
        }



    }
}
