using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communication.Engine.DTO
{
    public class EmailAttachmentDTO
    {
        public string Filename { get; set; } = string.Empty;
        public byte[] FileContent { get; set; } = new byte[0];
        public string FileUrl { get; set; } = string.Empty;
    }
}
