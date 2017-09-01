namespace IndicatorMagic2
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btn_go = new System.Windows.Forms.Button();
            this.txtbx_seconds = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_browse = new System.Windows.Forms.Button();
            this.txtbx_xml_filepath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkbx_repeat = new System.Windows.Forms.CheckBox();
            this.btn_stop = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 173);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(742, 386);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // btn_go
            // 
            this.btn_go.Location = new System.Drawing.Point(599, 132);
            this.btn_go.Name = "btn_go";
            this.btn_go.Size = new System.Drawing.Size(75, 23);
            this.btn_go.TabIndex = 3;
            this.btn_go.Text = "Go!";
            this.btn_go.UseVisualStyleBackColor = true;
            this.btn_go.Click += new System.EventHandler(this.btn_go_Click);
            // 
            // txtbx_seconds
            // 
            this.txtbx_seconds.Location = new System.Drawing.Point(440, 132);
            this.txtbx_seconds.Name = "txtbx_seconds";
            this.txtbx_seconds.Size = new System.Drawing.Size(100, 20);
            this.txtbx_seconds.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(357, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Repeat every: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(546, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "seconds";
            // 
            // btn_browse
            // 
            this.btn_browse.Location = new System.Drawing.Point(650, 103);
            this.btn_browse.Name = "btn_browse";
            this.btn_browse.Size = new System.Drawing.Size(75, 23);
            this.btn_browse.TabIndex = 7;
            this.btn_browse.Text = "Browse";
            this.btn_browse.UseVisualStyleBackColor = true;
            this.btn_browse.Click += new System.EventHandler(this.btn_browse_Click);
            // 
            // txtbx_xml_filepath
            // 
            this.txtbx_xml_filepath.Location = new System.Drawing.Point(16, 103);
            this.txtbx_xml_filepath.Name = "txtbx_xml_filepath";
            this.txtbx_xml_filepath.Size = new System.Drawing.Size(614, 20);
            this.txtbx_xml_filepath.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Goudy Stout", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(129, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(444, 74);
            this.label1.TabIndex = 9;
            this.label1.Text = "Indicators Are\r\nMagic!";
            // 
            // chkbx_repeat
            // 
            this.chkbx_repeat.AutoSize = true;
            this.chkbx_repeat.Location = new System.Drawing.Point(336, 132);
            this.chkbx_repeat.Name = "chkbx_repeat";
            this.chkbx_repeat.Size = new System.Drawing.Size(15, 14);
            this.chkbx_repeat.TabIndex = 10;
            this.chkbx_repeat.UseVisualStyleBackColor = true;
            // 
            // btn_stop
            // 
            this.btn_stop.Location = new System.Drawing.Point(681, 133);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(75, 23);
            this.btn_stop.TabIndex = 11;
            this.btn_stop.Text = "Stop!";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Image = global::IndicatorMagic2.Properties.Resources.pony_head;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.MinimumSize = new System.Drawing.Size(100, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 80);
            this.label4.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Image = global::IndicatorMagic2.Properties.Resources.Logo_Small_v6;
            this.label5.Location = new System.Drawing.Point(589, 0);
            this.label5.MinimumSize = new System.Drawing.Size(160, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(160, 100);
            this.label5.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 581);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_stop);
            this.Controls.Add(this.chkbx_repeat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtbx_xml_filepath);
            this.Controls.Add(this.btn_browse);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtbx_seconds);
            this.Controls.Add(this.btn_go);
            this.Controls.Add(this.richTextBox1);
            this.Name = "Form1";
            this.Text = "Indicator Magic";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btn_go;
        private System.Windows.Forms.TextBox txtbx_seconds;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_browse;
        private System.Windows.Forms.TextBox txtbx_xml_filepath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkbx_repeat;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}

