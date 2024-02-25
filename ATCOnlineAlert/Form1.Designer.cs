namespace ATCOnlineAlert
{
    partial class Form1
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
            btnTestTone = new Button();
            chkTower = new CheckBox();
            btnStartListen = new Button();
            label1 = new Label();
            txtAirportcode = new TextBox();
            listStatus = new ListBox();
            btnStopListening = new Button();
            chkGround = new CheckBox();
            SuspendLayout();
            // 
            // btnTestTone
            // 
            btnTestTone.Font = new Font("Segoe UI", 15.8571434F, FontStyle.Regular, GraphicsUnit.Point);
            btnTestTone.ForeColor = SystemColors.ActiveCaptionText;
            btnTestTone.Location = new Point(12, 426);
            btnTestTone.Name = "btnTestTone";
            btnTestTone.Size = new Size(280, 76);
            btnTestTone.TabIndex = 0;
            btnTestTone.Text = "Test Tone";
            btnTestTone.UseVisualStyleBackColor = true;
            btnTestTone.Click += btnTestTone_Click;
            // 
            // chkTower
            // 
            chkTower.AutoSize = true;
            chkTower.Font = new Font("Segoe UI", 15.8571434F, FontStyle.Regular, GraphicsUnit.Point);
            chkTower.Location = new Point(342, 102);
            chkTower.Name = "chkTower";
            chkTower.Size = new Size(144, 54);
            chkTower.TabIndex = 1;
            chkTower.Text = "Tower";
            chkTower.UseVisualStyleBackColor = true;
            // 
            // btnStartListen
            // 
            btnStartListen.Font = new Font("Segoe UI", 15.8571434F, FontStyle.Regular, GraphicsUnit.Point);
            btnStartListen.ForeColor = SystemColors.ActiveCaptionText;
            btnStartListen.Location = new Point(12, 241);
            btnStartListen.Name = "btnStartListen";
            btnStartListen.Size = new Size(280, 67);
            btnStartListen.TabIndex = 6;
            btnStartListen.Text = "Start Listening";
            btnStartListen.UseVisualStyleBackColor = true;
            btnStartListen.Click += btnStartListen_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.8571434F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(34, 27);
            label1.Name = "label1";
            label1.Size = new Size(234, 50);
            label1.TabIndex = 7;
            label1.Text = "Airport Code";
            // 
            // txtAirportcode
            // 
            txtAirportcode.Font = new Font("Segoe UI", 15.8571434F, FontStyle.Regular, GraphicsUnit.Point);
            txtAirportcode.Location = new Point(342, 24);
            txtAirportcode.Name = "txtAirportcode";
            txtAirportcode.Size = new Size(321, 57);
            txtAirportcode.TabIndex = 8;
            txtAirportcode.TextChanged += txtAirportcode_TextChanged;
            // 
            // listStatus
            // 
            listStatus.Font = new Font("Segoe UI", 14.1428576F, FontStyle.Regular, GraphicsUnit.Point);
            listStatus.FormattingEnabled = true;
            listStatus.ItemHeight = 45;
            listStatus.Location = new Point(342, 228);
            listStatus.Name = "listStatus";
            listStatus.Size = new Size(774, 274);
            listStatus.TabIndex = 9;
            // 
            // btnStopListening
            // 
            btnStopListening.Font = new Font("Segoe UI", 15.8571434F, FontStyle.Regular, GraphicsUnit.Point);
            btnStopListening.ForeColor = SystemColors.ActiveCaptionText;
            btnStopListening.Location = new Point(12, 329);
            btnStopListening.Name = "btnStopListening";
            btnStopListening.Size = new Size(280, 70);
            btnStopListening.TabIndex = 10;
            btnStopListening.Text = "Stop";
            btnStopListening.UseVisualStyleBackColor = true;
            btnStopListening.Click += btnStopListening_Click;
            // 
            // chkGround
            // 
            chkGround.AutoSize = true;
            chkGround.Font = new Font("Segoe UI", 15.8571434F, FontStyle.Regular, GraphicsUnit.Point);
            chkGround.Location = new Point(342, 152);
            chkGround.Name = "chkGround";
            chkGround.Size = new Size(172, 54);
            chkGround.TabIndex = 11;
            chkGround.Text = "Ground";
            chkGround.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AcceptButton = btnStartListen;
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1164, 532);
            Controls.Add(chkGround);
            Controls.Add(btnStopListening);
            Controls.Add(listStatus);
            Controls.Add(txtAirportcode);
            Controls.Add(label1);
            Controls.Add(btnStartListen);
            Controls.Add(chkTower);
            Controls.Add(btnTestTone);
            Name = "Form1";
            Text = "ATC Alert Tool";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnTestTone;
        private CheckBox chkTower;
        private Button btnStartListen;
        private Label label1;
        private TextBox txtAirportcode;
        private ListBox listStatus;
        private Button btnStopListening;
        private CheckBox chkGround;
    }
}
