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
-İletişim
-Adres
 */
namespace EntityLayer.Concrete
{
	public class Comment
	{
		[Key]
		public int CommentID { get; set; }
        
		public  string CommentUserName { get; set; }

        public string CommentTitle { get; set; }

		public string CommentContent { get; set; }

        public int BlogScore { get; set; }

        public DateTime CommentDate { get; set; }	

		public bool CommentStatus { get; set; }

        //Blog ile comment'i baplama part2
        //part3 işlemlerden sonra package manager console'da add-migration mig3 işlemi yapılır.	
        //bu işlem yapılırken default project DataAccesLayer seçilmelidir.
        public int BlogID { get; set; }
        public Blog  Blog { get; set; }


    }
}
