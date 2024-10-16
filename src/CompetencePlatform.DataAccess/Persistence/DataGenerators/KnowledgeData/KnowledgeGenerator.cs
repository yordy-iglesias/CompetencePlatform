using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompetencePlatform.Core.Entities;

namespace CompetencePlatform.Core.DataAccess.Persistence.DataGenerators.KnowledgeData
{
    public static class KnowledgeGenerator
    {
        public static List<Knowledge> Generate()
        {
            var knowledgeList = new List<Knowledge>();
            var knowldgeNames = new List<string>()
            {
                "Ingeniería de software.",
                "Ingeniería de requisitos (Estándar IEEE 830).",
                "Gestión de proyectos.",
                "Mejora de procesos.",
                "Metodología tradicional (RUP) y ágiles (al menos dos de las siguientes: SCRUM, Kanban, Extreme Programming (XP), Lean Software Development, entre otras).",
                "Proceso de desarrollo de software (ISO/IEC/IEEE 12207).",
                "Modelos de ciclo de vida (cascada, iterativo, incremental, espiral, iterativo – incremental, evolutivo).",
                "Nociones básicas del modelado de negocio.",
                "Idioma inglés.",
                "Nociones básicas de Programación y Bases de datos.",
                "Nociones básicas de negocio (objetivos empresariales, restricciones y oportunidades en el contexto empresarial)."
            };
            foreach (var knw in knowldgeNames)
            {
                var knowledge = new Knowledge();
                if (knw.Equals("Metodología tradicional (RUP) y ágiles (al menos dos de las siguientes: SCRUM, Kanban, Extreme Programming (XP), Lean Software Development, entre otras)."))
                    knowledge.Name = "Metodología tradicional y ágiles";
                else if (knw.Equals("Nociones básicas de negocio (objetivos empresariales, restricciones y oportunidades en el contexto empresarial)."))
                    knowledge.Name = "Nociones básicas de negocio";
                else
                    knowledge.Name = knw;
                knowledge.Description = knw;
                knowledge.IsDefault= true;
                knowledge.Deleted= false;
                knowledgeList.Add(knowledge);
               
            }
            return knowledgeList;
        }
    }
}
