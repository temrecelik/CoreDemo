using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
  Entities Katmanındaki tablolar
-Makale -Blog
-Kategori-Category
-Yorumlar-comment
-Yazarlar-Writer
-Hakkında
-İletişim-Contact
-Adres
 */
namespace EntityLayer.Concrete
{
	public class Writer
	{
		[Key]
		public int WriterId { get; set; }

        public string  WriterName { get; set; }

        public string WriterAbout { get; set; }

		public string WriterImage { get; set; }
		
        public string WriterMail { get; set; }

		public string WriterPassword { get; set; }

		public bool WriterStatus { get; set; }


		//bir yazarın yazdığı blogların hepsini listelemek işin kullanılır
		public List<Blog> Blogs { get; set; }

		public virtual ICollection<Message2> WriterSender { get; set; }
        public virtual ICollection<Message2> WriterReceiver { get; set; }

    }
}
