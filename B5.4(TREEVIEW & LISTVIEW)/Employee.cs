namespace B5._4_TREEVIEW___LISTVIEW_
{
    public class Employee
    {
        public string Id { get; set; }            // Mã NV
        public string FullName { get; set; }      // Họ tên
        public string Position { get; set; }      // Chức vụ
        public DateTime HireDate { get; set; }    // Ngày vào làm
        public string GroupPath { get; set; }     // Đường dẫn nhóm: "Công ty|Khối KD|KD Miền Bắc"
    }
}
