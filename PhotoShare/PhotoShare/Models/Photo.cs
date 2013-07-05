using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PhotoShare.Models
{

    // Custom Validation Method 1:
    public class MinimumTwoWordsAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string[] words = value.ToString().Split(' ');
                if (words.Length < 2)
                    return new ValidationResult("Your blurb must have at least two words");
            }
            return ValidationResult.Success;
        }
    }

    public class Photo
    {
        public int ID { get; set; }

        [Required]
        [StringLength(140)]
        [Display(Name="Blurb")]
        [MinimumTwoWords]
        public string Description { get; set; }

        public string FilePath { get; set; }
        
        [Range(1,10)]
        public int Rating { get; set; }
        public int AlbumID { get; set; }
    }
}