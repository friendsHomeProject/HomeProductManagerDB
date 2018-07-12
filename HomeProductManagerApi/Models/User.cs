﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Users")]
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
