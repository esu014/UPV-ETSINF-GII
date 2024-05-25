using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPVTube.Entities
{
    public partial class Content
    {
        public Content()
        {
            Visualizations = new List<Visualization>();
            Comments = new List<Comment>();
            Subjects = new List<Subject>();
        }

        public Content(String contentURI, String description, Boolean IsPublic, String title, DateTime uploadDate, Member Owner): this()
        {
            this.ContentURI = contentURI;
            this.Description = description;
            this.IsPublic = IsPublic;
            this.Title = title;
            this.UploadDate = uploadDate;
            this.Owner = Owner;
        }

        public void AddSubject(Subject subject)
        {
            Subjects.Add(subject);
        }
        public void AddComment(Comment comment) 
        {
            Comments.Add(comment);
        }
    }
}
