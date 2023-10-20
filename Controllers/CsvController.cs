using CsvHelper;
using CsvHelper.Configuration;
using CsvSeederWebAPI.Model;
using Microsoft.AspNetCore.Mvc;
using System.Formats.Asn1;
using System.Globalization;

namespace CsvSeederWebAPI.Controllers
{
    [Route("api/csv")]
    [ApiController]
    public class CsvController : ControllerBase
    {
        private readonly TestDemoDbContext _context;

        public CsvController(TestDemoDbContext context)
        {
            _context = context;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadCsv([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Invalid file");
            }

            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    var records = csv.GetRecords<CsvData>().ToList();
                    // Assuming CsvData is the model for your data table
                    // Now you can insert 'records' into the database using ADO.NET or Entity Framework

                    // Example using Entity Framework:
                    _context.CsvData.AddRange(records);
                    await _context.SaveChangesAsync();
                }
        }
        return Ok("CSV data uploaded and saved to the database.");
    }
}

}
