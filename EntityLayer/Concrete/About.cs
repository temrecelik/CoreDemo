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
-Hakkında-About
-İletişim-Contact
-Adres
 */


namespace EntityLayer.Concrete
{
	public class About
	{
		[Key]
        public int AboutID { get; set; }

		public string AboutDetails1 { get; set;}

		public string AboutDetails2 { get; set; }

		public string AboutImage1 { get; set; }

		public string AboutImage2 { get; set; }

		public string AboutMapLocatio { get; set; }	

		public bool AboutStatus { get; set; }	
	}
}
