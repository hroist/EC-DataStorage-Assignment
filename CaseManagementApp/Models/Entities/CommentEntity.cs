using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CaseManagementApp.Models.Entities
{
    internal class CommentEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CaseId { get; set; }
        public ReportEntity Report { get; set; } = null!;

        [Required]
        public DateTime TimeStamp { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string Text { get; set; } = string.Empty;

    }

}
