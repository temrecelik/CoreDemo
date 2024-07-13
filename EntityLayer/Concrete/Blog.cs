using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
	public class Blog
	{
        [Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int BlogID { get; set; }
       
        public string BlogTitle { get; set; }
        
        public string BlogContent { get; set; }

        public string BlogThumbnailImage { get; set; } //küçük görsel

        public string BlogImage {  get; set; }  
        
        public DateTime BlogCreateDate { get; set; }  
        
        public bool BlogStatus { get; set; }


        //blog ile category arasında ilişki kurma part2
        //part1 ve part2 den sonra package manager console'u açarız add-migration mig2 yazarız yenisi mig oluşur.
        //daha sonra biz sql tarafında database diagramsı reflesh edip new database diagrams diyip bu iki
        //tabloyu sçersek aralarında bir ilişki olduğunu görürüz.

        public int CategoryID { get; set; }
        public Category Category  { get; set; }


        //Comment ile bloğu bağlama bir bloğa birden fazla yorum yapılabilir part1

        public List<Comment> Comments { get; set; }


        //her blogu yazan bir writer olduğu için aradaki ilişkiyi kurduk
		public int WriterID { get; set; }
		public Writer Writer { get; set; }
	}
}
