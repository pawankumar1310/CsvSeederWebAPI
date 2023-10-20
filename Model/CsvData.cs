using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CsvSeederWebAPI.Model
{
    public class CsvData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Address { get; set; }
        // Add properties for other columns in your CSV
    }
}
