using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFSolutionsModel
{
    public class EmpAppAccount : NotMapped.DBentity
    {

        [Required(ErrorMessage = "AppPermissions can not empty")]
        public UInt64 AppPermissions { get; set; } = 0;


        [Required(ErrorMessage = "Password  can not empty")]
        //[MaxLength(42)] TODO: is een uitzondering
        public string Password { get; set; }


        [Required(ErrorMessage = "Username can not empty")]
        [MaxLength(20, ErrorMessage = "Gebruikersnaam kan niet langer zijn dan 20 karakters")]  //,ErrorMessage="Name cannot be greater than 50")
        [MinLength(5)]
        [Index(IsUnique = true)]
        public string UserName { get; set; }


        [Required(ErrorMessage = "LastResetted can not empty")]
        public DateTime LastResetted { get; set; } = DateTime.Now;



        [Required(ErrorMessage = "IsBlocked can not empty")]
        public bool IsBlocked { get; set; } = false;


        [Required(ErrorMessage = "IsPaswordResseted can not empty")]
        public bool IsPaswordResseted { get; set; } = true;


        [Required(ErrorMessage = "InlogAttempts can not empty")]
        public byte InlogAttempts { get; set; } = 0;



        //--------------navigation propertys------------//

        public virtual Employee Employee { get; set; }

    }
}
