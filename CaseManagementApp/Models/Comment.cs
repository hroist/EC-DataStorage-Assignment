using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseManagementApp.Models
{
    internal class Comment
    {
        public int Id { get; set; }

        public string Text { get; set; } = null!;

        public int CaseId { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
