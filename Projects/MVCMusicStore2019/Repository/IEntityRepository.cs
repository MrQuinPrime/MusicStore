using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCMusicStore2019.Repository
{
    public interface IEntityRepository<T> where T:class,new()
    {
        IQueryable<T> GetAll();
        void Create(T entity);
        void AddAndSave(T entity);
        bool Delete(Guid id);

        //T FindSingle(Guid objectId);
        void Edit(T entity);
        T GetSingleById(Guid id);//根据ID查找一条匹配的数据

        IQueryable<T1> GetRelevance<T1>();

        T1 GetSingleRelevance<T1>(Guid id);
    }
}
