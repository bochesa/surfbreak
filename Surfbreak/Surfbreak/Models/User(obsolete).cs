using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Surfbreak.Models
{
    public class User
    {
        public long Id { get; set; }
        private string _key;

        public string Key
        {
            get {
                if(_key == null)
                {
                    _key = Regex.Replace(Name.ToLower(), "[^a-z0-9]", "-");
                }
                return _key;
            }
            set { _key = value; }
        }

        private bool isAdmin = false;
        [BindNever, Display(Name ="User is an Admin ")]
        public bool IsAdmin
        {
            get { return isAdmin; }
            set { isAdmin = value; }
        }
        [Display(Name = "User Name")]
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Please input a valid Email address")]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [RegularExpression("^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z]).{8,32}$", 
            ErrorMessage = "The password must contain at least one upper and lower case letter, one number and have at least 8 characters")]
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
        //[Timestamp]
        //[ConcurrencyCheck]
        //public byte[] RowVersion { get; set; }
    }
}
