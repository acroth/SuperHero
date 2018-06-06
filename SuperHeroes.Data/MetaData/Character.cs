using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroes.Data//.MetaData
{
    [MetadataType(typeof (CharacterMetadata))]
    public partial class Character { }
    class CharacterMetadata
    {
        [Required]
        [Display(Name = "Character ID")]
        public int CharacterID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Alias { get; set; }
        [Required]
        public string Description { get; set; }
        [Display(Name ="Hero")]
        public Nullable<bool> IsHero { get; set; }
        [Display(Name = "Villain")]
        public Nullable<bool> IsVillan { get; set; }

    }
}
