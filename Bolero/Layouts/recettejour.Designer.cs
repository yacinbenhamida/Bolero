namespace Bolero.Layouts
{
    partial class recettejour
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
            this.commande1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSreport = new Bolero.DSreport();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            //this.commande1TableAdapter = new Bolero.DSreportTableAdapters.Commande1TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.commande1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSreport)).BeginInit();
            this.SuspendLayout();
            // 
            // commande1BindingSource
            // 
            this.commande1BindingSource.DataMember = "Commande1";
            this.commande1BindingSource.DataSource = this.dSreport;
            // 
            // dSreport
            // 
            this.dSreport.DataSetName = "DSreport";
            this.dSreport.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.commande1BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Bolero.Layouts.recettejour.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(814, 520);
            this.reportViewer1.TabIndex = 0;
            // 
            // commande1TableAdapter
            // 
           // this.commande1TableAdapter.ClearBeforeFill = true;
            // 
            // recettejour
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 520);
            this.Controls.Add(this.reportViewer1);
            this.Name = "recettejour";
            this.Text = "recettejour";
            this.Load += new System.EventHandler(this.recettejour_Load);
            ((System.ComponentModel.ISupportInitialize)(this.commande1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSreport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private DSreport dSreport;
        private System.Windows.Forms.BindingSource commande1BindingSource;
        //private DSreportTableAdapters.Commande1TableAdapter commande1TableAdapter;
    }
}