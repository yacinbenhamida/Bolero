namespace Bolero.Layouts
{
    partial class Facture
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
            this.ticketrepBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ticket_repTableAdapter = new Bolero.DSreportTableAdapters.ticket_repTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dSreport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ticketrepBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.ticketrepBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Bolero.Layouts.Facture.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(674, 376);
            this.reportViewer1.TabIndex = 0;
            // 
            // dSreport
            // 
            this.dSreport.DataSetName = "DSreport";
            this.dSreport.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ticketrepBindingSource
            // 
            this.ticketrepBindingSource.DataMember = "ticket_rep";
            this.ticketrepBindingSource.DataSource = this.dSreport;
            // 
            // ticket_repTableAdapter
            // 
            this.ticket_repTableAdapter.ClearBeforeFill = true;
            // 
            // Facture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 376);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Facture";
            this.Text = "Facture";
            this.Load += new System.EventHandler(this.Facture_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dSreport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ticketrepBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ticketrepBindingSource;
        private DSreport dSreport;
        private DSreportTableAdapters.ticket_repTableAdapter ticket_repTableAdapter;
        //private DSreportTableAdapters.DataTable1TableAdapter dataTable1TableAdapter;
    }
}