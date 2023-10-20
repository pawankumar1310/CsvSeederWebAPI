//using System;
//using System.Data;
//using System.Data.SqlClient;
//using System.Web.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Office.Interop.Excel;

//namespace CsvSeederWebAPI.Controllers
//{
//    public class CsvExportController : ApiController
//    {
//        [HttpGet]
//        public IHttpActionResult ExportToExcel()
//        {
//            try
//            {
//                // Establish a database connection.
//                string connectionString = "Server = DESKTOP-RUJ2TUO;Database=TestDemo;Trusted_Connection=True;TrustServerCertificate=True;";
//                using (SqlConnection connection = new SqlConnection(connectionString))
//                {
//                    connection.Open();

//                    // Define a SQL query to retrieve data from your database.
//                    string sqlQuery = "SELECT * FROM YourTable";

//                    // Create a SqlDataAdapter to fetch the data.
//                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlQuery, connection))
//                    {
//                        DataTable dataTable = new DataTable();
//                        dataAdapter.Fill(dataTable);

//                        // Generate the Excel file.
//                        byte[] excelBytes = GenerateExcel(dataTable);

//                        // Return the Excel file as a downloadable response.
//                        return ResponseMessage(new System.Net.Http.HttpResponseMessage
//                        {
//                            Content = new System.Net.Http.ByteArrayContent(excelBytes),
//                            ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
//                            {
//                                FileName = "DataExport.xlsx"
//                            },
//                            StatusCode = System.Net.HttpStatusCode.OK
//                        });
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                return InternalServerError(ex);
//            }
//        }

//        byte[] GenerateExcel(DataTable dataTable)
//        {
//            Application excelApp = new Application();
//            Workbook workbook = excelApp.Workbooks.Add();
//            Worksheet worksheet = workbook.Sheets[1];

//            // Write the column headers to the Excel sheet.
//            for (int col = 0; col < dataTable.Columns.Count; col++)
//            {
//                worksheet.Cells[1, col + 1] = dataTable.Columns[col].ColumnName;
//            }

//            // Write the data from the DataTable to the Excel sheet.
//            for (int row = 0; row < dataTable.Rows.Count; row++)
//            {
//                for (int col = 0; col < dataTable.Columns.Count; col++)
//                {
//                    worksheet.Cells[row + 2, col + 1] = dataTable.Rows[row][col].ToString();
//                }
//            }

//            // Save the Excel workbook to a byte array.
//            byte[] excelBytes = null;
//            workbook.SaveAs(ref excelBytes);
//            workbook.Close();
//            excelApp.Quit();

//            return excelBytes;
//        }
//    }

//}
