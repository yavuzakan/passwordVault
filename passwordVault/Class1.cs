using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

using System.Security.Cryptography;


namespace passwordVault
{
    internal class Class1
    {




        private string encrypt; // field
        public string Encrypt   // property
        {

            set { encrypt = value; }

            get
            {
                try
                {
                    string textToEncrypt = encrypt;
                    string ToReturn = "";
                    string publickey = "12345678";
                    string secretkey = "87654321";
                    byte[] secretkeyByte = { };
                    secretkeyByte = System.Text.Encoding.UTF8.GetBytes(secretkey);
                    byte[] publickeybyte = { };
                    publickeybyte = System.Text.Encoding.UTF8.GetBytes(publickey);
                    MemoryStream ms = null;
                    CryptoStream cs = null;
                    byte[] inputbyteArray = System.Text.Encoding.UTF8.GetBytes(textToEncrypt);
                    using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                    {
                        ms = new MemoryStream();
                        cs = new CryptoStream(ms, des.CreateEncryptor(publickeybyte, secretkeyByte), CryptoStreamMode.Write);
                        cs.Write(inputbyteArray, 0, inputbyteArray.Length);
                        cs.FlushFinalBlock();
                        ToReturn = Convert.ToBase64String(ms.ToArray());
                    }
                    return ToReturn;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex.InnerException);
                }



            }





        }








    }
}
