namespace PrinterSharing
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LocalPrinterListView = new System.Windows.Forms.ListView();
            this.listView1 = new System.Windows.Forms.ListView();
            this.ShareBtn = new System.Windows.Forms.Button();
            this.stsLabel = new System.Windows.Forms.Label();
            this.header = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Local Printers";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 299);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Remote Printers";
            // 
            // LocalPrinterListView
            // 
            this.LocalPrinterListView.FullRowSelect = true;
            this.LocalPrinterListView.LabelWrap = false;
            this.LocalPrinterListView.Location = new System.Drawing.Point(12, 146);
            this.LocalPrinterListView.MultiSelect = false;
            this.LocalPrinterListView.Name = "LocalPrinterListView";
            this.LocalPrinterListView.Size = new System.Drawing.Size(360, 100);
            this.LocalPrinterListView.TabIndex = 3;
            this.LocalPrinterListView.UseCompatibleStateImageBehavior = false;
            this.LocalPrinterListView.View = System.Windows.Forms.View.Details;
            // 
            // listView1
            // 
            this.listView1.FullRowSelect = true;
            this.listView1.LabelWrap = false;
            this.listView1.Location = new System.Drawing.Point(12, 320);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(360, 100);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // ShareBtn
            // 
            this.ShareBtn.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ShareBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ShareBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShareBtn.Location = new System.Drawing.Point(12, 252);
            this.ShareBtn.Name = "ShareBtn";
            this.ShareBtn.Size = new System.Drawing.Size(100, 30);
            this.ShareBtn.TabIndex = 5;
            this.ShareBtn.Text = "Share";
            this.ShareBtn.UseVisualStyleBackColor = false;
            // 
            // stsLabel
            // 
            this.stsLabel.AutoSize = true;
            this.stsLabel.Location = new System.Drawing.Point(12, 569);
            this.stsLabel.Name = "stsLabel";
            this.stsLabel.Size = new System.Drawing.Size(0, 13);
            this.stsLabel.TabIndex = 6;
            // 
            // header
            // 
            this.header.Image = global::PrinterSharing.Properties.Resources.share;
            this.header.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.header.Location = new System.Drawing.Point(15, 13);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(370, 100);
            this.header.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 561);
            this.Controls.Add(this.header);
            this.Controls.Add(this.stsLabel);
            this.Controls.Add(this.ShareBtn);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.LocalPrinterListView);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Printer Sharing 1.0";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView LocalPrinterListView;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button ShareBtn;
        private System.Windows.Forms.Label stsLabel;
        private System.Windows.Forms.Label header;
    }
}

