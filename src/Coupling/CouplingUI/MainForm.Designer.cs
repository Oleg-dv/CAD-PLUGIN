namespace CouplingUI
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.centralHoleDiameterTextBox = new System.Windows.Forms.TextBox();
            this.couplingDiameterTextBox = new System.Windows.Forms.TextBox();
            this.smallHolesDiameterTextBox = new System.Windows.Forms.TextBox();
            this.couplingWidthTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.buildButton = new System.Windows.Forms.Button();
            this.smallHolesDiameterLabel = new System.Windows.Forms.Label();
            this.centralHoleDiameterLabel = new System.Windows.Forms.Label();
            this.couplingDiameterLabel = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.countOfSmallHolesComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Количество малых отверстий";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Диаметр малых отверстий";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(181, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Диаметр центрального отверстия";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Диаметр кольца";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Толщина кольца";
            // 
            // centralHoleDiameterTextBox
            // 
            this.centralHoleDiameterTextBox.Location = new System.Drawing.Point(202, 75);
            this.centralHoleDiameterTextBox.Name = "centralHoleDiameterTextBox";
            this.centralHoleDiameterTextBox.Size = new System.Drawing.Size(36, 20);
            this.centralHoleDiameterTextBox.TabIndex = 6;
            this.centralHoleDiameterTextBox.Text = "10";
            this.centralHoleDiameterTextBox.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // couplingDiameterTextBox
            // 
            this.couplingDiameterTextBox.Location = new System.Drawing.Point(202, 101);
            this.couplingDiameterTextBox.Name = "couplingDiameterTextBox";
            this.couplingDiameterTextBox.Size = new System.Drawing.Size(36, 20);
            this.couplingDiameterTextBox.TabIndex = 7;
            this.couplingDiameterTextBox.Text = "40";
            this.couplingDiameterTextBox.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // smallHolesDiameterTextBox
            // 
            this.smallHolesDiameterTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.smallHolesDiameterTextBox.Location = new System.Drawing.Point(202, 49);
            this.smallHolesDiameterTextBox.Name = "smallHolesDiameterTextBox";
            this.smallHolesDiameterTextBox.Size = new System.Drawing.Size(36, 20);
            this.smallHolesDiameterTextBox.TabIndex = 8;
            this.smallHolesDiameterTextBox.Text = "6";
            this.smallHolesDiameterTextBox.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // couplingWidthTextBox
            // 
            this.couplingWidthTextBox.Location = new System.Drawing.Point(202, 127);
            this.couplingWidthTextBox.Name = "couplingWidthTextBox";
            this.couplingWidthTextBox.Size = new System.Drawing.Size(36, 20);
            this.couplingWidthTextBox.TabIndex = 9;
            this.couplingWidthTextBox.Text = "10";
            this.couplingWidthTextBox.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(169, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Параметры построения модели";
            // 
            // buildButton
            // 
            this.buildButton.Location = new System.Drawing.Point(318, 206);
            this.buildButton.Name = "buildButton";
            this.buildButton.Size = new System.Drawing.Size(75, 23);
            this.buildButton.TabIndex = 12;
            this.buildButton.Text = "Построить";
            this.buildButton.UseVisualStyleBackColor = true;
            this.buildButton.Click += new System.EventHandler(this.buildButton_Click);
            // 
            // smallHolesDiameterLabel
            // 
            this.smallHolesDiameterLabel.AutoSize = true;
            this.smallHolesDiameterLabel.Location = new System.Drawing.Point(244, 56);
            this.smallHolesDiameterLabel.Name = "smallHolesDiameterLabel";
            this.smallHolesDiameterLabel.Size = new System.Drawing.Size(95, 13);
            this.smallHolesDiameterLabel.TabIndex = 13;
            this.smallHolesDiameterLabel.Text = "от 6 мм до 24 мм";
            // 
            // centralHoleDiameterLabel
            // 
            this.centralHoleDiameterLabel.AutoSize = true;
            this.centralHoleDiameterLabel.Location = new System.Drawing.Point(245, 81);
            this.centralHoleDiameterLabel.Name = "centralHoleDiameterLabel";
            this.centralHoleDiameterLabel.Size = new System.Drawing.Size(101, 13);
            this.centralHoleDiameterLabel.TabIndex = 15;
            this.centralHoleDiameterLabel.Text = "от 10 мм до 30 мм";
            // 
            // couplingDiameterLabel
            // 
            this.couplingDiameterLabel.AutoSize = true;
            this.couplingDiameterLabel.Location = new System.Drawing.Point(245, 107);
            this.couplingDiameterLabel.Name = "couplingDiameterLabel";
            this.couplingDiameterLabel.Size = new System.Drawing.Size(101, 13);
            this.couplingDiameterLabel.TabIndex = 16;
            this.couplingDiameterLabel.Text = "от 40 мм до 70 мм";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(245, 133);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(101, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "от 10 мм до 50 мм";
            // 
            // countOfSmallHolesComboBox
            // 
            this.countOfSmallHolesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.countOfSmallHolesComboBox.FormattingEnabled = true;
            this.countOfSmallHolesComboBox.Items.AddRange(new object[] {
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.countOfSmallHolesComboBox.Location = new System.Drawing.Point(202, 22);
            this.countOfSmallHolesComboBox.Name = "countOfSmallHolesComboBox";
            this.countOfSmallHolesComboBox.Size = new System.Drawing.Size(36, 21);
            this.countOfSmallHolesComboBox.TabIndex = 18;
            this.countOfSmallHolesComboBox.Leave += new System.EventHandler(this.countOfSmallHolesComboBox_Leave);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.countOfSmallHolesComboBox);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.couplingDiameterLabel);
            this.groupBox1.Controls.Add(this.centralHoleDiameterLabel);
            this.groupBox1.Controls.Add(this.smallHolesDiameterLabel);
            this.groupBox1.Controls.Add(this.couplingWidthTextBox);
            this.groupBox1.Controls.Add(this.smallHolesDiameterTextBox);
            this.groupBox1.Controls.Add(this.couplingDiameterTextBox);
            this.groupBox1.Controls.Add(this.centralHoleDiameterTextBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(381, 160);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Параметры";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 240);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buildButton);
            this.Controls.Add(this.label6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox centralHoleDiameterTextBox;
        private System.Windows.Forms.TextBox couplingDiameterTextBox;
        private System.Windows.Forms.TextBox smallHolesDiameterTextBox;
        private System.Windows.Forms.TextBox couplingWidthTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buildButton;
        private System.Windows.Forms.Label smallHolesDiameterLabel;
        private System.Windows.Forms.Label centralHoleDiameterLabel;
        private System.Windows.Forms.Label couplingDiameterLabel;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox countOfSmallHolesComboBox;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

