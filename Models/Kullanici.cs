using System.ComponentModel.DataAnnotations;

namespace TestProject.Models
{
    /// Kullanici Modeli . Bir Kullaniciya ait bütün bilgileri içerir . Bütün CRUD işlemleri bu model üzerinden gerçekleştirilir.
    public class Kullanici
    {
        //Kullaniciya ait kayıt sırası .
        [Key]
        public int Id { get; set; }
        //Kullanici Adı
        public string Name { get; set; } = null!;
        //Kullanici Soyadı
        public string LastName { get; set; } = null!;
        //Kullanici Kullanıcı Adı
        public string UserName { get; set; } = null!;
        //Kullanicinin şifresi
        public string Password { get; set; } = null!;
        //Kullanicinin e-posta adresi 
        public string EmaillAddress { get; set; } = null!;
        //Kullanicinin telefon numarasi
        public string PhoneNumber { get; set; } = null!;
        
    }
}
