namespace Bolero.Layouts
{
    partial class recettemois
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dSreport = new Bolero.DSreport();
            this.commande2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.commande2TableAdapter = new Bolero.DSreportTableAdapters.Commande2TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dSreport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.commande2BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.commande2BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Bolero.Layouts.recettemois.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(686, 445);
            this.reportViewer1.TabIndex = 0;
            // 
            // dSreport
            // 
            this.dSreport.DataSetName = "DSreport";
            this.dSreport.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // commande2BindingSource
            // 
            this.commande2BindingSource.DataMember = "Commande2";
            this.commande2BindingSource.DataSource = this.dSreport;
            // 
            // commande2TableAdapter
            // 
            this.commande2TableAdapter.ClearBeforeFill = true;
            // 
            // recettemois
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 445);
            this.Controls.Add(this.reportViewer1);
            this.Name = "recettemois";
            this.Text = "recettemois";
            this.Load += new System.EventHandler(this.recettemois_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dSreport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.commande2BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private DSreport dSreport;
        private System.Windows.Forms.BindingSource commande2BindingSource;
        private DSreportTableAdapters.Commande2TableAdapter commande2TableAdapter;
    }
}