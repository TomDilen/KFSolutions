using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFSrepository_EF6.TDS
{
    public interface ISetInactiveInsteadOfRemove
    {

        [Required]
        bool IsActive { get; set; }
    }
}
