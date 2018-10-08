

using System.ComponentModel.DataAnnotations;

namespace SPR.Model
{
    class Email 
    {
        public int Id { get; set; }
        public string EmailAddress { get; }
        public string Subject { get; }
        public string Body { get; }

    }
}
