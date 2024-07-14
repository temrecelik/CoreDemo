using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Notification
    {
        [Key]
        public int NatificationId {  get; set; }    

        public string NatificationType { get; set; }

        public string NatificationTpeSymbol {  get; set; }  

        public string NatificationDetails { get; set; }

        public bool NatificationStatus {  get; set; }   

        public DateTime NatificationDate { get; set; } 

     



    }
}
