using System;
using System.Text;
using ITextLib;

namespace TextLib
{
    public class Converter : MarshalByRefObject, IRemoteText
    {
        public byte[] Unicode2GBK(string s)
        {
            var ret = Encoding.GetEncoding(936).GetBytes(s);
            Console.WriteLine(s.Length + " widechars converted to " + ret.Length + " bytes.");
            return ret;
        }
    }
}
