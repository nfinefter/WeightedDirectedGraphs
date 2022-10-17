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
            this.WallButton = new System.Windows.Forms.Button();
            this.StartVertexButton = new System.Windows.Forms.Button();
            this.EndVertexButton = new System.Windows.Forms.Button();
            this.HeavyVertexButton = new System.Windows.Forms.Button();
            this.BeginButton = new System.Windows.Forms.Button();
            this.HeuristicDropDown = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.GraphVisual)).BeginInit();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(806, 53);
            this.startButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(95, 31);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "CreateGrid";
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
            this.GraphVisual.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.GraphVisual.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.GraphVisual.Location = new System.Drawing.Point(229, 33);
            this.GraphVisual.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GraphVisual.Name = "GraphVisual";
            this.GraphVisual.Size = new System.Drawing.Size(400, 400);
            this.GraphVisual.TabIndex = 1;
            this.GraphVisual.TabStop = false;
            this.GraphVisual.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // artButton
            // 
            this.artButton.Location = new System.Drawing.Point(-1, 589);
            this.artButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.artButton.Name = "artButton";
            this.artButton.Size = new System.Drawing.Size(11, 13);
            this.artButton.TabIndex = 2;
            this.artButton.Text = "Art";
            this.artButton.UseVisualStyleBackColor = true;
            this.artButton.Click += new System.EventHandler(this.artButton_Click);
            // 
            // WallButton
            // 
            this.WallButton.Location = new System.Drawing.Point(806, 92);
            this.WallButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.WallButton.Name = "WallButton";
            this.WallButton.Size = new System.Drawing.Size(95, 31);
            this.WallButton.TabIndex = 3;
            this.WallButton.Text = "Wall";
            this.WallButton.UseVisualStyleBackColor = true;
            this.WallButton.Click += new System.EventHandler(this.WallButton_Click);
            // 
            // StartVertexButton
            // 
            this.StartVertexButton.Location = new System.Drawing.Point(806, 131);
            this.StartVertexButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.StartVertexButton.Name = "StartVertexButton";
            this.StartVertexButton.Size = new System.Drawing.Size(95, 31);
            this.StartVertexButton.TabIndex = 4;
            this.StartVertexButton.Text = "StartVertex";
            this.StartVertexButton.UseVisualStyleBackColor = true;
            this.StartVertexButton.Click += new System.EventHandler(this.StartVertexButton_Click);
            // 
            // EndVertexButton
            // 
            this.EndVertexButton.Location = new System.Drawing.Point(806, 169);
            this.EndVertexButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.EndVertexButton.Name = "EndVertexButton";
            this.EndVertexButton.Size = new System.Drawing.Size(95, 31);
            this.EndVertexButton.TabIndex = 5;
            this.EndVertexButton.Text = "EndVertex";
            this.EndVertexButton.UseVisualStyleBackColor = true;
            this.EndVertexButton.Click += new System.EventHandler(this.EndVertexButton_Click);
            // 
            // HeavyVertexButton
            // 
            this.HeavyVertexButton.Location = new System.Drawing.Point(806, 208);
            this.HeavyVertexButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.HeavyVertexButton.Name = "HeavyVertexButton";
            this.HeavyVertexButton.Size = new System.Drawing.Size(95, 31);
            this.HeavyVertexButton.TabIndex = 6;
            this.HeavyVertexButton.Text = "HeavyVertex";
            this.HeavyVertexButton.UseVisualStyleBackColor = true;
            this.HeavyVertexButton.Click += new System.EventHandler(this.HeavyVertexButton_Click);
            // 
            // BeginButton
            // 
            this.BeginButton.Location = new System.Drawing.Point(806, 15);
            this.BeginButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BeginButton.Name = "BeginButton";
            this.BeginButton.Size = new System.Drawing.Size(95, 31);
            this.BeginButton.TabIndex = 7;
            this.BeginButton.Text = "Begin AStar";
            this.BeginButton.UseVisualStyleBackColor = true;
            this.BeginButton.Click += new System.EventHandler(this.BeginButton_Click);
            // 
            // HeuristicDropDown
            // 
            this.HeuristicDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.HeuristicDropDown.FormattingEnabled = true;
            this.HeuristicDropDown.Items.AddRange(new object[] {
            "Manhattan",
            "Diagonal",
            "Euclidean",
            "Dijkstra"});
            this.HeuristicDropDown.Location = new System.Drawing.Point(806, 247);
            this.HeuristicDropDown.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.HeuristicDropDown.Name = "HeuristicDropDown";
            this.HeuristicDropDown.Size = new System.Drawing.Size(94, 28);
            this.HeuristicDropDown.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(914, 600);
            this.Controls.Add(this.HeuristicDropDown);
            this.Controls.Add(this.BeginButton);
            this.Controls.Add(this.HeavyVertexButton);
            this.Controls.Add(this.EndVertexButton);
            this.Controls.Add(this.StartVertexButton);
            this.Controls.Add(this.WallButton);
            this.Controls.Add(this.artButton);
            this.Controls.Add(this.GraphVisual);
            this.Controls.Add(this.startButton);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
        private Button WallButton;
        private Button StartVertexButton;
        private Button EndVertexButton;
        private Button HeavyVertexButton;
        private Button BeginButton;
        private ComboBox HeuristicDropDown;
    }
}