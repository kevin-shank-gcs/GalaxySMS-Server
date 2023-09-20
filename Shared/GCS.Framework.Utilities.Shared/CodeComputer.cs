using System;

namespace GCS.Framework.Utilities
{
    public class CodeComputer
    {
        public CodeComputer()
		{
			m_Code = 0;
		}

		private uint m_Code;              // this is the binary code
		private char[] m_Display = new char[8];                 // displayable form of code
		private string m_Str;

		/***********************************************************
			*     Encode byte for registration                        *
			*     Case Sensative                                      *
			***********************************************************/
		public void ComputeByte(char c)
		{
			m_Code ^= (byte)c;                          // xor in the byte
			for(int i=0; i < 8; i++)
			{
				if( ( m_Code & 1 ) != 0 )
				{
					m_Code >>= 1;
					m_Code ^= 0x95AE4200;
				}
				else
					m_Code >>= 1;
			}
		}

		/***********************************************************
			*     Encode string for registration                      *
			***********************************************************/
		public void ComputeString(string s)
		{
			for( int x = 0; x < s.Length; x++ )
			{
				ComputeByte( s[x] );
			}
		}

		/***********************************************************
			*     Encode byte for registration                        *
			*     Case Independent                                    *
			***********************************************************/
		public void ComputeByteNoCase(char c)
		{
			if( Char.IsLetterOrDigit(c) == false )
				return;             // ignore ascii
			if( Char.IsLower(c) )
				c = Char.ToUpper(c);     // ignore case - FORCE UPPER
			ComputeByte( c );
		}
			   
		/***********************************************************
			*                                                         *
			*     Encode string for registration                      *
			*                                                         *
			***********************************************************/
		public void ComputeStringNoCase(string s)
		{
			s.ToUpper();
			ComputeString(s);
		}

		public void Compute(ushort wd)
		{

			ComputeByte( (char)((wd & 0xff00 ) >> 8) );
			ComputeByte( (char)( wd & 0xff ) );
		}

		public void Compute(uint dwd)
		{
			ushort wd = (ushort)( ( dwd & 0xffff0000) >> 16);	
			Compute( wd );
			wd = (ushort)( dwd & 0xffff);	
			Compute( wd );
		}
	   
		public void Compute(int dwd)
		{
			ushort wd = (ushort)( ( dwd & 0xffff0000) >> 16);	
			Compute( wd );
			wd = (ushort)( dwd & 0xffff);	
			Compute( wd );
		}
		/***********************************************************
			*                                                         *
			*     Comvert code to Displayable form                    *
			*                                                         *
			***********************************************************/
		public string Convert()
		{
			char[] Alphabet = new char[32]
					{
						'M', '6', 'R', 'F', 'T', 'G', '2', 'C',
						'N', 'D', '5', '4', 'B', '7', '3', 'X',

						'G', 'P', 'F', 'Y', 'J', 'X', '5', '2',
						'W', '6', '3', 'T', '9', '4', 'H', 'L'};
			uint    i, j;
			uint    l;

			l = m_Code;                           // make a local copy
				
			m_Str = "";
			for(i=0; i<8; i++)
			{
				j = (l & 15);
				m_Display[i] = Alphabet[j];
				m_Str += System.Convert.ToString(m_Display[i]);
				l >>= 4;
				i++;
				j = (l & 15);
				m_Display[i] = Alphabet[j + 16];
				m_Str += System.Convert.ToString(m_Display[i]);
				l >>= 4;
			}

			return m_Str;
		}

		/***********************************************************
			*     Compare field for registration                      *
			***********************************************************/
		public int Equal(string s)
		{
			int     i;
			Convert();                          // convert to displayable
			for(i=0; i<8; i++)
			{
				if( s[i] != m_Display[i] )
					return 0;
			}
			return 1;
		}
    }
}
