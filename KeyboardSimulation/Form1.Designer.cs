namespace KeyboardSimulation
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.xTextBox1 = new System.Windows.Forms.TextBox();
            this.xLabel1 = new System.Windows.Forms.Label();
            this.hitButton = new System.Windows.Forms.Button();
            this.startTimer = new System.Windows.Forms.Timer(this.components);
            this.repeatTimer = new System.Windows.Forms.Timer(this.components);
            this.selectButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // xTextBox1
            // 
            this.xTextBox1.Enabled = false;
            this.xTextBox1.Location = new System.Drawing.Point(126, 134);
            this.xTextBox1.Name = "xTextBox1";
            this.xTextBox1.Size = new System.Drawing.Size(114, 20);
            this.xTextBox1.TabIndex = 1;
            this.xTextBox1.TextChanged += new System.EventHandler(this.xTextBox1_TextChanged);
            this.xTextBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.xTextBox1_KeyPress);
            // 
            // xLabel1
            // 
            this.xLabel1.AutoSize = true;
            this.xLabel1.Location = new System.Drawing.Point(105, 137);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(15, 13);
            this.xLabel1.TabIndex = 2;
            this.xLabel1.Text = "x:";
            // 
            // hitButton
            // 
            this.hitButton.Enabled = false;
            this.hitButton.Location = new System.Drawing.Point(165, 160);
            this.hitButton.Name = "hitButton";
            this.hitButton.Size = new System.Drawing.Size(75, 23);
            this.hitButton.TabIndex = 3;
            this.hitButton.Text = "Hit";
            this.hitButton.UseVisualStyleBackColor = true;
            this.hitButton.Click += new System.EventHandler(this.hitButton_Click);
            // 
            // selectButton
            // 
            this.selectButton.Location = new System.Drawing.Point(115, 47);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(125, 23);
            this.selectButton.TabIndex = 4;
            this.selectButton.Text = "Select Program";
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Enter process name:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(126, 89);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(114, 20);
            this.textBox1.TabIndex = 6;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(168, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "or";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1, 235);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Selected Program:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(132, 232);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(140, 20);
            this.textBox2.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(215, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Run process first...then select its executable";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.selectButton);
            this.Controls.Add(this.hitButton);
            this.Controls.Add(this.xLabel1);
            this.Controls.Add(this.xTextBox1);
            this.Name = "Form1";
            this.Text = "Keyboard Simulation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox xTextBox1;
        private System.Windows.Forms.Label xLabel1;
        private System.Windows.Forms.Button hitButton;
        private System.Windows.Forms.Timer startTimer;
        private System.Windows.Forms.Timer repeatTimer;
        private System.Windows.Forms.Button selectButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;
    }
}

