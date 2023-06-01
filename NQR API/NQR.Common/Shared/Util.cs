using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NQR.Common.Shared
{
    public static  class Util
    {
		public static string CreateMD5(string input)
		{
			// Use input string to calculate MD5 hash
			using (MD5 md5 = MD5.Create())
			{
				byte[] inputBytes = Encoding.ASCII.GetBytes(input);
				byte[] hashBytes = md5.ComputeHash(inputBytes);

                return Convert.ToHexString(hashBytes); // .NET 5 +

                // Convert the byte array to hexadecimal string prior to .NET 5
               /* StringBuilder sb = new System.Text.StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();*/
            }
		}

		public static string SignPayload(string payload, string PrivateKey)
		{
			// Add necessary fields and additional data to the payload
			string dataToSign = payload;

			// Create a new instance of HMACSHA256 with your private key
			using (HMACSHA256 hmac = new HMACSHA256(Encoding.UTF8.GetBytes(PrivateKey)))
			{
				// Compute the hash of the data to sign
				byte[] hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(dataToSign));

				// Convert the hash bytes to a hexadecimal string
				string signature = BitConverter.ToString(hashBytes).Replace("-", string.Empty);

				return signature;
			}
		}
	}
}
