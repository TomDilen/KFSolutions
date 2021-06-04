using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KFSolutionsModel;


namespace KFSrepository_EF6
{


    public interface IOrderInRepository : ITDSrepository<OrderIn>
    {
        List<OrderIn> GetAll_forOrderInHandling();
        void HandlelOrders(List<int> aListOrder, int aEmployeeId);
    }

    public class OrderInRepository : TDSrepository<OrderIn>, IOrderInRepository
    {
        public OrderInRepository(string aConnectionstring) : base(aConnectionstring)
        {

        }

        public List<OrderIn> GetAll_forOrderInHandling()
        {
            List<OrderIn> terug = null;


            using (KfsContext ctx = new KfsContext(_constring))
            {
                terug = ctx.OrderIns
                    .Include(nameof(OrderIn.OrderLineIns))
                    .Include(nameof(OrderIn.OrderLineIns)+"."+ (nameof(OrderLineIn.Product)))
                    .Include(nameof(OrderIn.Supplier))
                    .Where(x => x.HandledBy == null)
                    .ToList();
            }

            return terug;
        }

        public void HandlelOrders(List<int> aListOrder, int aEmployeeId)
        {
            DateTime nu = DateTime.Now;
            
            using (KfsContext ctx = new KfsContext(_constring))
            {
                foreach (var item in aListOrder)
                {
                    OrderIn gevonden = ctx.OrderIns.Where(x => x.Id == item).FirstOrDefault();
                    if (gevonden == null)
                    {
                        throw new KeyNotFoundException($"id {item} niet gevonden tijdens het afhandelen van OrderIn");
                    }

                    gevonden.Id_HandledBy = aEmployeeId;
                    gevonden.HandledAt = nu;
                }

                ctx.SaveChanges();
            }


        }
    }

}