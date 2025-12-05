using System.Collections.Generic;
using System.Threading.Tasks;
using TruNguyen.Domain.Entities;

namespace TruNguyen.Application.Interfaces
{
    public interface INewsSectionService
    {
        Task<List<NewsSection>> GetAll();
        Task<List<NewsSection>> GetByNewId(int newsId);
        Task<NewsSection> GetById(int id);
        Task<bool> Insert(NewsSection entity);
        Task<bool> Update(NewsSection entity);
        Task<bool> Delete(NewsSection entity);
    }
}
