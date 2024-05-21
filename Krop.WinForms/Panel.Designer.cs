namespace Krop.WinForms
{
    partial class Panel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Panel));
            tabControl1 = new TabControl();
            HomeTabPage = new TabPage();
            homeBttnExit = new Button();
            button1 = new Button();
            StocksTabPage = new TabPage();
            stockBttnTransfer = new Button();
            stockBttnReceipt = new Button();
            ProductionTabPage = new TabPage();
            productionBttnProduce = new Button();
            productionBttnList = new Button();
            ProductsTabPage = new TabPage();
            productBttnRecipe = new Button();
            productBttnCategoryAdd = new Button();
            productBttnDelete = new Button();
            productBttnUpdate = new Button();
            productBttnAdd = new Button();
            productBttnCard = new Button();
            productBttnList = new Button();
            CategoriesTabPage = new TabPage();
            categoryBttnDelete = new Button();
            categoryBttnUpdate = new Button();
            categoryBttnAdd = new Button();
            categoryBttnCard = new Button();
            categoryBttnList = new Button();
            CustomersTabPage = new TabPage();
            customerBttnOrders = new Button();
            customerBttnDelete = new Button();
            customerBttnUpdate = new Button();
            customerBttnAdd = new Button();
            customerBttnCard = new Button();
            customerBttnList = new Button();
            SuppliersTabPage = new TabPage();
            supplierBttnSupplierHistory = new Button();
            supplierBttnDelete = new Button();
            supplierBttnUpdate = new Button();
            supplierBttnAdd = new Button();
            supplierBttnCard = new Button();
            supplierBttnList = new Button();
            EmployeesTabPage = new TabPage();
            employeeBttnDelete = new Button();
            employeeBttnUpdate = new Button();
            employeeBttnAdd = new Button();
            employeeBttnCard = new Button();
            employeeBttnList = new Button();
            UsersTabPage = new TabPage();
            userBttnUpdate = new Button();
            userBttnAdd = new Button();
            userBttnCard = new Button();
            userBttnList = new Button();
            SettingsTabPage = new TabPage();
            ExitPageTab = new TabPage();
            panelBottom = new System.Windows.Forms.Panel();
            lblDate = new Label();
            lblUserName = new Label();
            lblWarehoseName = new Label();
            lblDatabaseName = new Label();
            lblServerName = new Label();
            lblCompanyName = new Label();
            panel1 = new System.Windows.Forms.Panel();
            BrandPage = new TabPage();
            bttnBrandDelete = new Button();
            bttnBrandUpdate = new Button();
            bttnBrandAdd = new Button();
            bttnBrandCart = new Button();
            bttnBrandList = new Button();
            AppUserRolePage = new TabPage();
            bttnAppUserRoleDelete = new Button();
            bttnAppUserRoleUpdate = new Button();
            bttnAppUserRoleAdd = new Button();
            bttnAppUserRoleCart = new Button();
            bttnAppUserRoleList = new Button();
            tabControl1.SuspendLayout();
            HomeTabPage.SuspendLayout();
            StocksTabPage.SuspendLayout();
            ProductionTabPage.SuspendLayout();
            ProductsTabPage.SuspendLayout();
            CategoriesTabPage.SuspendLayout();
            CustomersTabPage.SuspendLayout();
            SuppliersTabPage.SuspendLayout();
            EmployeesTabPage.SuspendLayout();
            UsersTabPage.SuspendLayout();
            panelBottom.SuspendLayout();
            BrandPage.SuspendLayout();
            AppUserRolePage.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(HomeTabPage);
            tabControl1.Controls.Add(StocksTabPage);
            tabControl1.Controls.Add(ProductionTabPage);
            tabControl1.Controls.Add(ProductsTabPage);
            tabControl1.Controls.Add(CategoriesTabPage);
            tabControl1.Controls.Add(BrandPage);
            tabControl1.Controls.Add(CustomersTabPage);
            tabControl1.Controls.Add(SuppliersTabPage);
            tabControl1.Controls.Add(EmployeesTabPage);
            tabControl1.Controls.Add(UsersTabPage);
            tabControl1.Controls.Add(AppUserRolePage);
            tabControl1.Controls.Add(SettingsTabPage);
            tabControl1.Controls.Add(ExitPageTab);
            tabControl1.Dock = DockStyle.Top;
            tabControl1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1884, 95);
            tabControl1.TabIndex = 0;
            // 
            // HomeTabPage
            // 
            HomeTabPage.BackColor = Color.Transparent;
            HomeTabPage.Controls.Add(homeBttnExit);
            HomeTabPage.Controls.Add(button1);
            HomeTabPage.Location = new Point(4, 24);
            HomeTabPage.Name = "HomeTabPage";
            HomeTabPage.Padding = new Padding(3);
            HomeTabPage.Size = new Size(1876, 67);
            HomeTabPage.TabIndex = 0;
            HomeTabPage.Text = "Ana Sayfa";
            // 
            // homeBttnExit
            // 
            homeBttnExit.BackColor = SystemColors.ButtonFace;
            homeBttnExit.Dock = DockStyle.Right;
            homeBttnExit.FlatAppearance.BorderColor = Color.White;
            homeBttnExit.FlatAppearance.BorderSize = 0;
            homeBttnExit.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            homeBttnExit.FlatStyle = FlatStyle.Flat;
            homeBttnExit.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            homeBttnExit.Image = (Image)resources.GetObject("homeBttnExit.Image");
            homeBttnExit.Location = new Point(1803, 3);
            homeBttnExit.Name = "homeBttnExit";
            homeBttnExit.Size = new Size(70, 61);
            homeBttnExit.TabIndex = 1;
            homeBttnExit.Text = "Çıkış";
            homeBttnExit.TextImageRelation = TextImageRelation.ImageAboveText;
            homeBttnExit.UseVisualStyleBackColor = false;
            homeBttnExit.Click += homeBttnExit_Click;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ButtonFace;
            button1.Dock = DockStyle.Left;
            button1.FlatAppearance.BorderColor = Color.White;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.Location = new Point(3, 3);
            button1.Name = "button1";
            button1.Size = new Size(70, 61);
            button1.TabIndex = 0;
            button1.Text = "Liste";
            button1.TextImageRelation = TextImageRelation.ImageAboveText;
            button1.UseVisualStyleBackColor = false;
            // 
            // StocksTabPage
            // 
            StocksTabPage.Controls.Add(stockBttnTransfer);
            StocksTabPage.Controls.Add(stockBttnReceipt);
            StocksTabPage.Location = new Point(4, 24);
            StocksTabPage.Name = "StocksTabPage";
            StocksTabPage.Size = new Size(1876, 67);
            StocksTabPage.TabIndex = 2;
            StocksTabPage.Text = "Stoklar";
            StocksTabPage.UseVisualStyleBackColor = true;
            // 
            // stockBttnTransfer
            // 
            stockBttnTransfer.BackColor = Color.Transparent;
            stockBttnTransfer.Dock = DockStyle.Left;
            stockBttnTransfer.FlatAppearance.BorderColor = Color.White;
            stockBttnTransfer.FlatAppearance.BorderSize = 0;
            stockBttnTransfer.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            stockBttnTransfer.FlatStyle = FlatStyle.Flat;
            stockBttnTransfer.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            stockBttnTransfer.Image = (Image)resources.GetObject("stockBttnTransfer.Image");
            stockBttnTransfer.Location = new Point(84, 0);
            stockBttnTransfer.Name = "stockBttnTransfer";
            stockBttnTransfer.Size = new Size(70, 67);
            stockBttnTransfer.TabIndex = 12;
            stockBttnTransfer.Text = "Transfer";
            stockBttnTransfer.TextImageRelation = TextImageRelation.ImageAboveText;
            stockBttnTransfer.UseVisualStyleBackColor = false;
            // 
            // stockBttnReceipt
            // 
            stockBttnReceipt.BackColor = Color.Transparent;
            stockBttnReceipt.Dock = DockStyle.Left;
            stockBttnReceipt.FlatAppearance.BorderColor = Color.White;
            stockBttnReceipt.FlatAppearance.BorderSize = 0;
            stockBttnReceipt.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            stockBttnReceipt.FlatStyle = FlatStyle.Flat;
            stockBttnReceipt.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            stockBttnReceipt.Image = (Image)resources.GetObject("stockBttnReceipt.Image");
            stockBttnReceipt.Location = new Point(0, 0);
            stockBttnReceipt.Name = "stockBttnReceipt";
            stockBttnReceipt.Size = new Size(84, 67);
            stockBttnReceipt.TabIndex = 11;
            stockBttnReceipt.Text = "Giriş";
            stockBttnReceipt.TextImageRelation = TextImageRelation.ImageAboveText;
            stockBttnReceipt.UseVisualStyleBackColor = false;
            // 
            // ProductionTabPage
            // 
            ProductionTabPage.Controls.Add(productionBttnProduce);
            ProductionTabPage.Controls.Add(productionBttnList);
            ProductionTabPage.Location = new Point(4, 24);
            ProductionTabPage.Name = "ProductionTabPage";
            ProductionTabPage.Size = new Size(1876, 67);
            ProductionTabPage.TabIndex = 9;
            ProductionTabPage.Text = "Üretim";
            ProductionTabPage.UseVisualStyleBackColor = true;
            // 
            // productionBttnProduce
            // 
            productionBttnProduce.BackColor = Color.Transparent;
            productionBttnProduce.Dock = DockStyle.Left;
            productionBttnProduce.FlatAppearance.BorderColor = Color.White;
            productionBttnProduce.FlatAppearance.BorderSize = 0;
            productionBttnProduce.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            productionBttnProduce.FlatStyle = FlatStyle.Flat;
            productionBttnProduce.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            productionBttnProduce.Image = (Image)resources.GetObject("productionBttnProduce.Image");
            productionBttnProduce.Location = new Point(70, 0);
            productionBttnProduce.Name = "productionBttnProduce";
            productionBttnProduce.Size = new Size(80, 67);
            productionBttnProduce.TabIndex = 10;
            productionBttnProduce.Text = "Ürün Üret";
            productionBttnProduce.TextImageRelation = TextImageRelation.ImageAboveText;
            productionBttnProduce.UseVisualStyleBackColor = false;
            // 
            // productionBttnList
            // 
            productionBttnList.BackColor = Color.Transparent;
            productionBttnList.Dock = DockStyle.Left;
            productionBttnList.FlatAppearance.BorderColor = Color.White;
            productionBttnList.FlatAppearance.BorderSize = 0;
            productionBttnList.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            productionBttnList.FlatStyle = FlatStyle.Flat;
            productionBttnList.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            productionBttnList.Image = (Image)resources.GetObject("productionBttnList.Image");
            productionBttnList.Location = new Point(0, 0);
            productionBttnList.Name = "productionBttnList";
            productionBttnList.Size = new Size(70, 67);
            productionBttnList.TabIndex = 9;
            productionBttnList.Text = "Liste";
            productionBttnList.TextImageRelation = TextImageRelation.ImageAboveText;
            productionBttnList.UseVisualStyleBackColor = false;
            // 
            // ProductsTabPage
            // 
            ProductsTabPage.Controls.Add(productBttnRecipe);
            ProductsTabPage.Controls.Add(productBttnCategoryAdd);
            ProductsTabPage.Controls.Add(productBttnDelete);
            ProductsTabPage.Controls.Add(productBttnUpdate);
            ProductsTabPage.Controls.Add(productBttnAdd);
            ProductsTabPage.Controls.Add(productBttnCard);
            ProductsTabPage.Controls.Add(productBttnList);
            ProductsTabPage.Location = new Point(4, 24);
            ProductsTabPage.Name = "ProductsTabPage";
            ProductsTabPage.Padding = new Padding(3);
            ProductsTabPage.Size = new Size(1876, 67);
            ProductsTabPage.TabIndex = 1;
            ProductsTabPage.Text = "Ürünler";
            ProductsTabPage.UseVisualStyleBackColor = true;
            // 
            // productBttnRecipe
            // 
            productBttnRecipe.BackColor = Color.Transparent;
            productBttnRecipe.Dock = DockStyle.Left;
            productBttnRecipe.FlatAppearance.BorderColor = Color.White;
            productBttnRecipe.FlatAppearance.BorderSize = 0;
            productBttnRecipe.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            productBttnRecipe.FlatStyle = FlatStyle.Flat;
            productBttnRecipe.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            productBttnRecipe.Image = (Image)resources.GetObject("productBttnRecipe.Image");
            productBttnRecipe.Location = new Point(517, 3);
            productBttnRecipe.Name = "productBttnRecipe";
            productBttnRecipe.Size = new Size(117, 61);
            productBttnRecipe.TabIndex = 10;
            productBttnRecipe.Text = "Ürün Reçetesi";
            productBttnRecipe.TextImageRelation = TextImageRelation.ImageAboveText;
            productBttnRecipe.UseVisualStyleBackColor = false;
            // 
            // productBttnCategoryAdd
            // 
            productBttnCategoryAdd.BackColor = Color.Transparent;
            productBttnCategoryAdd.Dock = DockStyle.Left;
            productBttnCategoryAdd.FlatAppearance.BorderColor = Color.White;
            productBttnCategoryAdd.FlatAppearance.BorderSize = 0;
            productBttnCategoryAdd.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            productBttnCategoryAdd.FlatStyle = FlatStyle.Flat;
            productBttnCategoryAdd.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            productBttnCategoryAdd.Image = (Image)resources.GetObject("productBttnCategoryAdd.Image");
            productBttnCategoryAdd.Location = new Point(400, 3);
            productBttnCategoryAdd.Name = "productBttnCategoryAdd";
            productBttnCategoryAdd.Size = new Size(117, 61);
            productBttnCategoryAdd.TabIndex = 9;
            productBttnCategoryAdd.Text = "Kategori Ataması";
            productBttnCategoryAdd.TextImageRelation = TextImageRelation.ImageAboveText;
            productBttnCategoryAdd.UseVisualStyleBackColor = false;
            // 
            // productBttnDelete
            // 
            productBttnDelete.BackColor = Color.Transparent;
            productBttnDelete.Dock = DockStyle.Left;
            productBttnDelete.FlatAppearance.BorderColor = Color.White;
            productBttnDelete.FlatAppearance.BorderSize = 0;
            productBttnDelete.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            productBttnDelete.FlatStyle = FlatStyle.Flat;
            productBttnDelete.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            productBttnDelete.Image = (Image)resources.GetObject("productBttnDelete.Image");
            productBttnDelete.Location = new Point(330, 3);
            productBttnDelete.Name = "productBttnDelete";
            productBttnDelete.Size = new Size(70, 61);
            productBttnDelete.TabIndex = 8;
            productBttnDelete.Text = "Sil";
            productBttnDelete.TextImageRelation = TextImageRelation.ImageAboveText;
            productBttnDelete.UseVisualStyleBackColor = false;
            // 
            // productBttnUpdate
            // 
            productBttnUpdate.BackColor = Color.Transparent;
            productBttnUpdate.Dock = DockStyle.Left;
            productBttnUpdate.FlatAppearance.BorderColor = Color.White;
            productBttnUpdate.FlatAppearance.BorderSize = 0;
            productBttnUpdate.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            productBttnUpdate.FlatStyle = FlatStyle.Flat;
            productBttnUpdate.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            productBttnUpdate.Image = (Image)resources.GetObject("productBttnUpdate.Image");
            productBttnUpdate.Location = new Point(260, 3);
            productBttnUpdate.Name = "productBttnUpdate";
            productBttnUpdate.Size = new Size(70, 61);
            productBttnUpdate.TabIndex = 7;
            productBttnUpdate.Text = "Güncelle";
            productBttnUpdate.TextImageRelation = TextImageRelation.ImageAboveText;
            productBttnUpdate.UseVisualStyleBackColor = false;
            // 
            // productBttnAdd
            // 
            productBttnAdd.BackColor = Color.Transparent;
            productBttnAdd.Dock = DockStyle.Left;
            productBttnAdd.FlatAppearance.BorderColor = Color.White;
            productBttnAdd.FlatAppearance.BorderSize = 0;
            productBttnAdd.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            productBttnAdd.FlatStyle = FlatStyle.Flat;
            productBttnAdd.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            productBttnAdd.Image = (Image)resources.GetObject("productBttnAdd.Image");
            productBttnAdd.Location = new Point(190, 3);
            productBttnAdd.Name = "productBttnAdd";
            productBttnAdd.Size = new Size(70, 61);
            productBttnAdd.TabIndex = 6;
            productBttnAdd.Text = "Ekle";
            productBttnAdd.TextImageRelation = TextImageRelation.ImageAboveText;
            productBttnAdd.UseVisualStyleBackColor = false;
            // 
            // productBttnCard
            // 
            productBttnCard.BackColor = Color.Transparent;
            productBttnCard.Dock = DockStyle.Left;
            productBttnCard.FlatAppearance.BorderColor = Color.White;
            productBttnCard.FlatAppearance.BorderSize = 0;
            productBttnCard.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            productBttnCard.FlatStyle = FlatStyle.Flat;
            productBttnCard.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            productBttnCard.Image = (Image)resources.GetObject("productBttnCard.Image");
            productBttnCard.Location = new Point(73, 3);
            productBttnCard.Name = "productBttnCard";
            productBttnCard.Size = new Size(117, 61);
            productBttnCard.TabIndex = 11;
            productBttnCard.Text = "Ürün Kartı";
            productBttnCard.TextImageRelation = TextImageRelation.ImageAboveText;
            productBttnCard.UseVisualStyleBackColor = false;
            // 
            // productBttnList
            // 
            productBttnList.BackColor = Color.Transparent;
            productBttnList.Dock = DockStyle.Left;
            productBttnList.FlatAppearance.BorderColor = Color.White;
            productBttnList.FlatAppearance.BorderSize = 0;
            productBttnList.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            productBttnList.FlatStyle = FlatStyle.Flat;
            productBttnList.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            productBttnList.Image = (Image)resources.GetObject("productBttnList.Image");
            productBttnList.Location = new Point(3, 3);
            productBttnList.Name = "productBttnList";
            productBttnList.Size = new Size(70, 61);
            productBttnList.TabIndex = 5;
            productBttnList.Text = "Liste";
            productBttnList.TextImageRelation = TextImageRelation.ImageAboveText;
            productBttnList.UseVisualStyleBackColor = false;
            productBttnList.Click += productBttnList_Click;
            // 
            // CategoriesTabPage
            // 
            CategoriesTabPage.Controls.Add(categoryBttnDelete);
            CategoriesTabPage.Controls.Add(categoryBttnUpdate);
            CategoriesTabPage.Controls.Add(categoryBttnAdd);
            CategoriesTabPage.Controls.Add(categoryBttnCard);
            CategoriesTabPage.Controls.Add(categoryBttnList);
            CategoriesTabPage.Location = new Point(4, 24);
            CategoriesTabPage.Name = "CategoriesTabPage";
            CategoriesTabPage.Size = new Size(1876, 67);
            CategoriesTabPage.TabIndex = 3;
            CategoriesTabPage.Text = "Kategoriler";
            CategoriesTabPage.UseVisualStyleBackColor = true;
            // 
            // categoryBttnDelete
            // 
            categoryBttnDelete.BackColor = Color.Transparent;
            categoryBttnDelete.Dock = DockStyle.Left;
            categoryBttnDelete.FlatAppearance.BorderColor = Color.White;
            categoryBttnDelete.FlatAppearance.BorderSize = 0;
            categoryBttnDelete.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            categoryBttnDelete.FlatStyle = FlatStyle.Flat;
            categoryBttnDelete.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            categoryBttnDelete.Image = (Image)resources.GetObject("categoryBttnDelete.Image");
            categoryBttnDelete.Location = new Point(327, 0);
            categoryBttnDelete.Name = "categoryBttnDelete";
            categoryBttnDelete.Size = new Size(70, 67);
            categoryBttnDelete.TabIndex = 15;
            categoryBttnDelete.Text = "Sil";
            categoryBttnDelete.TextImageRelation = TextImageRelation.ImageAboveText;
            categoryBttnDelete.UseVisualStyleBackColor = false;
            // 
            // categoryBttnUpdate
            // 
            categoryBttnUpdate.BackColor = Color.Transparent;
            categoryBttnUpdate.Dock = DockStyle.Left;
            categoryBttnUpdate.FlatAppearance.BorderColor = Color.White;
            categoryBttnUpdate.FlatAppearance.BorderSize = 0;
            categoryBttnUpdate.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            categoryBttnUpdate.FlatStyle = FlatStyle.Flat;
            categoryBttnUpdate.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            categoryBttnUpdate.Image = (Image)resources.GetObject("categoryBttnUpdate.Image");
            categoryBttnUpdate.Location = new Point(257, 0);
            categoryBttnUpdate.Name = "categoryBttnUpdate";
            categoryBttnUpdate.Size = new Size(70, 67);
            categoryBttnUpdate.TabIndex = 14;
            categoryBttnUpdate.Text = "Güncelle";
            categoryBttnUpdate.TextImageRelation = TextImageRelation.ImageAboveText;
            categoryBttnUpdate.UseVisualStyleBackColor = false;
            // 
            // categoryBttnAdd
            // 
            categoryBttnAdd.BackColor = Color.Transparent;
            categoryBttnAdd.Dock = DockStyle.Left;
            categoryBttnAdd.FlatAppearance.BorderColor = Color.White;
            categoryBttnAdd.FlatAppearance.BorderSize = 0;
            categoryBttnAdd.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            categoryBttnAdd.FlatStyle = FlatStyle.Flat;
            categoryBttnAdd.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            categoryBttnAdd.Image = (Image)resources.GetObject("categoryBttnAdd.Image");
            categoryBttnAdd.Location = new Point(187, 0);
            categoryBttnAdd.Name = "categoryBttnAdd";
            categoryBttnAdd.Size = new Size(70, 67);
            categoryBttnAdd.TabIndex = 13;
            categoryBttnAdd.Text = "Ekle";
            categoryBttnAdd.TextImageRelation = TextImageRelation.ImageAboveText;
            categoryBttnAdd.UseVisualStyleBackColor = false;
            categoryBttnAdd.Click += categoryBttnAdd_Click;
            // 
            // categoryBttnCard
            // 
            categoryBttnCard.BackColor = Color.Transparent;
            categoryBttnCard.Dock = DockStyle.Left;
            categoryBttnCard.FlatAppearance.BorderColor = Color.White;
            categoryBttnCard.FlatAppearance.BorderSize = 0;
            categoryBttnCard.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            categoryBttnCard.FlatStyle = FlatStyle.Flat;
            categoryBttnCard.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            categoryBttnCard.Image = (Image)resources.GetObject("categoryBttnCard.Image");
            categoryBttnCard.Location = new Point(70, 0);
            categoryBttnCard.Name = "categoryBttnCard";
            categoryBttnCard.Size = new Size(117, 67);
            categoryBttnCard.TabIndex = 16;
            categoryBttnCard.Text = "Kategori Kartı";
            categoryBttnCard.TextImageRelation = TextImageRelation.ImageAboveText;
            categoryBttnCard.UseVisualStyleBackColor = false;
            // 
            // categoryBttnList
            // 
            categoryBttnList.BackColor = Color.Transparent;
            categoryBttnList.Dock = DockStyle.Left;
            categoryBttnList.FlatAppearance.BorderColor = Color.White;
            categoryBttnList.FlatAppearance.BorderSize = 0;
            categoryBttnList.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            categoryBttnList.FlatStyle = FlatStyle.Flat;
            categoryBttnList.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            categoryBttnList.Image = (Image)resources.GetObject("categoryBttnList.Image");
            categoryBttnList.Location = new Point(0, 0);
            categoryBttnList.Name = "categoryBttnList";
            categoryBttnList.Size = new Size(70, 67);
            categoryBttnList.TabIndex = 12;
            categoryBttnList.Text = "Liste";
            categoryBttnList.TextImageRelation = TextImageRelation.ImageAboveText;
            categoryBttnList.UseVisualStyleBackColor = false;
            // 
            // CustomersTabPage
            // 
            CustomersTabPage.Controls.Add(customerBttnOrders);
            CustomersTabPage.Controls.Add(customerBttnDelete);
            CustomersTabPage.Controls.Add(customerBttnUpdate);
            CustomersTabPage.Controls.Add(customerBttnAdd);
            CustomersTabPage.Controls.Add(customerBttnCard);
            CustomersTabPage.Controls.Add(customerBttnList);
            CustomersTabPage.Location = new Point(4, 24);
            CustomersTabPage.Name = "CustomersTabPage";
            CustomersTabPage.Size = new Size(1876, 67);
            CustomersTabPage.TabIndex = 4;
            CustomersTabPage.Text = "Müşteriler";
            CustomersTabPage.UseVisualStyleBackColor = true;
            // 
            // customerBttnOrders
            // 
            customerBttnOrders.BackColor = Color.Transparent;
            customerBttnOrders.Dock = DockStyle.Left;
            customerBttnOrders.FlatAppearance.BorderColor = Color.White;
            customerBttnOrders.FlatAppearance.BorderSize = 0;
            customerBttnOrders.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            customerBttnOrders.FlatStyle = FlatStyle.Flat;
            customerBttnOrders.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            customerBttnOrders.Image = (Image)resources.GetObject("customerBttnOrders.Image");
            customerBttnOrders.Location = new Point(397, 0);
            customerBttnOrders.Name = "customerBttnOrders";
            customerBttnOrders.Size = new Size(123, 67);
            customerBttnOrders.TabIndex = 17;
            customerBttnOrders.Text = "Müşteri Siparişleri";
            customerBttnOrders.TextImageRelation = TextImageRelation.ImageAboveText;
            customerBttnOrders.UseVisualStyleBackColor = false;
            // 
            // customerBttnDelete
            // 
            customerBttnDelete.BackColor = Color.Transparent;
            customerBttnDelete.Dock = DockStyle.Left;
            customerBttnDelete.FlatAppearance.BorderColor = Color.White;
            customerBttnDelete.FlatAppearance.BorderSize = 0;
            customerBttnDelete.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            customerBttnDelete.FlatStyle = FlatStyle.Flat;
            customerBttnDelete.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            customerBttnDelete.Image = (Image)resources.GetObject("customerBttnDelete.Image");
            customerBttnDelete.Location = new Point(327, 0);
            customerBttnDelete.Name = "customerBttnDelete";
            customerBttnDelete.Size = new Size(70, 67);
            customerBttnDelete.TabIndex = 15;
            customerBttnDelete.Text = "Sil";
            customerBttnDelete.TextImageRelation = TextImageRelation.ImageAboveText;
            customerBttnDelete.UseVisualStyleBackColor = false;
            // 
            // customerBttnUpdate
            // 
            customerBttnUpdate.BackColor = Color.Transparent;
            customerBttnUpdate.Dock = DockStyle.Left;
            customerBttnUpdate.FlatAppearance.BorderColor = Color.White;
            customerBttnUpdate.FlatAppearance.BorderSize = 0;
            customerBttnUpdate.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            customerBttnUpdate.FlatStyle = FlatStyle.Flat;
            customerBttnUpdate.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            customerBttnUpdate.Image = (Image)resources.GetObject("customerBttnUpdate.Image");
            customerBttnUpdate.Location = new Point(257, 0);
            customerBttnUpdate.Name = "customerBttnUpdate";
            customerBttnUpdate.Size = new Size(70, 67);
            customerBttnUpdate.TabIndex = 14;
            customerBttnUpdate.Text = "Güncelle";
            customerBttnUpdate.TextImageRelation = TextImageRelation.ImageAboveText;
            customerBttnUpdate.UseVisualStyleBackColor = false;
            // 
            // customerBttnAdd
            // 
            customerBttnAdd.BackColor = Color.Transparent;
            customerBttnAdd.Dock = DockStyle.Left;
            customerBttnAdd.FlatAppearance.BorderColor = Color.White;
            customerBttnAdd.FlatAppearance.BorderSize = 0;
            customerBttnAdd.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            customerBttnAdd.FlatStyle = FlatStyle.Flat;
            customerBttnAdd.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            customerBttnAdd.Image = (Image)resources.GetObject("customerBttnAdd.Image");
            customerBttnAdd.Location = new Point(187, 0);
            customerBttnAdd.Name = "customerBttnAdd";
            customerBttnAdd.Size = new Size(70, 67);
            customerBttnAdd.TabIndex = 13;
            customerBttnAdd.Text = "Ekle";
            customerBttnAdd.TextImageRelation = TextImageRelation.ImageAboveText;
            customerBttnAdd.UseVisualStyleBackColor = false;
            // 
            // customerBttnCard
            // 
            customerBttnCard.BackColor = Color.Transparent;
            customerBttnCard.Dock = DockStyle.Left;
            customerBttnCard.FlatAppearance.BorderColor = Color.White;
            customerBttnCard.FlatAppearance.BorderSize = 0;
            customerBttnCard.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            customerBttnCard.FlatStyle = FlatStyle.Flat;
            customerBttnCard.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            customerBttnCard.Image = (Image)resources.GetObject("customerBttnCard.Image");
            customerBttnCard.Location = new Point(70, 0);
            customerBttnCard.Name = "customerBttnCard";
            customerBttnCard.Size = new Size(117, 67);
            customerBttnCard.TabIndex = 16;
            customerBttnCard.Text = "Müşteri Kartı";
            customerBttnCard.TextImageRelation = TextImageRelation.ImageAboveText;
            customerBttnCard.UseVisualStyleBackColor = false;
            // 
            // customerBttnList
            // 
            customerBttnList.BackColor = Color.Transparent;
            customerBttnList.Dock = DockStyle.Left;
            customerBttnList.FlatAppearance.BorderColor = Color.White;
            customerBttnList.FlatAppearance.BorderSize = 0;
            customerBttnList.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            customerBttnList.FlatStyle = FlatStyle.Flat;
            customerBttnList.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            customerBttnList.Image = (Image)resources.GetObject("customerBttnList.Image");
            customerBttnList.Location = new Point(0, 0);
            customerBttnList.Name = "customerBttnList";
            customerBttnList.Size = new Size(70, 67);
            customerBttnList.TabIndex = 12;
            customerBttnList.Text = "Liste";
            customerBttnList.TextImageRelation = TextImageRelation.ImageAboveText;
            customerBttnList.UseVisualStyleBackColor = false;
            // 
            // SuppliersTabPage
            // 
            SuppliersTabPage.Controls.Add(supplierBttnSupplierHistory);
            SuppliersTabPage.Controls.Add(supplierBttnDelete);
            SuppliersTabPage.Controls.Add(supplierBttnUpdate);
            SuppliersTabPage.Controls.Add(supplierBttnAdd);
            SuppliersTabPage.Controls.Add(supplierBttnCard);
            SuppliersTabPage.Controls.Add(supplierBttnList);
            SuppliersTabPage.Location = new Point(4, 24);
            SuppliersTabPage.Name = "SuppliersTabPage";
            SuppliersTabPage.Size = new Size(1876, 67);
            SuppliersTabPage.TabIndex = 5;
            SuppliersTabPage.Text = "Tedarikçiler";
            SuppliersTabPage.UseVisualStyleBackColor = true;
            // 
            // supplierBttnSupplierHistory
            // 
            supplierBttnSupplierHistory.BackColor = Color.Transparent;
            supplierBttnSupplierHistory.Dock = DockStyle.Left;
            supplierBttnSupplierHistory.FlatAppearance.BorderColor = Color.White;
            supplierBttnSupplierHistory.FlatAppearance.BorderSize = 0;
            supplierBttnSupplierHistory.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            supplierBttnSupplierHistory.FlatStyle = FlatStyle.Flat;
            supplierBttnSupplierHistory.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            supplierBttnSupplierHistory.Image = (Image)resources.GetObject("supplierBttnSupplierHistory.Image");
            supplierBttnSupplierHistory.Location = new Point(397, 0);
            supplierBttnSupplierHistory.Name = "supplierBttnSupplierHistory";
            supplierBttnSupplierHistory.Size = new Size(123, 67);
            supplierBttnSupplierHistory.TabIndex = 23;
            supplierBttnSupplierHistory.Text = "Tedarikçi Geçmişi";
            supplierBttnSupplierHistory.TextImageRelation = TextImageRelation.ImageAboveText;
            supplierBttnSupplierHistory.UseVisualStyleBackColor = false;
            // 
            // supplierBttnDelete
            // 
            supplierBttnDelete.BackColor = Color.Transparent;
            supplierBttnDelete.Dock = DockStyle.Left;
            supplierBttnDelete.FlatAppearance.BorderColor = Color.White;
            supplierBttnDelete.FlatAppearance.BorderSize = 0;
            supplierBttnDelete.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            supplierBttnDelete.FlatStyle = FlatStyle.Flat;
            supplierBttnDelete.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            supplierBttnDelete.Image = (Image)resources.GetObject("supplierBttnDelete.Image");
            supplierBttnDelete.Location = new Point(327, 0);
            supplierBttnDelete.Name = "supplierBttnDelete";
            supplierBttnDelete.Size = new Size(70, 67);
            supplierBttnDelete.TabIndex = 21;
            supplierBttnDelete.Text = "Sil";
            supplierBttnDelete.TextImageRelation = TextImageRelation.ImageAboveText;
            supplierBttnDelete.UseVisualStyleBackColor = false;
            // 
            // supplierBttnUpdate
            // 
            supplierBttnUpdate.BackColor = Color.Transparent;
            supplierBttnUpdate.Dock = DockStyle.Left;
            supplierBttnUpdate.FlatAppearance.BorderColor = Color.White;
            supplierBttnUpdate.FlatAppearance.BorderSize = 0;
            supplierBttnUpdate.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            supplierBttnUpdate.FlatStyle = FlatStyle.Flat;
            supplierBttnUpdate.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            supplierBttnUpdate.Image = (Image)resources.GetObject("supplierBttnUpdate.Image");
            supplierBttnUpdate.Location = new Point(257, 0);
            supplierBttnUpdate.Name = "supplierBttnUpdate";
            supplierBttnUpdate.Size = new Size(70, 67);
            supplierBttnUpdate.TabIndex = 20;
            supplierBttnUpdate.Text = "Güncelle";
            supplierBttnUpdate.TextImageRelation = TextImageRelation.ImageAboveText;
            supplierBttnUpdate.UseVisualStyleBackColor = false;
            // 
            // supplierBttnAdd
            // 
            supplierBttnAdd.BackColor = Color.Transparent;
            supplierBttnAdd.Dock = DockStyle.Left;
            supplierBttnAdd.FlatAppearance.BorderColor = Color.White;
            supplierBttnAdd.FlatAppearance.BorderSize = 0;
            supplierBttnAdd.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            supplierBttnAdd.FlatStyle = FlatStyle.Flat;
            supplierBttnAdd.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            supplierBttnAdd.Image = (Image)resources.GetObject("supplierBttnAdd.Image");
            supplierBttnAdd.Location = new Point(187, 0);
            supplierBttnAdd.Name = "supplierBttnAdd";
            supplierBttnAdd.Size = new Size(70, 67);
            supplierBttnAdd.TabIndex = 19;
            supplierBttnAdd.Text = "Ekle";
            supplierBttnAdd.TextImageRelation = TextImageRelation.ImageAboveText;
            supplierBttnAdd.UseVisualStyleBackColor = false;
            // 
            // supplierBttnCard
            // 
            supplierBttnCard.BackColor = Color.Transparent;
            supplierBttnCard.Dock = DockStyle.Left;
            supplierBttnCard.FlatAppearance.BorderColor = Color.White;
            supplierBttnCard.FlatAppearance.BorderSize = 0;
            supplierBttnCard.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            supplierBttnCard.FlatStyle = FlatStyle.Flat;
            supplierBttnCard.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            supplierBttnCard.Image = (Image)resources.GetObject("supplierBttnCard.Image");
            supplierBttnCard.Location = new Point(70, 0);
            supplierBttnCard.Name = "supplierBttnCard";
            supplierBttnCard.Size = new Size(117, 67);
            supplierBttnCard.TabIndex = 22;
            supplierBttnCard.Text = "Tedarikçi Kartı";
            supplierBttnCard.TextImageRelation = TextImageRelation.ImageAboveText;
            supplierBttnCard.UseVisualStyleBackColor = false;
            // 
            // supplierBttnList
            // 
            supplierBttnList.BackColor = Color.Transparent;
            supplierBttnList.Dock = DockStyle.Left;
            supplierBttnList.FlatAppearance.BorderColor = Color.White;
            supplierBttnList.FlatAppearance.BorderSize = 0;
            supplierBttnList.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            supplierBttnList.FlatStyle = FlatStyle.Flat;
            supplierBttnList.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            supplierBttnList.Image = (Image)resources.GetObject("supplierBttnList.Image");
            supplierBttnList.Location = new Point(0, 0);
            supplierBttnList.Name = "supplierBttnList";
            supplierBttnList.Size = new Size(70, 67);
            supplierBttnList.TabIndex = 18;
            supplierBttnList.Text = "Liste";
            supplierBttnList.TextImageRelation = TextImageRelation.ImageAboveText;
            supplierBttnList.UseVisualStyleBackColor = false;
            // 
            // EmployeesTabPage
            // 
            EmployeesTabPage.Controls.Add(employeeBttnDelete);
            EmployeesTabPage.Controls.Add(employeeBttnUpdate);
            EmployeesTabPage.Controls.Add(employeeBttnAdd);
            EmployeesTabPage.Controls.Add(employeeBttnCard);
            EmployeesTabPage.Controls.Add(employeeBttnList);
            EmployeesTabPage.Location = new Point(4, 24);
            EmployeesTabPage.Name = "EmployeesTabPage";
            EmployeesTabPage.Size = new Size(1876, 67);
            EmployeesTabPage.TabIndex = 10;
            EmployeesTabPage.Text = "Çalışanlar";
            EmployeesTabPage.UseVisualStyleBackColor = true;
            // 
            // employeeBttnDelete
            // 
            employeeBttnDelete.BackColor = Color.Transparent;
            employeeBttnDelete.Dock = DockStyle.Left;
            employeeBttnDelete.FlatAppearance.BorderColor = Color.White;
            employeeBttnDelete.FlatAppearance.BorderSize = 0;
            employeeBttnDelete.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            employeeBttnDelete.FlatStyle = FlatStyle.Flat;
            employeeBttnDelete.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            employeeBttnDelete.Image = (Image)resources.GetObject("employeeBttnDelete.Image");
            employeeBttnDelete.Location = new Point(327, 0);
            employeeBttnDelete.Name = "employeeBttnDelete";
            employeeBttnDelete.Size = new Size(70, 67);
            employeeBttnDelete.TabIndex = 26;
            employeeBttnDelete.Text = "Sil";
            employeeBttnDelete.TextImageRelation = TextImageRelation.ImageAboveText;
            employeeBttnDelete.UseVisualStyleBackColor = false;
            // 
            // employeeBttnUpdate
            // 
            employeeBttnUpdate.BackColor = Color.Transparent;
            employeeBttnUpdate.Dock = DockStyle.Left;
            employeeBttnUpdate.FlatAppearance.BorderColor = Color.White;
            employeeBttnUpdate.FlatAppearance.BorderSize = 0;
            employeeBttnUpdate.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            employeeBttnUpdate.FlatStyle = FlatStyle.Flat;
            employeeBttnUpdate.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            employeeBttnUpdate.Image = (Image)resources.GetObject("employeeBttnUpdate.Image");
            employeeBttnUpdate.Location = new Point(257, 0);
            employeeBttnUpdate.Name = "employeeBttnUpdate";
            employeeBttnUpdate.Size = new Size(70, 67);
            employeeBttnUpdate.TabIndex = 25;
            employeeBttnUpdate.Text = "Güncelle";
            employeeBttnUpdate.TextImageRelation = TextImageRelation.ImageAboveText;
            employeeBttnUpdate.UseVisualStyleBackColor = false;
            // 
            // employeeBttnAdd
            // 
            employeeBttnAdd.BackColor = Color.Transparent;
            employeeBttnAdd.Dock = DockStyle.Left;
            employeeBttnAdd.FlatAppearance.BorderColor = Color.White;
            employeeBttnAdd.FlatAppearance.BorderSize = 0;
            employeeBttnAdd.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            employeeBttnAdd.FlatStyle = FlatStyle.Flat;
            employeeBttnAdd.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            employeeBttnAdd.Image = (Image)resources.GetObject("employeeBttnAdd.Image");
            employeeBttnAdd.Location = new Point(187, 0);
            employeeBttnAdd.Name = "employeeBttnAdd";
            employeeBttnAdd.Size = new Size(70, 67);
            employeeBttnAdd.TabIndex = 24;
            employeeBttnAdd.Text = "Ekle";
            employeeBttnAdd.TextImageRelation = TextImageRelation.ImageAboveText;
            employeeBttnAdd.UseVisualStyleBackColor = false;
            // 
            // employeeBttnCard
            // 
            employeeBttnCard.BackColor = Color.Transparent;
            employeeBttnCard.Dock = DockStyle.Left;
            employeeBttnCard.FlatAppearance.BorderColor = Color.White;
            employeeBttnCard.FlatAppearance.BorderSize = 0;
            employeeBttnCard.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            employeeBttnCard.FlatStyle = FlatStyle.Flat;
            employeeBttnCard.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            employeeBttnCard.Image = (Image)resources.GetObject("employeeBttnCard.Image");
            employeeBttnCard.Location = new Point(70, 0);
            employeeBttnCard.Name = "employeeBttnCard";
            employeeBttnCard.Size = new Size(117, 67);
            employeeBttnCard.TabIndex = 27;
            employeeBttnCard.Text = "Çalışan Kartı";
            employeeBttnCard.TextImageRelation = TextImageRelation.ImageAboveText;
            employeeBttnCard.UseVisualStyleBackColor = false;
            // 
            // employeeBttnList
            // 
            employeeBttnList.BackColor = Color.Transparent;
            employeeBttnList.Dock = DockStyle.Left;
            employeeBttnList.FlatAppearance.BorderColor = Color.White;
            employeeBttnList.FlatAppearance.BorderSize = 0;
            employeeBttnList.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            employeeBttnList.FlatStyle = FlatStyle.Flat;
            employeeBttnList.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            employeeBttnList.Image = (Image)resources.GetObject("employeeBttnList.Image");
            employeeBttnList.Location = new Point(0, 0);
            employeeBttnList.Name = "employeeBttnList";
            employeeBttnList.Size = new Size(70, 67);
            employeeBttnList.TabIndex = 23;
            employeeBttnList.Text = "Liste";
            employeeBttnList.TextImageRelation = TextImageRelation.ImageAboveText;
            employeeBttnList.UseVisualStyleBackColor = false;
            // 
            // UsersTabPage
            // 
            UsersTabPage.Controls.Add(userBttnUpdate);
            UsersTabPage.Controls.Add(userBttnAdd);
            UsersTabPage.Controls.Add(userBttnCard);
            UsersTabPage.Controls.Add(userBttnList);
            UsersTabPage.Location = new Point(4, 24);
            UsersTabPage.Name = "UsersTabPage";
            UsersTabPage.Size = new Size(1876, 67);
            UsersTabPage.TabIndex = 7;
            UsersTabPage.Text = "Kullanıcılar";
            UsersTabPage.UseVisualStyleBackColor = true;
            // 
            // userBttnUpdate
            // 
            userBttnUpdate.BackColor = Color.Transparent;
            userBttnUpdate.Dock = DockStyle.Left;
            userBttnUpdate.FlatAppearance.BorderColor = Color.White;
            userBttnUpdate.FlatAppearance.BorderSize = 0;
            userBttnUpdate.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            userBttnUpdate.FlatStyle = FlatStyle.Flat;
            userBttnUpdate.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            userBttnUpdate.Image = (Image)resources.GetObject("userBttnUpdate.Image");
            userBttnUpdate.Location = new Point(257, 0);
            userBttnUpdate.Name = "userBttnUpdate";
            userBttnUpdate.Size = new Size(70, 67);
            userBttnUpdate.TabIndex = 25;
            userBttnUpdate.Text = "Güncelle";
            userBttnUpdate.TextImageRelation = TextImageRelation.ImageAboveText;
            userBttnUpdate.UseVisualStyleBackColor = false;
            // 
            // userBttnAdd
            // 
            userBttnAdd.BackColor = Color.Transparent;
            userBttnAdd.Dock = DockStyle.Left;
            userBttnAdd.FlatAppearance.BorderColor = Color.White;
            userBttnAdd.FlatAppearance.BorderSize = 0;
            userBttnAdd.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            userBttnAdd.FlatStyle = FlatStyle.Flat;
            userBttnAdd.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            userBttnAdd.Image = (Image)resources.GetObject("userBttnAdd.Image");
            userBttnAdd.Location = new Point(187, 0);
            userBttnAdd.Name = "userBttnAdd";
            userBttnAdd.Size = new Size(70, 67);
            userBttnAdd.TabIndex = 24;
            userBttnAdd.Text = "Ekle";
            userBttnAdd.TextImageRelation = TextImageRelation.ImageAboveText;
            userBttnAdd.UseVisualStyleBackColor = false;
            // 
            // userBttnCard
            // 
            userBttnCard.BackColor = Color.Transparent;
            userBttnCard.Dock = DockStyle.Left;
            userBttnCard.FlatAppearance.BorderColor = Color.White;
            userBttnCard.FlatAppearance.BorderSize = 0;
            userBttnCard.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            userBttnCard.FlatStyle = FlatStyle.Flat;
            userBttnCard.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            userBttnCard.Image = (Image)resources.GetObject("userBttnCard.Image");
            userBttnCard.Location = new Point(70, 0);
            userBttnCard.Name = "userBttnCard";
            userBttnCard.Size = new Size(117, 67);
            userBttnCard.TabIndex = 27;
            userBttnCard.Text = "Tedarikçi Kartı";
            userBttnCard.TextImageRelation = TextImageRelation.ImageAboveText;
            userBttnCard.UseVisualStyleBackColor = false;
            // 
            // userBttnList
            // 
            userBttnList.BackColor = Color.Transparent;
            userBttnList.Dock = DockStyle.Left;
            userBttnList.FlatAppearance.BorderColor = Color.White;
            userBttnList.FlatAppearance.BorderSize = 0;
            userBttnList.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            userBttnList.FlatStyle = FlatStyle.Flat;
            userBttnList.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            userBttnList.Image = (Image)resources.GetObject("userBttnList.Image");
            userBttnList.Location = new Point(0, 0);
            userBttnList.Name = "userBttnList";
            userBttnList.Size = new Size(70, 67);
            userBttnList.TabIndex = 23;
            userBttnList.Text = "Liste";
            userBttnList.TextImageRelation = TextImageRelation.ImageAboveText;
            userBttnList.UseVisualStyleBackColor = false;
            // 
            // SettingsTabPage
            // 
            SettingsTabPage.Location = new Point(4, 24);
            SettingsTabPage.Name = "SettingsTabPage";
            SettingsTabPage.Size = new Size(1876, 67);
            SettingsTabPage.TabIndex = 6;
            SettingsTabPage.Text = "Ayarlar";
            SettingsTabPage.UseVisualStyleBackColor = true;
            // 
            // ExitPageTab
            // 
            ExitPageTab.Location = new Point(4, 24);
            ExitPageTab.Name = "ExitPageTab";
            ExitPageTab.Size = new Size(1876, 67);
            ExitPageTab.TabIndex = 8;
            ExitPageTab.Text = "Çıkış";
            ExitPageTab.UseVisualStyleBackColor = true;
            // 
            // panelBottom
            // 
            panelBottom.BackColor = SystemColors.Highlight;
            panelBottom.Controls.Add(lblDate);
            panelBottom.Controls.Add(lblUserName);
            panelBottom.Controls.Add(lblWarehoseName);
            panelBottom.Controls.Add(lblDatabaseName);
            panelBottom.Controls.Add(lblServerName);
            panelBottom.Controls.Add(lblCompanyName);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 991);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(1884, 30);
            panelBottom.TabIndex = 1;
            // 
            // lblDate
            // 
            lblDate.Dock = DockStyle.Right;
            lblDate.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblDate.ForeColor = Color.White;
            lblDate.Location = new Point(1739, 0);
            lblDate.Name = "lblDate";
            lblDate.Padding = new Padding(5, 0, 5, 0);
            lblDate.Size = new Size(145, 30);
            lblDate.TabIndex = 5;
            lblDate.Text = "Tarih";
            lblDate.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblUserName
            // 
            lblUserName.Dock = DockStyle.Left;
            lblUserName.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblUserName.ForeColor = Color.White;
            lblUserName.Location = new Point(893, 0);
            lblUserName.Name = "lblUserName";
            lblUserName.Padding = new Padding(5, 0, 0, 0);
            lblUserName.Size = new Size(189, 30);
            lblUserName.TabIndex = 4;
            lblUserName.Text = "Kullanıcı Adı :";
            lblUserName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblWarehoseName
            // 
            lblWarehoseName.Dock = DockStyle.Left;
            lblWarehoseName.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblWarehoseName.ForeColor = Color.White;
            lblWarehoseName.Location = new Point(704, 0);
            lblWarehoseName.Name = "lblWarehoseName";
            lblWarehoseName.Padding = new Padding(5, 0, 0, 0);
            lblWarehoseName.Size = new Size(189, 30);
            lblWarehoseName.TabIndex = 3;
            lblWarehoseName.Text = "Şube Adı :";
            lblWarehoseName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblDatabaseName
            // 
            lblDatabaseName.Dock = DockStyle.Left;
            lblDatabaseName.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblDatabaseName.ForeColor = Color.White;
            lblDatabaseName.Location = new Point(515, 0);
            lblDatabaseName.Name = "lblDatabaseName";
            lblDatabaseName.Padding = new Padding(5, 0, 0, 0);
            lblDatabaseName.Size = new Size(189, 30);
            lblDatabaseName.TabIndex = 2;
            lblDatabaseName.Text = "Veritabanı Adı :";
            lblDatabaseName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblServerName
            // 
            lblServerName.Dock = DockStyle.Left;
            lblServerName.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblServerName.ForeColor = Color.White;
            lblServerName.Location = new Point(326, 0);
            lblServerName.Name = "lblServerName";
            lblServerName.Padding = new Padding(5, 0, 0, 0);
            lblServerName.Size = new Size(189, 30);
            lblServerName.TabIndex = 1;
            lblServerName.Text = "Sunucu Adı :";
            lblServerName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCompanyName
            // 
            lblCompanyName.Dock = DockStyle.Left;
            lblCompanyName.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblCompanyName.ForeColor = Color.White;
            lblCompanyName.Location = new Point(0, 0);
            lblCompanyName.Name = "lblCompanyName";
            lblCompanyName.Padding = new Padding(5, 0, 0, 0);
            lblCompanyName.Size = new Size(326, 30);
            lblCompanyName.TabIndex = 0;
            lblCompanyName.Text = "Firma Adı : ";
            lblCompanyName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 95);
            panel1.Name = "panel1";
            panel1.Size = new Size(1884, 896);
            panel1.TabIndex = 2;
            // 
            // BrandPage
            // 
            BrandPage.Controls.Add(bttnBrandDelete);
            BrandPage.Controls.Add(bttnBrandUpdate);
            BrandPage.Controls.Add(bttnBrandAdd);
            BrandPage.Controls.Add(bttnBrandCart);
            BrandPage.Controls.Add(bttnBrandList);
            BrandPage.Location = new Point(4, 24);
            BrandPage.Name = "BrandPage";
            BrandPage.Size = new Size(1876, 67);
            BrandPage.TabIndex = 11;
            BrandPage.Text = "Markalar";
            BrandPage.UseVisualStyleBackColor = true;
            // 
            // bttnBrandDelete
            // 
            bttnBrandDelete.BackColor = Color.Transparent;
            bttnBrandDelete.Dock = DockStyle.Left;
            bttnBrandDelete.FlatAppearance.BorderColor = Color.White;
            bttnBrandDelete.FlatAppearance.BorderSize = 0;
            bttnBrandDelete.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            bttnBrandDelete.FlatStyle = FlatStyle.Flat;
            bttnBrandDelete.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            bttnBrandDelete.Image = (Image)resources.GetObject("bttnBrandDelete.Image");
            bttnBrandDelete.Location = new Point(327, 0);
            bttnBrandDelete.Name = "bttnBrandDelete";
            bttnBrandDelete.Size = new Size(70, 67);
            bttnBrandDelete.TabIndex = 20;
            bttnBrandDelete.Text = "Sil";
            bttnBrandDelete.TextImageRelation = TextImageRelation.ImageAboveText;
            bttnBrandDelete.UseVisualStyleBackColor = false;
            // 
            // bttnBrandUpdate
            // 
            bttnBrandUpdate.BackColor = Color.Transparent;
            bttnBrandUpdate.Dock = DockStyle.Left;
            bttnBrandUpdate.FlatAppearance.BorderColor = Color.White;
            bttnBrandUpdate.FlatAppearance.BorderSize = 0;
            bttnBrandUpdate.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            bttnBrandUpdate.FlatStyle = FlatStyle.Flat;
            bttnBrandUpdate.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            bttnBrandUpdate.Image = (Image)resources.GetObject("bttnBrandUpdate.Image");
            bttnBrandUpdate.Location = new Point(257, 0);
            bttnBrandUpdate.Name = "bttnBrandUpdate";
            bttnBrandUpdate.Size = new Size(70, 67);
            bttnBrandUpdate.TabIndex = 19;
            bttnBrandUpdate.Text = "Güncelle";
            bttnBrandUpdate.TextImageRelation = TextImageRelation.ImageAboveText;
            bttnBrandUpdate.UseVisualStyleBackColor = false;
            // 
            // bttnBrandAdd
            // 
            bttnBrandAdd.BackColor = Color.Transparent;
            bttnBrandAdd.Dock = DockStyle.Left;
            bttnBrandAdd.FlatAppearance.BorderColor = Color.White;
            bttnBrandAdd.FlatAppearance.BorderSize = 0;
            bttnBrandAdd.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            bttnBrandAdd.FlatStyle = FlatStyle.Flat;
            bttnBrandAdd.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            bttnBrandAdd.Image = (Image)resources.GetObject("bttnBrandAdd.Image");
            bttnBrandAdd.Location = new Point(187, 0);
            bttnBrandAdd.Name = "bttnBrandAdd";
            bttnBrandAdd.Size = new Size(70, 67);
            bttnBrandAdd.TabIndex = 18;
            bttnBrandAdd.Text = "Ekle";
            bttnBrandAdd.TextImageRelation = TextImageRelation.ImageAboveText;
            bttnBrandAdd.UseVisualStyleBackColor = false;
            // 
            // bttnBrandCart
            // 
            bttnBrandCart.BackColor = Color.Transparent;
            bttnBrandCart.Dock = DockStyle.Left;
            bttnBrandCart.FlatAppearance.BorderColor = Color.White;
            bttnBrandCart.FlatAppearance.BorderSize = 0;
            bttnBrandCart.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            bttnBrandCart.FlatStyle = FlatStyle.Flat;
            bttnBrandCart.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            bttnBrandCart.Image = (Image)resources.GetObject("bttnBrandCart.Image");
            bttnBrandCart.Location = new Point(70, 0);
            bttnBrandCart.Name = "bttnBrandCart";
            bttnBrandCart.Size = new Size(117, 67);
            bttnBrandCart.TabIndex = 21;
            bttnBrandCart.Text = "Marka Kartı";
            bttnBrandCart.TextImageRelation = TextImageRelation.ImageAboveText;
            bttnBrandCart.UseVisualStyleBackColor = false;
            // 
            // bttnBrandList
            // 
            bttnBrandList.BackColor = Color.Transparent;
            bttnBrandList.Dock = DockStyle.Left;
            bttnBrandList.FlatAppearance.BorderColor = Color.White;
            bttnBrandList.FlatAppearance.BorderSize = 0;
            bttnBrandList.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            bttnBrandList.FlatStyle = FlatStyle.Flat;
            bttnBrandList.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            bttnBrandList.Image = (Image)resources.GetObject("bttnBrandList.Image");
            bttnBrandList.Location = new Point(0, 0);
            bttnBrandList.Name = "bttnBrandList";
            bttnBrandList.Size = new Size(70, 67);
            bttnBrandList.TabIndex = 17;
            bttnBrandList.Text = "Liste";
            bttnBrandList.TextImageRelation = TextImageRelation.ImageAboveText;
            bttnBrandList.UseVisualStyleBackColor = false;
            // 
            // AppUserRolePage
            // 
            AppUserRolePage.Controls.Add(bttnAppUserRoleDelete);
            AppUserRolePage.Controls.Add(bttnAppUserRoleUpdate);
            AppUserRolePage.Controls.Add(bttnAppUserRoleAdd);
            AppUserRolePage.Controls.Add(bttnAppUserRoleCart);
            AppUserRolePage.Controls.Add(bttnAppUserRoleList);
            AppUserRolePage.Location = new Point(4, 26);
            AppUserRolePage.Name = "AppUserRolePage";
            AppUserRolePage.Size = new Size(1876, 65);
            AppUserRolePage.TabIndex = 12;
            AppUserRolePage.Text = "Yetkiler";
            AppUserRolePage.UseVisualStyleBackColor = true;
            // 
            // bttnAppUserRoleDelete
            // 
            bttnAppUserRoleDelete.BackColor = Color.Transparent;
            bttnAppUserRoleDelete.Dock = DockStyle.Left;
            bttnAppUserRoleDelete.FlatAppearance.BorderColor = Color.White;
            bttnAppUserRoleDelete.FlatAppearance.BorderSize = 0;
            bttnAppUserRoleDelete.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            bttnAppUserRoleDelete.FlatStyle = FlatStyle.Flat;
            bttnAppUserRoleDelete.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            bttnAppUserRoleDelete.Image = (Image)resources.GetObject("bttnAppUserRoleDelete.Image");
            bttnAppUserRoleDelete.Location = new Point(327, 0);
            bttnAppUserRoleDelete.Name = "bttnAppUserRoleDelete";
            bttnAppUserRoleDelete.Size = new Size(70, 65);
            bttnAppUserRoleDelete.TabIndex = 31;
            bttnAppUserRoleDelete.Text = "Sil";
            bttnAppUserRoleDelete.TextImageRelation = TextImageRelation.ImageAboveText;
            bttnAppUserRoleDelete.UseVisualStyleBackColor = false;
            // 
            // bttnAppUserRoleUpdate
            // 
            bttnAppUserRoleUpdate.BackColor = Color.Transparent;
            bttnAppUserRoleUpdate.Dock = DockStyle.Left;
            bttnAppUserRoleUpdate.FlatAppearance.BorderColor = Color.White;
            bttnAppUserRoleUpdate.FlatAppearance.BorderSize = 0;
            bttnAppUserRoleUpdate.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            bttnAppUserRoleUpdate.FlatStyle = FlatStyle.Flat;
            bttnAppUserRoleUpdate.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            bttnAppUserRoleUpdate.Image = (Image)resources.GetObject("bttnAppUserRoleUpdate.Image");
            bttnAppUserRoleUpdate.Location = new Point(257, 0);
            bttnAppUserRoleUpdate.Name = "bttnAppUserRoleUpdate";
            bttnAppUserRoleUpdate.Size = new Size(70, 65);
            bttnAppUserRoleUpdate.TabIndex = 30;
            bttnAppUserRoleUpdate.Text = "Güncelle";
            bttnAppUserRoleUpdate.TextImageRelation = TextImageRelation.ImageAboveText;
            bttnAppUserRoleUpdate.UseVisualStyleBackColor = false;
            // 
            // bttnAppUserRoleAdd
            // 
            bttnAppUserRoleAdd.BackColor = Color.Transparent;
            bttnAppUserRoleAdd.Dock = DockStyle.Left;
            bttnAppUserRoleAdd.FlatAppearance.BorderColor = Color.White;
            bttnAppUserRoleAdd.FlatAppearance.BorderSize = 0;
            bttnAppUserRoleAdd.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            bttnAppUserRoleAdd.FlatStyle = FlatStyle.Flat;
            bttnAppUserRoleAdd.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            bttnAppUserRoleAdd.Image = (Image)resources.GetObject("bttnAppUserRoleAdd.Image");
            bttnAppUserRoleAdd.Location = new Point(187, 0);
            bttnAppUserRoleAdd.Name = "bttnAppUserRoleAdd";
            bttnAppUserRoleAdd.Size = new Size(70, 65);
            bttnAppUserRoleAdd.TabIndex = 29;
            bttnAppUserRoleAdd.Text = "Ekle";
            bttnAppUserRoleAdd.TextImageRelation = TextImageRelation.ImageAboveText;
            bttnAppUserRoleAdd.UseVisualStyleBackColor = false;
            // 
            // bttnAppUserRoleCart
            // 
            bttnAppUserRoleCart.BackColor = Color.Transparent;
            bttnAppUserRoleCart.Dock = DockStyle.Left;
            bttnAppUserRoleCart.FlatAppearance.BorderColor = Color.White;
            bttnAppUserRoleCart.FlatAppearance.BorderSize = 0;
            bttnAppUserRoleCart.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            bttnAppUserRoleCart.FlatStyle = FlatStyle.Flat;
            bttnAppUserRoleCart.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            bttnAppUserRoleCart.Image = (Image)resources.GetObject("bttnAppUserRoleCart.Image");
            bttnAppUserRoleCart.Location = new Point(70, 0);
            bttnAppUserRoleCart.Name = "bttnAppUserRoleCart";
            bttnAppUserRoleCart.Size = new Size(117, 65);
            bttnAppUserRoleCart.TabIndex = 32;
            bttnAppUserRoleCart.Text = "Çalışan Kartı";
            bttnAppUserRoleCart.TextImageRelation = TextImageRelation.ImageAboveText;
            bttnAppUserRoleCart.UseVisualStyleBackColor = false;
            // 
            // bttnAppUserRoleList
            // 
            bttnAppUserRoleList.BackColor = Color.Transparent;
            bttnAppUserRoleList.Dock = DockStyle.Left;
            bttnAppUserRoleList.FlatAppearance.BorderColor = Color.White;
            bttnAppUserRoleList.FlatAppearance.BorderSize = 0;
            bttnAppUserRoleList.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            bttnAppUserRoleList.FlatStyle = FlatStyle.Flat;
            bttnAppUserRoleList.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            bttnAppUserRoleList.Image = (Image)resources.GetObject("bttnAppUserRoleList.Image");
            bttnAppUserRoleList.Location = new Point(0, 0);
            bttnAppUserRoleList.Name = "bttnAppUserRoleList";
            bttnAppUserRoleList.Size = new Size(70, 65);
            bttnAppUserRoleList.TabIndex = 28;
            bttnAppUserRoleList.Text = "Liste";
            bttnAppUserRoleList.TextImageRelation = TextImageRelation.ImageAboveText;
            bttnAppUserRoleList.UseVisualStyleBackColor = false;
            // 
            // Panel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1884, 1021);
            Controls.Add(panel1);
            Controls.Add(panelBottom);
            Controls.Add(tabControl1);
            Name = "Panel";
            Text = "Panel";
            WindowState = FormWindowState.Maximized;
            tabControl1.ResumeLayout(false);
            HomeTabPage.ResumeLayout(false);
            StocksTabPage.ResumeLayout(false);
            ProductionTabPage.ResumeLayout(false);
            ProductsTabPage.ResumeLayout(false);
            CategoriesTabPage.ResumeLayout(false);
            CustomersTabPage.ResumeLayout(false);
            SuppliersTabPage.ResumeLayout(false);
            EmployeesTabPage.ResumeLayout(false);
            UsersTabPage.ResumeLayout(false);
            panelBottom.ResumeLayout(false);
            BrandPage.ResumeLayout(false);
            AppUserRolePage.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage HomeTabPage;
        private TabPage StocksTabPage;
        private TabPage ProductionTabPage;
        private TabPage ProductsTabPage;
        private TabPage CategoriesTabPage;
        private TabPage CustomersTabPage;
        private TabPage SuppliersTabPage;
        private TabPage UsersTabPage;
        private TabPage SettingsTabPage;
        private TabPage ExitPageTab;
        private Button button1;
        private Button productBttnCard;
        private Button productBttnRecipe;
        private Button productBttnCategoryAdd;
        private Button productBttnDelete;
        private Button productBttnUpdate;
        private Button productBttnAdd;
        private Button productBttnList;
        private Button categoryBttnDelete;
        private Button categoryBttnUpdate;
        private Button categoryBttnAdd;
        private Button categoryBttnCard;
        private Button categoryBttnList;
        private Button customerBttnOrders;
        private Button customerBttnDelete;
        private Button customerBttnUpdate;
        private Button customerBttnAdd;
        private Button customerBttnCard;
        private Button customerBttnList;
        private Button supplierBttnSupplierHistory;
        private Button supplierBttnDelete;
        private Button supplierBttnUpdate;
        private Button supplierBttnAdd;
        private Button supplierBttnCard;
        private Button supplierBttnList;
        private Button userBttnUpdate;
        private Button userBttnAdd;
        private Button userBttnCard;
        private Button userBttnList;
        private TabPage EmployeesTabPage;
        private Button employeeBttnDelete;
        private Button employeeBttnUpdate;
        private Button employeeBttnAdd;
        private Button employeeBttnCard;
        private Button employeeBttnList;
        private System.Windows.Forms.Panel panelBottom;
        private Label lblCompanyName;
        private Label lblDate;
        private Label lblUserName;
        private Label lblWarehoseName;
        private Label lblDatabaseName;
        private Label lblServerName;
        private Button homeBttnExit;
        private Button stockBttnTransfer;
        private Button stockBttnReceipt;
        private Button productionBttnProduce;
        private Button productionBttnList;
        private System.Windows.Forms.Panel panel1;
        private TabPage BrandPage;
        private Button bttnBrandDelete;
        private Button bttnBrandUpdate;
        private Button bttnBrandAdd;
        private Button bttnBrandCart;
        private Button bttnBrandList;
        private TabPage AppUserRolePage;
        private Button bttnAppUserRoleDelete;
        private Button bttnAppUserRoleUpdate;
        private Button bttnAppUserRoleAdd;
        private Button bttnAppUserRoleCart;
        private Button bttnAppUserRoleList;
    }
}