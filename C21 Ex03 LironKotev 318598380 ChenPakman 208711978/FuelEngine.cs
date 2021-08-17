using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
   public class FuelEngine :Engine
    {
    
        public enum eFuelType
        {
            Octan98=1,
            Octan96,
            Octan95,
            Soler
        }
        private eFuelType m_FuelType;

        public FuelEngine(
      eFuelType i_FuelType,
     float i_CurrentEnginePower,
     float i_MaxEnginePower)
     : base(i_CurrentEnginePower, i_MaxEnginePower)
        {
            m_FuelType = i_FuelType;
        }
        public eFuelType FuelType
        {
            get
            {
                return m_FuelType;
            }
            set
            {
                m_FuelType = value;
            }
        }
        public void RefuelingAction(eFuelType i_FuelType, float i_FuelToAdd)
        {
            float newFuelAmount = i_FuelToAdd + base.m_CurrentEnginePower;
            if (i_FuelType != m_FuelType)
            {
                throw new ArgumentException("The Fuel type does not match");
            }
            else
            {
                if(newFuelAmount>base.m_MaxEnginePower)
                {
                    throw new ValueOutOfRangeException(base.m_CurrentEnginePower,base.m_MaxEnginePower,0);
                }
                else
                {
                    base.CurrentEnginePower = newFuelAmount;
                }
            }
        }
        public override string ToString()
        {
            string EngineDetails = string.Format($@"
The Engin Type is: Fuel type
");
            return EngineDetails;
        }

    }
}
