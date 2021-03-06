﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public DateTime? BirthDate { get; set; }

        public string ProfileImagePath { get; set; }

        public byte MembershipTypeId { get; set; }
        public MembershipType MembershipType { get; set; }

        public ICollection<Rental> Rentals { get; set; }
    }
}