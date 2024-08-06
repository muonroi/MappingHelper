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
            SuspendLayout();
            // 
            // txtSource
            // 
            txtSource.Location = new Point(56, 39);
            txtSource.Multiline = true;
            txtSource.Name = "txtSource";
            txtSource.Size = new Size(327, 270);
            txtSource.TabIndex = 0;
            // 
            // txtResult
            // 
            txtResult.Location = new Point(56, 395);
            txtResult.Multiline = true;
            txtResult.Name = "txtResult";
            txtResult.Size = new Size(691, 253);
            txtResult.TabIndex = 1;
            // 
            // txtDestination
            // 
            txtDestination.Location = new Point(420, 39);
            txtDestination.Multiline = true;
            txtDestination.Name = "txtDestination";
            txtDestination.Size = new Size(327, 270);
            txtDestination.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(184, 9);
            label1.Name = "label1";
            label1.Size = new Size(58, 20);
            label1.TabIndex = 6;
            label1.Text = "Source ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(553, 9);
            label2.Name = "label2";
            label2.Size = new Size(89, 20);
            label2.TabIndex = 7;
            label2.Text = "Destination ";
            // 
            // btnProcess
            // 
            btnProcess.Location = new Point(653, 332);
            btnProcess.Name = "btnProcess";
            btnProcess.Size = new Size(94, 29);
            btnProcess.TabIndex = 8;
            btnProcess.Text = "Process";
            btnProcess.UseVisualStyleBackColor = true;
            btnProcess.Click += BtnProcess_Click;
            // 
            // rdMM
            // 
            rdMM.AutoSize = true;
            rdMM.Checked = true;
            rdMM.Location = new Point(56, 337);
            rdMM.Name = "rdMM";
            rdMM.Size = new Size(130, 24);
            rdMM.TabIndex = 9;
            rdMM.TabStop = true;
            rdMM.Text = "Model - Model";
            rdMM.UseVisualStyleBackColor = true;
            // 
            // rdPM
            // 
            rdPM.AutoSize = true;
            rdPM.Location = new Point(192, 337);
            rdPM.Name = "rdPM";
            rdPM.Size = new Size(123, 24);
            rdPM.TabIndex = 10;
            rdPM.Text = "Proto - Model";
            rdPM.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.LinkColor = Color.Red;
            linkLabel1.Location = new Point(249, 674);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(273, 20);
            linkLabel1.TabIndex = 11;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "SAY NO WITH AUTOMAPPER - MuonRoi";
            linkLabel1.LinkClicked += ProfileUrl_LinkClicked;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(831, 703);
            Controls.Add(linkLabel1);
            Controls.Add(rdPM);
            Controls.Add(rdMM);
            Controls.Add(btnProcess);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtDestination);
            Controls.Add(txtResult);
            Controls.Add(txtSource);
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
    }
}
