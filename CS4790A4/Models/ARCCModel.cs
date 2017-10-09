using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel; 

namespace CS4790A4.Models
{
    public class ARCCModel
    {

    }

    //Create a class for each table in the database, matching column names and types
    [Table("Member")]
    public class Member
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("Email Address")]
        public string Email { get; set; }
    }

    [Table("Proposal")]
    public class Proposal
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Proposal Name")]
        public string ProposalName { get; set; }
        [DisplayName("Educational Experience")]
        public int? EdExpRating { get; set; }
        [DisplayName("Innovation")]
        public int? InnovationRating { get; set; }
        [DisplayName("Dissemination")]
        public int? DissemRating { get; set; }
        [DisplayName("Evaluation")]
        public int? EvalRating { get; set; }
        [DisplayName("Support")]
        public int? SupportRating { get; set; }
        [DisplayName("Email")]
        public string Email { get; set; }
    }

    public class ARCCDbContext : DbContext
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<Proposal> Proposals { get; set; }
    }

}