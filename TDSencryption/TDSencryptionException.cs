using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TDSencryption
{

    [Serializable]
    public class TDSencryptionException : Exception, ISerializable
    {
        public string Message_NL { get; private set; }
        public string Key { get; private set; }
        public string StringToEncryptOrDecrypt { get; private set; }

        //======================================================================constructors
        public TDSencryptionException(
            string aMessageEN, 
            string aMessageNL, 
            string aStringToEncryptOrDecrypt, 
            string aKey) 
                    : base(aMessageEN)
        {
            Message_NL = aMessageNL;
            StringToEncryptOrDecrypt = aStringToEncryptOrDecrypt;
            Key = aKey;
        }

        //--------------------------------------------------------------------------------
        // TODO: serialisatie testen
        //serialisatie op bijvoorbeeld een server, dit komt uit boek Exam Ref 70-483, 
        //moest deze op de server abnormaal doen dan moet hier nog aan gesleuteld worden
        protected TDSencryptionException( SerializationInfo info, StreamingContext context)
        {
            Message_NL = (string)info.GetValue("Message_NL", typeof(string));
            StringToEncryptOrDecrypt = (string)info.GetValue("StringToEncryptOrDecrypt", typeof(string));
            Key = (string)info.GetValue("Key", typeof(string));
        }
        //===============================================================================

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Message_NL", Message_NL, typeof(string));
            info.AddValue("StringToEncryptOrDecrypt", StringToEncryptOrDecrypt, typeof(string));
            info.AddValue("Key", Key, typeof(string));
        }
    }
}
