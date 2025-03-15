using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentInformationSystem.Infrastructure.Entities
{
    [Table("User")]
    public class User : IdentityUser
    { }

    
}
