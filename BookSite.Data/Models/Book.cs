
using System.ComponentModel.DataAnnotations;

namespace BookSite.Data;

public class Book
{
		public int Id { get; set; }

		[Required]
		[MaxLength(64)]
        public string Title { get; set; } = string.Empty;

		[Required]
		[MaxLength(64)]
        public string Author { get; set; } = string.Empty;

		public DateTime? CreatedOn {get;set;}
		public DateTime? UpdatedOn {get;set;}
}
