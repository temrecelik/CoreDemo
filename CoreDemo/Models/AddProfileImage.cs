namespace CoreDemo.Models
{

    /// <summary>
    /// Burası writer prop tutacak sadece WriterImage'in veritipi değişecek entity'yi değiştirmemek için kulllanılıyor
    /// </summary>
    public class AddProfileImage
    {
        public int WriterId { get; set; }

        public string WriterName { get; set; }

        public string WriterAbout { get; set; }

        public IFormFile WriterImage { get; set; }

        public string WriterMail { get; set; }

        public string WriterPassword { get; set; }

        public bool WriterStatus { get; set; }

    }
}
