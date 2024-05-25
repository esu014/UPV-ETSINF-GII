using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPVTube.Entities;

namespace UPVTube.Entities
{
    public partial class Content
    {
        public Authorized Authorized
        {
            get;
            set;
        }
       public String ContentURI
       {
          get; set;
       }

        public String Description
        {
          get;set;
        }

        //[DatabaseGeneratedAttribute(DatabaseGeneratedOption.None), Key()]
        [Key]
        public int Id
        {
            get;set;
        }

        public Boolean IsPublic
        {
            get;set;
        }

        public String Title
        {
            get;set;
        }

        public DateTime UploadDate
        {
            get;set;
        }

        public ICollection<Visualization> Visualizations
        {
            get;
            set;
        }

        [Required]
        public virtual Member Owner
        {
            get;set;
        }

        public ICollection<Comment> Comments
        {
            get;
            set;
        }

        public virtual Evaluation Evaluation
        {
            get;
            set;
        }

        public ICollection<Subject> Subjects
        {
            get;
            set;
        }

    }
}
