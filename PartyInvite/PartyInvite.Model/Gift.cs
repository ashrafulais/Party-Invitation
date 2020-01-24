using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PartyInvite.Model
{
    public class Gift
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }

        //[NotMapped]
        //public IList<GuestResponse> GuestResponses { get; set; }
    }
}
