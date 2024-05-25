using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPVTube.Entities
{
    public partial class Evaluation
    {
        public Evaluation()
        {

        }

        public Evaluation(DateTime evaluationDate, string rejectionReason, Member censor, Content contenido)
        {
            this.EvaluationDate = evaluationDate;
            this.RejectionReason = rejectionReason;
            this.Content = contenido;
            this.Censor = censor;
        }
    }
}
