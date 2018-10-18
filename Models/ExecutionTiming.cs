using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clarksons.Cloud.Logging.Models
{
    
    public class ExecutionTiming
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? FinishTime { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public float? ExecutionTime { get; set; }
    }
}
