using Feedback.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feedback.Services
{
    public class MockFeedBackStore : IFeedBackStore
    {
        private static readonly List<FeedBack> mockFeedBacks;
        private static int nextFeedBackId;

        static MockFeedBackStore()
        {
            mockFeedBacks = new List<FeedBack>
            {
                new FeedBack { Id = 1, Author = "N/A", Description= "Sua entrega foi muito boa", RegisterDate = DateTime.Now, Type = FeedBackType.Positivo, BoxColor="#09BC8A"},
                new FeedBack { Id = 2, Author = "N/A", Description= "Muito Educado", RegisterDate = DateTime.Now, Type = FeedBackType.Positivo, BoxColor="#09BC8A"},
                new FeedBack { Id = 3, Author = "N/A", Description= "Foi impaciente ao conversar com outra equipe", RegisterDate = DateTime.Now, Type = FeedBackType.Negativo, BoxColor="#A30015"},
                new FeedBack { Id = 4, Author = "N/A", Description= "Destacou-se em desenvolver programas / estratégias que trouxeram os X resultados.", RegisterDate = DateTime.Now, Type = FeedBackType.Positivo, BoxColor="#09BC8A"},
                new FeedBack { Id = 5, Author = "N/A", Description= "Alcançou níveis ótimos de desempenho e performance", RegisterDate = DateTime.Now, Type = FeedBackType.Positivo, BoxColor="#09BC8A"},
                new FeedBack { Id = 6, Author = "N/A", Description= "Acompanha continuamente a eficácia administrativa e busca melhores procedimentos", RegisterDate = DateTime.Now, Type = FeedBackType.Positivo, BoxColor="#09BC8A"},
                new FeedBack { Id = 7, Author = "N/A", Description= "Está constantemente fazendo testes para trazer", RegisterDate = DateTime.Now, Type = FeedBackType.Positivo, BoxColor="#09BC8A"},
                new FeedBack { Id = 8, Author = "N/A", Description= "Não se esforçou o suficiente para realizar a entrega", RegisterDate = DateTime.Now, Type = FeedBackType.Negativo, BoxColor="#A30015"},
                new FeedBack { Id = 9, Author = "N/A", Description= "Não constuma ser proativo", RegisterDate = DateTime.Now, Type = FeedBackType.Negativo, BoxColor="#A30015"},
            };

            nextFeedBackId = mockFeedBacks.Count;
        }

        public MockFeedBackStore()
        {
        }

        public async Task<int> AddAsync(FeedBack feedBack)
        {
            lock (this)
            {
                feedBack.Id = nextFeedBackId;
                mockFeedBacks.Add(feedBack);
                nextFeedBackId++;
            }
            return await Task.FromResult(feedBack.Id);
        }

        public async Task<FeedBack> GetAsync(int id)
        {
            var feedBack = mockFeedBacks.FirstOrDefault(x => x.Id == id);
            var returnFeedBack = CopyFeedBack(feedBack);
            return await Task.FromResult(returnFeedBack);
        }

        public async Task<IList<FeedBack>> GetListAsync()
        {
            var returnFeedBacks = new List<FeedBack>();
            foreach (var feedBack in mockFeedBacks)
                returnFeedBacks.Add(CopyFeedBack(feedBack));
            return await Task.FromResult(returnFeedBacks);
        }

        private static FeedBack CopyFeedBack(FeedBack feedBack)
        {
            return new FeedBack { Id = feedBack.Id, Author = feedBack.Author, Description = feedBack.Description, RegisterDate = feedBack.RegisterDate, Type = feedBack.Type, BoxColor = feedBack.BoxColor };
        }
    }
}
