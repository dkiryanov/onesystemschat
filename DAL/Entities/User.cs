//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public User()
        {
            this.Messages = new HashSet<Message>();
            this.IncomingMessages = new HashSet<Message>();
        }
    
        public int UserId { get; set; }
        public string Password { get; set; }
        public string Login { get; set; }
    
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<Message> IncomingMessages { get; set; }
    }
}
