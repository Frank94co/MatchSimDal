namespace MatchSimDalWindows
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
            this.btnCampoNeutral = new System.Windows.Forms.Button();
            this.btnLocVisi = new System.Windows.Forms.Button();
            this.btnCopa = new System.Windows.Forms.Button();
            this.btnMultijornada = new System.Windows.Forms.Button();
            this.btnReportBug = new System.Windows.Forms.Button();
            this.seleccionarArchivo = new System.Windows.Forms.OpenFileDialog();
            this.btnCopaCompleta = new System.Windows.Forms.Button();
            this.seleccionarArchivoCopa = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // btnCampoNeutral
            // 
            this.btnCampoNeutral.Location = new System.Drawing.Point(12, 12);
            this.btnCampoNeutral.Name = "btnCampoNeutral";
            this.btnCampoNeutral.Size = new System.Drawing.Size(190, 34);
            this.btnCampoNeutral.TabIndex = 0;
            this.btnCampoNeutral.Text = "Partido en campo neutral";
            this.btnCampoNeutral.UseVisualStyleBackColor = true;
            this.btnCampoNeutral.Click += new System.EventHandler(this.btnCampoNeutral_Click);
            // 
            // btnLocVisi
            // 
            this.btnLocVisi.Location = new System.Drawing.Point(242, 12);
            this.btnLocVisi.Name = "btnLocVisi";
            this.btnLocVisi.Size = new System.Drawing.Size(190, 34);
            this.btnLocVisi.TabIndex = 1;
            this.btnLocVisi.Text = "Partido con local y visitante";
            this.btnLocVisi.UseVisualStyleBackColor = true;
            this.btnLocVisi.Click += new System.EventHandler(this.btnLocVisi_Click);
            // 
            // btnCopa
            // 
            this.btnCopa.Location = new System.Drawing.Point(12, 71);
            this.btnCopa.Name = "btnCopa";
            this.btnCopa.Size = new System.Drawing.Size(190, 34);
            this.btnCopa.TabIndex = 2;
            this.btnCopa.Text = "Partido de Copa";
            this.btnCopa.UseVisualStyleBackColor = true;
            this.btnCopa.Click += new System.EventHandler(this.btnCopa_Click);
            // 
            // btnMultijornada
            // 
            this.btnMultijornada.Location = new System.Drawing.Point(148, 128);
            this.btnMultijornada.Name = "btnMultijornada";
            this.btnMultijornada.Size = new System.Drawing.Size(141, 40);
            this.btnMultijornada.TabIndex = 4;
            this.btnMultijornada.Text = "Multijornada";
            this.btnMultijornada.UseVisualStyleBackColor = true;
            this.btnMultijornada.Click += new System.EventHandler(this.btnMultijornada_Click);
            // 
            // btnReportBug
            // 
            this.btnReportBug.Location = new System.Drawing.Point(148, 184);
            this.btnReportBug.Name = "btnReportBug";
            this.btnReportBug.Size = new System.Drawing.Size(141, 36);
            this.btnReportBug.TabIndex = 5;
            this.btnReportBug.Text = "Reportar un bug";
            this.btnReportBug.UseVisualStyleBackColor = true;
            this.btnReportBug.Click += new System.EventHandler(this.btnReportBug_Click);
            // 
            // seleccionarArchivo
            // 
            this.seleccionarArchivo.FileName = "openFileDialog1";
            this.seleccionarArchivo.Filter = "Archivos delimitados (*.csv, *.txt)|*.csv;*.txt;";
            this.seleccionarArchivo.InitialDirectory = "C:/Desktop";
            // 
            // btnCopaCompleta
            // 
            this.btnCopaCompleta.Location = new System.Drawing.Point(242, 70);
            this.btnCopaCompleta.Name = "btnCopaCompleta";
            this.btnCopaCompleta.Size = new System.Drawing.Size(190, 35);
            this.btnCopaCompleta.TabIndex = 6;
            this.btnCopaCompleta.Text = "Copa completa";
            this.btnCopaCompleta.UseVisualStyleBackColor = true;
            this.btnCopaCompleta.Click += new System.EventHandler(this.btnCopaCompleta_Click);
            // 
            // seleccionarArchivoCopa
            // 
            this.seleccionarArchivoCopa.Filter = "Archivos delimitados (*.csv, *.txt)|*.csv;*.txt;";
            this.seleccionarArchivoCopa.InitialDirectory = "C:/Desktop";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 232);
            this.Controls.Add(this.btnCopaCompleta);
            this.Controls.Add(this.btnReportBug);
            this.Controls.Add(this.btnMultijornada);
            this.Controls.Add(this.btnCopa);
            this.Controls.Add(this.btnLocVisi);
            this.Controls.Add(this.btnCampoNeutral);
            this.Name = "Form1";
            this.Text = "MatchSimDal";
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnCampoNeutral;
        private Button btnLocVisi;
        private Button btnCopa;
        private Button btnMultijornada;
        private Button btnReportBug;
        private OpenFileDialog seleccionarArchivo;
        private Button btnCopaCompleta;
        private OpenFileDialog seleccionarArchivoCopa;
    }
}