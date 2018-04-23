using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;

namespace RepTreeListHierarchicalDataRelationships {
    public partial class Form1 : Form {
        private XtraReport report;
        private DataSet dataSet;
        private int indent = 0;

        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            List<Employee> employes = Employee.GenerateSeveralEmployes();

            dataSet = DataSetHelper.HierarchicalListToDataSet(employes, "Id", "ParentId");

            DataSetHelper2.FillTreeView(treeView1, dataSet);
            treeView1.CollapseAll();
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e) {
            GenerateReport();
            report.ShowPreviewDialog();
        }

        private void GenerateReport() {
            ReportHeaderBand headerBand = new ReportHeaderBand();
            DetailBand detailBand = new DetailBand();
            XRLabel title = new XRLabel();
            string dataPath = dataSet.Tables[0].TableName;

            report = new XtraReport();
            report.DataMember = dataPath;

            headerBand.Height = 50;
            detailBand.Height = 25;
            title.Size = new Size(report.PageWidth - report.Margins.Left - report.Margins.Right - 1, 50);
            title.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            title.Font = new Font(title.Font.FontFamily, 20);
            title.Text = "Hierarchical Data Report";

            headerBand.Controls.Add(title);
            report.Bands.Add(headerBand);
            report.Bands.Add(detailBand);

            AddDataFieldsToBand(dataSet.Tables[0], detailBand, dataPath, false);

            XtraReportBase nextReport = report;

            for(int i = 0; i < dataSet.Relations.Count; i++) {
                DataRelation dataRelation = dataSet.Relations[i];

                dataPath += "." + dataRelation.RelationName;
                nextReport = CreateReportForTable(nextReport, dataRelation.ChildTable, dataPath);
            }

            report.DataSource = dataSet;
        }

        private void AddDataFieldsToBand(DataTable dataTable, DetailBand band, string dataPath, bool addKeyFields) {
            XRTable table = XRTable.CreateTable(new Rectangle(indent, 0, report.PageWidth - report.Margins.Left - report.Margins.Right - indent - 1, 25), 1, dataTable.Columns.Count - (addKeyFields ? 0 : 2));
            int cellIndex = 0;

            for(int i = 0; i < dataTable.Columns.Count; i++) {
                DataColumn dataColumn = dataTable.Columns[i];

                if(addKeyFields || (!addKeyFields && !dataColumn.ColumnName.ToUpper().Contains("ID")))
                    table.Rows[0].Cells[cellIndex++].DataBindings.Add("Text", null, dataPath + "." + dataColumn.ColumnName);
            }

            table.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0);
            band.Controls.Add(table);
            indent += 50;
        }

        private XtraReportBase CreateReportForTable(XtraReportBase parentReport, DataTable dataTable, string dataPath) {
            DetailReportBand detailReport = new DetailReportBand();
            DetailBand detailBand = new DetailBand();

            detailBand.Height = 25;
            detailReport.Bands.Add(detailBand);
            parentReport.Bands.Add(detailReport);
            AddDataFieldsToBand(dataTable, detailBand, dataPath, false);
            detailReport.DataMember = dataPath;

            return detailReport;
        }

    }

}
