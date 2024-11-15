using System;
using System.Linq;
using System.Windows;
using BusinessObject;
using DataAccessLayer.DAO;

namespace QuanLiKho
{
    public partial class OutputWindow : Window
    {
        private OutputInfo selectedOutputInfo;

        public OutputWindow()
        {
            InitializeComponent();
            LoadObjectNames();
            LoadOutputInfos();
            LoadCustomerName();
        }

        private void LoadCustomerName()
        {
            cbCustomerName.ItemsSource = CustomerDAO.Instance.GetAll();
        }

        // Load danh sách vật tư vào ComboBox
        private void LoadObjectNames()
        {
            cbObjectName.ItemsSource = ObjectDAO.Instance.GetAll();
        }

        // Load danh sách OutputInfo vào DataGrid
        private void LoadOutputInfos()
        {
            dgOutputInfo.ItemsSource = OutputDAO.Instance.GetAll().ToList();
        }

        // Khi chọn một dòng trong DataGrid
        private void dgOutputInfo_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            selectedOutputInfo = dgOutputInfo.SelectedItem as OutputInfo;

            if (selectedOutputInfo != null)
            {
                cbCustomerName.SelectedValue = selectedOutputInfo.CustomerId;
                cbObjectName.SelectedValue = selectedOutputInfo.ObjectId;
                dpOutputDate.SelectedDate = selectedOutputInfo.OutputDate.ToDateTime(TimeOnly.MinValue);
                txtCount.Text = selectedOutputInfo.Count.ToString();
                txtStatus.Text = selectedOutputInfo.Status;

                // Lấy thông tin InputInfo thông qua ObjectId (khóa ngoại)
                var inputInfo = InputDAO.Instance.GetByObjectId(selectedOutputInfo.ObjectId);
                if (inputInfo != null)
                {
                    // Hiển thị giá trị InputPrice và OutputPrice từ InputInfo
                    txtInputPrice.Text = inputInfo.InputPrice.ToString();
                    txtOutputPrice.Text = inputInfo.OutputPrice.ToString();
                }
            }
        }

        // Thêm mới OutputInfo
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Lấy các giá trị từ giao diện người dùng
                int customerId = (int)cbCustomerName.SelectedValue;
                int objectId = (int)cbObjectName.SelectedValue;
                int count = int.Parse(txtCount.Text);
                DateOnly outputDate = DateOnly.FromDateTime(dpOutputDate.SelectedDate.Value);
                string status = txtStatus.Text;

                // Kiểm tra nếu tồn tại InputInfo tương ứng với ObjectId
                var inputInfo = InputDAO.Instance.GetByObjectId(objectId);

                if (inputInfo == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin nhập kho cho vật tư đã chọn. Vui lòng kiểm tra lại.");
                    return;
                }

                // Kiểm tra số lượng xuất kho không vượt quá số lượng trong kho
                if (count > inputInfo.Count)
                {
                    MessageBox.Show("Số lượng xuất kho không được lớn hơn số lượng nhập kho hiện có.");
                    return;
                }

                // Tạo mới đối tượng OutputInfo
                var newOutputInfo = new OutputInfo
                {
                    CustomerId = customerId,
                    ObjectId = objectId,
                    InputInfoId = inputInfo.InputInfoId, // Gán InputInfoId từ bản ghi InputInfo tương ứng
                    Count = count,
                    OutputDate = outputDate,
                    Status = status
                };

                // Thêm mới OutputInfo thông qua OutputDAO
                OutputDAO.Instance.Add(newOutputInfo);

                // Cập nhật lại danh sách OutputInfos sau khi thêm mới
                LoadOutputInfos();

                MessageBox.Show("Thêm mới thông tin xuất kho thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }

        // Sửa thông tin OutputInfo
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (selectedOutputInfo != null)
            {
                selectedOutputInfo.CustomerId = (int)cbCustomerName.SelectedValue;
                selectedOutputInfo.ObjectId = (int)cbObjectName.SelectedValue;
                selectedOutputInfo.Count = int.Parse(txtCount.Text);
                selectedOutputInfo.OutputDate = DateOnly.FromDateTime(dpOutputDate.SelectedDate.Value);
                selectedOutputInfo.Status = txtStatus.Text;

                // Cập nhật thông tin OutputInfo, không thay đổi InputPrice và OutputPrice
                OutputDAO.Instance.Update(selectedOutputInfo);
                LoadOutputInfos();
            }
        }

        // Xóa OutputInfo
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (selectedOutputInfo != null)
            {
                OutputDAO.Instance.Delete(selectedOutputInfo.OutputInfoId);
                LoadOutputInfos();
            }
        }
    }
}
