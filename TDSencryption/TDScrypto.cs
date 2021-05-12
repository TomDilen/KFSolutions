using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace TDSencryption
{
    public class TDScrypto
    {

        private const int LENGTE_ENCRYPT_ZONDER_SOM = 40;


        #region ========================================================================EncriptString
        /// <summary>
        /// deze geeft een enctypted paswoord terug aan de hand van de sleutel, het encrypted paswoord
        /// is steeds 42 tekens lang, 
        /// als de sleutel <
        /// </summary>
        /// <param name="aStringToEncrypt"></param>
        /// <param name="aKey"></param>
        /// <returns></returns>
        public  string EncriptString(string aStringToEncrypt, string aKey)
        {
            //=====================================================standaard validatie
            if(string.IsNullOrEmpty( aStringToEncrypt)|| string.IsNullOrEmpty(aKey))
            {
                throw new TDSencryptionException(
                    $"The value or key is not an acceptable value to encrypt",
                    $"De waarde van de sleutel is geen acceptabele waarde om te encrypten",
                    aStringToEncrypt, aKey
                    );
            }
            if (aStringToEncrypt.Length>20 || aKey.Length>20)
            {
                throw new TDSencryptionException(
                    $"cannot encrypt: The length of the value or key can be up to 20 characters",
                    $"kan niet encrypten: De lengte van de waarde of de sleutel mag maximum 20 tekens lang zijn",
                    aStringToEncrypt, aKey
                    );
            }
            //=====================================================validation dat je kan overriden
            if ( ! IsValidStringToEncrypt(aStringToEncrypt))
            {
                throw new TDSencryptionException(
                    $"The value: {aStringToEncrypt} is not a valid value to encrypt",
                    $"De waarde: {aStringToEncrypt} is geen acceptabele waarde om te encrypten",
                    aStringToEncrypt,aKey
                    );
            }
            if(!IsValidKeyToEncrypt(aKey)){
                throw new TDSencryptionException(
                    $"The Key: {aStringToEncrypt} is not a valid Key to encrypt",
                    $"De sleutel: {aStringToEncrypt} is geen acceptabele sleutel om te encrypten",
                    aStringToEncrypt, aKey
                    );
            }
            //===============================================================




            //Thread.Sleep(1); //om te testen, nog wegdoen
            Random rnd = new Random();
            string terug = aStringToEncrypt;
            int asciSomSleutel = SomAscciVanKarakters(aKey);
            //string tussentegooienrommel = "!@#$%^&*()_+=[{]};:<>|./?,-";


            terug = Somvan2stringen(terug, "ma" + aKey + "tr");
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
            int calculated = randomInt - (aStringToEncrypt.Length * 3);
            terug += (char)randomInt;
            terug += (char)calculated;




            return @terug;
        }
        #endregion===================================================================================






        #region ========================================================================DecriptString
        public  string DecriptString(string aStringToDecrypt, string aKey)
        {
            //=====================================================standaard validatie
            if (string.IsNullOrEmpty(aStringToDecrypt) || string.IsNullOrEmpty(aKey))
            {
                throw new TDSencryptionException(
                    $"The value or key is not an acceptable value to decrypt",
                    $"De waarde van de sleutel is geen acceptabele waarde om te decrypten",
                    aStringToDecrypt, aKey
                    );
            }
            if (aKey.Length > 20)
            {
                throw new TDSencryptionException(
                    $"cannot decrypt: The length of the key can be up to 20 characters",
                    $"kan niet decrypten: De lengte van de sleutel mag maximum 20 tekens lang zijn",
                    aStringToDecrypt, aKey
                    );
            }
            if(aStringToDecrypt.Length != 42)
            {
                throw new TDSencryptionException(
                    $"cannot decrypt: the length of the value must be 42 characters long",
                    $"kan niet decrypten: De lengte van de sleutel moet 42 tekens lang zijn",
                    aStringToDecrypt, aKey
                    );
            }
            //=====================================================validation dat je kan overriden
            if (!IsValidStringToEncrypt(aStringToDecrypt))
            {
                throw new TDSencryptionException(
                    $"The value: {aStringToDecrypt} is not a valid value to decrypt",
                    $"De waarde: {aStringToDecrypt} is geen acceptabele waarde om te decrypten",
                    aStringToDecrypt, aKey
                    );
            }
            if (!IsValidKeyToEncrypt(aKey))
            {
                throw new TDSencryptionException(
                    $"The Key: {aStringToDecrypt} is not a valid Key to decrypt",
                    $"De sleutel: {aStringToDecrypt} is geen acceptabele sleutel om te decrypten",
                    aStringToDecrypt, aKey
                    );
            }
            //===============================================================


            byte b1 = (byte)aStringToDecrypt[aStringToDecrypt.Length - 2];
            byte b2 = (byte)aStringToDecrypt[aStringToDecrypt.Length - 1];

            string terug = aStringToDecrypt.Substring(0, ((b1 - b2) / 3) * 2);

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
            terug = Verschilvan2stringen(terug, "ma" + aKey + "tr");


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
        private  string DraaiStringOm(string aString)
        {
            string terug = string.Empty;
            for (int i = aString.Length - 1; i >= 0; i--)
                terug += aString[i];
            return terug;
        }


        //--------------------------------------------------------------------------------
        private  int SomAscciVanKarakters(string aString)
        {
            int terug = 0;
            for (int i = 0; i < aString.Length; i++)
            {
                terug += (int)aString[i];
            }
            return terug;
        }
        //-------------------------------------------------------------------------------
        private  string Somvan2stringen(string aDeTerugTeGevenString, string aString2)
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
        private  string Verschilvan2stringen(string aDeTerugTeGevenString, string aString2)
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

        public virtual bool IsValidKeyToEncrypt(string aKeyToDecrypt)
        {
            return true;
        }
        public virtual bool IsValidKeyToDecrypt(string aKeyToDecrypt)
        {
            return true;
        }
        public virtual bool IsValidStringToEncrypt(string aStringToEncrypt)
        {
            return true;
        }
        //public virtual bool IsValidStringToDecrypt(string aStringToDecrypt)
        //{
        //    return true;
        //}




    }
}
