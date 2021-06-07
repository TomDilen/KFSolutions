using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KFSolutionsModel;


namespace KFSrepository_EF6
{


    public interface IClientRepository : ITDSrepository<Client>
    {
        List<Client> GetAllClientsWithAdress();

        List<Client> GetAllForOverview();
    }

    public class ClientRepository : TDSrepository<Client>, IClientRepository
    {
        public ClientRepository(string aConnectionstring) : base(aConnectionstring)
        {

        }

        public List<Client> GetAllClientsWithAdress()
        {
            List<Client> terug = new List<Client>();

            using (KfsContext ctx = new KfsContext(_constring))
            {
                terug = ctx.Clients
                    .Include(nameof(Client.CltAddresss)).ToList()
                    .ToList();
            }
            return terug;
        }

        public List<Client> GetAllForOverview()
        {
            List<Client> terug = new List<Client>();
            using (KfsContext ctx = new KfsContext(_constring))
            {
                terug = ctx.Set<Client>()
                    //.Include(nameof(EmpAppAccount.Employee))
                    .Where(x => x.IsActive)
                    .ToList();
            }

           
            return terug;
        }
    }


}
