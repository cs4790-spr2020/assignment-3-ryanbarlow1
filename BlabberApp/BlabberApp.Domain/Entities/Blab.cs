using System;

namespace BlabberApp.Domain
{
    public class Blab : EntityBase
    {
        public string Message { get; set; }
        public DateTime DateCreated { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}