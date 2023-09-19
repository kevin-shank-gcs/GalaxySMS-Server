using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Framework.Security
{
    public class X509CertificatesHelpers
    {
        internal static byte[] ReadFile(string fileName)
        {
            FileStream f = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            int size = (int)f.Length;
            byte[] data = new byte[size];
            size = f.Read(data, 0, size);
            f.Close();
            return data;
        }

        public static X509Certificate2 FromFile(string filename)
        {
            try
            {

                X509Certificate2 x509 = new X509Certificate2();
                //Create X509Certificate2 object from .cer file.
                byte[] rawData = ReadFile(filename);

                x509.Import(rawData);
                return x509;

                ////Print to console information contained in the certificate.
                //Console.WriteLine("{0}Subject: {1}{0}", Environment.NewLine, x509.Subject);
                //Console.WriteLine("{0}Issuer: {1}{0}", Environment.NewLine, x509.Issuer);
                //Console.WriteLine("{0}Version: {1}{0}", Environment.NewLine, x509.Version);
                //Console.WriteLine("{0}Valid Date: {1}{0}", Environment.NewLine, x509.NotBefore);
                //Console.WriteLine("{0}Expiry Date: {1}{0}", Environment.NewLine, x509.NotAfter);
                //Console.WriteLine("{0}Thumbprint: {1}{0}", Environment.NewLine, x509.Thumbprint);
                //Console.WriteLine("{0}Serial Number: {1}{0}", Environment.NewLine, x509.SerialNumber);
                //Console.WriteLine("{0}Friendly Name: {1}{0}", Environment.NewLine, x509.PublicKey.Oid.FriendlyName);
                //Console.WriteLine("{0}Public Key Format: {1}{0}", Environment.NewLine, x509.PublicKey.EncodedKeyValue.Format(true));
                //Console.WriteLine("{0}Raw Data Length: {1}{0}", Environment.NewLine, x509.RawData.Length);
                //Console.WriteLine("{0}Certificate to string: {1}{0}", Environment.NewLine, x509.ToString(true));

                //Console.WriteLine("{0}Certificate to XML String: {1}{0}", Environment.NewLine, x509.PublicKey.Key.ToXmlString(false));

                ////Add the certificate to a X509Store.
                //X509Store store = new X509Store();
                //store.Open(OpenFlags.MaxAllowed);
                //store.Add(x509);
                //store.Close();
            }

            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine("Error: The directory specified could not be found.");
                throw ex;
            }
            catch (IOException ex)
            {
                Console.WriteLine("Error: A file in the directory could not be accessed.");
                throw ex;
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("File must be a .cer file. Program does not have access to that type of file.");
                throw ex;
            }
        }

        public static X509Certificate2 LoadCertificateFromStoreByThumbprint(string thumbPrint, StoreName storeName = StoreName.My, StoreLocation storeLocation = StoreLocation.LocalMachine )
        {
            using (var store = new X509Store(storeName, storeLocation))
            {
                store.Open(OpenFlags.ReadOnly);
                var certCollection = store.Certificates.Find(X509FindType.FindByThumbprint,
                    thumbPrint, true);
                if (certCollection.Count == 0)
                {
                    throw new Exception("The specified certificate wasn't found.");
                }
                return certCollection[0];
            }
        }

    }
}
