using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Twitter.Models;

namespace Twitter.App.Models
{
    public class TagShortModel
    {
        public static Expression<Func<Tag, TagShortModel>> FromTag
        {
            get
            {
                return tag => new TagShortModel
                {
                    Id = tag.Id,
                    Name = tag.Name
                };
            }
        }
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }
    }
}