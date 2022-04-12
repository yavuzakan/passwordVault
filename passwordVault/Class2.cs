using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace passwordVault
{
    internal class Class2
    {

        private string decrypt; // field
        public string Decrypt   // property
        {

            set { decrypt = value; }

            get
            {
                try
                {
                    string textToDecrypt = decrypt;
                    string ToReturn = "";
                    string publickey = "12345678";
                    string secretkey = "87654321";
                    byte[] privatekeyByte = { };
                    privatekeyByte = System.Text.Encoding.UTF8.GetBytes(secretkey);
                    byte[] publickeybyte = { };
                    publickeybyte = System.Text.Encoding.UTF8.GetBytes(publickey);
                    MemoryStream ms = null;
                    CryptoStream cs = null;
                    byte[] inputbyteArray = new byte[textToDecrypt.Replace(" ", "+").Length];
                    inputbyteArray = Convert.FromBase64String(textToDecrypt.Replace(" ", "+"));
                    using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                    {
                        ms = new MemoryStream();
                        cs = new CryptoStream(ms, des.CreateDecryptor(publickeybyte, privatekeyByte), CryptoStreamMode.Write);
                        cs.Write(inputbyteArray, 0, inputbyteArray.Length);
                        cs.FlushFinalBlock();
                        Encoding encoding = Encoding.UTF8;
                        ToReturn = encoding.GetString(ms.ToArray());
                    }
                    return ToReturn;
                }
                catch (Exception ae)
                {
                    throw new Exception(ae.Message, ae.InnerException);
                }



            }





        }





    }
}
