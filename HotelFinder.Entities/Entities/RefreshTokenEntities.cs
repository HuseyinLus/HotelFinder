using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class RefreshTokenEntities
    {
        public int Id { get; set; }  // Token'ın benzersiz kimliği
        public string? Token { get; set; } // Yenileme tokenı
        public DateTime Expires { get; set; } // Token'ın geçerlilik süresi
        public int UserId { get; set; } // Token'ın ait olduğu kullanıcı kimliği
        public bool IsRevoked { get; set; } // Token'ın iptal edilip edilmediğini belirten bayrak
        public DateTime CreatedAt { get; set; }  // Token'ın oluşturulma zamanı

        public Login? Logins { get; set; } // İlişkili kullanıcı
    }
}
