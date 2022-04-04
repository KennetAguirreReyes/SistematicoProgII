
namespace practicaDepreciacion
{
    partial class FrmBuscar
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
            this.cmbEmpleado = new System.Windows.Forms.ComboBox();
            this.btnFindActivo = new System.Windows.Forms.Button();
            this.cmbEmpleadoId = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbEmpleado
            // 
            this.cmbEmpleado.FormattingEnabled = true;
            this.cmbEmpleado.Location = new System.Drawing.Point(12, 12);
            this.cmbEmpleado.Name = "cmbEmpleado";
            this.cmbEmpleado.Size = new System.Drawing.Size(121, 24);
            this.cmbEmpleado.TabIndex = 1;
            this.cmbEmpleado.SelectedIndexChanged += new System.EventHandler(this.cmbEmpleado_SelectedIndexChanged);
            // 
            // btnFindActivo
            // 
            this.btnFindActivo.Location = new System.Drawing.Point(12, 59);
            this.btnFindActivo.Name = "btnFindActivo";
            this.btnFindActivo.Size = new System.Drawing.Size(121, 48);
            this.btnFindActivo.TabIndex = 2;
            this.btnFindActivo.Text = "Mostrar Activos";
            this.btnFindActivo.UseVisualStyleBackColor = true;
            this.btnFindActivo.Click += new System.EventHandler(this.btnFindActivo_Click);
            // 
            // cmbEmpleadoId
            // 
            this.cmbEmpleadoId.FormattingEnabled = true;
            this.cmbEmpleadoId.Location = new System.Drawing.Point(12, 129);
            this.cmbEmpleadoId.Name = "cmbEmpleadoId";
            this.cmbEmpleadoId.Size = new System.Drawing.Size(121, 24);
            this.cmbEmpleadoId.TabIndex = 4;
            this.cmbEmpleadoId.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(139, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(318, 300);
            this.dataGridView1.TabIndex = 5;
            // 
            // FrmBuscar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.ClientSize = new System.Drawing.Size(454, 299);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cmbEmpleadoId);
            this.Controls.Add(this.btnFindActivo);
            this.Controls.Add(this.cmbEmpleado);
            this.Name = "FrmBuscar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAsignacion";
            this.Load += new System.EventHandler(this.FrmBuscar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbEmpleado;
        private System.Windows.Forms.Button btnFindActivo;
        private System.Windows.Forms.ComboBox cmbEmpleadoId;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}