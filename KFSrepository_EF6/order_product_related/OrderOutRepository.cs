using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KFSolutionsModel;


namespace KFSrepository_EF6
{


    public interface IOrderOutRepository : ITDSrepository<OrderOut>
    {
        OrderOut GetForInvoiceById(int aOrderoutId);

        List<OrderOut> GetForBalance();
        
    }

    public class OrderOutRepository : TDSrepository<OrderOut>, IOrderOutRepository
    {
        public OrderOutRepository(string aConnectionstring) : base(aConnectionstring)
        {

        }

        public override OrderOut Add(OrderOut aEntity)
        {
            OrderOut terug = null;

            using (KfsContext ctx = new KfsContext(_constring))
            {
                //bijwerken stok
                foreach (var lines in aEntity.OrderLineOuts)
                {
                    Product gevondenProdukt = ctx.Products.FirstOrDefault(x => x.EAN == lines.EAN_Product);
                    if (gevondenProdukt == null)
                    {
                        throw new KeyNotFoundException($"EAN {lines.EAN_Product}, niet gevonden bij het bijwerken van de stock");
                    }
                    gevondenProdukt.CountInStock -= lines.NumberOfProducts;
                }

                //als dat gelukt is dan bijwerken OrderOut
                terug = base.Add(aEntity);

                //uiteindelijk saven
                ctx.SaveChanges();
            }
            return terug;
        }



        public OrderOut GetForInvoiceById(int aOrderoutId)
        {
            OrderOut terug = null;

            using (KfsContext ctx = new KfsContext(_constring))
            {
                terug = ctx.OrderOuts
                    .Include(nameof( OrderOut.Client))
                    .Include(nameof(OrderOut.Client) + "." + nameof(Client.CltAddresss))
                    .Include(nameof( OrderOut.OrderLineOuts))
                    .Include(nameof(OrderOut.OrderLineOuts) + "." + nameof(OrderLineOut.Product))
                    .Where(x => x.Id == aOrderoutId)
                    
                    .FirstOrDefault();
            }
            return terug;
        }

        public List<OrderOut> GetForBalance()
        {
            List<OrderOut> terug = new List<OrderOut>();

            using (KfsContext ctx = new KfsContext(_constring))
            {
                terug = ctx.OrderOuts
                    .Include(nameof(OrderOut.Client))
                    //.Include(nameof(OrderOut.Client) + "." + nameof(Client.CltAddresss))
                    .Include(nameof(OrderOut.OrderLineOuts))
                    .Include(nameof(OrderOut.OrderLineOuts) + "." + nameof(OrderLineOut.Product))

                    .ToList();
            }

            return terug;
        }



    }



}