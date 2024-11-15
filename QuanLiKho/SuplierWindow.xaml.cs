using BusinessObject;
using DataAccessLayer.Repository;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace QuanLiKho
{
    public partial class SuplierWindow : Window, INotifyPropertyChanged
    {
        private readonly ISupplierRepository supplierRepository;

        public ObservableCollection<Supplier> Suppliers { get; set; }
        private Supplier _selectedSupplier;

        public Supplier SelectedSupplier
        {
            get => _selectedSupplier;
            set
            {
                _selectedSupplier = value;
                OnPropertyChanged();
            }
        }

        public SuplierWindow()
        {
            supplierRepository = new SupplierRepository();
            InitializeComponent();
            DataContext = this;
            LoadSupplierList();
        }

        public void LoadSupplierList()
        {
            Suppliers = new ObservableCollection<Supplier>(supplierRepository.GetAllSuppliers());
            OnPropertyChanged(nameof(Suppliers));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchTextBox.Text.ToLower();
            var filteredSuppliers = supplierRepository.GetAllSuppliers()
                .Where(s => s.SupplierName.ToLower().Contains(searchText))
                .ToList();
            Suppliers.Clear();
            foreach (var supplier in filteredSuppliers)
            {
                Suppliers.Add(supplier);
            }
        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            SupplierForm supplierForm = new SupplierForm();
            if (supplierForm.ShowDialog() == true)
            {
                supplierRepository.AddSupplier(supplierForm.Supplier);
                LoadSupplierList();
            }
        }

        private void Button_Edit(object sender, RoutedEventArgs e)
        {
            if (SelectedSupplier != null && SelectedSupplier.SupplierId != 0)
            {
                supplierRepository.UpdateSupplier(SelectedSupplier);
                LoadSupplierList();
            }
        }

        private void Button_Delete(object sender, RoutedEventArgs e)
        {
            if (SelectedSupplier != null && SelectedSupplier.SupplierId != 0)
            {
                supplierRepository.DeleteSupplier(SelectedSupplier.SupplierId);
                LoadSupplierList();

                SelectedSupplier = new Supplier();
            }
        }
    }
}
