namespace B5._4_TREEVIEW___LISTVIEW_
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        // ===== CONTROL DECLARATIONS =====
        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.TreeView tvDepartments;
        private System.Windows.Forms.ListView lsvEmployees;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblViewMode;
        private System.Windows.Forms.ComboBox cboViewMode;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.ImageList imageListSmall;
        private System.Windows.Forms.ImageList imageListLarge;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblCount;
        private System.Windows.Forms.ColumnHeader colId;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colPosition;
        private System.Windows.Forms.ColumnHeader colHireDate;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            // ===== IMAGE LISTS =====
            this.imageListSmall = new System.Windows.Forms.ImageList(this.components);
            this.imageListSmall.ImageSize = new System.Drawing.Size(16, 16);
            this.imageListSmall.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;

            this.imageListLarge = new System.Windows.Forms.ImageList(this.components);
            this.imageListLarge.ImageSize = new System.Drawing.Size(32, 32);
            this.imageListLarge.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;

            // ===== SPLIT CONTAINER =====
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.splitMain.SplitterDistance = 320;
            this.splitMain.SplitterWidth = 6;
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            this.Controls.Add(this.splitMain);

            // ===== TREE VIEW (Panel1) =====
            this.tvDepartments = new System.Windows.Forms.TreeView();
            this.tvDepartments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvDepartments.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tvDepartments.ImageList = this.imageListSmall;
            this.tvDepartments.ShowLines = true;
            this.tvDepartments.ShowPlusMinus = true;
            this.tvDepartments.ShowRootLines = true;
            this.tvDepartments.HideSelection = false;
            this.splitMain.Panel1.Controls.Add(this.tvDepartments);

            // ===== PANEL TOP (Panel2) =====
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Height = 45;
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.splitMain.Panel2.Controls.Add(this.panelTop);

            this.lblViewMode = new System.Windows.Forms.Label();
            this.lblViewMode.Text = "Chế độ xem:";
            this.lblViewMode.Location = new System.Drawing.Point(10, 13);
            this.lblViewMode.AutoSize = true;
            this.lblViewMode.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.panelTop.Controls.Add(this.lblViewMode);

            this.cboViewMode = new System.Windows.Forms.ComboBox();
            this.cboViewMode.Location = new System.Drawing.Point(110, 10);
            this.cboViewMode.Size = new System.Drawing.Size(160, 30);
            this.cboViewMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboViewMode.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.panelTop.Controls.Add(this.cboViewMode);

            this.lblPath = new System.Windows.Forms.Label();
            this.lblPath.Text = "";
            this.lblPath.Location = new System.Drawing.Point(290, 13);
            this.lblPath.AutoSize = true;
            this.lblPath.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblPath.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.panelTop.Controls.Add(this.lblPath);

            // ===== LIST VIEW (Panel2 fill) =====
            this.lsvEmployees = new System.Windows.Forms.ListView();
            this.lsvEmployees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvEmployees.View = System.Windows.Forms.View.Details;
            this.lsvEmployees.FullRowSelect = true;
            this.lsvEmployees.GridLines = true;
            this.lsvEmployees.MultiSelect = false;
            this.lsvEmployees.SmallImageList = this.imageListSmall;
            this.lsvEmployees.LargeImageList = this.imageListLarge;
            this.lsvEmployees.Font = new System.Drawing.Font("Segoe UI", 10F);

            this.colId = new System.Windows.Forms.ColumnHeader();
            this.colId.Text = "Mã NV";
            this.colId.Width = 100;

            this.colName = new System.Windows.Forms.ColumnHeader();
            this.colName.Text = "Họ Tên";
            this.colName.Width = 220;

            this.colPosition = new System.Windows.Forms.ColumnHeader();
            this.colPosition.Text = "Chức vụ";
            this.colPosition.Width = 180;

            this.colHireDate = new System.Windows.Forms.ColumnHeader();
            this.colHireDate.Text = "Ngày vào làm";
            this.colHireDate.Width = 140;

            this.lsvEmployees.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                this.colId, this.colName, this.colPosition, this.colHireDate
            });
            this.splitMain.Panel2.Controls.Add(this.lsvEmployees);

            // ===== STATUS STRIP =====
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusStrip.BackColor = System.Drawing.Color.FromArgb(230, 240, 250);

            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatus.Text = "Sẵn sàng";

            this.lblCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCount.Text = "0 nhân viên";
            this.lblCount.Spring = true;
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCount.ForeColor = System.Drawing.Color.DarkRed;

            this.statusStrip.Items.Add(this.lblStatus);
            this.statusStrip.Items.Add(this.lblCount);
            this.Controls.Add(this.statusStrip);

            // ===== FORM =====
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 680);
            this.Text = "B5.4 TreeView & ListView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Font = new System.Drawing.Font("Segoe UI", 10F);

            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            this.splitMain.ResumeLayout(false);
        }
    }
}
