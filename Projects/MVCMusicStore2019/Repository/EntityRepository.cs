using MVCMusicStore2019.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace MVCMusicStore2019.Repository
{
    public class EntityRepository<T>:IEntityRepository<T> where T:class, IEntity,new()
    {
        readonly MusicDbContext _context;
        public EntityRepository(MusicDbContext context)
        {
            _context = context;
        }
        public virtual IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }
        public virtual void Create(T entity)
        {
            DbEntityEntry dbEntityEntry = _context.Entry<T>(entity);
            _context.Set<T>().Add(entity);
        }
        public virtual void Save()
        {
            _context.SaveChanges();
        }
        public virtual void AddAndSave(T entity)
        {
            Create(entity);
            Save();
        }
        //public virtual void Delete(Guid objectId)
        //{
        //    var dbSet = _context.Set(typeof(T));
        //    var returnStatus = true;
        //    var returnMessage = "";
        //    var bo = dbSet.Find(objectId);
        //    if (bo == null)
        //    {
        //        returnStatus = false;
        //        returnMessage = "你所删除的数据不存在。";
        //    }
        //    else
        //    {
        //        if (returnStatus)
        //        {
        //            try
        //            {
        //                dbSet.Remove(bo);
        //                _context.SaveChanges();
        //                returnMessage = "删除成功。";
        //            }
        //            catch
        //            {
        //                returnStatus = false;
        //                returnMessage = "删除失败。";
        //            }
        //        }
        //    }
        //}
        //public virtual T FindSingle(Guid objectId)
        //{
        //    return GetAll().FirstOrDefault(x => x.Id == objectId);
        //}
        public virtual void Edit(T entity)
        {
            if(entity==null)
            {
                throw new ArgumentException("entity实体为空");
            }
            else
            {
                DbEntityEntry dbEntityEntry = _context.Entry<T>(entity);
                RemoveHoldingEntityInContext(entity);
                _context.Set<T>().Attach(entity);
                dbEntityEntry.State = EntityState.Modified;
                Save();
            }
            
        }

        private Boolean RemoveHoldingEntityInContext(T entity)
        {
            var objContext = ((IObjectContextAdapter)_context).ObjectContext;
            var objSet = objContext.CreateObjectSet<T>();
            var entityKey = objContext.CreateEntityKey(objSet.EntitySet.Name, entity);

            Object foundEntity;
            var exists = objContext.TryGetObjectByKey(entityKey, out foundEntity);

            if(exists)
            {
                objContext.Detach(foundEntity);
            }
            return (exists);
        }

        public virtual T GetSingleById(Guid id)
        {
            T entity = _context.Set<T>().Where(x => x.Id == id).DefaultIfEmpty<T>().First();

            if (entity!=null)
                return _context.Set<T>().Where(x => x.Id == id).First();
            else
                return null;
            
        }

        public bool Delete(Guid id)
        {
            var dbSet = _context.Set(typeof(T));//获取实体的数据集
            var returnStatus = true;//定义状态值
            var entity = dbSet.Find(id);//根据id查找数据集中的一条记录
            if(entity==null)
            {
                returnStatus = false;
            }
            else
            {
                if(returnStatus)
                {
                    try
                    {
                        dbSet.Remove(entity);//当查找结果为true，移除本次查找记录
                        _context.SaveChanges();//保存，存盘
                        return returnStatus;
                    }
                    catch
                    {
                        returnStatus = false;
                    }
                }
            }
            return returnStatus;
        }
        /// <summary>
        /// 获取关联类数据集
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <returns></returns>
        public virtual IQueryable<T1> GetRelevance<T1>()
        {
            var dbList = _context.Set(typeof(T1));
            var query = dbList as IQueryable<T1>;
            return query;
        }
        /// <summary>
        /// 获取关联类数据
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual T1 GetSingleRelevance<T1>(Guid id)
        {
            var dbSet = _context.Set(typeof(T1));
            return (T1)dbSet.Find(id);
        }
    }
}