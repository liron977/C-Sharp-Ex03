using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    class ElecticityEngine : Engine
    {
        public ElecticityEngine(
           float i_CurrentEnginePower,
           float i_MaxEnginePower)
           : base(i_CurrentEnginePower, i_MaxEnginePower)
        {
         
        }
    }
}
