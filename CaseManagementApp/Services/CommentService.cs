using CaseManagementApp.Contexts;
using CaseManagementApp.Models;
using CaseManagementApp.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseManagementApp.Services
{
    internal class CommentService
    {
        private static DataContext _context = new DataContext();

        public static async Task SaveCommentAsync(Report report, Comment comment)
        {
            var _commentEntity = new CommentEntity
            {
                Text = comment.Text,
                TimeStamp = DateTime.Now,
                ReportId = report.Id,
            };

            _context.Add(_commentEntity);
            await _context.SaveChangesAsync();
        }

        public static async Task<IEnumerable<Comment>> GetCommentsAsync(Report report)
        {
            var _comments = new List<Comment>();

            foreach (var _comment in await _context.Comments.Where(x => x.ReportId == report.Id).ToListAsync())
                _comments.Add(new Comment
                {
                    Id = _comment.Id,
                    Text = _comment.Text,
                    TimeStamp = _comment.TimeStamp,
                    ReportId = report.Id
                });
            return _comments;
        }
    }
}
