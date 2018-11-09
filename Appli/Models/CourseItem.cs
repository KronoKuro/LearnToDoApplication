using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appli.Models
{
    public class CourseItem
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public bool IsCompleted { get; set; } 

        public string CourseId { get; set; }

        public virtual Course Course { get; set; }

        public byte[] ImageData { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ImageMimeType { get; set; }
    }
}
