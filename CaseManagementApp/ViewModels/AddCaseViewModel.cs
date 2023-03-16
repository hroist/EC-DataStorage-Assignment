using CaseManagementApp.Models;
using CaseManagementApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CaseManagementApp.ViewModels
{
    public partial class AddCaseViewModel : ObservableValidator
    {

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "Fyll i ditt förnamn")]
        private string firstName = string.Empty;

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "Fyll i ditt efternamn")]
        private string lastName = string.Empty;

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "Fyll i din e-postadress")]
        private string email = string.Empty;

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [MaxLength(13, ErrorMessage = "Telefonnummer får innehålla maximalt 13 tecken inkl. mellanrum.")]
        private string phoneNumber = string.Empty;

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "Fyll i ämne för ditt ärende")]
        private string caseTitle = string.Empty;

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "Beskriv ditt ärende")]
        private string caseDescription = string.Empty;

        [ObservableProperty]
        private string message = string.Empty;

        [RelayCommand]
        private async void AddReport()
        {
            ValidateAllProperties();
            if(HasErrors)
            {
                Message = string.Join(Environment.NewLine, GetErrors().Select(x => x.ErrorMessage));
            } 
            else
            {
                Message = string.Empty;

                var _report = new Report
                {
                    ClientFirstName = FirstName,
                    ClientLastName = LastName,
                    ClientEmail = Email,
                    ClientPhoneNumber = PhoneNumber ?? "",
                    Title = CaseTitle,
                    Description = CaseDescription,
                    Status = "Ej påbörjad",
                    TimeStamp = DateTime.Now
                };

                //save to database
                await CaseService.SaveAsync(_report);

                // clear input fields
                FirstName = String.Empty;
                LastName = String.Empty;
                Email = String.Empty;
                PhoneNumber = String.Empty;
                CaseTitle = String.Empty;
                CaseDescription = String.Empty;

                ClearErrors();
            }
        }
    }
}
