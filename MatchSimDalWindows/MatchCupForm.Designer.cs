namespace MatchSimDalWindows
{
    partial class MatchCupForm
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
            this.btnCupResult = new System.Windows.Forms.Button();
            this.spinVisitante = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.spinLocal = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbVisitante = new System.Windows.Forms.ComboBox();
            this.cmbLocal = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.spinVisitante)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinLocal)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCupResult
            // 
            this.btnCupResult.Location = new System.Drawing.Point(117, 187);
            this.btnCupResult.Name = "btnCupResult";
            this.btnCupResult.Size = new System.Drawing.Size(75, 23);
            this.btnCupResult.TabIndex = 9;
            this.btnCupResult.Text = "Resultado";
            this.btnCupResult.UseVisualStyleBackColor = true;
            this.btnCupResult.Click += new System.EventHandler(this.btnCupResult_Click);
            // 
            // spinVisitante
            // 
            this.spinVisitante.Location = new System.Drawing.Point(173, 101);
            this.spinVisitante.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.spinVisitante.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinVisitante.Name = "spinVisitante";
            this.spinVisitante.Size = new System.Drawing.Size(120, 23);
            this.spinVisitante.TabIndex = 8;
            this.spinVisitante.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Categoría del visitante";
            // 
            // spinLocal
            // 
            this.spinLocal.Location = new System.Drawing.Point(175, 27);
            this.spinLocal.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.spinLocal.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinLocal.Name = "spinLocal";
            this.spinLocal.Size = new System.Drawing.Size(120, 23);
            this.spinLocal.TabIndex = 6;
            this.spinLocal.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Categoría del local";
            // 
            // cmbVisitante
            // 
            this.cmbVisitante.FormattingEnabled = true;
            this.cmbVisitante.Items.AddRange(new object[] {
            "Alto",
            "Medio",
            "Bajo"});
            this.cmbVisitante.Location = new System.Drawing.Point(172, 135);
            this.cmbVisitante.Name = "cmbVisitante";
            this.cmbVisitante.Size = new System.Drawing.Size(121, 23);
            this.cmbVisitante.TabIndex = 13;
            // 
            // cmbLocal
            // 
            this.cmbLocal.FormattingEnabled = true;
            this.cmbLocal.Items.AddRange(new object[] {
            "Alto",
            "Medio",
            "Bajo"});
            this.cmbLocal.Location = new System.Drawing.Point(173, 62);
            this.cmbLocal.Name = "cmbLocal";
            this.cmbLocal.Size = new System.Drawing.Size(121, 23);
            this.cmbLocal.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "Nivel del visitante";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Nivel del local";
            // 
            // MatchCupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 235);
            this.Controls.Add(this.cmbVisitante);
            this.Controls.Add(this.cmbLocal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCupResult);
            this.Controls.Add(this.spinVisitante);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.spinLocal);
            this.Controls.Add(this.label1);
            this.Name = "MatchCupForm";
            this.Text = "Partido de Copa";
            ((System.ComponentModel.ISupportInitialize)(this.spinVisitante)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinLocal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnCupResult;
        private NumericUpDown spinVisitante;
        private Label label2;
        private NumericUpDown spinLocal;
        private Label label1;
        private ComboBox cmbVisitante;
        private ComboBox cmbLocal;
        private Label label3;
        private Label label4;
    }
}