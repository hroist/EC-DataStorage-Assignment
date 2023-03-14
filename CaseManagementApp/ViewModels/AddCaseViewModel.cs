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
        private async void AddCase()
        {
            var _case = new Case();

            _case.ClientFirstName = FirstName;
            _case.ClientLastName = LastName;
            _case.ClientEmail = Email;
            _case.ClientPhoneNumber = PhoneNumber ?? "";
            _case.Title = CaseTitle;
            _case.Description = CaseDescription;
            _case.Status = "Ej påbörjad";
            _case.TimeStamp = DateTime.Now;

            //save to database
            await CaseService.SaveAsync(_case);

            FirstName = String.Empty;
            LastName = String.Empty;
            Email = String.Empty;
            PhoneNumber = String.Empty;
            CaseTitle = String.Empty;
            CaseDescription = String.Empty;

        }
    }
}
