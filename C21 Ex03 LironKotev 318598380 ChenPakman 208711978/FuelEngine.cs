using System;


namespace Ex03.GarageLogic
{
    public class FuelEngine : Engine
    {
        public enum eFuelType
        {
            Octan98 = 1,
            Octan96,
            Octan95,
            Soler
        }

        private eFuelType m_FuelType;

        public FuelEngine(eFuelType i_FuelType, float i_CurrentEnginePower, float i_MaxEnginePower)
            : base(i_MaxEnginePower, i_CurrentEnginePower)
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
            if(i_FuelType != m_FuelType)
            {
                throw new ArgumentException("The Fuel type does not match");
            }

            if(newFuelAmount > m_MaxEnginePower)
            {
                throw new ValueOutOfRangeException(m_CurrentEnginePower, m_MaxEnginePower, 0);
            }

            CurrentEnginePower = newFuelAmount;
        }

        public override string ToString()
        {
            string engineDetails = string.Format(
                $@"
The engine type is fuel type,and the fuel type {m_FuelType}
The energy amount is : {m_CurrentEnginePower}
");
            return engineDetails;
        }
    }
}