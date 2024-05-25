using UPVTube.Entities;
using UPVTube.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Contexts;
using System.Data.Entity.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace UPVTube.Services
{
    public class UPVTubeService: IUPVTubeService
    {
        private readonly IDAL dal;
        private const int AUTORIZED = 2;

        public UPVTubeService(IDAL dal)
        {
            this.dal = dal;
        }

        public void RemoveAllData()
        {
            dal.RemoveAllData();
        }

        public void Commit()
        {
            dal.Commit();
        }

        public void DBInitialization()
        {
            RemoveAllData();

            Subject s1 = new Subject(11555, "Ingeniería del software", "ISW");
            AddSubject(s1);
            Subject s2 = new Subject(11553, "Arquitectura e ingeniería de computadores", "AIC");
            AddSubject(s2);
            Subject s3 = new Subject(11548, "Bases de datos y sistemas de información", "BDA");
            AddSubject(s3);
            Subject s4 = new Subject(11560, "Sistemas inteligentes", "SIN");
            AddSubject(s4);

            // Añadir los 3 miembros
            Member m1 = new Member("jdiaz@dsic.upv.es","Sanchez Diaz, Juan",DateTime.Now,"jdiaz","Artatack123");
            AddMember(m1);
            Member m2 = new Member("esopurb@inf.upv.es","Sopeña Urbano, Enrique", DateTime.Now, "jdiaz","Artatack123");
            AddMember(m2);
            Member m3 = new Member("alambar@inf.upv.es","Lambaraa Ben Razzouq, Anass", DateTime.Now, "jdiaz","Artatack123");
            AddMember(m3);

            // Añadir los 4 contenidos
            Content c1 = new Content("URI al contenido del vídeo", "Vídeo de cómose programa", true, "Programar", DateTime.Now, m1);
            AddContent(c1);
            Content c2 = new Content("URI al contenido del vídeo", "Vídeo de cómose programa", true, "Programar", DateTime.Now, m1);
            AddContent(c2);
            Content c3 = new Content("URI al contenido del vídeo", "Vídeo de cómose programa", true, "Programar", DateTime.Now, m1);
            AddContent(c3);
            Content c4 = new Content("URI al contenido del vídeo", "Vídeo de cómose programa", true, "Programar", DateTime.Now, m1);
            AddContent(c4);
        }

        public void AddSubject(Subject subject)
        {
            // Restricción: No puede haber dos asignaturas con el mismo code
            if (dal.GetById<Subject>(subject.Code) == null)
            {
                // Restricción: No puede haber dos asignaturas con el mismo name
                if (!dal.GetWhere<Subject>(x => x.Name == subject.Name).Any())
                {
                    // Sólo se salva si no hay Code ni email duplicado
                    dal.Insert<Subject>(subject);
                    dal.Commit();
                }
                else
                    throw new ServiceException("Subject with name " + subject.Name + " already exists.");
            }
            else
                throw new ServiceException("Subject with code " + subject.Code + " already exists.");
        }
        public void AddMember(Member member)
        {
            // Restricción: No puede haber dos miembros con el mismo email
            if (dal.GetById<Member>(member.Email) == null)
            {
                // Restricción: No puede haber dos miembros con el mismo nick
                if (dal.GetById<Member>(member.Nick) == null)
                {
                    // Sólo se salva si no hay Code ni email duplicado
                    dal.Insert<Member>(member);
                    dal.Commit();
                }
                else
                    throw new ServiceException("Member with Email " + member.Email + " already exists.");
            }
            else
                throw new ServiceException("Member with Nick " + member.Nick + " already exists.");
        }
        public void AddContent(Content content){ 
            dal.Insert<Content>(content);
            dal.Commit(); 
            
        }

        // A partir de aquí los métodos para implementar los CU

        Member signed;
        public void singUp(String email, String name, String nick, String password)
        {
            if (email != "" && name != "" && nick != "" && password != "" && valido(email))
            {
                signed = null;
                Member emailNuevo;
                emailNuevo = findMemberById(email);
                Member nickNuevo;
                nickNuevo = findMemberById(nick);
                if (emailNuevo == null && nickNuevo == null)
                {
                    signed = new Member(email, name, DateTime.Now, nick, password);
                    AddMember(signed);

                }
                else
                {
                    throw new ServiceException("Nickname o email ya registrados.");
                }
            }
            else if(!valido(email))
            {
                throw new ServiceException("Por favor introduzca un email valido");
            }
            else
            { 
                throw new ServiceException("Por favor complete los datos de registro."); 
            }
            
        }
        public Boolean valido (String email)
        {
            string patronCorreo = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Regex regex = new Regex(patronCorreo);
            return regex.IsMatch(email);
        }

        public Member findMemberById(String s)
        {
            Member m = dal.GetById<Member>(s);
            return m;
        }

        //Usuario que ha hecho login con exito en la aplicacion
        Member logged;
        public void login(String nick, String password)
        {
            logged = null;
            Member usuarioLogeado;
            usuarioLogeado = findMemberById(nick);
            if(usuarioLogeado!=null)
            {
                if(usuarioLogeado.Password == password)
                {
                    logged = usuarioLogeado;
                }
                else
                {
                    throw new ServiceException("There is not a user with that login or password");
                }
            }
            else
            {
                throw new ServiceException("There is not a user with that login or password");
            }

        }
        public void logout()
        {
            logged.LastAccessDate = DateTime.Now;
            logged = null;
        }
        public Member userLogged() 
        { 
            return logged; 
        }
        public IEnumerable<Content> searchContent(int authoriced, DateTime? fechaIni, DateTime? fechaFin, String nick, String words, int? subjectcode)
        {
            if (userLogged() == null) throw new ServiceException("The user is not logged");
            IEnumerable<Content> list = dal.GetAll<Content>();
            if(fechaIni != null && fechaFin != null)
            {
                list = from content in list where (content.UploadDate >= fechaIni && content.UploadDate <= fechaFin) select content;
            }
            if(nick != null)
            {
                list = from content in list where (content.Owner.Nick == nick) select content;
            }
            if (subjectcode != -1)
            {
                list = from content in list where (content.Subjects.Where<Subject>(subject => subject.Code == subjectcode ).Any()) select content;
            }
            if (words != null)
            {
                list = from content in list where (content.Title.Contains(words)) select content;
            }
            if (authoriced != AUTORIZED)
            {
                list = from content in list where (content.IsPublic == true) select content;
            }
            list = list.OrderBy(content => content.UploadDate);
            return list;
        }
        public void UploadContent(String contentURI, String description, Boolean IsPublic, String title)
        {
            //No hay usuario loggeado
            if (userLogged() == null) throw new ServiceException("No user is logged");

            Content content = new Content(contentURI, description, IsPublic, title, DateTime.Now, userLogged());
            dal.Insert<Content>(content);
            dal.Commit();
        }
        public Content watchContent(int autorizado, DateTime? uploadDate, String nick, int? subjectCode, String title)
        {
            //No hay usuario loggeado
            if (userLogged() == null) throw new ServiceException("No user is logged");

            IEnumerable<Content> contents = searchContent(autorizado, uploadDate, uploadDate, nick, title, subjectCode);

            if (!contents.Any())
            {
                throw new ServiceException("There is not any content uploaded with that data");
            }
            if (contents.Count() > 1)
            {
                throw new ServiceException("There is more than one content uploaded with that data");
            }

            Content content = contents.First();
            return content;

        }

        public void ReviewContent()
        {
            //No hay usuario loggeado
            if (userLogged() == null) throw new ServiceException("No user is logged");
            if (logged.IsTeacher())
            {
                IEnumerable<Content> pendingContents = from content in searchContent(AUTORIZED, null, null, null, null, null) where content.IsPublic == false select content;

                if (pendingContents.Count() == 0)
                {
                    Console.WriteLine("There are no pending contents");
                }
                else
                {
                    Console.WriteLine("Pending contents are: ");
                }
                foreach (Content content in pendingContents)
                {
                    watchContent(AUTORIZED, content.UploadDate, content.Owner.Nick, content.Subjects.FirstOrDefault().Code, content.Title);
                }
            }
            else
            {
                throw new ServiceException("logged is not teacher");
            }
            //puede ser que haya que sacar una excepcion por no ser profesor
            
        }
        public int searchSubject(String s)
        {
            IEnumerable<Subject> list = dal.GetAll<Subject>();
            Subject sb = list.FirstOrDefault(subj => subj.FullName == s);
            if (sb != null)
            {
                return sb.Code;
            }
            return 0;

        }
        public void AuthorizeContent(Content content)
        {
            if (content == null)
            {
                throw new ServiceException("Contenido no proporcionado.");
            }

            content.Authorized = Authorized.Yes;
            dal.Commit();
        }
        public void NotAuthorizeContent(Content content, Comment comment)
        {
            if (content == null)
            {
                throw new ServiceException("Contenido no proporcionado.");
            }

            content.Authorized = Authorized.No;
            AddComment(comment);
            DeleteContent(content);
            dal.Commit();
        }
        public void AddComment(Comment comment)
        {
            dal.Insert<Comment>(comment);
            dal.Commit();
        }
        public void DeleteContent(Content content)
        {
            if (userLogged() == null) throw new ServiceException("No user is logged");
            if (content == null) throw new ServiceException("Contenido no proporcionado.");
            dal.Delete<Content>(content); // Esto podría funcionar para actualizaciones si el ORM maneja correctamente el estado de la entidad
            dal.Commit();
        }
        public IEnumerable<Comment> GetComentariosPorContenido(string titulo, string autor)
        {
            var contenido = dal.GetWhere<Content>(c => c.Title == titulo).FirstOrDefault();

            if (contenido == null)
            {
                // Manejar el caso en que no se encuentra el contenido
                throw new ServiceException("Contenido no encontrado.");
            }

            return contenido.Comments.OrderBy(c => c.WritingDate);
        }
        public void AddComment2(String titulo, String autor, DateTime fecha_sub, String comentari, Member m2)
        {
            int auto = 2;
            if(logged.IsTeacher())
            {
                auto = 0;
            }
            Content content = watchContent(auto, null, autor, null, titulo);
            Comment coment = new Comment(comentari, fecha_sub, content, m2);
            ; AddComment(coment);
        }
    }
}

