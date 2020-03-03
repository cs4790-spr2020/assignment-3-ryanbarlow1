using System.Collections.Generic;

namespace BlabberApp.Domain
{
    public class User : EntityBase
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public List<Blab> Blabs { get; set; }
    }
}