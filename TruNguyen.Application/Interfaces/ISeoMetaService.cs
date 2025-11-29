using System.Collections.Generic;
using System.Threading.Tasks;
using TruNguyen.Domain.Entities;

namespace TruNguyen.Application.Interfaces
{
    public interface ISeoMetaService
    {
        Task<List<SeoMeta>> GetAll();
        Task<SeoMeta> GetById(int id);
        Task<bool> Insert(SeoMeta entity);
        Task<bool> Update(SeoMeta entity);
        Task<bool> Delete(SeoMeta entity);
    }
}
