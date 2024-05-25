using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPVTube.Entities
{
    public partial class Subject
    {
        public Subject()
        {
            Contents = new List<Content>();
        }
        public Subject(int code, String fullName, String name): this()
        {
            this.Code = code;
            this.FullName = fullName;
            this.Name = name;
        }
        public void AddContents(Content content) 
        {
            Contents.Add(content);
        }
    }
}
