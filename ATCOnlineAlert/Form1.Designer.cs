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
            listStatus = new ListView();
            btnStartListen = new Button();
            label1 = new Label();
            txtAirportcode = new TextBox();
            SuspendLayout();
            // 
            // btnTestTone
            // 
            btnTestTone.Font = new Font("Segoe UI", 15.8571434F, FontStyle.Regular, GraphicsUnit.Point);
            btnTestTone.ForeColor = SystemColors.ActiveCaptionText;
            btnTestTone.Location = new Point(71, 420);
            btnTestTone.Name = "btnTestTone";
            btnTestTone.Size = new Size(365, 76);
            btnTestTone.TabIndex = 0;
            btnTestTone.Text = "Test Tone";
            btnTestTone.UseVisualStyleBackColor = true;
            btnTestTone.Click += btnTestTone_Click;
            // 
            // chkTower
            // 
            chkTower.AutoSize = true;
            chkTower.Font = new Font("Segoe UI", 15.8571434F, FontStyle.Regular, GraphicsUnit.Point);
            chkTower.Location = new Point(776, 89);
            chkTower.Name = "chkTower";
            chkTower.Size = new Size(144, 54);
            chkTower.TabIndex = 1;
            chkTower.Text = "Tower";
            chkTower.UseVisualStyleBackColor = true;
            // 
            // listStatus
            // 
            listStatus.Font = new Font("Segoe UI", 14.1428576F, FontStyle.Regular, GraphicsUnit.Point);
            listStatus.LabelWrap = false;
            listStatus.Location = new Point(570, 303);
            listStatus.Name = "listStatus";
            listStatus.Size = new Size(743, 193);
            listStatus.TabIndex = 5;
            listStatus.UseCompatibleStateImageBehavior = false;
            listStatus.View = View.List;
            // 
            // btnStartListen
            // 
            btnStartListen.Font = new Font("Segoe UI", 15.8571434F, FontStyle.Regular, GraphicsUnit.Point);
            btnStartListen.ForeColor = SystemColors.ActiveCaptionText;
            btnStartListen.Location = new Point(71, 303);
            btnStartListen.Name = "btnStartListen";
            btnStartListen.Size = new Size(365, 78);
            btnStartListen.TabIndex = 6;
            btnStartListen.Text = "Start Listening";
            btnStartListen.UseVisualStyleBackColor = true;
            btnStartListen.Click += btnStartListen_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.8571434F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(71, 90);
            label1.Name = "label1";
            label1.Size = new Size(234, 50);
            label1.TabIndex = 7;
            label1.Text = "Airport Code";
            // 
            // txtAirportcode
            // 
            txtAirportcode.Font = new Font("Segoe UI", 15.8571434F, FontStyle.Regular, GraphicsUnit.Point);
            txtAirportcode.Location = new Point(311, 90);
            txtAirportcode.Name = "txtAirportcode";
            txtAirportcode.Size = new Size(321, 57);
            txtAirportcode.TabIndex = 8;
            // 
            // Form1
            // 
            AcceptButton = btnStartListen;
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1398, 564);
            Controls.Add(txtAirportcode);
            Controls.Add(label1);
            Controls.Add(btnStartListen);
            Controls.Add(listStatus);
            Controls.Add(chkTower);
            Controls.Add(btnTestTone);
            Name = "Form1";
            Text = "ATC Alert Tool";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnTestTone;
        private CheckBox chkTower;
        private ListView listStatus;
        private Button btnStartListen;
        private Label label1;
        private TextBox txtAirportcode;
    }
}
