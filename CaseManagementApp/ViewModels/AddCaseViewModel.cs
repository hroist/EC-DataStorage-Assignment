using CaseManagementApp.Models;
using CaseManagementApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseManagementApp.ViewModels
{
    public partial class AddCaseViewModel : ObservableObject
    {

        [ObservableProperty]
        private string firstName = string.Empty;

        [ObservableProperty]
        private string lastName = string.Empty;

        [ObservableProperty]
        private string email = string.Empty;

        [ObservableProperty]
        private string phoneNumber = string.Empty;

        [ObservableProperty]
        private string caseTitle = string.Empty;

        [ObservableProperty]
        private string caseDescription = string.Empty;

        [RelayCommand]
        private async void AddReport()
        {
            var _report = new Report();

            _report.ClientFirstName = FirstName;
            _report.ClientLastName = LastName;
            _report.ClientEmail = Email;
            _report.ClientPhoneNumber = PhoneNumber ?? "";
            _report.Title = CaseTitle;
            _report.Description = CaseDescription;
            _report.Status = "Ej påbörjad";
            _report.TimeStamp = DateTime.Now;

            //save to database
            await CaseService.SaveAsync(_report);

            FirstName = String.Empty;
            LastName = String.Empty;
            Email = String.Empty;
            PhoneNumber = String.Empty;
            CaseTitle = String.Empty;
            CaseDescription = String.Empty;

        }
    }
}
