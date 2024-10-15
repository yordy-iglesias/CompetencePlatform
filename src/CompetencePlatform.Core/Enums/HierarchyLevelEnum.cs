using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Core.Enums
{
    public enum HierarchyLevelEnum
    {
        None = 0,
        [Description("High Management")]
        //Alta Dirección (C-Suite o Ejecutiva)
        C_Suite = 1,
        [Description("Functional Managment")]
        //Dirección Funcional (Jefes de Área o Directores de Departamento)
        Functional_Managment =1,
        [Description("Intermediate Managment")]
        //Gerencia Intermedia (Gerentes de División o Unidad)
        Intermediate_Management =2,
        [Description("Operative Supervisors")]
        //Supervisores/Coordinadores (Supervisión Operativa)
        Operative_Supervisors =3,
        [Description("Operative Level")]
        //Nivel Operativo (Personal operativo o especializado)
        Operative_Level =4,
        [Description("Subcontrated Support Personal")]
        //Personal de Soporte y Subcontratados
        Subcontrated_Support_Personal =5
    }
}
