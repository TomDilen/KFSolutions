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
        List<OrderIn> GetForBalance();
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
                    OrderIn gevondenOrderIn = ctx.OrderIns
                        .Include(nameof(OrderIn.OrderLineIns))
                        .Include(nameof(OrderIn.OrderLineIns) + "." + nameof(OrderLineIn.Product))
                        .Where(x => x.Id == item).FirstOrDefault();
                    if (gevondenOrderIn == null)
                    {
                        throw new KeyNotFoundException($"id {item} niet gevonden tijdens het afhandelen van OrderIn");
                    }
                    foreach (var orderline in gevondenOrderIn.OrderLineIns)
                    {
                        //de stock updaten
                        orderline.Product.CountInStock += orderline.NumberOfProducts;
                    }

                    

                    gevondenOrderIn.Id_HandledBy = aEmployeeId;
                    gevondenOrderIn.HandledAt = nu;
                }

                ctx.SaveChanges();
            }
        }

        public List<OrderIn> GetForBalance()
        {
            List<OrderIn> terug = new List<OrderIn>();

            using (KfsContext ctx = new KfsContext(_constring))
            {
                terug = ctx.OrderIns
                    .Include(nameof(OrderIn.Supplier))
                    ////.Include(nameof(OrderOut.Client) + "." + nameof(Client.CltAddresss))
                    .Include(nameof(OrderIn.OrderLineIns))
                    .Include(nameof(OrderIn.OrderLineIns) + "." + nameof(OrderLineIn.Product))
                    .Include(nameof(OrderIn.OrderedBy))
                    .Include(nameof(OrderIn.HandledBy))
                    .ToList();
            }

            return terug;
        }

    }

}

