#nullable disable
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace B5._4_TREEVIEW___LISTVIEW_
{
    public partial class Form1 : Form
    {
        private readonly List<Employee> _allEmployees = new List<Employee>();
        private readonly Dictionary<string, List<Employee>> _employeesByNode = new Dictionary<string, List<Employee>>();

        public Form1()
        {
            InitializeComponent();

            this.Load += Form1_Load;
            tvDepartments.AfterSelect += TvDepartments_AfterSelect;
            cboViewMode.SelectedIndexChanged += CboViewMode_SelectedIndexChanged;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateIcons();
            LoadSampleData();
            BuildTree();
            SetupViewModeCombo();
            lsvEmployees.View = View.Details;
            lblStatus.Text = "Nhấn vào Node trên cây để xem nhân viên";

            // Ensure a node is selected after building the tree so the ListView is populated
            if (tvDepartments.Nodes.Count > 0)
                tvDepartments.SelectedNode = tvDepartments.Nodes[0];
        }

        private void CreateIcons()
        {
            // 16x16 icons
            imageListSmall.Images.Clear();
            imageListSmall.Images.Add("company", DrawIcon(Color.DarkBlue, "🏢", 16));
            imageListSmall.Images.Add("department", DrawIcon(Color.DarkGreen, "📁", 16));
            imageListSmall.Images.Add("group", DrawIcon(Color.Orange, "👥", 16));
            imageListSmall.Images.Add("employee", DrawIcon(Color.DarkRed, "👤", 16));

            // 32x32 icons
            imageListLarge.Images.Clear();
            imageListLarge.Images.Add("employee", DrawIcon(Color.DarkRed, "👤", 32));
            imageListLarge.Images.Add("company", DrawIcon(Color.DarkBlue, "🏢", 32));
        }

        private Image DrawIcon(Color color, string emoji, int size)
        {
            Bitmap bmp = new Bitmap(size, size);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.Clear(Color.Transparent);
                using (Font f = new Font("Segoe UI Emoji", size * 0.7f, GraphicsUnit.Pixel))
                using (SolidBrush b = new SolidBrush(color))
                using (StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                {
                    g.DrawString(emoji, f, b, new RectangleF(0, 0, size, size), sf);
                }
            }
            return bmp;
        }

        private void LoadSampleData()
        {
            _allEmployees.AddRange(new[]
            {
                new Employee { Id = "NV001", FullName = "Nguyễn Văn An",    
                    Position = "Giám đốc",         HireDate = new DateTime(2015, 3, 1),
                    GroupPath = "Công ty" },
                new Employee { Id = "NV002", FullName = "Trần Thị Bình",   
                    Position = "Trưởng phòng KD",  HireDate = new DateTime(2017, 6, 15),
                    GroupPath = "Công ty|Khối Kinh Doanh" },
                new Employee { Id = "NV003", FullName = "Lê Hoàng Cường",  
                    Position = "Nhân viên KD",     HireDate = new DateTime(2019, 8, 20),
                    GroupPath = "Công ty|Khối Kinh Doanh|KD Miền Bắc" },
                new Employee { Id = "NV004", FullName = "Phạm Thu Dung",   
                    Position = "Nhân viên KD",     HireDate = new DateTime(2020, 1, 5),
                    GroupPath = "Công ty|Khối Kinh Doanh|KD Miền Bắc" },
                new Employee { Id = "NV005", FullName = "Vũ Minh Đức",     
                    Position = "Nhân viên KD",     HireDate = new DateTime(2021, 4, 12),
                    GroupPath = "Công ty|Khối Kinh Doanh|KD Miền Nam" },
                new Employee { Id = "NV006", FullName = "Hoàng Thị Em",    
                    Position = "Trưởng phòng KT",  HireDate = new DateTime(2016, 9, 1),
                    GroupPath = "Công ty|Khối Kỹ Thuật" },
                new Employee { Id = "NV007", FullName = "Đỗ Văn Phúc",     
                    Position = "Lập trình viên",   HireDate = new DateTime(2018, 11, 25),
                    GroupPath = "Công ty|Khối Kỹ Thuật|Dev Team" },
                new Employee { Id = "NV008", FullName = "Ngô Thị Giang",   
                    Position = "Tester",           HireDate = new DateTime(2020, 7, 10),
                    GroupPath = "Công ty|Khối Kỹ Thuật|Dev Team" },
                new Employee { Id = "NV009", FullName = "Bùi Quang Hải",   
                    Position = "DevOps",           HireDate = new DateTime(2022, 2, 14),
                    GroupPath = "Công ty|Khối Kỹ Thuật|Dev Team" },
                new Employee { Id = "NV010", FullName = "Lý Thị Inh",      
                    Position = "Kế toán",          HireDate = new DateTime(2019, 5, 3),
                    GroupPath = "Công ty|Khối Hành Chính" },
                new Employee { Id = "NV011", FullName = "Trịnh Văn Khoa",  
                    Position = "Nhân sự",          HireDate = new DateTime(2021, 8, 9),
                    GroupPath = "Công ty|Khối Hành Chính" },
            });
        }

        private void BuildTree()
        {
            tvDepartments.BeginUpdate();
            tvDepartments.Nodes.Clear();

            // Root node
            TreeNode root = new TreeNode("Công ty ABC") { ImageKey = "company", SelectedImageKey = "company" };
            root.Tag = "Công ty";
            tvDepartments.Nodes.Add(root);

            // Khối Kinh Doanh
            TreeNode kd = new TreeNode("Khối Kinh Doanh") { ImageKey = "department", SelectedImageKey = "department" };
            kd.Tag = "Công ty|Khối Kinh Doanh";
            kd.Nodes.Add(new TreeNode("KD Miền Bắc") { ImageKey = "group", SelectedImageKey = "group", Tag = "Công ty|Khối Kinh Doanh|KD Miền Bắc" });
            kd.Nodes.Add(new TreeNode("KD Miền Nam") { ImageKey = "group", SelectedImageKey = "group", Tag = "Công ty|Khối Kinh Doanh|KD Miền Nam" });
            root.Nodes.Add(kd);

            // Khối Kỹ Thuật
            TreeNode kt = new TreeNode("Khối Kỹ Thuật") { ImageKey = "department", SelectedImageKey = "department" };
            kt.Tag = "Công ty|Khối Kỹ Thuật";
            kt.Nodes.Add(new TreeNode("Dev Team") { ImageKey = "group", SelectedImageKey = "group", Tag = "Công ty|Khối Kỹ Thuật|Dev Team" });
            root.Nodes.Add(kt);

            // Khối Hành Chính
            TreeNode hc = new TreeNode("Khối Hành Chính") { ImageKey = "department", SelectedImageKey = "department" };
            hc.Tag = "Công ty|Khối Hành Chính";
            root.Nodes.Add(hc);

            tvDepartments.EndUpdate();
        }

        private void PopulateListView(List<Employee> list)
        {
            lsvEmployees.BeginUpdate();
            lsvEmployees.Items.Clear();

            foreach (var emp in list)
            {
                ListViewItem item = new ListViewItem(emp.Id) { ImageKey = "employee" };
                item.SubItems.Add(emp.FullName);
                item.SubItems.Add(emp.Position);
                item.SubItems.Add(emp.HireDate.ToShortDateString());
                lsvEmployees.Items.Add(item);
            }

            lsvEmployees.EndUpdate();
        }

        private void SetupViewModeCombo()
        {
            cboViewMode.Items.Clear();
            cboViewMode.Items.AddRange(new object[] { "Details", "Large Icon", "Small Icon", "List", "Tile" });
            cboViewMode.SelectedIndex = 0;
        }

        private void CboViewMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboViewMode.SelectedIndex)
            {
                case 0: lsvEmployees.View = View.Details; break;
                case 1: lsvEmployees.View = View.LargeIcon; break;
                case 2: lsvEmployees.View = View.SmallIcon; break;
                case 3: lsvEmployees.View = View.List; break;
                case 4: lsvEmployees.View = View.Tile; break;
            }
        }

        private void TvDepartments_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null) return;

            // ★ KEY FIX: use Tag (real path key) instead of FullPath (display text)
            string nodeKey = e.Node.Tag as string ?? "";
            if (string.IsNullOrEmpty(nodeKey)) return;

            // Update path label with the FULL path (cosmetic)
            lblPath.Text = "📂 " + e.Node.FullPath;

            // Filter: exact match OR descendant of nodeKey
            List<Employee> matches = _allEmployees
                .Where(emp => emp.GroupPath == nodeKey
                           || emp.GroupPath.StartsWith(nodeKey + "|"))
                .ToList();

            PopulateListView(matches);

            lblCount.Text = $"{matches.Count} nhân viên";
            lblStatus.Text = $"Đang xem: {e.Node.Text} ({matches.Count} nhân viên)";
        }
    }
}
