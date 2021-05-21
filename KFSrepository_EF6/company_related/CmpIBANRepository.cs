using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KFSolutionsModel;


namespace KFSrepository_EF6
{


    public interface ICmpIBANRepository : ITDSrepository<CmpIBAN>
    {

    }

    public class CmpIBANRepository : TDSrepository<CmpIBAN>, ICmpIBANRepository
    {
        public CmpIBANRepository(string aConnectionstring) : base(aConnectionstring)
        {

        }
    }

}