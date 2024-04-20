using CompetencePlatform.Core.Common;

namespace CompetencePlatform.Core.Entities
{
    public class TodoList : BaseEntity, IAuditedEntity
    {
        public string Title { get; set; }

        public List<TodoItem> Items { get; } = new List<TodoItem>();

        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }
        // <summary>
        /// Gets or sets the Delete Borrado Logico.
        /// </summary>
        public bool? Deleted { get; set; }
        /// <summary>
		/// Gets or sets the IsSelected Determine if this Object is part of the organization
		/// </summary>
        public bool? IsSelected { get; set; }
    }
}
