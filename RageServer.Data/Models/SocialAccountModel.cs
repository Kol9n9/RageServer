using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RageServer.Data.Models
{
    public class SocialAccountModel
    {
        [Key]
        public int SocialAccountId { get; set; }
        public ulong SocialId { get; set; }
    }
}
