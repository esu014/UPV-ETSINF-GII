using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace UPVTube.Entities
{
    public partial class Member
    { 
    public String Email
        {
            get; set;
        }

        public String FullName
        {
            get; set;

        }
        public DateTime LastAccessDate
        {
            get; set;
        }
        [Key]
        public String Nick
        {
            get; set;
        }

        public String Password
        {
            get; set;

        }
        public virtual ICollection<Comment> Comments
        {
            get;set;
        }

        public virtual ICollection<Evaluation> Evaluations
        {
            get;set;
        }

        public virtual ICollection<Content> Contents
        {
            get;set;
        }

        public virtual ICollection<Visualization> Visualizations
        {
            get; set;
        }

        public virtual ICollection<Member> Subscriptors

        {
            get;
            set;
        }

        public virtual ICollection<Member> SubscribedTo
        {
            get;
            set;
        }

        
    }
}