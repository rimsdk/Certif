using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace Gestion_Certif.ViewModels
{
    public class AuthVM
    { 
        public string? email { get; set; }
       
        public string? password { get; set; }
      

    }
}
