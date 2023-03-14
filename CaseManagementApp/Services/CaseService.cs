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

        public static async Task SaveAsync(Case c )
        {
            var _caseEntity = new CaseEntity
            {
                Title = c.Title,
                Description = c.Description,
                TimeStamp = c.TimeStamp,
            };

            var _clientEntity = await _context.Clients.FirstOrDefaultAsync(x => x.FirstName == c.ClientFirstName && x.LastName == c.ClientLastName && x.Email == c.ClientEmail && x.PhoneNumber == c.ClientPhoneNumber);
            if ( _clientEntity != null )
            {
                _caseEntity.ClientId = _clientEntity.Id;
            }
            else
            {
                _caseEntity.Client = new ClientEntity
                {
                    FirstName = c.ClientFirstName,
                    LastName = c.ClientLastName,
                    Email = c.ClientEmail,
                    PhoneNumber = c.ClientPhoneNumber
                };
            }

            var _statusEntity = await _context.Statuses.FirstOrDefaultAsync(x => x.Description == c.Status);
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

        public static async Task <IEnumerable<Case>> GetAllAsync()
        {
            var _cases = new List<Case>();

            foreach(var _case in await _context.Cases.Include(x => x.Client).Include(x => x.Status).ToListAsync())
            {
                _cases.Add(new Case
                {
                    Id = _case.Id,
                    Title = _case.Title,
                    Description = _case.Description,
                    Status = _case.Status.Description,
                    ClientFirstName = _case.Client.FirstName,
                    ClientLastName = _case.Client.LastName,
                    ClientEmail = _case.Client.Email,
                    ClientPhoneNumber = _case.Client.PhoneNumber,
                    TimeStamp = _case.TimeStamp

                });
            }


            return _cases;
        }
    }
}
