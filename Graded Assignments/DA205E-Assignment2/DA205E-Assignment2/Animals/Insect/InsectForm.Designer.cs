namespace DA205E_Assignment1.Animals.Insect
{
    partial class InsectForm
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
            chkHasWings = new CheckBox();
            cmbLifecycleStage = new ComboBox();
            lblLifecycleStage = new Label();
            grpSpecificToAnimal = new GroupBox();
            cmbSpecificToAnimal1 = new ComboBox();
            lblSpecificToAnimal1 = new Label();
            btnCancel = new Button();
            btnOK = new Button();
            grpCategory.SuspendLayout();
            grpSpecificToAnimal.SuspendLayout();
            SuspendLayout();
            // 
            // grpCategory
            // 
            grpCategory.Controls.Add(chkHasWings);
            grpCategory.Controls.Add(cmbLifecycleStage);
            grpCategory.Controls.Add(lblLifecycleStage);
            grpCategory.Location = new Point(12, 12);
            grpCategory.Name = "grpCategory";
            grpCategory.Size = new Size(328, 85);
            grpCategory.TabIndex = 1;
            grpCategory.TabStop = false;
            grpCategory.Text = "General Insect Data";
            // 
            // chkHasWings
            // 
            chkHasWings.AutoSize = true;
            chkHasWings.Location = new Point(6, 22);
            chkHasWings.Name = "chkHasWings";
            chkHasWings.Size = new Size(80, 19);
            chkHasWings.TabIndex = 4;
            chkHasWings.Text = "Has wings";
            chkHasWings.UseVisualStyleBackColor = true;
            // 
            // cmbLifecycleStage
            // 
            cmbLifecycleStage.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLifecycleStage.FormattingEnabled = true;
            cmbLifecycleStage.Location = new Point(160, 49);
            cmbLifecycleStage.Name = "cmbLifecycleStage";
            cmbLifecycleStage.Size = new Size(162, 23);
            cmbLifecycleStage.TabIndex = 3;
            // 
            // lblLifecycleStage
            // 
            lblLifecycleStage.AutoSize = true;
            lblLifecycleStage.Location = new Point(6, 52);
            lblLifecycleStage.Name = "lblLifecycleStage";
            lblLifecycleStage.Size = new Size(84, 15);
            lblLifecycleStage.TabIndex = 2;
            lblLifecycleStage.Text = "Lifecycle stage";
            // 
            // grpSpecificToAnimal
            // 
            grpSpecificToAnimal.Controls.Add(cmbSpecificToAnimal1);
            grpSpecificToAnimal.Controls.Add(lblSpecificToAnimal1);
            grpSpecificToAnimal.Location = new Point(12, 118);
            grpSpecificToAnimal.Name = "grpSpecificToAnimal";
            grpSpecificToAnimal.Size = new Size(328, 237);
            grpSpecificToAnimal.TabIndex = 4;
            grpSpecificToAnimal.TabStop = false;
            grpSpecificToAnimal.Text = "Specific data to <ANIMAL>";
            // 
            // cmbSpecificToAnimal1
            // 
            cmbSpecificToAnimal1.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSpecificToAnimal1.FormattingEnabled = true;
            cmbSpecificToAnimal1.Location = new Point(160, 25);
            cmbSpecificToAnimal1.Name = "cmbSpecificToAnimal1";
            cmbSpecificToAnimal1.Size = new Size(162, 23);
            cmbSpecificToAnimal1.TabIndex = 4;
            // 
            // lblSpecificToAnimal1
            // 
            lblSpecificToAnimal1.AutoSize = true;
            lblSpecificToAnimal1.Location = new Point(6, 28);
            lblSpecificToAnimal1.Name = "lblSpecificToAnimal1";
            lblSpecificToAnimal1.Size = new Size(110, 15);
            lblSpecificToAnimal1.TabIndex = 0;
            lblSpecificToAnimal1.Text = "Specific to animal 1";
            lblSpecificToAnimal1.Visible = false;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(196, 380);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(144, 31);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            btnOK.DialogResult = DialogResult.OK;
            btnOK.Location = new Point(12, 380);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(144, 31);
            btnOK.TabIndex = 5;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // InsectForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(352, 423);
            Controls.Add(grpSpecificToAnimal);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(grpCategory);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "InsectForm";
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
        private ComboBox cmbLifecycleStage;
        private Label lblLifecycleStage;
        private CheckBox chkHasWings;
        private GroupBox grpSpecificToAnimal;
        private Label lblSpecificToAnimal1;
        private Button btnCancel;
        private Button btnOK;
        private ComboBox cmbSpecificToAnimal1;
    }
}