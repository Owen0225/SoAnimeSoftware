namespace Hyper_Useful_Injector
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.pathSelectButton = new System.Windows.Forms.Button();
            this.mainMethodTextBox = new System.Windows.Forms.TextBox();
            this.mainMethodCheckBox = new System.Windows.Forms.CheckBox();
            this.processComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.injectButton = new System.Windows.Forms.Button();
            this.closeCheckBox = new System.Windows.Forms.CheckBox();
            this.doCopyCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // pathTextBox
            // 
            this.pathTextBox.Location = new System.Drawing.Point(12, 70);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.Size = new System.Drawing.Size(258, 20);
            this.pathTextBox.TabIndex = 1;
            // 
            // pathSelectButton
            // 
            this.pathSelectButton.Location = new System.Drawing.Point(276, 69);
            this.pathSelectButton.Name = "pathSelectButton";
            this.pathSelectButton.Size = new System.Drawing.Size(46, 22);
            this.pathSelectButton.TabIndex = 2;
            this.pathSelectButton.Text = "Select";
            this.pathSelectButton.UseVisualStyleBackColor = true;
            this.pathSelectButton.Click += new System.EventHandler(this.pathSelectButton_Click);
            // 
            // mainMethodTextBox
            // 
            this.mainMethodTextBox.Location = new System.Drawing.Point(12, 119);
            this.mainMethodTextBox.Name = "mainMethodTextBox";
            this.mainMethodTextBox.Size = new System.Drawing.Size(100, 20);
            this.mainMethodTextBox.TabIndex = 3;
            this.mainMethodTextBox.TextChanged += new System.EventHandler(this.mainMethodTextBox_TextChanged);
            // 
            // mainMethodCheckBox
            // 
            this.mainMethodCheckBox.AutoSize = true;
            this.mainMethodCheckBox.Location = new System.Drawing.Point(12, 96);
            this.mainMethodCheckBox.Name = "mainMethodCheckBox";
            this.mainMethodCheckBox.Size = new System.Drawing.Size(87, 17);
            this.mainMethodCheckBox.TabIndex = 4;
            this.mainMethodCheckBox.Text = "Main method";
            this.mainMethodCheckBox.UseVisualStyleBackColor = true;
            this.mainMethodCheckBox.CheckedChanged += new System.EventHandler(this.mainMethodCheckBox_CheckedChanged);
            // 
            // processComboBox
            // 
            this.processComboBox.FormattingEnabled = true;
            this.processComboBox.Location = new System.Drawing.Point(12, 30);
            this.processComboBox.Name = "processComboBox";
            this.processComboBox.Size = new System.Drawing.Size(310, 21);
            this.processComboBox.TabIndex = 5;
            this.processComboBox.DropDown += new System.EventHandler(this.processComboBox_DropDown);
            this.processComboBox.TextUpdate += new System.EventHandler(this.processComboBox_TextUpdate);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Path";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Process";
            // 
            // injectButton
            // 
            this.injectButton.Location = new System.Drawing.Point(247, 117);
            this.injectButton.Name = "injectButton";
            this.injectButton.Size = new System.Drawing.Size(75, 23);
            this.injectButton.TabIndex = 8;
            this.injectButton.Text = "Inject";
            this.injectButton.UseVisualStyleBackColor = true;
            this.injectButton.Click += new System.EventHandler(this.injectButton_Click);
            // 
            // closeCheckBox
            // 
            this.closeCheckBox.AutoSize = true;
            this.closeCheckBox.Checked = true;
            this.closeCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.closeCheckBox.Location = new System.Drawing.Point(161, 121);
            this.closeCheckBox.Name = "closeCheckBox";
            this.closeCheckBox.Size = new System.Drawing.Size(76, 17);
            this.closeCheckBox.TabIndex = 9;
            this.closeCheckBox.Text = "Auto close";
            this.closeCheckBox.UseVisualStyleBackColor = true;
            this.closeCheckBox.CheckedChanged += new System.EventHandler(this.closeCheckBox_CheckedChanged);
            // 
            // doCopyCheckBox
            // 
            this.doCopyCheckBox.AutoSize = true;
            this.doCopyCheckBox.Checked = true;
            this.doCopyCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.doCopyCheckBox.Location = new System.Drawing.Point(161, 96);
            this.doCopyCheckBox.Name = "doCopyCheckBox";
            this.doCopyCheckBox.Size = new System.Drawing.Size(50, 17);
            this.doCopyCheckBox.TabIndex = 10;
            this.doCopyCheckBox.Text = "Copy";
            this.doCopyCheckBox.UseVisualStyleBackColor = true;
            this.doCopyCheckBox.CheckedChanged += new System.EventHandler(this.doCopyCheckBox_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 154);
            this.Controls.Add(this.doCopyCheckBox);
            this.Controls.Add(this.closeCheckBox);
            this.Controls.Add(this.injectButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.processComboBox);
            this.Controls.Add(this.mainMethodCheckBox);
            this.Controls.Add(this.mainMethodTextBox);
            this.Controls.Add(this.pathSelectButton);
            this.Controls.Add(this.pathTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "HUI";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.CheckBox doCopyCheckBox;

        #endregion
        private System.Windows.Forms.TextBox pathTextBox;
        private System.Windows.Forms.Button pathSelectButton;
        private System.Windows.Forms.TextBox mainMethodTextBox;
        private System.Windows.Forms.CheckBox mainMethodCheckBox;
        private System.Windows.Forms.ComboBox processComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button injectButton;
        private System.Windows.Forms.CheckBox closeCheckBox;
    }
}

