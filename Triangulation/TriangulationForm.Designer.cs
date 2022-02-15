
namespace Triangulation {
    partial class TriangulationForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.numericUpDownPoints = new System.Windows.Forms.NumericUpDown();
            this.labelPoints = new System.Windows.Forms.Label();
            this.buttonPoints = new System.Windows.Forms.Button();
            this.buttonTriangulate = new System.Windows.Forms.Button();
            this.buttonShowVoronoi = new System.Windows.Forms.Button();
            this.buttonShowDelaunay = new System.Windows.Forms.Button();
            this.buttonMove = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPoints)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(137, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(500, 500);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // numericUpDownPoints
            // 
            this.numericUpDownPoints.Location = new System.Drawing.Point(11, 71);
            this.numericUpDownPoints.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numericUpDownPoints.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownPoints.Name = "numericUpDownPoints";
            this.numericUpDownPoints.Size = new System.Drawing.Size(119, 23);
            this.numericUpDownPoints.TabIndex = 1;
            this.numericUpDownPoints.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // labelPoints
            // 
            this.labelPoints.AutoSize = true;
            this.labelPoints.Location = new System.Drawing.Point(17, 53);
            this.labelPoints.Name = "labelPoints";
            this.labelPoints.Size = new System.Drawing.Size(104, 15);
            this.labelPoints.TabIndex = 2;
            this.labelPoints.Text = "Amount of points:";
            // 
            // buttonPoints
            // 
            this.buttonPoints.Location = new System.Drawing.Point(11, 100);
            this.buttonPoints.Name = "buttonPoints";
            this.buttonPoints.Size = new System.Drawing.Size(119, 25);
            this.buttonPoints.TabIndex = 3;
            this.buttonPoints.Text = "Generate points";
            this.buttonPoints.UseVisualStyleBackColor = true;
            this.buttonPoints.Click += new System.EventHandler(this.buttonPoints_Click);
            // 
            // buttonTriangulate
            // 
            this.buttonTriangulate.Enabled = false;
            this.buttonTriangulate.Location = new System.Drawing.Point(12, 149);
            this.buttonTriangulate.Name = "buttonTriangulate";
            this.buttonTriangulate.Size = new System.Drawing.Size(118, 55);
            this.buttonTriangulate.TabIndex = 4;
            this.buttonTriangulate.Text = "Triangulate points and generate Voronoi diagram";
            this.buttonTriangulate.UseVisualStyleBackColor = true;
            this.buttonTriangulate.Click += new System.EventHandler(this.buttonTriangulate_Click);
            // 
            // buttonShowVoronoi
            // 
            this.buttonShowVoronoi.Enabled = false;
            this.buttonShowVoronoi.Location = new System.Drawing.Point(12, 410);
            this.buttonShowVoronoi.Name = "buttonShowVoronoi";
            this.buttonShowVoronoi.Size = new System.Drawing.Size(119, 42);
            this.buttonShowVoronoi.TabIndex = 6;
            this.buttonShowVoronoi.Text = "Show Voronoi without Delaunay";
            this.buttonShowVoronoi.UseVisualStyleBackColor = true;
            this.buttonShowVoronoi.Click += new System.EventHandler(this.buttonShowVoronoi_Click);
            // 
            // buttonShowDelaunay
            // 
            this.buttonShowDelaunay.Enabled = false;
            this.buttonShowDelaunay.Location = new System.Drawing.Point(12, 458);
            this.buttonShowDelaunay.Name = "buttonShowDelaunay";
            this.buttonShowDelaunay.Size = new System.Drawing.Size(119, 40);
            this.buttonShowDelaunay.TabIndex = 7;
            this.buttonShowDelaunay.Text = "Show Delaunay without Voronoi";
            this.buttonShowDelaunay.UseVisualStyleBackColor = true;
            this.buttonShowDelaunay.Click += new System.EventHandler(this.buttonShowDelaunay_Click);
            // 
            // buttonMove
            // 
            this.buttonMove.Enabled = false;
            this.buttonMove.Location = new System.Drawing.Point(13, 303);
            this.buttonMove.Name = "buttonMove";
            this.buttonMove.Size = new System.Drawing.Size(117, 41);
            this.buttonMove.TabIndex = 8;
            this.buttonMove.Text = "Start moving points";
            this.buttonMove.UseVisualStyleBackColor = true;
            this.buttonMove.Click += new System.EventHandler(this.buttonMove_Click);
            // 
            // TriangulationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 521);
            this.Controls.Add(this.buttonMove);
            this.Controls.Add(this.buttonShowDelaunay);
            this.Controls.Add(this.buttonShowVoronoi);
            this.Controls.Add(this.buttonTriangulate);
            this.Controls.Add(this.buttonPoints);
            this.Controls.Add(this.labelPoints);
            this.Controls.Add(this.numericUpDownPoints);
            this.Controls.Add(this.pictureBox);
            this.Name = "TriangulationForm";
            this.Text = "TriangulationForm";
            this.ResizeEnd += new System.EventHandler(this.TriangulationForm_ResizeEnd);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPoints)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.NumericUpDown numericUpDownPoints;
        private System.Windows.Forms.Label labelPoints;
        private System.Windows.Forms.Button buttonPoints;
        private System.Windows.Forms.Button buttonTriangulate;
        private System.Windows.Forms.Button buttonShowVoronoi;
        private System.Windows.Forms.Button buttonShowDelaunay;
        private System.Windows.Forms.Button buttonMove;
    }
}