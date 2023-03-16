using CaseManagementApp.Models;
using CaseManagementApp.Models.Entities;
using CaseManagementApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Printing;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CaseManagementApp.ViewModels
{
    public partial class CasesViewModel : ObservableObject
    {
        private string selectedStatus = string.Empty;

        public CasesViewModel()
        {
            LoadCasesAsync();
        }

        [ObservableProperty]
        private ObservableCollection<Report> reports = null!;

        [ObservableProperty]
        private Report selectedReport = null!;

        [ObservableProperty]
        private bool selectedIsNotNull = false;

        [ObservableProperty]
        private ObservableCollection<Comment> comments = null!;

        public ObservableCollection<string> Statuses { get; set; } = new ObservableCollection<string> { "Ej påbörjad", "Pågående", "Avslutad" };

        [ObservableProperty]
        private string commentText;

        public string SelectedStatus {
            get
            {
                return selectedStatus;
            }
            set
            {
                if(SelectedReport != null!)
                {
                    selectedStatus = value;
                    SelectedReport.Status = selectedStatus;
                    UpdateStatus();
                }

            } 
        }


        private async void LoadCasesAsync()
        {
            Reports = new ObservableCollection<Report>(await CaseService.GetAllAsync());
        }

        public async void ShowCommentsAsync(Report report)
        {
            Comments = new ObservableCollection<Comment>(await CommentService.GetCommentsAsync(report));
        }

        partial void OnSelectedReportChanged(Report value)
        {
            if(SelectedReport != null!)
            {
                SelectedIsNotNull = true;
                ShowCommentsAsync(SelectedReport);
            }

        }

        [RelayCommand]
        private async void AddComment()
        {
            var _selectedReport = SelectedReport;

            var _comment = new Comment
            {
                Text = CommentText,
                TimeStamp = DateTime.Now,
                ReportId = _selectedReport.Id
            };

            //save to database
            await CommentService.SaveCommentAsync(_selectedReport, _comment);

            CommentText = string.Empty;


            SelectedReport = null!;
            SelectedReport = _selectedReport;
        }

        
        public async void UpdateStatus()
        {

            //save to database
            await CaseService.UpdateStatusAsync(SelectedReport);
        }

        [RelayCommand]
        public async void RemoveButton()
        {
            if (MessageBox.Show("Är du säker på att du vill ta bort kontakten?", "RemoveQuestion", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
            {
                await CaseService.DeleteAsync(SelectedReport);
                LoadCasesAsync();
                SelectedIsNotNull = false;
            }
            else { }
        }
    }
}
