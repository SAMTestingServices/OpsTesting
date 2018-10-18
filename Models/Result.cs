using System.ComponentModel.DataAnnotations.Schema;

namespace Clarksons.Cloud.Logging.Models
{

    [Table("Results")]
    public class Result
    {
        public int Id { get; set; }
        public string ResultType { get; set; }
    }
}
