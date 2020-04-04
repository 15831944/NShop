using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Management;
using System.IO;
using System.IO.Compression;
namespace NShop.Funs
{
    class Encodetool
    {
        /**/
        /// <summary>
        /// MD5 16位加密 加密后密码为小写
        /// </summary>
        /// <param name="ConvertString"></param>
        /// <returns></returns>
        public static string Md5(string ConvertString)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            string t2 = BitConverter.ToString(md5.ComputeHash(Encoding.GetEncoding("GBK").GetBytes(ConvertString)), 4, 8);
            t2 = t2.Replace("-", "");
            return t2;

        }

        /**/
        /// <summary>
        /// MD5　32位加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Md5_32(string str)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] encryptedBytes = md5.ComputeHash(Encoding.GetEncoding("GBK").GetBytes(str));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < encryptedBytes.Length; i++)
            {
                sb.AppendFormat("{0:x2}", encryptedBytes[i]);
            }
            return sb.ToString();
        }



        public static string Base64Encode(string Message)
        {
            char[] Base64Code = new char[]{'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T',
         'U','V','W','X','Y','Z','a','b','c','d','e','f','g','h','i','j','k','l','m','n',
         'o','p','q','r','s','t','u','v','w','x','y','z','0','1','2','3','4','5','6','7',
         '8','9','+','/','='};
            byte empty = (byte)0;
            System.Collections.ArrayList byteMessage = new System.Collections.ArrayList(Encoding.GetEncoding("GBK").GetBytes(Message));
            System.Text.StringBuilder outmessage;
            int messageLen = byteMessage.Count;
            int page = messageLen / 3;
            int use = 0;
            if ((use = messageLen % 3) > 0)
            {
                for (int i = 0; i < 3 - use; i++)
                    byteMessage.Add(empty);
                page++;
            }
            outmessage = new System.Text.StringBuilder(page * 4);
            for (int i = 0; i < page; i++)
            {
                byte[] instr = new byte[3];
                instr[0] = (byte)byteMessage[i * 3];
                instr[1] = (byte)byteMessage[i * 3 + 1];
                instr[2] = (byte)byteMessage[i * 3 + 2];
                int[] outstr = new int[4];
                outstr[0] = instr[0] >> 2;
                outstr[1] = ((instr[0] & 0x03) << 4) ^ (instr[1] >> 4);
                if (!instr[1].Equals(empty))
                    outstr[2] = ((instr[1] & 0x0f) << 2) ^ (instr[2] >> 6);
                else
                    outstr[2] = 64;
                if (!instr[2].Equals(empty))
                    outstr[3] = (instr[2] & 0x3f);
                else
                    outstr[3] = 64;
                outmessage.Append(Base64Code[outstr[0]]);
                outmessage.Append(Base64Code[outstr[1]]);
                outmessage.Append(Base64Code[outstr[2]]);
                outmessage.Append(Base64Code[outstr[3]]);
            }
            return outmessage.ToString();
        }

        /// <summary>
        /// Base64解码
        /// </summary>
        /// <param name="Message"></param>
        /// <returns></returns>
        public static string Base64Decode(string Message)
        {
            if ((Message.Length % 4) != 0)
            {
                throw new ArgumentException("不是正确的BASE64编码，请检查。", "Message");
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(Message, "^[A-Z0-9/+=]*$", System.Text.RegularExpressions.RegexOptions.IgnoreCase))
            {
                throw new ArgumentException("包含不正确的BASE64编码，请检查。", "Message");
            }
            string Base64Code = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=";
            int page = Message.Length / 4;
            System.Collections.ArrayList outMessage = new System.Collections.ArrayList(page * 3);
            char[] message = Message.ToCharArray();
            for (int i = 0; i < page; i++)
            {
                byte[] instr = new byte[4];
                instr[0] = (byte)Base64Code.IndexOf(message[i * 4]);
                instr[1] = (byte)Base64Code.IndexOf(message[i * 4 + 1]);
                instr[2] = (byte)Base64Code.IndexOf(message[i * 4 + 2]);
                instr[3] = (byte)Base64Code.IndexOf(message[i * 4 + 3]);
                byte[] outstr = new byte[3];
                outstr[0] = (byte)((instr[0] << 2) ^ ((instr[1] & 0x30) >> 4));
                if (instr[2] != 64)
                {
                    outstr[1] = (byte)((instr[1] << 4) ^ ((instr[2] & 0x3c) >> 2));
                }
                else
                {
                    outstr[2] = 0;
                }
                if (instr[3] != 64)
                {
                    outstr[2] = (byte)((instr[2] << 6) ^ instr[3]);
                }
                else
                {
                    outstr[2] = 0;
                }
                outMessage.Add(outstr[0]);
                if (outstr[1] != 0)
                    outMessage.Add(outstr[1]);
                if (outstr[2] != 0)
                    outMessage.Add(outstr[2]);
            }
            byte[] outbyte = (byte[])outMessage.ToArray(Type.GetType("System.Byte"));
            return System.Text.Encoding.Default.GetString(outbyte);
        }


       public static string DES3Encrypt(string data, string key)
        {
            TripleDESCryptoServiceProvider DES = new TripleDESCryptoServiceProvider();
            DES.Key = Encoding.GetEncoding("GBK").GetBytes(key);
            DES.Mode = CipherMode.ECB;
            DES.Padding = PaddingMode.PKCS7;
            ICryptoTransform DESEncrypt = DES.CreateEncryptor();
            byte[] Buffer = Encoding.GetEncoding("GBK").GetBytes(data);
            return Convert.ToBase64String(DESEncrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));

        }

        public static string DES3Decrypt(string data, string key)
        {

            TripleDESCryptoServiceProvider DES = new TripleDESCryptoServiceProvider();
            DES.Key = Encoding.GetEncoding("GBK").GetBytes(key);
            DES.Mode = CipherMode.ECB;
            DES.Padding = PaddingMode.PKCS7;
            ICryptoTransform DESDecrypt = DES.CreateDecryptor();
            byte[] Buffer = Convert.FromBase64String(data);
            return Encoding.GetEncoding("GBK").GetString(DESDecrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));

        }

        
    



     public static string GetMacAddress()
        {
            try
            {
                //获取网卡硬件地址
                string mac="";
                ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach(ManagementObject mo in moc)
                {
                    if((bool)mo["IPEnabled"] == true)
                    {
                        mac=mo["MacAddress"].ToString();
                        break;
                    }
                }
                moc=null;
                mc=null;
                return mac;
            }
            catch
            {
                return "unknow";
            }
            finally
            {
            }
            
        }


     /// <summary>  
     /// 将传入字符串以GZip算法压缩后，返回Base64编码字符  
     /// </summary>  
     /// <param name="rawString">需要压缩的字符串</param>  
     /// <returns>压缩后的Base64编码的字符串</returns>  
     public static string GZipCompressString(string rawString)
     {
         if (string.IsNullOrEmpty(rawString) || rawString.Length == 0)
         {
             return "";
         }
         else
         {
             byte[] rawData = Encoding.GetEncoding("GBK").GetBytes(rawString.ToString());
             byte[] zippedData = Compress(rawData);
             return (string)(Convert.ToBase64String(zippedData));
         }

     }
     /// <summary>  
     /// GZip压缩  
     /// </summary>  
     /// <param name="rawData"></param>  
     /// <returns></returns>  
     public static byte[] Compress(byte[] rawData)
     {
         MemoryStream ms = new MemoryStream();
         GZipStream compressedzipStream = new GZipStream(ms, CompressionMode.Compress, true);
         compressedzipStream.Write(rawData, 0, rawData.Length);
         compressedzipStream.Close();
         return ms.ToArray();
     }
     /// <summary>  
     /// 将传入的二进制字符串资料以GZip算法解压缩  
     /// </summary>  
     /// <param name="zippedString">经GZip压缩后的二进制字符串</param>  
     /// <returns>原始未压缩字符串</returns>  
     public static string GZipDecompressString(string zippedString)
     {
         if (string.IsNullOrEmpty(zippedString) || zippedString.Length == 0)
         {
             return "";
         }
         else
         {
             byte[] zippedData = Convert.FromBase64String(zippedString.ToString());
             return (string)(Encoding.GetEncoding("GBK").GetString(Decompress(zippedData)));
         }
     }
     /// <summary>  
     /// ZIP解压  
     /// </summary>  
     /// <param name="zippedData"></param>  
     /// <returns></returns>  
     public static byte[] Decompress(byte[] zippedData)
     {
         MemoryStream ms = new MemoryStream(zippedData);
         GZipStream compressedzipStream = new GZipStream(ms, CompressionMode.Decompress);
         MemoryStream outBuffer = new MemoryStream();
         byte[] block = new byte[1024];
         while (true)
         {
             int bytesRead = compressedzipStream.Read(block, 0, block.Length);
             if (bytesRead <= 0)
                 break;
             else
                 outBuffer.Write(block, 0, bytesRead);
         }
         compressedzipStream.Close();
         return outBuffer.ToArray();
     }

     //des加密，与便民服务站自动登录时加密口令
     public static string DESEncrypt(string text, string key)
     {
         DESCryptoServiceProvider des = new DESCryptoServiceProvider();
         byte[] inputByteArray = Encoding.GetEncoding("UTF-8").GetBytes(text);
         des.Padding = PaddingMode.PKCS7;
         des.Mode = CipherMode.ECB;

         des.Key = ASCIIEncoding.ASCII.GetBytes(key);
         des.IV = ASCIIEncoding.ASCII.GetBytes(key);
         MemoryStream ms = new MemoryStream();
         CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);

         cs.Write(inputByteArray, 0, inputByteArray.Length);
         cs.FlushFinalBlock();

         StringBuilder ret = new StringBuilder();
         foreach (byte b in ms.ToArray())
         {
             ret.AppendFormat("{0:x2}", b);//将第一个参数转换为十六进制数,长度为2,不足前面补0
         }
         return ret.ToString();
     }

     public static string DESDecrypt(string cyphertext, string key)
     {
         if (string.IsNullOrEmpty(cyphertext))
             return string.Empty;
         DESCryptoServiceProvider des = new DESCryptoServiceProvider();
         des.Padding = PaddingMode.PKCS7;
         des.Mode = CipherMode.ECB;

         byte[] inputByteArray = new byte[cyphertext.Length / 2];
         for (int x = 0; x < cyphertext.Length / 2; x++)
         {
             int i = (Convert.ToInt32(cyphertext.Substring(x * 2, 2), 16));
             inputByteArray[x] = (byte)i;
         }

         des.Key = ASCIIEncoding.ASCII.GetBytes(key);
         des.IV = ASCIIEncoding.ASCII.GetBytes(key);
         MemoryStream ms = new MemoryStream();
         CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
         cs.Write(inputByteArray, 0, inputByteArray.Length);
         cs.FlushFinalBlock();

         StringBuilder ret = new StringBuilder();

         return System.Text.Encoding.GetEncoding("UTF-8").GetString(ms.ToArray());
     }

   }
}
