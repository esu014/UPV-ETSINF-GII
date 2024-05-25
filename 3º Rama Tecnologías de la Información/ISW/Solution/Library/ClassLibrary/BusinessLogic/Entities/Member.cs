using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPVTube.Entities
{
    public partial class Member
    {
        public Member()
        {
            Comments = new List<Comment>();
            Evaluations = new List<Evaluation>();
            Contents = new List<Content>();
            Visualizations = new List<Visualization>();
            Subscriptors = new List<Member>();
            SubscribedTo = new List<Member>();
        }
        
        //Los atributos tienen que esttar en orden alfabetico porque sino falla
        public Member(String email, String fullName, DateTime lastAccessDate, String nick, String password): this()
        {
            this.Email = email;
            this.FullName = fullName;
            this.LastAccessDate = lastAccessDate;
            this.Nick = nick;
            this.Password = password;
        }

        // La implementación para saber si es un alumno o un profesor pasa por dos atributos de clase y dos métodos
        static private List<String> TeacherDomains = new List<string> { "@dsic.upv.es", "@dsica.upv.es" };
        static private List<String> StudentDomains = new List<string> { "@inf.upv.es" };

        /// <summary>
        /// Devuelve true si el correo es de un profesor
        /// </summary>
        /// <returns></returns>
        public bool IsTeacher()
        {
            foreach (String alias in TeacherDomains)
                if (Email.Contains(alias)) return true;
            return false;
        }

        /// <summary>
        /// Devuelve true si el correo es de un alumno (de la lista de servidores de alumno)
        /// </summary>
        /// <returns></returns>
        public bool IsStudent()
        {
            foreach (String alias in StudentDomains)
                if (Email.Contains(alias)) return true;
            return false;
        }

        public void AddContent(Content content)
        {
            Contents.Add(content);
        }
    }
}
