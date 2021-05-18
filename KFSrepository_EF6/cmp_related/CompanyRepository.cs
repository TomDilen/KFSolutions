using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KFSolutionsModel;

namespace KFSrepository_EF6
{


    public interface ICompanyRepository : ITDSrepository<Company>
    {

    }

    public class CompanyRepository : TDSrepository<Company>, ICompanyRepository
    {
        public CompanyRepository(string aConnectionstring) : base(aConnectionstring)
        {

        }
    }

}
