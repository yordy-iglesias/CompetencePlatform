using System.ComponentModel.DataAnnotations;

namespace CompetencePlatform.Core.Common
{
    public abstract class BaseEntity
    {
        [Key]
        /// <summary>
		/// Gets or sets the identifier.
		/// </summary>
        public int Id { get; set; }
    }
}
