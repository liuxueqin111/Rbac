using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryEF;
using RbacRepository.FenYe;

namespace RbacRepository
{
    public abstract class BaseDTO<T, TKey> : IBaseDTO<T, TKey>
        where T : class
        where TKey : struct
    {
        protected MyDbContext db;
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public virtual int Create(T list)
        {
            db.Set<T>().Add(list);
            return db.SaveChanges();
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="k"></param>
        /// <returns></returns>
        public virtual int Del(TKey k)
        {
            var list = db.Set<T>().Find(k);
            db.Remove(list);
            return db.SaveChanges();
        }
        /// <summary>
        /// 反填
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual T Get(int id)
        {
            return db.Set<T>().Find(id);
        }
        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        public virtual List<T> GetAll()
        {
            var list = db.Set<T>().AsQueryable();
            return list.ToList();
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="j"></param>
        /// <returns></returns>
        public virtual shuju GetFen(TiaoJian j)
        {
            var list = db.Role.AsQueryable();
            var to = list.Count();
            var data = list.Skip((j.pageindex - 1) * j.pagesize).Take(j.pagesize);
            shuju s = new shuju();
            s.totacount = to;
            s.shu = data.ToList();
            return s;
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public virtual int Upd(T t)
        {
            db.Entry<T>(t).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return db.SaveChanges();
        }

        /// <summary>
        /// 返回单件数据
        /// </summary>
        /// <returns></returns>
        public virtual T GetEntity(TKey key)
        {
            return db.Set<T>().Find(key);
        }

        /// <summary>
        /// 返回单件数据
        /// </summary>
        /// <returns></returns>
        public virtual T GetEntity(Expression<Func<T, bool>> predicate)
        {
            return db.Set<T>().Where(predicate).FirstOrDefault();
        }
    }
}
