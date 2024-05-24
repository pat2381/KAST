using KAST.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAST.Domain.Entities
{
    public class Author : BaseEntity
    {
        public Guid AuthorId { get; set; }
        public string? Name { get; set; }
        public string? URL { get; set; }

        public List<Mod>? mods { get; set; }
    }
}
