using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseManagementApp.Models
{
    internal class Case
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public string ClientFirstName { get; set; } = string.Empty;

        public string ClientLastName { get; set; } = string.Empty;

        public string ClientEmail { get; set; } = string.Empty;

        public string? ClientPhoneNumber { get; set; } 

        public DateTime TimeStamp { get; set; }

        public List<Comment>? Comments { get; set; }
    }
}
