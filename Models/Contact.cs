﻿using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi_ManageContacts.Models
{
    public class Contact
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        [EmailAddress]
        public string Email { get; set; }
    }
}
