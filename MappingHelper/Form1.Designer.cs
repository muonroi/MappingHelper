namespace MappingHelper
{
    partial class Home
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtSource = new TextBox();
            txtResult = new TextBox();
            txtDestination = new TextBox();
            label1 = new Label();
            label2 = new Label();
            btnProcess = new Button();
            rdMM = new RadioButton();
            rdPM = new RadioButton();
            linkLabel1 = new LinkLabel();
            btnCoppy = new Button();
            SuspendLayout();
            // 
            // txtSource
            // 
            txtSource.Location = new Point(49, 29);
            txtSource.Margin = new Padding(3, 2, 3, 2);
            txtSource.Multiline = true;
            txtSource.Name = "txtSource";
            txtSource.ScrollBars = ScrollBars.Horizontal;
            txtSource.Size = new Size(287, 204);
            txtSource.TabIndex = 0;
            // 
            // txtResult
            // 
            txtResult.BackColor = SystemColors.Info;
            txtResult.Enabled = false;
            txtResult.Location = new Point(49, 296);
            txtResult.Margin = new Padding(3, 2, 3, 2);
            txtResult.Multiline = true;
            txtResult.Name = "txtResult";
            txtResult.Size = new Size(605, 191);
            txtResult.TabIndex = 1;
            // 
            // txtDestination
            // 
            txtDestination.Location = new Point(368, 29);
            txtDestination.Margin = new Padding(3, 2, 3, 2);
            txtDestination.Multiline = true;
            txtDestination.Name = "txtDestination";
            txtDestination.ScrollBars = ScrollBars.Horizontal;
            txtDestination.Size = new Size(287, 204);
            txtDestination.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(161, 7);
            label1.Name = "label1";
            label1.Size = new Size(46, 15);
            label1.TabIndex = 6;
            label1.Text = "Source ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(484, 7);
            label2.Name = "label2";
            label2.Size = new Size(70, 15);
            label2.TabIndex = 7;
            label2.Text = "Destination ";
            // 
            // btnProcess
            // 
            btnProcess.Location = new Point(571, 249);
            btnProcess.Margin = new Padding(3, 2, 3, 2);
            btnProcess.Name = "btnProcess";
            btnProcess.Size = new Size(82, 22);
            btnProcess.TabIndex = 8;
            btnProcess.Text = "Process";
            btnProcess.UseVisualStyleBackColor = true;
            btnProcess.Click += BtnProcess_Click;
            // 
            // rdMM
            // 
            rdMM.AutoSize = true;
            rdMM.Checked = true;
            rdMM.Location = new Point(49, 253);
            rdMM.Margin = new Padding(3, 2, 3, 2);
            rdMM.Name = "rdMM";
            rdMM.Size = new Size(104, 19);
            rdMM.TabIndex = 9;
            rdMM.TabStop = true;
            rdMM.Text = "Model - Model";
            rdMM.UseVisualStyleBackColor = true;
            // 
            // rdPM
            // 
            rdPM.AutoSize = true;
            rdPM.Location = new Point(168, 253);
            rdPM.Margin = new Padding(3, 2, 3, 2);
            rdPM.Name = "rdPM";
            rdPM.Size = new Size(99, 19);
            rdPM.TabIndex = 10;
            rdPM.Text = "Proto - Model";
            rdPM.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.LinkColor = Color.Red;
            linkLabel1.Location = new Point(218, 506);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(219, 15);
            linkLabel1.TabIndex = 11;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "SAY NO WITH AUTOMAPPER - MuonRoi";
            linkLabel1.LinkClicked += ProfileUrl_LinkClicked;
            // 
            // btnCoppy
            // 
            btnCoppy.Location = new Point(660, 368);
            btnCoppy.Name = "btnCoppy";
            btnCoppy.Size = new Size(64, 23);
            btnCoppy.TabIndex = 12;
            btnCoppy.Text = "Coppy";
            btnCoppy.UseVisualStyleBackColor = true;
            btnCoppy.Click += BtnCoppy_Click;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(727, 527);
            Controls.Add(btnCoppy);
            Controls.Add(linkLabel1);
            Controls.Add(rdPM);
            Controls.Add(rdMM);
            Controls.Add(btnProcess);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtDestination);
            Controls.Add(txtResult);
            Controls.Add(txtSource);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Home";
            Text = "Mr.Maping v1.0";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtSource;
        private TextBox txtResult;
        private TextBox txtDestination;
        private Label label1;
        private Label label2;
        private Button btnProcess;
        private RadioButton rdMM;
        private RadioButton rdPM;
        private LinkLabel linkLabel1;
        private Button btnCoppy;
    }
}
