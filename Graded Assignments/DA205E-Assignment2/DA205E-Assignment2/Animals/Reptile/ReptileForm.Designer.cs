namespace DA205E_Assignment1.Animals.Reptile
{
    partial class ReptileForm
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
            chkCanRegrowTail = new CheckBox();
            chkLivesInWater = new CheckBox();
            grpSpecificToAnimal = new GroupBox();
            chkVenomous = new CheckBox();
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
            grpCategory.Controls.Add(chkCanRegrowTail);
            grpCategory.Controls.Add(chkLivesInWater);
            grpCategory.Location = new Point(12, 12);
            grpCategory.Name = "grpCategory";
            grpCategory.Size = new Size(328, 74);
            grpCategory.TabIndex = 0;
            grpCategory.TabStop = false;
            grpCategory.Text = "General Reptile Data";
            // 
            // chkCanRegrowTail
            // 
            chkCanRegrowTail.AutoSize = true;
            chkCanRegrowTail.Location = new Point(6, 47);
            chkCanRegrowTail.Name = "chkCanRegrowTail";
            chkCanRegrowTail.Size = new Size(106, 19);
            chkCanRegrowTail.TabIndex = 2;
            chkCanRegrowTail.Text = "Can regrow tail";
            chkCanRegrowTail.UseVisualStyleBackColor = true;
            // 
            // chkLivesInWater
            // 
            chkLivesInWater.AutoSize = true;
            chkLivesInWater.Location = new Point(6, 22);
            chkLivesInWater.Name = "chkLivesInWater";
            chkLivesInWater.Size = new Size(97, 19);
            chkLivesInWater.TabIndex = 1;
            chkLivesInWater.Text = "Lives in water";
            chkLivesInWater.UseVisualStyleBackColor = true;
            // 
            // grpSpecificToAnimal
            // 
            grpSpecificToAnimal.Controls.Add(chkVenomous);
            grpSpecificToAnimal.Controls.Add(txtSpecificToAnimal1);
            grpSpecificToAnimal.Controls.Add(lblSpecificToAnimal1);
            grpSpecificToAnimal.Location = new Point(12, 105);
            grpSpecificToAnimal.Name = "grpSpecificToAnimal";
            grpSpecificToAnimal.Size = new Size(328, 250);
            grpSpecificToAnimal.TabIndex = 1;
            grpSpecificToAnimal.TabStop = false;
            grpSpecificToAnimal.Text = "Specific data to <ANIMAL>";
            // 
            // chkVenomous
            // 
            chkVenomous.AutoSize = true;
            chkVenomous.Location = new Point(6, 59);
            chkVenomous.Name = "chkVenomous";
            chkVenomous.Size = new Size(82, 19);
            chkVenomous.TabIndex = 2;
            chkVenomous.Text = "Venomous";
            chkVenomous.UseVisualStyleBackColor = true;
            chkVenomous.Visible = false;
            // 
            // txtSpecificToAnimal1
            // 
            txtSpecificToAnimal1.Location = new Point(160, 25);
            txtSpecificToAnimal1.Name = "txtSpecificToAnimal1";
            txtSpecificToAnimal1.Size = new Size(162, 23);
            txtSpecificToAnimal1.TabIndex = 1;
            txtSpecificToAnimal1.Visible = false;
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
            // btnOK
            // 
            btnOK.DialogResult = DialogResult.OK;
            btnOK.Location = new Point(12, 380);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(144, 31);
            btnOK.TabIndex = 2;
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
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // ReptileForm
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
            Name = "ReptileForm";
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
        private CheckBox chkLivesInWater;
        private CheckBox chkCanRegrowTail;
        private GroupBox grpSpecificToAnimal;
        private Button btnOK;
        private Button btnCancel;
        private Label lblSpecificToAnimal1;
        private TextBox txtSpecificToAnimal1;
        private CheckBox chkVenomous;
    }
}