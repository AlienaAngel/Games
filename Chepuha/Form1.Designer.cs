namespace Chepuha
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.generate_btn = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.loadBase_btn = new System.Windows.Forms.Button();
            this.aboutProgram_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // generate_btn
            // 
            this.generate_btn.BackColor = System.Drawing.Color.DarkSlateGray;
            this.generate_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.generate_btn.ForeColor = System.Drawing.Color.White;
            this.generate_btn.Location = new System.Drawing.Point(228, 30);
            this.generate_btn.Name = "generate_btn";
            this.generate_btn.Size = new System.Drawing.Size(124, 23);
            this.generate_btn.TabIndex = 0;
            this.generate_btn.Text = "Сгенерировать бред";
            this.generate_btn.UseVisualStyleBackColor = false;
            this.generate_btn.Click += new System.EventHandler(this.generate_btn_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox1.ForeColor = System.Drawing.Color.White;
            this.richTextBox1.Location = new System.Drawing.Point(12, 59);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(521, 387);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(12, 33);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(129, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "base.txt";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(254, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Название файла с базой (по умолчанию base.txt)";
            // 
            // loadBase_btn
            // 
            this.loadBase_btn.BackColor = System.Drawing.Color.DarkSlateGray;
            this.loadBase_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadBase_btn.ForeColor = System.Drawing.Color.White;
            this.loadBase_btn.Location = new System.Drawing.Point(147, 30);
            this.loadBase_btn.Name = "loadBase_btn";
            this.loadBase_btn.Size = new System.Drawing.Size(75, 23);
            this.loadBase_btn.TabIndex = 4;
            this.loadBase_btn.Text = "Загрузить";
            this.loadBase_btn.UseVisualStyleBackColor = false;
            this.loadBase_btn.Click += new System.EventHandler(this.loadBase_btn_Click);
            // 
            // aboutProgram_btn
            // 
            this.aboutProgram_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.aboutProgram_btn.BackColor = System.Drawing.Color.DarkSlateGray;
            this.aboutProgram_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.aboutProgram_btn.ForeColor = System.Drawing.Color.White;
            this.aboutProgram_btn.Location = new System.Drawing.Point(442, 30);
            this.aboutProgram_btn.Name = "aboutProgram_btn";
            this.aboutProgram_btn.Size = new System.Drawing.Size(91, 23);
            this.aboutProgram_btn.TabIndex = 5;
            this.aboutProgram_btn.Text = "О Программе";
            this.aboutProgram_btn.UseVisualStyleBackColor = false;
            this.aboutProgram_btn.Click += new System.EventHandler(this.aboutProgram_btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(545, 458);
            this.Controls.Add(this.aboutProgram_btn);
            this.Controls.Add(this.loadBase_btn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.generate_btn);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(561, 473);
            this.Name = "Form1";
            this.Text = "Чепуха";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DoubleClick += new System.EventHandler(this.Form1_DoubleClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button generate_btn;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button loadBase_btn;
        private System.Windows.Forms.Button aboutProgram_btn;
    }
}

