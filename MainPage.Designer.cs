namespace BaslerTemplate
{
    partial class MainPage
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
            this.BaslerImage = new System.Windows.Forms.PictureBox();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.cbTools = new System.Windows.Forms.ComboBox();
            this.btnOpenTool = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ClassName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NumberofDetections = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtExposure = new System.Windows.Forms.TextBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.lblexposure = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.BaslerImage)).BeginInit();
            this.SuspendLayout();
            // 
            // BaslerImage
            // 
            this.BaslerImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BaslerImage.Location = new System.Drawing.Point(22, 108);
            this.BaslerImage.Name = "BaslerImage";
            this.BaslerImage.Size = new System.Drawing.Size(719, 479);
            this.BaslerImage.TabIndex = 0;
            this.BaslerImage.TabStop = false;
            // 
            // btnStartStop
            // 
            this.btnStartStop.Location = new System.Drawing.Point(321, 623);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(75, 23);
            this.btnStartStop.TabIndex = 1;
            this.btnStartStop.Text = "Start";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // cbTools
            // 
            this.cbTools.FormattingEnabled = true;
            this.cbTools.Items.AddRange(new object[] {
            "Height Sensor",
            "Light Controller"});
            this.cbTools.Location = new System.Drawing.Point(884, 39);
            this.cbTools.Name = "cbTools";
            this.cbTools.Size = new System.Drawing.Size(121, 21);
            this.cbTools.TabIndex = 2;
            // 
            // btnOpenTool
            // 
            this.btnOpenTool.Location = new System.Drawing.Point(904, 88);
            this.btnOpenTool.Name = "btnOpenTool";
            this.btnOpenTool.Size = new System.Drawing.Size(75, 23);
            this.btnOpenTool.TabIndex = 3;
            this.btnOpenTool.Text = "Open";
            this.btnOpenTool.UseVisualStyleBackColor = true;
            this.btnOpenTool.Click += new System.EventHandler(this.btnOpenTool_Click);
            // 
            // listView1
            // 
            this.listView1.AllowColumnReorder = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.ClassName,
            this.NumberofDetections});
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(777, 165);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(296, 111);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // ID
            // 
            this.ID.Text = "ID";
            // 
            // ClassName
            // 
            this.ClassName.Text = "ClassName";
            this.ClassName.Width = 109;
            // 
            // NumberofDetections
            // 
            this.NumberofDetections.Text = "Number of Detections";
            this.NumberofDetections.Width = 123;
            // 
            // txtExposure
            // 
            this.txtExposure.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtExposure.Location = new System.Drawing.Point(133, 21);
            this.txtExposure.Multiline = true;
            this.txtExposure.Name = "txtExposure";
            this.txtExposure.Size = new System.Drawing.Size(100, 20);
            this.txtExposure.TabIndex = 5;
            this.txtExposure.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(285, 21);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 6;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // lblexposure
            // 
            this.lblexposure.AutoSize = true;
            this.lblexposure.Location = new System.Drawing.Point(70, 23);
            this.lblexposure.Name = "lblexposure";
            this.lblexposure.Size = new System.Drawing.Size(57, 13);
            this.lblexposure.TabIndex = 7;
            this.lblexposure.Text = "Exposure :";
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 688);
            this.Controls.Add(this.lblexposure);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.txtExposure);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.btnOpenTool);
            this.Controls.Add(this.cbTools);
            this.Controls.Add(this.btnStartStop);
            this.Controls.Add(this.BaslerImage);
            this.Name = "MainPage";
            this.Text = "Basler Camera";
            ((System.ComponentModel.ISupportInitialize)(this.BaslerImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox BaslerImage;
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.ComboBox cbTools;
        private System.Windows.Forms.Button btnOpenTool;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader ClassName;
        private System.Windows.Forms.ColumnHeader NumberofDetections;
        private System.Windows.Forms.TextBox txtExposure;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Label lblexposure;
    }
}

