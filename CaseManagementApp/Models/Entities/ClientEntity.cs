using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CaseManagementApp.Models.Entities
{
    internal class ClientEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "nvarchar(150)")]
        public string Email { get; set; } = string.Empty;

        [Column(TypeName = "char(13)")]
        public string? PhoneNumber { get; set; } = string.Empty;

        public ICollection <ReportEntity> Reports = new HashSet<ReportEntity>();
    }

}
