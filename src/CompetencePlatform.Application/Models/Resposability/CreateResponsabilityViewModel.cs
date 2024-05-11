using CompetencePlatform.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Application.Models.Resposability
{
    public class CreateResponsabilityViewModel : ResponsabilityViewModel
    {
        public int? CompetenceProfileId { get; set; }

    }
}
