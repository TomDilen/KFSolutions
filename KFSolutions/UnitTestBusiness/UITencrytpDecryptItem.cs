using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDSencryption;

namespace KFSolutions.UnitTestBusiness
{
    class UITencrytpDecryptItem
    {
        public string UserName { get; set; }
        public string PasswordInitValue { get; set; }
        public string PasswordEncrypted { get; set; }
        public string PassWordDecrypted { get; set; }
        public string Result { get; set; }


        public static List<UITencrytpDecryptItem> Test_Encryp_DecryptVersie1(int aAantalTeGenereren)
        {
            List<UITencrytpDecryptItem> terug = new List<UITencrytpDecryptItem>();

            string kleineLetters = "abcdefghijklmnopqrstuvwxyz";
            string groteLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string cijfers = "0123456789";
            string toegelatenPaswoord = "!@#$%^&*()_+=[{]};:<>|./?,-";
            string toegelatenGebruikersnaam = "_";

            string ttPaswoord = kleineLetters + groteLetters + toegelatenPaswoord + cijfers;
            string ttGebruikersnaam = kleineLetters + groteLetters + toegelatenGebruikersnaam + cijfers;

            Random rnd = new Random();

            for (int i = 0; i < aAantalTeGenereren; i++)
            {
                UITencrytpDecryptItem newUITencrytpDecryptItem = new UITencrytpDecryptItem();

                //randomPaswoord aanmaken
                //--------------------------------------------------------------
                int lengteString = rnd.Next(8, 21);//van 8 tem 20
                string nieuwePasw = string.Empty;
                for (int j = 0; j < lengteString; j++)
                {
                    int randomKarakter = rnd.Next(ttPaswoord.Length);
                    nieuwePasw += ttPaswoord[randomKarakter];
                }
                //---------------------------------------
                newUITencrytpDecryptItem.PasswordInitValue = nieuwePasw;
                //---------------------------------------

                //random key aanmaken (key is gebruikersnaam)
                //--------------------------------------------------------------

                lengteString = rnd.Next(5, 21);//van 5 tem 20 (+1tjes om te testen)
                string nieuweGebr = string.Empty;
                for (int j = 0; j < lengteString; j++)
                {
                    int randomKarakter = rnd.Next(ttGebruikersnaam.Length);
                    nieuweGebr += ttGebruikersnaam[randomKarakter];
                }

                //---------------------------------------
                newUITencrytpDecryptItem.UserName = nieuweGebr;
                //---------------------------------------


                string encripted = TDSencryption.TDSencryption.EncriptString(nieuwePasw, nieuweGebr);
                string decripted = TDSencryption.TDSencryption.DecriptString(encripted, nieuweGebr);

                //---------------------------------------
                newUITencrytpDecryptItem.PasswordEncrypted = encripted;
                newUITencrytpDecryptItem.PassWordDecrypted = decripted;
                //---------------------------------------


                //int r = rnd.Next(100); //testen dat het werkt :-)
                //if (r == 1) decripted += "p";

                //in item steken



                if (nieuwePasw != decripted)
                {
                    newUITencrytpDecryptItem.Result = "ERROR_paswoorden komen niet overeen";
                }
                else
                {
                    newUITencrytpDecryptItem.Result = "ok";
                }
                terug.Add(newUITencrytpDecryptItem);

            }

            return terug;

        }
    }
}
