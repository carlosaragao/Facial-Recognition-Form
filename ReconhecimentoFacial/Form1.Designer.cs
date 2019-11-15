namespace ReconhecimentoFacial
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
            this.WebcamBox = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.IDBox = new System.Windows.Forms.TextBox();
            this.TrainButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.OutPutBox = new System.Windows.Forms.RichTextBox();
            this.SquareButton = new System.Windows.Forms.Button();
            this.EyeButton = new System.Windows.Forms.Button();
            this.PredictButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.WebcamBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Webcam";
            // 
            // WebcamBox
            // 
            this.WebcamBox.Location = new System.Drawing.Point(13, 34);
            this.WebcamBox.Name = "WebcamBox";
            this.WebcamBox.Size = new System.Drawing.Size(648, 648);
            this.WebcamBox.TabIndex = 1;
            this.WebcamBox.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(689, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Digite seu id:";
            // 
            // IDBox
            // 
            this.IDBox.Location = new System.Drawing.Point(692, 34);
            this.IDBox.Name = "IDBox";
            this.IDBox.Size = new System.Drawing.Size(295, 22);
            this.IDBox.TabIndex = 3;
            // 
            // TrainButton
            // 
            this.TrainButton.Location = new System.Drawing.Point(692, 81);
            this.TrainButton.Name = "TrainButton";
            this.TrainButton.Size = new System.Drawing.Size(295, 66);
            this.TrainButton.TabIndex = 4;
            this.TrainButton.Text = "Começar Treinamento";
            this.TrainButton.UseVisualStyleBackColor = true;
            this.TrainButton.Click += new System.EventHandler(this.TrainButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(692, 215);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Saída";
            // 
            // OutPutBox
            // 
            this.OutPutBox.Location = new System.Drawing.Point(695, 236);
            this.OutPutBox.Name = "OutPutBox";
            this.OutPutBox.Size = new System.Drawing.Size(292, 269);
            this.OutPutBox.TabIndex = 6;
            this.OutPutBox.Text = "";
            // 
            // SquareButton
            // 
            this.SquareButton.Location = new System.Drawing.Point(695, 512);
            this.SquareButton.Name = "SquareButton";
            this.SquareButton.Size = new System.Drawing.Size(134, 52);
            this.SquareButton.TabIndex = 7;
            this.SquareButton.Text = "Visualizar face: Off";
            this.SquareButton.UseVisualStyleBackColor = true;
            this.SquareButton.Click += new System.EventHandler(this.SquareButton_Click);
            // 
            // EyeButton
            // 
            this.EyeButton.Location = new System.Drawing.Point(853, 512);
            this.EyeButton.Name = "EyeButton";
            this.EyeButton.Size = new System.Drawing.Size(134, 52);
            this.EyeButton.TabIndex = 8;
            this.EyeButton.Text = "Visualizar olhos: Off";
            this.EyeButton.UseVisualStyleBackColor = true;
            this.EyeButton.Click += new System.EventHandler(this.EyeButton_Click);
            // 
            // PredictButton
            // 
            this.PredictButton.Location = new System.Drawing.Point(692, 613);
            this.PredictButton.Name = "PredictButton";
            this.PredictButton.Size = new System.Drawing.Size(295, 69);
            this.PredictButton.TabIndex = 9;
            this.PredictButton.Text = "Reconhecer Face";
            this.PredictButton.UseVisualStyleBackColor = true;
            this.PredictButton.Click += new System.EventHandler(this.PredictButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 694);
            this.Controls.Add(this.PredictButton);
            this.Controls.Add(this.EyeButton);
            this.Controls.Add(this.SquareButton);
            this.Controls.Add(this.OutPutBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TrainButton);
            this.Controls.Add(this.IDBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.WebcamBox);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.WebcamBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox WebcamBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox IDBox;
        private System.Windows.Forms.Button TrainButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox OutPutBox;
        private System.Windows.Forms.Button SquareButton;
        private System.Windows.Forms.Button EyeButton;
        private System.Windows.Forms.Button PredictButton;
    }
}

