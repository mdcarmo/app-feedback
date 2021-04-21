using Feedback.Models;
using System;

namespace Feedback.ViewModels
{
    public class FeedBackDetailViewModel: BaseViewModel
    {
        public FeedBack FeedBack { get; set; }

        public bool IsNewFeedBack { get; set; }

        public String FeedBackAuthor
        {
            get { return FeedBack.Author; }
            set
            {
                FeedBack.Author = value;
                OnPropertyChanged();
            }
        }

        public String FeedBackDescription
        {
            get { return FeedBack.Description; }
            set
            {
                FeedBack.Description = value;
                OnPropertyChanged();
            }
        }

        public DateTime FeedBackRegisterDate
        {
            get { return FeedBack.RegisterDate; }
            set
            {
                FeedBack.RegisterDate = DateTime.Now;
                OnPropertyChanged();
            }
        }

        public FeedBackType FeedBackType
        {
            get { return FeedBack.Type; }
            set
            {
                FeedBack.Type = value;
                OnPropertyChanged();
            }
        }

        public FeedBackDetailViewModel(FeedBack feedBack = null)
        {
            IsNewFeedBack = feedBack == null;

            Title = IsNewFeedBack ? "Adicionar FeedBack" : "Editar FeedBack";
            FeedBack = feedBack ?? new FeedBack();
        }
    }
}
