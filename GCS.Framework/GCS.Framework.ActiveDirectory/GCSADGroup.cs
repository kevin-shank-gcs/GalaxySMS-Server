using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.DirectoryServices.Protocols;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Framework.ActiveDirectory
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A gcsad group. </summary>
    ///
    /// <remarks>   Kevin, 6/10/2014. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	public class GCSADGroup
	{
        public GCSADGroup()
        {
            DistinguishedName = string.Empty;
            Name = string.Empty;
            GroupId = string.Empty;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the distinguished. </summary>
        ///
        /// <value> The name of the distinguished. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

		public string DistinguishedName { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name. </summary>
        ///
        /// <value> The name. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

		public string Name { get; set; }


        public string GroupId { get; set; }
        /// <summary>   The properties. </summary>
		private Dictionary<String, object> _properties = new Dictionary<String, object>();


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the properties. </summary>
        ///
        /// <value> The properties. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

		public IDictionary<String, object> Properties
		{
			get { return _properties; }
		}

        /////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Adds a property to 'value'. </summary>
        ///
        /// <remarks>   Kevin, 6/10/2014. </remarks>
        ///
        /// <param name="sKey">     The key. </param>
        /// <param name="value">    The value. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

		public void AddProperty(String sKey, object value)
		{
            System.Diagnostics.Trace.WriteLine(string.Format("{0}, {1}", sKey, value));
			string key = sKey.ToLower();
			_properties.Add(key, value);
			switch (key)
			{
				case "name":
					Name = value as String;
					break;
			}
		}

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Process the dictionary entry described by de. </summary>
        ///
        /// <remarks>   Kevin, 6/10/2014. </remarks>
        ///
        /// <param name="de">   The de. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

		public void ProcessDictionaryEntry(DictionaryEntry de)
		{
			//						System.Diagnostics.Trace.WriteLine(string.Format("Key = {0}, Value = {1}", de.Key, de.Value));
			System.Diagnostics.Trace.Write(string.Format("Key:{0}, Value:", de.Key));
			if (de.Value is DirectoryAttribute)
			{
				DirectoryAttribute da = de.Value as DirectoryAttribute;
				if (da != null)
				{

					Type t = typeof(string);
					String sKey = de.Key as String;
					bool bUseByteArray = false;
					switch (sKey.ToLower())
					{
						case "objectguid":
						case "parentguid":
							t = typeof(Guid);
							bUseByteArray = true;
							break;
					}

					object[] strValues = da.GetValues(typeof(String));
					object[] baValues = da.GetValues(typeof(byte[]));
					if (strValues.Length != baValues.Length)
						System.Diagnostics.Trace.WriteLine("length mismatch");

					if (bUseByteArray == false)
					{
						if (strValues.Length == 0)
						{
							this.AddProperty(sKey, null);
							System.Diagnostics.Trace.WriteLine(string.Empty);
						}
						else if (strValues.Length > 1)
						{
							List<String> values = new List<string>();
							foreach (string s in strValues)
							{
								values.Add(s);
								System.Diagnostics.Trace.WriteLine(s);
							}
							this.AddProperty(sKey, values);
						}
						else
						{
							foreach (string s in strValues)
							{
								if (t != typeof(Guid))
									this.AddProperty(sKey, s);
								System.Diagnostics.Trace.WriteLine(s);
							}
						}
					}
					else
					{
						foreach (byte[] ba in baValues)
						{
							if (t == typeof(Guid))
							{
								Guid g = new Guid(ba);
								System.Diagnostics.Trace.WriteLine(g.ToString());
								this.AddProperty(sKey, g);
							}
							else
							{
								String s = System.Text.Encoding.Default.GetString(ba);
								System.Diagnostics.Trace.WriteLine(s);
								this.AddProperty(sKey, ba);
							}
						}
					}
				}
				else
				{
					System.Diagnostics.Trace.WriteLine(de.Value.ToString());
				}
			}
			else
				System.Diagnostics.Trace.WriteLine(de.Value.ToString());

		}

        public override string ToString()
        {
            return Name;
        }
	}
}

