namespace DA205E_Assignment1
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            grpCreateAnimal = new GroupBox();
            btnCreateAnimal = new Button();
            chkListAllSpecies = new CheckBox();
            lstSpecies = new ListBox();
            lstCategory = new ListBox();
            picImage = new PictureBox();
            btnLoadImage = new Button();
            grpGeneralData = new GroupBox();
            lblGender = new Label();
            lblWeight = new Label();
            lblAge = new Label();
            cmbGender = new ComboBox();
            txtWeight = new TextBox();
            txtAge = new TextBox();
            txtName = new TextBox();
            lblName = new Label();
            btnAdd = new Button();
            rtxtAnimalData = new RichTextBox();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            loadImageToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            grpCreateAnimal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picImage).BeginInit();
            grpGeneralData.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // grpCreateAnimal
            // 
            grpCreateAnimal.Controls.Add(btnCreateAnimal);
            grpCreateAnimal.Controls.Add(chkListAllSpecies);
            grpCreateAnimal.Controls.Add(lstSpecies);
            grpCreateAnimal.Controls.Add(lstCategory);
            grpCreateAnimal.Location = new Point(12, 28);
            grpCreateAnimal.Name = "grpCreateAnimal";
            grpCreateAnimal.Size = new Size(300, 247);
            grpCreateAnimal.TabIndex = 0;
            grpCreateAnimal.TabStop = false;
            grpCreateAnimal.Text = "Create Animal";
            // 
            // btnCreateAnimal
            // 
            btnCreateAnimal.Location = new Point(6, 208);
            btnCreateAnimal.Name = "btnCreateAnimal";
            btnCreateAnimal.Size = new Size(265, 33);
            btnCreateAnimal.TabIndex = 3;
            btnCreateAnimal.Text = "Create Animal";
            btnCreateAnimal.UseVisualStyleBackColor = true;
            btnCreateAnimal.Click += btnCreateAnimal_Click;
            // 
            // chkListAllSpecies
            // 
            chkListAllSpecies.AutoSize = true;
            chkListAllSpecies.Location = new Point(132, 33);
            chkListAllSpecies.Name = "chkListAllSpecies";
            chkListAllSpecies.Size = new Size(139, 19);
            chkListAllSpecies.TabIndex = 2;
            chkListAllSpecies.Text = "List all animal species";
            chkListAllSpecies.UseVisualStyleBackColor = true;
            chkListAllSpecies.CheckedChanged += chkListAllSpecies_CheckedChanged;
            // 
            // lstSpecies
            // 
            lstSpecies.FormattingEnabled = true;
            lstSpecies.Location = new Point(132, 63);
            lstSpecies.Name = "lstSpecies";
            lstSpecies.Size = new Size(139, 124);
            lstSpecies.TabIndex = 1;
            lstSpecies.SelectedIndexChanged += lstSpecies_SelectedIndexChanged;
            // 
            // lstCategory
            // 
            lstCategory.FormattingEnabled = true;
            lstCategory.Location = new Point(6, 33);
            lstCategory.Name = "lstCategory";
            lstCategory.Size = new Size(120, 154);
            lstCategory.TabIndex = 0;
            lstCategory.SelectedIndexChanged += lstCategory_SelectedIndexChanged;
            // 
            // picImage
            // 
            picImage.BorderStyle = BorderStyle.FixedSingle;
            picImage.Location = new Point(344, 28);
            picImage.Name = "picImage";
            picImage.Size = new Size(214, 149);
            picImage.TabIndex = 1;
            picImage.TabStop = false;
            // 
            // btnLoadImage
            // 
            btnLoadImage.Location = new Point(344, 183);
            btnLoadImage.Name = "btnLoadImage";
            btnLoadImage.Size = new Size(214, 33);
            btnLoadImage.TabIndex = 2;
            btnLoadImage.Text = "Load Image";
            btnLoadImage.UseVisualStyleBackColor = true;
            btnLoadImage.Click += btnLoadImage_Click;
            // 
            // grpGeneralData
            // 
            grpGeneralData.Controls.Add(lblGender);
            grpGeneralData.Controls.Add(lblWeight);
            grpGeneralData.Controls.Add(lblAge);
            grpGeneralData.Controls.Add(cmbGender);
            grpGeneralData.Controls.Add(txtWeight);
            grpGeneralData.Controls.Add(txtAge);
            grpGeneralData.Controls.Add(txtName);
            grpGeneralData.Controls.Add(lblName);
            grpGeneralData.Location = new Point(12, 297);
            grpGeneralData.Name = "grpGeneralData";
            grpGeneralData.Size = new Size(300, 134);
            grpGeneralData.TabIndex = 3;
            grpGeneralData.TabStop = false;
            grpGeneralData.Text = "General Data";
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Location = new Point(6, 106);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(45, 15);
            lblGender.TabIndex = 7;
            lblGender.Text = "Gender";
            // 
            // lblWeight
            // 
            lblWeight.AutoSize = true;
            lblWeight.Location = new Point(6, 77);
            lblWeight.Name = "lblWeight";
            lblWeight.Size = new Size(45, 15);
            lblWeight.TabIndex = 6;
            lblWeight.Text = "Weight";
            // 
            // lblAge
            // 
            lblAge.AutoSize = true;
            lblAge.Location = new Point(6, 48);
            lblAge.Name = "lblAge";
            lblAge.Size = new Size(28, 15);
            lblAge.TabIndex = 5;
            lblAge.Text = "Age";
            // 
            // cmbGender
            // 
            cmbGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGender.FormattingEnabled = true;
            cmbGender.Location = new Point(118, 103);
            cmbGender.Name = "cmbGender";
            cmbGender.Size = new Size(153, 23);
            cmbGender.TabIndex = 4;
            // 
            // txtWeight
            // 
            txtWeight.Location = new Point(118, 74);
            txtWeight.Name = "txtWeight";
            txtWeight.Size = new Size(153, 23);
            txtWeight.TabIndex = 3;
            // 
            // txtAge
            // 
            txtAge.Location = new Point(118, 45);
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(153, 23);
            txtAge.TabIndex = 2;
            // 
            // txtName
            // 
            txtName.Location = new Point(118, 16);
            txtName.Name = "txtName";
            txtName.Size = new Size(153, 23);
            txtName.TabIndex = 1;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(6, 19);
            lblName.Name = "lblName";
            lblName.Size = new Size(39, 15);
            lblName.TabIndex = 0;
            lblName.Text = "Name";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(12, 437);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(300, 44);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // rtxtAnimalData
            // 
            rtxtAnimalData.Location = new Point(344, 236);
            rtxtAnimalData.Name = "rtxtAnimalData";
            rtxtAnimalData.ReadOnly = true;
            rtxtAnimalData.Size = new Size(214, 245);
            rtxtAnimalData.TabIndex = 5;
            rtxtAnimalData.Text = "";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(570, 24);
            menuStrip1.TabIndex = 6;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { loadImageToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // loadImageToolStripMenuItem
            // 
            loadImageToolStripMenuItem.Name = "loadImageToolStripMenuItem";
            loadImageToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Alt | Keys.L;
            loadImageToolStripMenuItem.Size = new Size(199, 22);
            loadImageToolStripMenuItem.Text = "Load Image";
            loadImageToolStripMenuItem.Click += loadImageToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 20);
            helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Alt | Keys.A;
            aboutToolStripMenuItem.Size = new Size(172, 22);
            aboutToolStripMenuItem.Text = "&About";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(570, 493);
            Controls.Add(rtxtAnimalData);
            Controls.Add(btnAdd);
            Controls.Add(grpGeneralData);
            Controls.Add(btnLoadImage);
            Controls.Add(picImage);
            Controls.Add(grpCreateAnimal);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "MainForm";
            Text = "E-Animal Management System";
            grpCreateAnimal.ResumeLayout(false);
            grpCreateAnimal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picImage).EndInit();
            grpGeneralData.ResumeLayout(false);
            grpGeneralData.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grpCreateAnimal;
        private ListBox lstCategory;
        private CheckBox chkListAllSpecies;
        private ListBox lstSpecies;
        private Button btnCreateAnimal;
        private PictureBox picImage;
        private Button btnLoadImage;
        private GroupBox grpGeneralData;
        private ComboBox cmbGender;
        private TextBox txtWeight;
        private TextBox txtAge;
        private TextBox txtName;
        private Label lblName;
        private Label lblAge;
        private Label lblWeight;
        private Label lblGender;
        private Button btnAdd;
        private RichTextBox rtxtAnimalData;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem loadImageToolStripMenuItem;
    }
}
