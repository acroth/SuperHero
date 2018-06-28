using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroes.Data//.MetaData
{
    [MetadataType(typeof(CoursMetadata))]
    public partial class Cours { }
    class CoursMetadata
    {
        [Required]
        public string Name { get; set; }    
        public string Description { get; set; }
        [Required]
        [Display (Name ="Date & Time")]       
        public System.DateTime DateTime { get; set; }
        [Required]
        public string Location { get; set; }
        public Nullable<int> Capacity { get; set; }
        [Required]
        public int CourseID { get; set; }

    }
}
