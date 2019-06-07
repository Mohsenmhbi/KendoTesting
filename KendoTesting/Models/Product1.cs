using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KendoTesting.Models
{
    public class Product1
    {

        #region Configuration
        internal class Configuration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Product1>
        {
            public Configuration()
            {
                HasRequired(current => current.Group)
                    .WithMany(company => company.Product1s)
                    .HasForeignKey(current => current.GroupId)
                    .WillCascadeOnDelete(false);

                HasRequired(current => current.RangGroup)
                   .WithMany(customer => customer.Product1s)
                   .HasForeignKey(current => current.RangGroupId)
                   .WillCascadeOnDelete(false);
            }
        }

        #endregion Configuration

        public int Id { get; set; }

        public string Name  { get; set; }
        public virtual int GroupId { get; set; }
        [ForeignKey("GroupId")]
        public virtual Group Group { get; set; }

        public virtual int RangGroupId { get; set; }
        [ForeignKey("RangGroupId")]
        public virtual RangGroup RangGroup { get; set; }
    }
    public class Group
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public virtual IList<Product1> Product1s { get; set; }
    }
}