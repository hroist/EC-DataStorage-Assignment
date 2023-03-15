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
    internal class CaseService
    {
        private static DataContext _context = new DataContext();

        public static async Task SaveAsync(Report report )
        {
            var _caseEntity = new ReportEntity
            {
                Title = report.Title,
                Description = report.Description,
                TimeStamp = report.TimeStamp,
            };

            var _clientEntity = await _context.Clients.FirstOrDefaultAsync(x => x.FirstName == report.ClientFirstName && x.LastName == report.ClientLastName && x.Email == report.ClientEmail && x.PhoneNumber == report.ClientPhoneNumber);
            if ( _clientEntity != null )
            {
                _caseEntity.ClientId = _clientEntity.Id;
            }
            else
            {
                _caseEntity.Client = new ClientEntity
                {
                    FirstName = report.ClientFirstName,
                    LastName = report.ClientLastName,
                    Email = report.ClientEmail,
                    PhoneNumber = report.ClientPhoneNumber
                };
            }

            var _statusEntity = await _context.Statuses.FirstOrDefaultAsync(x => x.Description == report.Status);
            if (_statusEntity != null)
            {
                _caseEntity.StatusId = _statusEntity.Id;
            }
            else
            {
                _caseEntity.Status = new StatusEntity
                {
                    Description = "Ej påbörjad"
                };
            }

            _context.Add( _caseEntity );
            await _context.SaveChangesAsync();
        }

        public static async Task<IEnumerable<Report>> GetAllAsync()
        {
            var _reports = new List<Report>();

            foreach(var _report in await _context.Reports.Include(x => x.Client).Include(x => x.Status).ToListAsync())
            {
                _reports.Add(new Report
                {
                    Id = _report.Id,
                    Title = _report.Title,
                    Description = _report.Description,
                    Status = _report.Status.Description,
                    ClientFirstName = _report.Client.FirstName,
                    ClientLastName = _report.Client.LastName,
                    ClientEmail = _report.Client.Email,
                    ClientPhoneNumber = _report.Client.PhoneNumber,
                    TimeStamp = _report.TimeStamp
                });
            }
            return _reports;
        }

        public static async Task UpdateStatusAsync(Report report)
        {
            var _reportEntity = await _context.Reports.Include(x => x.Client).Include(x => x.Status).FirstOrDefaultAsync(x => x.Id == report.Id);
            if( _reportEntity != null )
            {
                if (!string.IsNullOrEmpty(report.Status))
                {
                    var _statusEntity = await _context.Statuses.FirstOrDefaultAsync(x => x.Description == report.Status);
                    if( _statusEntity != null )
                    {
                        _reportEntity.StatusId = _statusEntity.Id;
                    }
                    else
                    {
                        _reportEntity.Status = new StatusEntity
                        {
                            Description = report.Status
                        };
                    }
                }
                _context.Update(_reportEntity);
                await _context.SaveChangesAsync();

            }
        }
    }
}
