using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Steganography.Web.Models
{
    public class EmbedModel
    {
        public string SecretMessage { get; set; }
        public int PValue { get; set; }
        public int QValue { get; set; }
        public int Resistance { get; set; }
    }
}