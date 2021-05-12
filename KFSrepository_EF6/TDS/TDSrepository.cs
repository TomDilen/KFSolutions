using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFSrepository_EF6
{
    public class TDSrepository<TDSentity> : ITDSrepository<TDSentity>
        //where TDSxxx : DbContext
        where TDSentity : class 
    {
        //readonly kan enkel in constructor of hier aangemaakt xworden
        //protected readonly DbContext _context;

        protected readonly string _constring = string.Empty;
        //================================================================================== constructor
        public TDSrepository(string aConnectionString)
        {
            _constring = aConnectionString;
           
        }

        //======================================================================================== reads
        //public virtual TDSentity GetById(int aId)
        //{
        //    //hetEntity Framework vereist dat deze methode hetzelfde exemplaar retourneert
        //    //elke keer dat het wordt aangeroepen voor een gegeven contextinstantie en entiteitstype.
        //    //de niet-algemene System.Data.Entity.DbSet geretourneerd door de System.Data.Entity.DbContext.Set(System.Type)
        //    //methode moet dezelfde onderliggende query en set entiteiten bevatten.Deze invarianten
        //    //moet worden gehandhaafd als deze methode wordt overschreven voor iets anders dan het maken van
        //    //test verdubbelt voor het testen van eenheden. Zie de klasse System.Data.Entity.DbSet'1 voor meer informatie
        //    //DbSet<TDSentity> tmp = _context.Set<TDSentity>();

        //    //Vindt een entiteit met de opgegeven primaire sleutelwaarden. Als een entiteit met de opgegeven
        //    //primaire sleutelwaarden bestaan ​​in de context en worden onmiddellijk zonder
        //    //het doen van een verzoek aan de DB, anders wordt er een verzoek gedaan aan de DB voor
        //    //een entiteit met de opgegeven primaire sleutelwaarden en deze entiteit, indien gevonden, is bijgevoegd
        //    //aan de context en keerde terug.Als er geen entiteit wordt gevonden in de context of de DB,
        //    //dan wordt null geretourneerd.
        //    //TDSentity terug = tmp.Find(aId);
        //    TDSentity terug = null;
        //    return terug;
        //}
        ////---------------------------------------------------------------------------------- 
        public virtual IEnumerable<TDSentity> GetAll()
        {
            IEnumerable<TDSentity> terug = null;
            using (var ctx = new KfsContext(_constring))
            {
                terug = ctx.Set<TDSentity>().ToList();
            }
            return terug;
        }
        //{
        //    return _context.Set<TDSentity>().ToList();
        //}
        ////----------------------------------------------------------------------------------
        //public virtual IEnumerable<TDSentity> Find(Expression<Func<TDSentity, bool>> aPredicate)
        //{
        //    throw new NotImplementedException();
        //}
        ////----------------------------------------------------------------------------------
        //public virtual TDSentity SingleOrDefault(Expression<Func<TDSentity, bool>> aPredicate)
        //{
        //    return _context.Set<TDSentity>().SingleOrDefault(aPredicate);
        //}

        ////===================================================================================== Create's
        public virtual TDSentity Add(TDSentity aEntity)
        {
            if (aEntity is IDateTimeCreateAndUpdate)
            {
                DateTime nu = DateTime.Now;
                (aEntity as IDateTimeCreateAndUpdate).CreatedAt = nu;
                (aEntity as IDateTimeCreateAndUpdate).UpdatedAt = nu;
            }

            using (KfsContext ctx = new KfsContext(_constring))
            {
                ctx.Set<TDSentity>().Add(aEntity);
                ctx.SaveChanges();
            }
            return aEntity;
        }
        //{
        //    _context.Set<TDSentity>().Add(aEntity);
        //}
        ////------------------------------------------------------------------------
        //public virtual void AddRange(IEnumerable<TDSentity> aEntities)
        //{
        //    throw new NotImplementedException();
        //}
        ////====================================================================================== Removes

        //public virtual void Remove(TDSentity aEntity)
        //{
        //    _context.Set<TDSentity>().Remove(aEntity);
        //}
        ////------------------------------------------------------------------------
        //public virtual void RemoveRange(IEnumerable<TDSentity> aEntities)
        //{
        //    throw new NotImplementedException();
        //}
        //==================================================================================




        protected static void DisplayTrackedEntities(DbChangeTracker changeTracker)
        {
            Console.WriteLine("");

            var entries = changeTracker.Entries();
            foreach (var entry in entries)
            {
                Console.WriteLine("Entity Name: {0}", entry.Entity.GetType().FullName);
                Console.WriteLine("Status: {0}", entry.State);
            }
            Console.WriteLine("");
            Console.WriteLine("---------------------------------------");
        }
    }
}
