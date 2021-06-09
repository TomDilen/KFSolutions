using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
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

        Client Update(Client aClient);

        Client Delete(Client aClient);
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
                    .Include(nameof(Client.CltAddresss))
                    .Where(x => x.IsActive)
                    .ToList();
            }

           
            return terug;
        }

        public Client Update(Client aClient)
        {
            Client gevonden = null;


            using (KfsContext ctx = new KfsContext(_constring))
            {
                gevonden = ctx.Set<Client>()
                    .FirstOrDefault(u => u.Id == aClient.Id);

                if (gevonden == null)
                {
                    throw new DuplicateNameException($"user with {aClient.FirstName} not exist");
                }


                ctx.Entry(gevonden).CurrentValues.SetValues(aClient);


                ctx.Entry(gevonden.CltAddresss.ToList()[0]).CurrentValues.SetValues(aClient.CltAddresss.ToList()[0]);
                ctx.SaveChanges();

            }


            return gevonden;
        }


        public Client Delete(Client aClient)
        {

            Client gevonden = null;

                

            using (KfsContext ctx = new KfsContext(_constring))
            {
                gevonden = ctx.Set<Client>()
                    .FirstOrDefault(u => u.Id == aClient.Id);

                if (gevonden == null)
                {
                    throw new DuplicateNameException($"user with {aClient.FirstName} not exist");
                }

                gevonden.IsActive = false;
                ctx.SaveChanges();

            }

            return gevonden;
        }


    }


}
