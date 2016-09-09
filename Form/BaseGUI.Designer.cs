namespace VOIPTextToSpeechVAC
{
    partial class BaseGUI
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
            this.txtDetectedKeys = new System.Windows.Forms.RichTextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.lblIsListening = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtDetectedKeys
            // 
            this.txtDetectedKeys.Location = new System.Drawing.Point(52, 40);
            this.txtDetectedKeys.Name = "txtDetectedKeys";
            this.txtDetectedKeys.ReadOnly = true;
            this.txtDetectedKeys.Size = new System.Drawing.Size(320, 268);
            this.txtDetectedKeys.TabIndex = 0;
            this.txtDetectedKeys.Text = "";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(52, 342);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(80, 17);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // lblIsListening
            // 
            this.lblIsListening.AutoSize = true;
            this.lblIsListening.ForeColor = System.Drawing.Color.Red;
            this.lblIsListening.Location = new System.Drawing.Point(52, 379);
            this.lblIsListening.Name = "lblIsListening";
            this.lblIsListening.Size = new System.Drawing.Size(91, 13);
            this.lblIsListening.TabIndex = 2;
            this.lblIsListening.Text = "Is Listening: False";
            // 
            // BaseGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 537);
            this.Controls.Add(this.lblIsListening);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.txtDetectedKeys);
            this.Name = "BaseGUI";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BaseGUI_FormClosing);
            this.Load += new System.EventHandler(this.BaseGUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtDetectedKeys;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label lblIsListening;
    }
}

