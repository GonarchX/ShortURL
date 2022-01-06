using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShortURL.Models
{
    public class ShortUrlInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        //ShortURL
        [Required(AllowEmptyStrings = false)]
        public string Token { get; set; }
        
        [Required]
        public string LongUrl { get; set; }
        
        [Required]
        public DateTime CreateDate { get; set; }

        [Required]
        public int ClickNum { get; set; }
    }
}