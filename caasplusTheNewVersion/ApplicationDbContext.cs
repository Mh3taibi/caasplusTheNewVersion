 


using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace caasplusTheNewVersion
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        // Define your DbSets (tables) here
       
        public DbSet<Users> Users { get; set; }
        public DbSet<Attachments> attachments { get; set; }
        public DbSet<Requests> Requests { get; set; }
        public DbSet<Bids> bid { get; set; }
    }

     

 

    public class Users : BaseTable
    {
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }
        public required string fullName { get; set; }
        public required string passwordHashed { get; set; }
        public required int UserType { get; set; }
        public required string CompanyName { get; set; }
        public required string CR { get; set; }
        public required int postalCode { get; set; }
        public required string city { get; set; }
        public  string district { get; set; } = null;
        public  string Street { get; set; } = null;
        

    }

    public class Requests : BaseTable
    {
        public required int ClientID { get; set; }
        public required int RequestStatus { get; set; }
        public required string description { get; set; }
        public required string RequestName { get; set; }
        public required string DesFile { get; set; }
        public required long budget { get; set; }
        public required DateTime SubmitDueDate { get; set; }
        public required DateTime OfferDueDate { get; set; }

    }


    public class Bids : BaseTable
    {
        public required long requestID { get; set; }
        public required long prices { get; set; } = 0;
        public required long BidStatus { get; set; }
        public required long UserID { get; set; }

    }

    public class Attachments
    {
        public required Guid Id { get; set; }
        public required string contentType { get; set; }
        public required string filename { get; set; }
        public required byte[] stream { get; set; }
    }

    public class BaseTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required DateTime creationDate { get; set; }
        public required DateTime lastUpdateDate { get; set; }
        public required int recordStatus { get; set; }


    }
}
