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
using System.Text;
using System.Threading.Tasks;

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
        private ObservableCollection<Report> reports;

        [ObservableProperty]
        private Report selectedReport = null!;

        [ObservableProperty]
        private ObservableCollection<Comment> comments;

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
                selectedStatus = value;
                SelectedReport.Status = selectedStatus;
                UpdateStatus();
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
            ShowCommentsAsync(SelectedReport);

        }


        [RelayCommand]
        private async void AddComment()
        {
            var _comment = new Comment();

            _comment.Text = CommentText;
            _comment.TimeStamp = DateTime.Now;
            _comment.ReportId = SelectedReport.Id;

            //save to database
            await CommentService.SaveCommentAsync(SelectedReport, _comment);

            CommentText = string.Empty;

        }

        
        public async void UpdateStatus()
        {

            //save to database
            await CaseService.UpdateStatusAsync(SelectedReport);
        }

    }
}
