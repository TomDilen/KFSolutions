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

    }

    public class ClientRepository : TDSrepository<Client>, IClientRepository
    {
        public ClientRepository(string aConnectionstring) : base(aConnectionstring)
        {

        }
    }

}
