using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TDSencryption;

namespace KFSolutions.UnitTestBusiness
{
    class UITcustomEncrypter : TDScrypto
    {

        public override bool IsValidKeyToDecrypt(string aKeyToDecrypt)
        {
            return base.IsValidKeyToDecrypt(aKeyToDecrypt);
        }
        public override bool IsValidKeyToEncrypt(string aKeyToDecrypt)
        {

           return  new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?\"\'()@$%^&*+./.,-]).{8,20}$").IsMatch(aKeyToDecrypt);
        }

        public override bool IsValidStringToDecrypt(string aStringToDecrypt)
        {
            return base.IsValidStringToDecrypt(aStringToDecrypt);
        }

        public override bool IsValidStringToEncrypt(string aStringToEncrypt)
        {
            //cijfers, grote en kleine letters, underscores en range
            return new Regex("^[0-9A-Za-z]{5,20}$").IsMatch(aStringToEncrypt);
        }
    }
}
