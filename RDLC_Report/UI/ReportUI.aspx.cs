using Microsoft.Reporting.WebForms;
using Microsoft.ReportingServices.Diagnostics.Internal;
using RDLC_Report.ReportDataSets;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RDLC_Report.UI
{
    public partial class ReportUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoadReport_Click(object sender, EventArgs e)
        {
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/StudentDetails.rdlc");

            StudentDataSet student = GetData();
            ReportDataSource dataSource = new ReportDataSource("StudentDataSet", student.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(dataSource);


        }
        private StudentDataSet GetData () {
            string conString = ConfigurationManager.ConnectionStrings["StudentDBTestConString"].ConnectionString;
            string query = "[spGetStudents]";
            SqlCommand command = new SqlCommand(query);
            command.CommandType=System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@StudentID", Convert.ToInt32(TextID.Text));
            using (SqlConnection connection = new SqlConnection(conString))
            {
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    command.Connection = connection;
                    da.SelectCommand = command;
                    using (StudentDataSet student = new StudentDataSet())
                    {
                        da.Fill(student,"Student");
                        return student;
                    }
                }
            }
        }
    }
}