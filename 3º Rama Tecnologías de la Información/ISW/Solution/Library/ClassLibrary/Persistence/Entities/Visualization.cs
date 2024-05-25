using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPVTube.Entities
{
    public partial class Visualization
    {
        //[DatabaseGeneratedAttribute(DatabaseGeneratedOption.None), Key()]
        [Key]
        public int Id
        {
            get; set;
        }

        public DateTime VisualizationDate
        {
            get; set;
        }

        [Required]
        public virtual Member Member
        {
            get; set;
        }

        [Required]
        public virtual Content Content
        {
            get;
            set;
        }

        
    }
}
