
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class UserApp : IdentityUser
    {
        public UserApp()
        {
            IsActive = false;
        }
        public string Name { get; set; }
        public string CardId { get; set; }
        
        public bool IsActive { get; set; }

    }
}
