using System;

namespace Posting.Core.Dtos
{
    public class PostDto
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public DateTime? Date { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
