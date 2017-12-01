namespace Bolero.Layouts
{
    partial class Ticket
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
            this.ticketrepBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dSreport = new Bolero.DSreport();
            this.ticketrepBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ticket_repTableAdapter = new Bolero.DSreportTableAdapters.ticket_repTableAdapter();
            this.ticket_repBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ticketrepBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSreport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ticketrepBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ticket_repBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ticketrepBindingSource1
            // 
            this.ticketrepBindingSource1.DataMember = "ticket_rep";
            this.ticketrepBindingSource1.DataSource = this.dSreport;
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
            // reportViewer1
            // 
            this.reportViewer1.AutoScroll = true;
            this.reportViewer1.AutoSize = true;
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.IsDocumentMapWidthFixed = true;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.ticketrepBindingSource1;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Bolero.Layouts.ticket.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ShowBackButton = false;
            this.reportViewer1.ShowPageNavigationControls = false;
            this.reportViewer1.ShowStopButton = false;
            this.reportViewer1.ShowZoomControl = false;
            this.reportViewer1.Size = new System.Drawing.Size(352, 432);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // ticket_repTableAdapter
            // 
            this.ticket_repTableAdapter.ClearBeforeFill = true;
            // 
            // ticket_repBindingSource
            // 
            this.ticket_repBindingSource.DataMember = "ticket_rep";
            this.ticket_repBindingSource.DataSource = this.dSreport;
            // 
            // Ticket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 432);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Ticket";
            this.Text = "Ticket";
            this.Load += new System.EventHandler(this.Ticket_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ticketrepBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSreport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ticketrepBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ticket_repBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ticketrepBindingSource;
        private DSreport dSreport;
        private DSreportTableAdapters.ticket_repTableAdapter ticket_repTableAdapter;
        private System.Windows.Forms.BindingSource ticket_repBindingSource;
        private System.Windows.Forms.BindingSource ticketrepBindingSource1;

        //private DSreportTableAdapters.DataTable1TableAdapter dataTable1TableAdapter;
    }
}