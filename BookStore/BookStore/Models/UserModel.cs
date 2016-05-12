using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;


namespace BookStore.Models
{
    public class GrupedUserModel
    {

        public List<UserModel> Users { get; set; }
    }
    public class UserModel
    {

        //public string RoleId { get; set; }
        public string Email { get; set; }
    }
    

}