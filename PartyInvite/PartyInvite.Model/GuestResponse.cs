using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PartyInvite.Model
{
    public class GuestResponse
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Please enter your name")]
        [Column(TypeName="varchar(100)")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your email address")]
        [RegularExpression( ".+\\@.+\\..+" , ErrorMessage ="Please enter a valid email address")]
        [Column(TypeName = "varchar(100)")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your phone number")]
        [Column(TypeName = "varchar(100)")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please specify whether you'll attend")]
        public bool? WillAttend { get; set; }

        [Required(ErrorMessage = "Please select a gift")]
        [Column(TypeName = "varchar(100)")]
        public int GiftId { get; set; }

        [NotMapped]
        public Gift GuestGift { get; set; }
    }
}
