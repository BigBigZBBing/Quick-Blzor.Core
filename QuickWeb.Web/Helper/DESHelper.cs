using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace QuickWeb.Web.Helper
{
    public static class DESHelper
    {
        //密钥
        public static readonly byte[] _KEY = new byte[]
        {
            0x01, 0x02, 0x03, 0x04,
            0x05, 0x06, 0x07, 0x08
        };

        //向量
        public static readonly byte[] _IV = new byte[]
        {
            0x08, 0x07, 0x06, 0x05,
            0x04, 0x03, 0x02, 0x01
        };

        /// <summary>
        /// DES加密
        /// </summary>
        /// <param name="input">待加密的字符串</param>
        /// <param name="key">加密密钥</param>
        /// <returns></returns>
        public static string Encrypt(string EncryptString)
        {
            //byte[] rgbKey = Encoding.UTF8.GetBytes(key.Substring(0, 8));
            byte[] inputByteArray = Encoding.UTF8.GetBytes(EncryptString);
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            MemoryStream mStream = new MemoryStream();
            CryptoStream cStream = new CryptoStream(mStream, des.CreateEncryptor(_KEY, _IV), CryptoStreamMode.Write);
            cStream.Write(inputByteArray, 0, inputByteArray.Length);
            cStream.FlushFinalBlock();
            return Convert.ToBase64String(mStream.ToArray());
        }

        /// <summary>
        /// DES解密
        /// </summary>
        /// <param name="input">待解密的字符串</param>
        /// <param name="key">解密密钥,要求为8位,和加密密钥相同</param>
        /// <returns>解密成功返回解密后的字符串,失败返源串</returns>
        public static string Decrypt(string DecryptString)
        {
            try
            {
                //byte[] rgbKey = Encoding.UTF8.GetBytes(Key);
                byte[] inputByteArray = Convert.FromBase64String(DecryptString);
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();

                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, des.CreateDecryptor(_KEY, _IV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Encoding.UTF8.GetString(mStream.ToArray());
            }
            catch
            {
                return "";
            }
        }
    }
}