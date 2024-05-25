using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPVTube.Entities
{
    public partial class Visualization
    {
        public Visualization()
        {

        }
        public Visualization(DateTime visualizationDate, Content contenido, Member miembro)
        {
            this.VisualizationDate = visualizationDate;
            this.Member = miembro;
            this.Content = contenido;
        }
    }
}
