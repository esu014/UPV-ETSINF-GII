using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPVTube.Entities
{
    public partial class Subject
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None), Key()]
        public int Code
        {
            get;
            set;
        }
        public String FullName
        {
            get;
            set;
        }
        public String Name
        {
            get;
            set;
        }
        public virtual ICollection<Content> Contents
        {
            get;
            set;
        }
        




    }
}
