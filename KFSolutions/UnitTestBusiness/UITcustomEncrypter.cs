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
            return new Regex("^[0-9A-Za-z_]{5,20}$").IsMatch(aKeyToDecrypt);
        }
        public override bool IsValidKeyToEncrypt(string aKeyToDecrypt)
        {
            //cijfers, grote en kleine letters, underscores en range
            return new Regex("^[0-9A-Za-z_]{5,20}$").IsMatch(aKeyToDecrypt);
        }


        public override bool IsValidStringToEncrypt(string aStringToEncrypt)
        {
            string geldigPaswoordRegString =
                "^"
                +
                "(?=.*[A-Z]+)"          // [A-Z] betekend een hoofdletter, het plusje betekend '1 of meer'
                +
                "(?=.*[a-z]+)"          // [a-z] betekend een kleine letter, het plusje betekend '1 of meer'
                +
                "(?=.*[0-9]+)"          // [0-9] betekend een digital, het plusje betekend '1 of meer'
                +
                $"(?=.*[_]+)"           //tekens tss aanhalingstekenz, het plusje betekend '1 of meer'
                +
                ".{8,20}$"         // !!! zou moeten kijken of het geheel 8tot 20 lang is, bovengrens is niet gelukt !!!
            ;

            return new Regex(geldigPaswoordRegString).IsMatch(aStringToEncrypt);


            //"^[a-zA-Z0-9_]*$"

            //^ : start of string
            //[ : beginning of character group
            //a - z : any lowercase letter
            //A - Z : any uppercase letter
            //0 - 9 : any digit
            //_ : underscore
            //] : end of character group
            //* : zero or more of the given characters
            //$ : end of string
        }
    }
}
