using Feedback.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Feedback.Services
{
    public interface IFeedBackStore
    {
        Task<int> AddAsync(FeedBack feedBack);
        Task<FeedBack> GetAsync(int id);
        Task<IList<FeedBack>> GetListAsync();
    }
}
