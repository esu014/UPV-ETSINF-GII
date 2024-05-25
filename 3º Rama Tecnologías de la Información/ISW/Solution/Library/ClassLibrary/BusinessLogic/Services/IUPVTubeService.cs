using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPVTube.Entities;


namespace UPVTube.Services
{
    public interface IUPVTubeService
    {
        void RemoveAllData();
        void Commit();

        // Necesario para la inicialización de la BD
        void DBInitialization();
        void AddSubject(Subject subject);

        void AddMember(Member member);
        void AddContent(Content content);

        Member findMemberById(String s);
        //
        // A partir de aquí los necesarios para los CU solicitados
        //

        void login(String nick, String password);
        void singUp(String email, String name, String nick, String password);

        void logout();
        Member userLogged();
        void UploadContent(String contentURI, String description, Boolean IsPublic, String title);

        IEnumerable<Content> searchContent(int authoriced,DateTime? fechaIni, DateTime? fechaFin, String nick, String words, int? subjectcode);

        Content watchContent(int autorizado, DateTime? uploadDate, String nick, int? subjectCode, String title);

        void ReviewContent();
        int searchSubject(String subject);
        void AuthorizeContent(Content content);
        void NotAuthorizeContent(Content content, Comment comment);
        void AddComment(Comment comment);
        void DeleteContent(Content content);
        IEnumerable<Comment> GetComentariosPorContenido(string titulo, string autor);
        void AddComment2(String titulo, String autor, DateTime fecha_sub, String comentari, Member m2);


    }
}
