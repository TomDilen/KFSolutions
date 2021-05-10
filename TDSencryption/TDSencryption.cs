using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TDSencryption
{
    public  class TDSencryption
    {

        private const int LENGTE_ENCRYPT_ZONDER_SOM = 40;


        #region ========================================================================EncriptString
        public static string EncriptString(string aString, string aSleutel)
        {

            Thread.Sleep(1); //om te testen, nog wegdoen
            Random rnd = new Random();
            string terug = aString;
            int asciSomSleutel = SomAscciVanKarakters(aSleutel);
            //string tussentegooienrommel = "!@#$%^&*()_+=[{]};:<>|./?,-";


            terug = Somvan2stringen(terug, "ma" + aSleutel + "tr");
            terug = DraaiStringOm(terug);

            //karaktertjes nog een beetje bijwerken
            //-------------------------------------
            string tmp = string.Empty;
            for (int i = 0; i < terug.Length; i++)
            {
                if (i % 4 == 0) tmp += (char)(terug[i] + 4);
                else if (i % 4 == 1) tmp += (char)(terug[i] + 1);
                else if (i % 4 == 2) tmp += (char)(terug[i] - 1);
                else if (i % 4 == 3) tmp += (char)(terug[i] - 4);
            }
            terug = tmp;

            //en we gooien er nog wat random charkes tussen :-)
            //--------------------------------------------------
            tmp = string.Empty;
            for (int i = 0; i < terug.Length; i++)
            {
                //int randomKarakter = rnd.Next(tussentegooienrommel.Length);
                //tmp += terug[i] + tussentegooienrommel[randomKarakter].ToString();
                tmp += terug[i] + ((char)(rnd.Next(220) + 34)).ToString();
            }
            terug = tmp;

            //  !!!  terug heeft nu altijd een lengte van 2 keer het paswoord !!!

            //en nog wat charkes onderaan om de encrypty altijd even
            //lang te maken
            //-------------------------------------------------------------
            tmp = string.Empty;
            for (int i = terug.Length; i < LENGTE_ENCRYPT_ZONDER_SOM; i++)
            {
                //int randomKarakter = rnd.Next(tussentegooienrommel.Length);
                //tmp += tussentegooienrommel[randomKarakter].ToString();
                tmp += ((char)(rnd.Next(220) + 34)).ToString();
            }
            terug += tmp;


            //we hebben de lengte van het paswoord nodig in de decrypty,
            //dit verstoppen we in de 2 charkes die we achteraan invoegen 
            //(die we dan in de decryptie berekenen)
            //-------------------------------------------------------------
            int randomInt = rnd.Next(70) + 180;
            int calculated = randomInt - (aString.Length * 3);
            terug += (char)randomInt;
            terug += (char)calculated;




            return @terug;
        }
        #endregion===================================================================================






        #region ========================================================================DecriptString
        public static string DecriptString(string aString, string aSleutel)
        {
            byte b1 = (byte)aString[aString.Length - 2];
            byte b2 = (byte)aString[aString.Length - 1];

            string terug = aString.Substring(0, ((b1 - b2) / 3) * 2);

            //randomkarakters eruit filteren
            //------------------------------
            string tmp = string.Empty;
            for (int i = 0; i < terug.Length; i++)
            {
                if (i % 2 == 0)
                    tmp += terug[i];
            }
            terug = tmp;

            //bewerkte karaktertjes terug herstellen
            //--------------------------------------
            tmp = string.Empty;
            for (int i = 0; i < terug.Length; i++)
            {
                if (i % 4 == 0) tmp += (char)(terug[i] - 4);
                else if (i % 4 == 1) tmp += (char)(terug[i] - 1);
                else if (i % 4 == 2) tmp += (char)(terug[i] + 1);
                else if (i % 4 == 3) tmp += (char)(terug[i] + 4);
            }
            terug = tmp;

            terug = DraaiStringOm(terug);
            terug = Verschilvan2stringen(terug, "ma" + aSleutel + "tr");


            //-------------------------------------------- een ramp dat maar half werkt :-(
            //int asciSomSleutel = SomAscciVanKarakters(aSleutel);
            //string tmp = string.Empty;
            //for (int i = 0; i < terug.Length; i++)
            //{
            //    tmp += (char)((((int)(terug[i] - asciSomSleutel )%256)+256)%256);

            //    //Console.WriteLine("====" + ((int)terug[i]));
            //    //Console.WriteLine("====" + (asciSomSleutel - (int)terug[i]));
            //    //Console.WriteLine("====" + ((int)terug[i] - asciSomSleutel));
            //    //Console.WriteLine(((terug[i] - asciSomSleutel) % 256)+256);
            //    //Console.WriteLine("---------------------------------------");
            //}
            //terug = tmp;
            //-----------------------------------------------------------------------------

            return @terug;
        }

        #endregion===================================================================================








        #region ============================================================================= helpers
        private static string DraaiStringOm(string aString)
        {
            string terug = string.Empty;
            for (int i = aString.Length - 1; i >= 0; i--)
                terug += aString[i];
            return terug;
        }


        //--------------------------------------------------------------------------------
        private static int SomAscciVanKarakters(string aString)
        {
            int terug = 0;
            for (int i = 0; i < aString.Length; i++)
            {
                terug += (int)aString[i];
            }
            return terug;
        }
        //-------------------------------------------------------------------------------
        private static string Somvan2stringen(string aDeTerugTeGevenString, string aString2)
        {
            string terug = string.Empty;
            int kleinsteString = Math.Min(aDeTerugTeGevenString.Length, aString2.Length);
            char[] bewerkt = aDeTerugTeGevenString.ToCharArray();

            for (int i = 0; i < kleinsteString; i++)
            {
                bewerkt[i] = (char)(((int)aDeTerugTeGevenString[i] + (int)aString2[i]) % 256);
            }
            for (int i = 0; i < bewerkt.Length; i++)
            {
                terug += bewerkt[i];
            }
            return @terug;
        }
        //-------------------------------------------------------------------------------
        private static string Verschilvan2stringen(string aDeTerugTeGevenString, string aString2)
        {
            string terug = string.Empty;
            int kleinsteString = Math.Min(aDeTerugTeGevenString.Length, aString2.Length);

            char[] bewerkt = aDeTerugTeGevenString.ToCharArray();
            for (int i = 0; i < kleinsteString; i++)
            {
                //bewerkt[i] = (char)(((int)aDeTerugTeGevenString[i] - (int)aString2[i]) % 256);
                bewerkt[i] = (char)((((int)(aDeTerugTeGevenString[i] - (int)aString2[i]) % 256) + 256) % 256);
                //tmp +=     (char)((((int)(terug[i] -                   asciSomSleutel) % 256) + 256) % 256);
            }
            for (int i = 0; i < bewerkt.Length; i++)
            {
                terug += bewerkt[i];
            }
            return @terug;
        }


        #endregion===================================================================================


    }
}
