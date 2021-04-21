using Feedback.Models;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Feedback.ViewModels
{
    public class FeedBacksViewModel: BaseViewModel
    {
        public ObservableCollection<FeedBack> FeedBacks { get; set; }

        public Command LoadItemsCommand { get; set; }

        public FeedBacksViewModel()
        {
            Title = "FeedBack";
            FeedBacks = new ObservableCollection<FeedBack>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<FeedBackDetailViewModel, FeedBack>(this, "SaveNote",
                async (sender, feedBack) =>
                {
                    FeedBacks.Add(feedBack);
                    await FeedBackStore.AddAsync(feedBack);
                }
                );

            //MessagingCenter.Subscribe<FeedBackDetailViewModel, Note>(this, "UpdateNote",
            //    async (sender, note) =>
            //    {
            //        await NoteDataStore.UpdateNoteAsync(note);

            //        await ExecuteLoadItemsCommand();
            //    }
            //    );
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                FeedBacks.Clear();
                var feedBacks = await FeedBackStore.GetListAsync();
                foreach (var feedBack in feedBacks)
                {
                    FeedBacks.Add(feedBack);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
