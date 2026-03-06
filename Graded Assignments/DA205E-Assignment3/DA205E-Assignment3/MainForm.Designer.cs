namespace DA205E_Assignment3
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
            mnuFile = new ToolStripMenuItem();
            mnuFileNew = new ToolStripMenuItem();
            mnuFileOpen = new ToolStripMenuItem();
            mnuFileSave = new ToolStripMenuItem();
            mnuFileSaveAs = new ToolStripMenuItem();
            mnuFileLoadImage = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            mnuFileExitApp = new ToolStripMenuItem();
            mnuHelp = new ToolStripMenuItem();
            mnuHelpAbout = new ToolStripMenuItem();
            lstAnimals = new ListBox();
            btnChange = new Button();
            btnDelete = new Button();
            lblSpecies = new Label();
            lblId = new Label();
            lblNameLst = new Label();
            lblAgeLst = new Label();
            lblWeightLst = new Label();
            lblGenderLst = new Label();
            rtxtAdditionalData = new RichTextBox();
            btnClearSelection = new Button();
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
            grpCreateAnimal.Size = new Size(300, 185);
            grpCreateAnimal.TabIndex = 0;
            grpCreateAnimal.TabStop = false;
            grpCreateAnimal.Text = "Create Animal";
            // 
            // btnCreateAnimal
            // 
            btnCreateAnimal.Location = new Point(6, 143);
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
            lstSpecies.Size = new Size(139, 64);
            lstSpecies.TabIndex = 1;
            lstSpecies.SelectedIndexChanged += lstSpecies_SelectedIndexChanged;
            // 
            // lstCategory
            // 
            lstCategory.FormattingEnabled = true;
            lstCategory.Location = new Point(6, 33);
            lstCategory.Name = "lstCategory";
            lstCategory.Size = new Size(120, 94);
            lstCategory.TabIndex = 0;
            lstCategory.SelectedIndexChanged += lstCategory_SelectedIndexChanged;
            // 
            // picImage
            // 
            picImage.BorderStyle = BorderStyle.FixedSingle;
            picImage.Location = new Point(624, 27);
            picImage.Name = "picImage";
            picImage.Size = new Size(262, 135);
            picImage.TabIndex = 1;
            picImage.TabStop = false;
            // 
            // btnLoadImage
            // 
            btnLoadImage.Location = new Point(624, 180);
            btnLoadImage.Name = "btnLoadImage";
            btnLoadImage.Size = new Size(262, 33);
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
            grpGeneralData.Location = new Point(318, 28);
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
            btnAdd.Location = new Point(318, 180);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(300, 33);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // rtxtAnimalData
            // 
            rtxtAnimalData.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rtxtAnimalData.Location = new Point(425, 227);
            rtxtAnimalData.Name = "rtxtAnimalData";
            rtxtAnimalData.ReadOnly = true;
            rtxtAnimalData.Size = new Size(193, 254);
            rtxtAnimalData.TabIndex = 5;
            rtxtAnimalData.Text = "";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { mnuFile, mnuHelp });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(898, 24);
            menuStrip1.TabIndex = 6;
            menuStrip1.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            mnuFile.DropDownItems.AddRange(new ToolStripItem[] { mnuFileNew, mnuFileOpen, mnuFileSave, mnuFileSaveAs, mnuFileLoadImage, toolStripMenuItem1, mnuFileExitApp });
            mnuFile.Name = "mnuFile";
            mnuFile.Size = new Size(37, 20);
            mnuFile.Text = "File";
            // 
            // mnuFileNew
            // 
            mnuFileNew.Name = "mnuFileNew";
            mnuFileNew.ShortcutKeys = Keys.Control | Keys.N;
            mnuFileNew.Size = new Size(199, 22);
            mnuFileNew.Text = "New";
            // 
            // mnuFileOpen
            // 
            mnuFileOpen.Name = "mnuFileOpen";
            mnuFileOpen.ShortcutKeys = Keys.Control | Keys.O;
            mnuFileOpen.Size = new Size(199, 22);
            mnuFileOpen.Text = "Open...";
            // 
            // mnuFileSave
            // 
            mnuFileSave.Name = "mnuFileSave";
            mnuFileSave.ShortcutKeys = Keys.Control | Keys.S;
            mnuFileSave.Size = new Size(199, 22);
            mnuFileSave.Text = "Save";
            // 
            // mnuFileSaveAs
            // 
            mnuFileSaveAs.Name = "mnuFileSaveAs";
            mnuFileSaveAs.ShortcutKeys = Keys.Control | Keys.Alt | Keys.S;
            mnuFileSaveAs.Size = new Size(199, 22);
            mnuFileSaveAs.Text = "Save As...";
            // 
            // mnuFileLoadImage
            // 
            mnuFileLoadImage.Name = "mnuFileLoadImage";
            mnuFileLoadImage.ShortcutKeys = Keys.Control | Keys.Alt | Keys.L;
            mnuFileLoadImage.Size = new Size(199, 22);
            mnuFileLoadImage.Text = "Load Image";
            mnuFileLoadImage.Click += loadImageToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(196, 6);
            // 
            // mnuFileExitApp
            // 
            mnuFileExitApp.Name = "mnuFileExitApp";
            mnuFileExitApp.ShortcutKeys = Keys.Alt | Keys.F4;
            mnuFileExitApp.Size = new Size(199, 22);
            mnuFileExitApp.Text = "Exit";
            // 
            // mnuHelp
            // 
            mnuHelp.DropDownItems.AddRange(new ToolStripItem[] { mnuHelpAbout });
            mnuHelp.Name = "mnuHelp";
            mnuHelp.Size = new Size(44, 20);
            mnuHelp.Text = "&Help";
            // 
            // mnuHelpAbout
            // 
            mnuHelpAbout.Name = "mnuHelpAbout";
            mnuHelpAbout.ShortcutKeys = Keys.Control | Keys.Alt | Keys.A;
            mnuHelpAbout.Size = new Size(180, 22);
            mnuHelpAbout.Text = "&About";
            mnuHelpAbout.Click += aboutToolStripMenuItem_Click;
            // 
            // lstAnimals
            // 
            lstAnimals.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lstAnimals.FormattingEnabled = true;
            lstAnimals.Location = new Point(12, 245);
            lstAnimals.Name = "lstAnimals";
            lstAnimals.Size = new Size(407, 184);
            lstAnimals.TabIndex = 7;
            lstAnimals.SelectedIndexChanged += lstAnimals_SelectedIndexChanged;
            // 
            // btnChange
            // 
            btnChange.Location = new Point(12, 448);
            btnChange.Name = "btnChange";
            btnChange.Size = new Size(159, 33);
            btnChange.TabIndex = 8;
            btnChange.Text = "Change";
            btnChange.UseVisualStyleBackColor = true;
            btnChange.Click += btnChange_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(301, 448);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(118, 33);
            btnDelete.TabIndex = 9;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // lblSpecies
            // 
            lblSpecies.AutoSize = true;
            lblSpecies.Location = new Point(12, 227);
            lblSpecies.Name = "lblSpecies";
            lblSpecies.Size = new Size(46, 15);
            lblSpecies.TabIndex = 11;
            lblSpecies.Text = "Species";
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(90, 227);
            lblId.Name = "lblId";
            lblId.Size = new Size(18, 15);
            lblId.TabIndex = 12;
            lblId.Text = "ID";
            // 
            // lblNameLst
            // 
            lblNameLst.AutoSize = true;
            lblNameLst.Location = new Point(144, 227);
            lblNameLst.Name = "lblNameLst";
            lblNameLst.Size = new Size(39, 15);
            lblNameLst.TabIndex = 13;
            lblNameLst.Text = "Name";
            // 
            // lblAgeLst
            // 
            lblAgeLst.AutoSize = true;
            lblAgeLst.Location = new Point(245, 227);
            lblAgeLst.Name = "lblAgeLst";
            lblAgeLst.Size = new Size(28, 15);
            lblAgeLst.TabIndex = 14;
            lblAgeLst.Text = "Age";
            // 
            // lblWeightLst
            // 
            lblWeightLst.AutoSize = true;
            lblWeightLst.Location = new Point(301, 227);
            lblWeightLst.Name = "lblWeightLst";
            lblWeightLst.Size = new Size(45, 15);
            lblWeightLst.TabIndex = 15;
            lblWeightLst.Text = "Weight";
            // 
            // lblGenderLst
            // 
            lblGenderLst.AutoSize = true;
            lblGenderLst.Location = new Point(374, 227);
            lblGenderLst.Name = "lblGenderLst";
            lblGenderLst.Size = new Size(45, 15);
            lblGenderLst.TabIndex = 16;
            lblGenderLst.Text = "Gender";
            // 
            // rtxtAdditionalData
            // 
            rtxtAdditionalData.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rtxtAdditionalData.Location = new Point(624, 227);
            rtxtAdditionalData.Name = "rtxtAdditionalData";
            rtxtAdditionalData.ReadOnly = true;
            rtxtAdditionalData.Size = new Size(262, 254);
            rtxtAdditionalData.TabIndex = 17;
            rtxtAdditionalData.Text = "";
            // 
            // btnClearSelection
            // 
            btnClearSelection.Location = new Point(177, 448);
            btnClearSelection.Name = "btnClearSelection";
            btnClearSelection.Size = new Size(118, 33);
            btnClearSelection.TabIndex = 18;
            btnClearSelection.Text = "Clear Selection";
            btnClearSelection.UseVisualStyleBackColor = true;
            btnClearSelection.Click += btnClearSelection_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(898, 493);
            Controls.Add(btnClearSelection);
            Controls.Add(rtxtAdditionalData);
            Controls.Add(lblGenderLst);
            Controls.Add(lblWeightLst);
            Controls.Add(lblAgeLst);
            Controls.Add(lblNameLst);
            Controls.Add(lblId);
            Controls.Add(lblSpecies);
            Controls.Add(btnDelete);
            Controls.Add(btnChange);
            Controls.Add(lstAnimals);
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
            Text = "E-Animal Management System (V2)";
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
        private ToolStripMenuItem mnuFile;
        private ToolStripMenuItem mnuHelp;
        private ToolStripMenuItem mnuHelpAbout;
        private ToolStripMenuItem mnuFileLoadImage;
        private ListBox lstAnimals;
        private Button btnChange;
        private Button btnDelete;
        private Label lblSpecies;
        private Label lblId;
        private Label lblNameLst;
        private Label lblAgeLst;
        private Label lblWeightLst;
        private Label lblGenderLst;
        private RichTextBox rtxtAdditionalData;
        private Button btnClearSelection;
        private ToolStripMenuItem mnuFileNew;
        private ToolStripMenuItem mnuFileOpen;
        private ToolStripMenuItem mnuFileSave;
        private ToolStripMenuItem mnuFileSaveAs;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem mnuFileExitApp;
    }
}
