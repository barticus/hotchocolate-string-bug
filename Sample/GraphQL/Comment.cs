using System;
using System.ComponentModel.DataAnnotations;

namespace Sample.GraphQL
{
    public class Comment
    {
        public Guid Id { get; set; }

        [Required]
        public string Content { get; set; } = default!;
    }
}
