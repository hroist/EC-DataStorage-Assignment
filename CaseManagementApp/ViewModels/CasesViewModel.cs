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
            var cases = CaseService.GetAllAsync();
            
        }

        [ObservableProperty]
        private ObservableCollection<Case> cases;

  
    }
}
