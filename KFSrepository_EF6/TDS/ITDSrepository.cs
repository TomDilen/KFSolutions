using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFSrepository_EF6
{
    public interface ITDSrepository<TDSentity> where TDSentity : class
        //public interface ITDSrepository<TEntity> where TEntity : new()
    {
        //TDSentity GetById(int aId);
        //IEnumerable<TDSentity> GetAll();
        //IEnumerable<TDSentity> Find(Expression<Func<TDSentity, bool>> aPredicate);
        //TDSentity SingleOrDefault(Expression<Func<TDSentity, bool>> aPredicate);

        TDSentity Add(TDSentity aEntity);

        //void AddRange(IEnumerable<TDSentity> aEntities);

        //void Remove(TDSentity aEntity);
        //void RemoveRange(IEnumerable<TDSentity> aEntities);


    }
}
