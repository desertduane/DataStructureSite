using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStructureSite.Models
{
    public class StructureTitleViewModel
    {
        public List<Datastructure> datastructure;
        public SelectList titles;
        public string datastructureTitle { get; set; }

    }
}
