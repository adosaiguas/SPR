

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SPR.Model
{
    class Email 
    {
        public int Id { get; set; }
        public string EmailAddress { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public IList<Receiver> Receivers { get; set; }
    }
}
