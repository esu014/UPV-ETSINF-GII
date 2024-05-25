using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace UPVTube.Entities
{
    public partial class Comment
    {
        //[DatabaseGeneratedAttribute(DatabaseGeneratedOption.None), Key()]
        [Key]
        public int Id
        {
            get;
            set;
        }

        public String Text
        {
            get;
            set;
        }

        public DateTime WritingDate
        {
            get;
            set;
        }
        [Required]
        public virtual Member Writer
        {
            get;
            set;
        }
        [Required]
        public virtual Content Content
        {
            get;
            set;
        }

    }
}
