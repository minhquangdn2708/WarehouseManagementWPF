using System;
using System.Linq;
using System.Windows;
using BusinessObject;
using DataAccessLayer.DAO;

namespace QuanLiKho
{
    public partial class InputWindow : Window
    {
        private InputInfo selectedInputInfo;

        public InputWindow()
        {
            InitializeComponent();
            LoadObjectNames();
            LoadInputInfos();
        }

        // Load danh sách vật tư vào ComboBox
        private void LoadObjectNames()
        {
            cbObjectName.ItemsSource = ObjectDAO.Instance.GetAll();
        }

        // Load danh sách InputInfo vào DataGrid
        private void LoadInputInfos()
        {
            dgInputInfo.ItemsSource = InputDAO.Instance.GetAll().ToList();
        }

        // Khi chọn một dòng trong DataGrid
        private void dgInputInfo_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            selectedInputInfo = dgInputInfo.SelectedItem as InputInfo;

            if (selectedInputInfo != null)
            {
                cbObjectName.SelectedValue = selectedInputInfo.ObjectId;
                dpInputDate.SelectedDate = selectedInputInfo.InputDate.ToDateTime(TimeOnly.MinValue);
                txtCount.Text = selectedInputInfo.Count.ToString();
                txtInputPrice.Text = selectedInputInfo.InputPrice.ToString();
                txtOutputPrice.Text = selectedInputInfo.OutputPrice.ToString();
                txtStatus.Text = selectedInputInfo.Status;
            }
        }

        // Thêm mới InputInfo
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var newInputInfo = new InputInfo
            {
                ObjectId = (int)cbObjectName.SelectedValue,
                Count = int.Parse(txtCount.Text),
                InputPrice = int.Parse(txtInputPrice.Text),
                OutputPrice = int.Parse(txtOutputPrice.Text),
                InputDate = DateOnly.FromDateTime(dpInputDate.SelectedDate.Value),
                Status = txtStatus.Text
            };

            InputDAO.Instance.Add(newInputInfo);
            LoadInputInfos();
        }

        // Sửa thông tin InputInfo
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (selectedInputInfo != null)
            {
                selectedInputInfo.ObjectId = (int)cbObjectName.SelectedValue;
                selectedInputInfo.Count = int.Parse(txtCount.Text);
                selectedInputInfo.InputPrice = int.Parse(txtInputPrice.Text);
                selectedInputInfo.OutputPrice = int.Parse(txtOutputPrice.Text);
                selectedInputInfo.InputDate = DateOnly.FromDateTime(dpInputDate.SelectedDate.Value);
                selectedInputInfo.Status = txtStatus.Text;

                InputDAO.Instance.Update(selectedInputInfo);
                LoadInputInfos();
            }
        }

        // Xóa InputInfo
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (selectedInputInfo != null)
            {
                InputDAO.Instance.Delete(selectedInputInfo.InputInfoId);
                LoadInputInfos();
            }
        }
    }
}
