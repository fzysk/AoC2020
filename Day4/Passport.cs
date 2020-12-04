using Day4.Attributes;
using System;
using System.Reflection;

namespace Day4
{
    internal class Passport
    {
        /// <summary>
        /// Birth Year
        /// </summary>
        [Required]
        [Range(1920, 2002)]
        public string byr { get; set; }

        /// <summary>
        /// Issue Year
        /// </summary>
        [Required]
        [Range(2010, 2020)]
        public string iyr { get; set; }

        /// <summary>
        /// Expiration Year
        /// </summary>
        [Required]
        [Range(2020, 2030)]
        public string eyr { get; set; }

        /// <summary>
        /// Height
        /// </summary>
        [Required]
        [Height]
        public string hgt { get; set; }

        /// <summary>
        /// Hair Color
        /// </summary>
        [Required]
        [Color]
        public string hcl { get; set; }

        /// <summary>
        /// Eye Color
        /// </summary>
        [Required]
        [EyeColor]
        public string ecl { get; set; }

        /// <summary>
        /// Passport ID
        /// </summary>
        [Required]
        [PasspordId]
        public string pid { get; set; }

        /// <summary>
        /// Country ID
        /// </summary>
        public string cid { get; set; }

        public bool IsPassportValid()
        {
            foreach (PropertyInfo prop in typeof(Passport).GetProperties())
            {
                string value = (string)prop.GetValue(this);

                foreach (IValiditationAttribute attribute in prop.GetCustomAttributes(true))
                {
                    if (!attribute.IsValid(value))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public override string ToString()
        {
            return $"byr:{byr},iyr:{iyr},eyr:{eyr},hgt:{hgt},hcl:{hcl},ecl:{ecl},pid:{pid},cid:{cid}";
        }
    }
}
