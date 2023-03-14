using CaseManagementApp.Models;
using CaseManagementApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseManagementApp.ViewModels
{
    public partial class CasesViewModel : ObservableObject
    {
        public CasesViewModel()
        {
            LoadCasesAsync();
        }

        private async void LoadCasesAsync()
        {
            Reports = new ObservableCollection<Report>(await CaseService.GetAllAsync());
        }


        [ObservableProperty]
        private ObservableCollection<Report> reports;


    }
}
