namespace UnrealWarcraftInfo
{
    partial class War3InfoForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose ( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose( );
            }
            base.Dispose( disposing );
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent ( )
        {
            this.GenerateWar3Info = new System.Windows.Forms.Button();
            this.SaveIP = new System.Windows.Forms.CheckBox();
            this.GenerateProcessList = new System.Windows.Forms.CheckBox();
            this.PrintWar3ModuleList = new System.Windows.Forms.CheckBox();
            this.Warcraft3DirectoryInfo = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // GenerateWar3Info
            // 
            this.GenerateWar3Info.Location = new System.Drawing.Point(92, 221);
            this.GenerateWar3Info.Name = "GenerateWar3Info";
            this.GenerateWar3Info.Size = new System.Drawing.Size(103, 23);
            this.GenerateWar3Info.TabIndex = 0;
            this.GenerateWar3Info.Text = "Сгенерировать";
            this.GenerateWar3Info.UseVisualStyleBackColor = true;
            this.GenerateWar3Info.Click += new System.EventHandler(this.GenerateWar3Info_Click);
            // 
            // SaveIP
            // 
            this.SaveIP.AutoSize = true;
            this.SaveIP.Checked = true;
            this.SaveIP.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SaveIP.Location = new System.Drawing.Point(24, 19);
            this.SaveIP.Name = "SaveIP";
            this.SaveIP.Size = new System.Drawing.Size(115, 17);
            this.SaveIP.TabIndex = 1;
            this.SaveIP.Text = "Сохранить мой IP";
            this.SaveIP.UseVisualStyleBackColor = true;
            // 
            // GenerateProcessList
            // 
            this.GenerateProcessList.AutoSize = true;
            this.GenerateProcessList.Checked = true;
            this.GenerateProcessList.CheckState = System.Windows.Forms.CheckState.Checked;
            this.GenerateProcessList.Location = new System.Drawing.Point(24, 54);
            this.GenerateProcessList.Name = "GenerateProcessList";
            this.GenerateProcessList.Size = new System.Drawing.Size(175, 17);
            this.GenerateProcessList.TabIndex = 1;
            this.GenerateProcessList.Text = "Сохранить список процессов";
            this.GenerateProcessList.UseVisualStyleBackColor = true;
            // 
            // PrintWar3ModuleList
            // 
            this.PrintWar3ModuleList.AutoSize = true;
            this.PrintWar3ModuleList.Location = new System.Drawing.Point(24, 87);
            this.PrintWar3ModuleList.Name = "PrintWar3ModuleList";
            this.PrintWar3ModuleList.Size = new System.Drawing.Size(220, 17);
            this.PrintWar3ModuleList.TabIndex = 1;
            this.PrintWar3ModuleList.Text = "Сохранить список модулей Warcraft III";
            this.PrintWar3ModuleList.UseVisualStyleBackColor = true;
            // 
            // Warcraft3DirectoryInfo
            // 
            this.Warcraft3DirectoryInfo.AutoSize = true;
            this.Warcraft3DirectoryInfo.Location = new System.Drawing.Point(24, 120);
            this.Warcraft3DirectoryInfo.Name = "Warcraft3DirectoryInfo";
            this.Warcraft3DirectoryInfo.Size = new System.Drawing.Size(238, 17);
            this.Warcraft3DirectoryInfo.TabIndex = 1;
            this.Warcraft3DirectoryInfo.Text = "Сохранить содержимое папки Warcraft III ";
            this.Warcraft3DirectoryInfo.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 182);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Формат сохранения:";
            // 
            // comboBox1
            // 
            this.comboBox1.Enabled = false;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "BB-Code",
            "HTML-Code",
            "Обычный текст"});
            this.comboBox1.Location = new System.Drawing.Point(143, 178);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(90, 21);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.Text = "BB-Code";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Enabled = false;
            this.checkBox2.Location = new System.Drawing.Point(24, 153);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(235, 17);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "Сохранить дополнительную информацию";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // War3InfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.Warcraft3DirectoryInfo);
            this.Controls.Add(this.PrintWar3ModuleList);
            this.Controls.Add(this.GenerateProcessList);
            this.Controls.Add(this.SaveIP);
            this.Controls.Add(this.GenerateWar3Info);
            this.Name = "War3InfoForm";
            this.Text = "Generate Warcraft III Info";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button GenerateWar3Info;
        private System.Windows.Forms.CheckBox SaveIP;
        private System.Windows.Forms.CheckBox GenerateProcessList;
        private System.Windows.Forms.CheckBox PrintWar3ModuleList;
        private System.Windows.Forms.CheckBox Warcraft3DirectoryInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.CheckBox checkBox2;
    }
}

