using BusinessObject;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace QuanLiKho
{
    public partial class SupplierForm : Window
    {
        public Supplier Supplier { get; set; }

        public SupplierForm(Supplier supplier = null)
        {
            InitializeComponent();

            if (supplier != null)
            {
                Supplier = supplier;
                SupplierNameTextBox.Text = supplier.SupplierName;
                AddressTextBox.Text = supplier.Address;
                PhoneTextBox.Text = supplier.Phone;
                EmailTextBox.Text = supplier.Email;
                ContractDatePicker.SelectedDate = supplier.ContractDate?.ToDateTime(new TimeOnly(0, 0));
            }
            else
            {
                Supplier = new Supplier();
            }
        }

        private void OnSaveClick(object sender, RoutedEventArgs e)
        {
            Supplier.SupplierName = SupplierNameTextBox.Text;
            Supplier.Address = AddressTextBox.Text;
            Supplier.Phone = PhoneTextBox.Text;
            Supplier.Email = EmailTextBox.Text;
            Supplier.ContractDate = ContractDatePicker.SelectedDate.HasValue
                                    ? DateOnly.FromDateTime(ContractDatePicker.SelectedDate.Value)
                                    : null;

            DialogResult = true;
            Close();
        }
        private void OnTextBoxGotFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox != null && textBox.Text == textBox.Tag.ToString())
            {
                textBox.Text = "";
                textBox.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void OnTextBoxLostFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox != null && string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = textBox.Tag.ToString();
                textBox.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }


        private void OnCancelClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
