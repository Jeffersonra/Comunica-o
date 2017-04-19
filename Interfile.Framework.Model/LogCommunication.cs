using Interfile.Framework.Model.Enum;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Interfile.Framework.Model
{
    [Table("LogCommunication")]
    public class LogCommunication : BaseModel
    {
        public int ServiceID { get; set; }
        public CommunicationType CommunicationType { get; set; }
        public string Sender { get; set; }
        public string Recipients { get; set; }   //andre@teste.com;monike@teste.com;jeff@teste.com ou 5511997776644;5511982727766
        public string Message { get; set; }
        public string Result { get; set; }
        public bool Success { get; set; }
        public DateTime? SendDate { get; set; }
    }
}
