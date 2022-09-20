namespace AStarVisualizer
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
            this.components = new System.ComponentModel.Container();
            this.startButton = new System.Windows.Forms.Button();
            this.Updater = new System.Windows.Forms.Timer(this.components);
            this.GraphVisual = new System.Windows.Forms.PictureBox();
            this.artButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GraphVisual)).BeginInit();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(713, 12);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // Updater
            // 
            this.Updater.Interval = 17;
            this.Updater.Tick += new System.EventHandler(this.Updater_Tick);
            // 
            // GraphVisual
            // 
            this.GraphVisual.BackColor = System.Drawing.Color.WhiteSmoke;
            this.GraphVisual.Location = new System.Drawing.Point(200, 25);
            this.GraphVisual.Name = "GraphVisual";
            this.GraphVisual.Size = new System.Drawing.Size(400, 400);
            this.GraphVisual.TabIndex = 1;
            this.GraphVisual.TabStop = false;
            this.GraphVisual.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // artButton
            // 
            this.artButton.Location = new System.Drawing.Point(713, 41);
            this.artButton.Name = "artButton";
            this.artButton.Size = new System.Drawing.Size(75, 22);
            this.artButton.TabIndex = 2;
            this.artButton.Text = "Art";
            this.artButton.UseVisualStyleBackColor = true;
            this.artButton.Click += new System.EventHandler(this.artButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.artButton);
            this.Controls.Add(this.GraphVisual);
            this.Controls.Add(this.startButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GraphVisual)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button startButton;
        private System.Windows.Forms.Timer Updater;
        private PictureBox GraphVisual;
        private Button artButton;
    }
}