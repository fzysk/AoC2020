using Day4.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Day4
{
    internal class Passport
    {
        /// <summary>
        /// Birth Year
        /// </summary>
        [Required]
        public string byr { get; set; }

        /// <summary>
        /// Issue Year
        /// </summary>
        [Required]
        public string iyr { get; set; }

        /// <summary>
        /// Expiration Year
        /// </summary>
        [Required]
        public string eyr { get; set; }

        /// <summary>
        /// Height
        /// </summary>
        [Required]
        public string hgt { get; set; }

        /// <summary>
        /// Hair Color
        /// </summary>
        [Required]
        public string hcl { get; set; }

        /// <summary>
        /// Eye Color
        /// </summary>
        [Required]
        public string ecl { get; set; }

        /// <summary>
        /// Passport ID
        /// </summary>
        [Required]
        public string pid { get; set; }

        /// <summary>
        /// Country ID
        /// </summary>
        public string cid { get; set; }

        public bool IsPassportValid()
        {
            IEnumerable<PropertyInfo> requiredProperties =
                typeof(Passport).GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(RequiredAttribute)));

            foreach (PropertyInfo prop in requiredProperties)
            {
                if (prop.GetValue(this) == null)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
