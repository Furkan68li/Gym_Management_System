namespace SporSalonuYönetimSistemi.Models
{
    public class Admin
    {
        public int AdminId { get; set; }    
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
