using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace BL
{
    public static class EncryptDecrypt
    {
        public static string EncryptRaw(string plainText,  Int32 KeySize = 256)
        {
            var keybytes = Encoding.UTF8.GetBytes("8080908080808085");
            var iv = Encoding.UTF8.GetBytes("8040804080408085"); 
            byte[] encryptedBytes = EncryptStringToBytesAes(plainText, keybytes, iv, KeySize);
            // add salt as first 8 bytes 
            // base64 encode
            return Convert.ToBase64String(encryptedBytes);
        }

        public static string DecryptRaw(string raw)
        {
            var keybytes = Encoding.UTF8.GetBytes("8080908080808085");
            var iv = Encoding.UTF8.GetBytes("8040804080408085");
            var encrypted = Convert.FromBase64String(raw);
            string decriptedData = DecryptStringFromBytesAes(encrypted, keybytes, iv);
            return decriptedData;
        }

        public static byte[] EncryptStringToBytesAes(string plainText, byte[] key, byte[] iv, Int32 KeySize = 256)
        {
            Int32 blockSize = 128;
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException("key");
            if (iv == null || iv.Length <= 0)
                throw new ArgumentNullException("iv");

            // Declare the stream used to encrypt to an in memory
            // array of bytes.
            MemoryStream msEncrypt;

            // Declare the RijndaelManaged object
            // used to encrypt the data.
            RijndaelManaged aesAlg = null;

            try
            {
                // Create a RijndaelManaged object
                // with the specified key and IV.
                aesAlg = new RijndaelManaged { Mode = CipherMode.CBC, KeySize = KeySize, BlockSize = blockSize, Key = key, IV = iv };

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                msEncrypt = new MemoryStream();
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {

                        //Write all data to the stream.
                        swEncrypt.Write(plainText);
                        swEncrypt.Flush();
                        swEncrypt.Close();
                    }
                }
            }
            finally
            {
                // Clear the RijndaelManaged object.
                if (aesAlg != null)
                    aesAlg.Clear();
            }

            // Return the encrypted bytes from the memory stream.
            return msEncrypt.ToArray();
        }

        public static string DecryptStringFromBytesAes(byte[] cipherText, byte[] key, byte[] iv, Int32 KeySize = 256)
        {
            Int32 blockSize = 128;
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException("key");
            if (iv == null || iv.Length <= 0)
                throw new ArgumentNullException("iv");

            // Declare the RijndaelManaged object
            // used to decrypt the data.
            RijndaelManaged aesAlg = null;

            // Declare the string used to hold
            // the decrypted text.
            string plaintext;

            try
            {
                // Create a RijndaelManaged object
                // with the specified key and IV.
                aesAlg = new RijndaelManaged { Mode = CipherMode.CBC, KeySize = KeySize, BlockSize = blockSize, Key = key, IV = iv };

                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                            srDecrypt.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                plaintext = ex.Message + "" + ex.StackTrace;
            }
            finally
            {
                // Clear the RijndaelManaged object.
                if (aesAlg != null)
                    aesAlg.Clear();
            }

            return plaintext;
        }
    }
}
