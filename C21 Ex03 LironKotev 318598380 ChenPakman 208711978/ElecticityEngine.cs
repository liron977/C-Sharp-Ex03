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

        public void chargingAction(float i_BatteryhoursToCharge)
        {
            float newBatteryHoursAmount = i_BatteryhoursToCharge + base.m_CurrentEnginePower;
            if (newBatteryHoursAmount > base.m_MaxEnginePower)
            {
                throw new ValueOutOfRangeException(base.m_CurrentEnginePower, base.m_MaxEnginePower, 0);
            }
            else
            {
                base.CurrentEnginePower = newBatteryHoursAmount;
            }
        }
        public override string ToString()
        {
            string EngineDetails = string.Format($@"
The Engin Type is: Electricity type
");
            return EngineDetails;
        }

    }

}

