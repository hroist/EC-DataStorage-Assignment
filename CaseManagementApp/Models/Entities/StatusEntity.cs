using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CaseManagementApp.Models.Entities
{
    internal class StatusEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Description { get; set; } = string.Empty;

        public ICollection<ReportEntity> Reports = new HashSet<ReportEntity>();
    }

}
