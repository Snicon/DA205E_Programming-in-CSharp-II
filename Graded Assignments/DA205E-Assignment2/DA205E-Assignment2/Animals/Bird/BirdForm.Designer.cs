namespace DA205E_Assignment1.Animals.Bird
{
    partial class BirdForm
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
            grpCategory = new GroupBox();
            cmbBeakType = new ComboBox();
            lblBeakType = new Label();
            txtWingspan = new TextBox();
            lblWingspan = new Label();
            grpSpecificToAnimal = new GroupBox();
            txtSpecificToAnimal1 = new TextBox();
            lblSpecificToAnimal1 = new Label();
            btnOK = new Button();
            btnCancel = new Button();
            grpCategory.SuspendLayout();
            grpSpecificToAnimal.SuspendLayout();
            SuspendLayout();
            // 
            // grpCategory
            // 
            grpCategory.Controls.Add(cmbBeakType);
            grpCategory.Controls.Add(lblBeakType);
            grpCategory.Controls.Add(txtWingspan);
            grpCategory.Controls.Add(lblWingspan);
            grpCategory.Location = new Point(12, 12);
            grpCategory.Name = "grpCategory";
            grpCategory.Size = new Size(328, 85);
            grpCategory.TabIndex = 0;
            grpCategory.TabStop = false;
            grpCategory.Text = "General Bird Data";
            // 
            // cmbBeakType
            // 
            cmbBeakType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBeakType.FormattingEnabled = true;
            cmbBeakType.Location = new Point(160, 49);
            cmbBeakType.Name = "cmbBeakType";
            cmbBeakType.Size = new Size(162, 23);
            cmbBeakType.TabIndex = 3;
            // 
            // lblBeakType
            // 
            lblBeakType.AutoSize = true;
            lblBeakType.Location = new Point(6, 52);
            lblBeakType.Name = "lblBeakType";
            lblBeakType.Size = new Size(58, 15);
            lblBeakType.TabIndex = 2;
            lblBeakType.Text = "Beak type";
            // 
            // txtWingspan
            // 
            txtWingspan.Location = new Point(160, 19);
            txtWingspan.Name = "txtWingspan";
            txtWingspan.Size = new Size(162, 23);
            txtWingspan.TabIndex = 1;
            // 
            // lblWingspan
            // 
            lblWingspan.AutoSize = true;
            lblWingspan.Location = new Point(6, 22);
            lblWingspan.Name = "lblWingspan";
            lblWingspan.Size = new Size(60, 15);
            lblWingspan.TabIndex = 0;
            lblWingspan.Text = "Wingspan";
            // 
            // grpSpecificToAnimal
            // 
            grpSpecificToAnimal.Controls.Add(txtSpecificToAnimal1);
            grpSpecificToAnimal.Controls.Add(lblSpecificToAnimal1);
            grpSpecificToAnimal.Location = new Point(12, 119);
            grpSpecificToAnimal.Name = "grpSpecificToAnimal";
            grpSpecificToAnimal.Size = new Size(328, 237);
            grpSpecificToAnimal.TabIndex = 1;
            grpSpecificToAnimal.TabStop = false;
            grpSpecificToAnimal.Text = "Specific data to <ANIMAL>";
            // 
            // txtSpecificToAnimal1
            // 
            txtSpecificToAnimal1.Location = new Point(160, 25);
            txtSpecificToAnimal1.Name = "txtSpecificToAnimal1";
            txtSpecificToAnimal1.Size = new Size(162, 23);
            txtSpecificToAnimal1.TabIndex = 2;
            // 
            // lblSpecificToAnimal1
            // 
            lblSpecificToAnimal1.AutoSize = true;
            lblSpecificToAnimal1.Location = new Point(6, 28);
            lblSpecificToAnimal1.Name = "lblSpecificToAnimal1";
            lblSpecificToAnimal1.Size = new Size(110, 15);
            lblSpecificToAnimal1.TabIndex = 1;
            lblSpecificToAnimal1.Text = "Specific to animal 1";
            // 
            // btnOK
            // 
            btnOK.DialogResult = DialogResult.OK;
            btnOK.Location = new Point(12, 380);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(144, 31);
            btnOK.TabIndex = 3;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(196, 380);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(144, 31);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // BirdForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(352, 423);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(grpSpecificToAnimal);
            Controls.Add(grpCategory);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "BirdForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Animal Specifications";
            grpCategory.ResumeLayout(false);
            grpCategory.PerformLayout();
            grpSpecificToAnimal.ResumeLayout(false);
            grpSpecificToAnimal.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpCategory;
        private Label lblWingspan;
        private TextBox txtWingspan;
        private Label lblBeakType;
        private ComboBox cmbBeakType;
        private GroupBox grpSpecificToAnimal;
        private Button btnOK;
        private Button btnCancel;
        private Label lblSpecificToAnimal1;
        private TextBox txtSpecificToAnimal1;
    }
}