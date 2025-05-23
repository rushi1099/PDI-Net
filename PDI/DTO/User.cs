﻿using System.ComponentModel.DataAnnotations;

namespace PDI.DTO
{
    public class User
    {
        public int Id { get; set; }
        public string userName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
    public class userSignup
    {
        [Required]
        public string userName { get; set; }

        [Required]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

    }
    public class userSignIn
    {
        [Required]
        public string userName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
