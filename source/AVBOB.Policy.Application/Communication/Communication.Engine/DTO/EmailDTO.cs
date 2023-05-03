using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communication.Engine.DTO
{
    public class EmailDTO
    {

        public string[] ReplyTo { get; set; } = new string[0];

        public string[] BCC { get; set; } = new string[0];

        public string[] CC { get; set; } = new string[0];

        public bool IsHTML { get; set; }

        public byte[] Message { get; set; } = new byte[0];

        public string EmailAccount { get; set; } = string.Empty;

        public string Subject { get; set; } = string.Empty;

        public string FromName { get; set; } = string.Empty;

        public string From { get; set; } = string.Empty;

        public string[] Recipients { get; set; } = new string[0];

        public EmailAttachmentDTO[] Attachments { get; set; } = new EmailAttachmentDTO[0];

    }
}
