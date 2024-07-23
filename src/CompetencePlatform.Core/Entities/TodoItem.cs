﻿using CompetencePlatform.Core.Common;

namespace CompetencePlatform.Core.Entities
{
    public class TodoItem : BaseEntity, IAuditedEntity
    {
        public string Title { get; set; }

        public string Body { get; set; }

        public bool IsDone { get; set; }

        public virtual TodoList List { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public int UpdatedBy { get; set; }

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
