namespace SuperGame
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
            this.newGame_btn = new System.Windows.Forms.Button();
            this.gameField = new System.Windows.Forms.Panel();
            this.gameField.SuspendLayout();
            this.SuspendLayout();
            // 
            // newGame_btn
            // 
            this.newGame_btn.Location = new System.Drawing.Point(5, 7);
            this.newGame_btn.Name = "newGame_btn";
            this.newGame_btn.Size = new System.Drawing.Size(75, 23);
            this.newGame_btn.TabIndex = 0;
            this.newGame_btn.Text = "Новая игра";
            this.newGame_btn.UseVisualStyleBackColor = true;
            this.newGame_btn.Click += new System.EventHandler(this.newGame_btn_Click);
            // 
            // gameField
            // 
            this.gameField.Controls.Add(this.newGame_btn);
            this.gameField.Location = new System.Drawing.Point(7, 5);
            this.gameField.Name = "gameField";
            this.gameField.Size = new System.Drawing.Size(615, 339);
            this.gameField.TabIndex = 1;
            this.gameField.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gameField_MouseClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 474);
            this.Controls.Add(this.gameField);
            this.Name = "Form1";
            this.Text = "Игра";
            this.gameField.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button newGame_btn;
        private System.Windows.Forms.Panel gameField;
    }
}

