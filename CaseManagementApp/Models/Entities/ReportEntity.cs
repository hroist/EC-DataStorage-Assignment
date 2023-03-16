using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseManagementApp.Models.Entities
{
    internal class ReportEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string Description { get; set; } = string.Empty;

        [Required]
        public int StatusId { get; set; }
        public StatusEntity Status { get; set; } = null!;

        [Required]
        public int ClientId { get; set; }
        public ClientEntity Client { get; set; } = null!;

        public ICollection<CommentEntity>? Comments { get; set; }

        [Required]
        public DateTime TimeStamp { get; set; }
    }
}
