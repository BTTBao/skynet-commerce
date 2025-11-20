namespace WindowsFormsApp11
{
    partial class ucOrder
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label(); // ⭐ thêm
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cbStatusFilter = new System.Windows.Forms.ComboBox();
            this.btnAdvancedFilter = new System.Windows.Forms.Button();
            this.pnlSummary = new System.Windows.Forms.Panel();
            this.lblCanceled = new System.Windows.Forms.Label();
            this.lblCompleted = new System.Windows.Forms.Label();
            this.lblDelivering = new System.Windows.Forms.Label();
            this.lblPending = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.colOrderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlHeader.SuspendLayout();
            this.pnlSummary.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.SuspendLayout();

            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblTitle); // ⭐ thêm
            this.pnlHeader.Controls.Add(this.txtSearch);
            this.pnlHeader.Controls.Add(this.cbStatusFilter);
            this.pnlHeader.Controls.Add(this.btnAdvancedFilter);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Size = new System.Drawing.Size(1000, 90); // tăng chiều cao để chứa header

            // 
            // lblHeader (Header đơn hàng của shop)
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(15, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(183, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Quản lý sản phẩm";

            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.Location = new System.Drawing.Point(20, 50); // xuống dưới header
            this.txtSearch.Size = new System.Drawing.Size(300, 25);
            this.txtSearch.Text = "🔍 Tìm kiếm theo mã đơn hoặc tên khách hàng...";
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);

            // 
            // cbStatusFilter
            // 
            this.cbStatusFilter.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbStatusFilter.FormattingEnabled = true;
            this.cbStatusFilter.Items.AddRange(new object[] {
                "Tất cả trạng thái",
                "Chờ xử lý",
                "Đang giao",
                "Hoàn thành",
                "Đã hủy"});
            this.cbStatusFilter.SelectedIndex = 0;
            this.cbStatusFilter.Location = new System.Drawing.Point(340, 50);
            this.cbStatusFilter.Size = new System.Drawing.Size(180, 25);

            // 
            // btnAdvancedFilter
            // 
            this.btnAdvancedFilter.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnAdvancedFilter.Location = new System.Drawing.Point(540, 50);
            this.btnAdvancedFilter.Size = new System.Drawing.Size(120, 25);
            this.btnAdvancedFilter.Text = "Lọc nâng cao";
            this.btnAdvancedFilter.UseVisualStyleBackColor = true;
            // 
            // pnlSummary
            // 
            this.pnlSummary.BackColor = System.Drawing.Color.White;
            this.pnlSummary.Controls.Add(this.lblCanceled);
            this.pnlSummary.Controls.Add(this.lblCompleted);
            this.pnlSummary.Controls.Add(this.lblDelivering);
            this.pnlSummary.Controls.Add(this.lblPending);
            this.pnlSummary.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSummary.Size = new System.Drawing.Size(1000, 50);
            // 
            // lblPending
            // 
            this.lblPending.AutoSize = true;
            this.lblPending.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPending.ForeColor = System.Drawing.Color.Orange;
            this.lblPending.Location = new System.Drawing.Point(20, 15);
            this.lblPending.Text = "Chờ xử lý: 0";
            // 
            // lblDelivering
            // 
            this.lblDelivering.AutoSize = true;
            this.lblDelivering.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDelivering.ForeColor = System.Drawing.Color.Blue;
            this.lblDelivering.Location = new System.Drawing.Point(150, 15);
            this.lblDelivering.Text = "Đang giao: 0";
            // 
            // lblCompleted
            // 
            this.lblCompleted.AutoSize = true;
            this.lblCompleted.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCompleted.ForeColor = System.Drawing.Color.Green;
            this.lblCompleted.Location = new System.Drawing.Point(280, 15);
            this.lblCompleted.Text = "Hoàn thành: 0";
            // 
            // lblCanceled
            // 
            this.lblCanceled.AutoSize = true;
            this.lblCanceled.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCanceled.ForeColor = System.Drawing.Color.Red;
            this.lblCanceled.Location = new System.Drawing.Point(410, 15);
            this.lblCanceled.Text = "Đã hủy: 0";
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.dgvOrders);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // dgvOrders
            // 
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            this.dgvOrders.AutoGenerateColumns = false;
            this.dgvOrders.BackgroundColor = System.Drawing.Color.White;
            this.dgvOrders.ColumnHeadersHeight = 40;
            this.dgvOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colOrderID,
            this.colCustomer,
            this.colProduct,
            this.colOrderDate,
            this.colTotal,
            this.colStatus,
            this.colAction});
            this.dgvOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrders.RowTemplate.Height = 80;
            this.dgvOrders.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvOrders_CellPainting);
            this.dgvOrders.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrders_CellClick);
            // 
            // Columns
            // 
            this.colOrderID.DataPropertyName = "OrderID";
            this.colOrderID.HeaderText = "Mã đơn";
            this.colCustomer.DataPropertyName = "Customer";
            this.colCustomer.HeaderText = "Khách hàng";
            this.colProduct.DataPropertyName = "Product";
            this.colProduct.HeaderText = "Sản phẩm";
            this.colOrderDate.DataPropertyName = "OrderDate";
            this.colOrderDate.HeaderText = "Ngày đặt";
            this.colTotal.DataPropertyName = "Total";
            this.colTotal.HeaderText = "Tổng tiền";
            this.colStatus.DataPropertyName = "Status";
            this.colStatus.HeaderText = "Trạng thái";
            this.colAction.HeaderText = "Thao tác";
            // 
            // ucOrder
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlSummary);
            this.Controls.Add(this.pnlHeader);
            this.Size = new System.Drawing.Size(1000, 600);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlSummary.ResumeLayout(false);
            this.pnlSummary.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cbStatusFilter;
        private System.Windows.Forms.Button btnAdvancedFilter;
        private System.Windows.Forms.Panel pnlSummary;
        private System.Windows.Forms.Label lblPending;
        private System.Windows.Forms.Label lblDelivering;
        private System.Windows.Forms.Label lblCompleted;
        private System.Windows.Forms.Label lblCanceled;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAction;
    }
}
