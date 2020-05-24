using Steganography.Web.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Steganography.Web.Models
{
    public class AudioSummaryModel
    {
        public string AudioFileName { get; set; }
        public int FileSize { get; set; }
        public AudioType AudioType { get; set; }
    }
}