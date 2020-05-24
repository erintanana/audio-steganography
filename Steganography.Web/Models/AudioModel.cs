using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Steganography.Web.Models
{
    public class AudioModel
    {
        public byte[] ByteArray { get; set; }

        public short[] ShortStream { get; set; }

        public short[] MetaData { get; set; }

        public short[] Wavdata { get; set; }

        public int WavSize { get; set; }

        public int ShortSize { get; set; }           
      
    }
}