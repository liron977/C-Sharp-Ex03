using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    class Motorcycle : Vehicle
    {
        public enum eLicenseType
        {
            A,
            B1,
            AA,
            BB
        }
        private eLicenseType m_LicenseType;
        private readonly int m_EngineCapacity;

        public Motorcycle(
            string i_MotorcycleModel,
            string i_LicenseNumber,
            float i_EnergyPercentage,
            List<Wheel> i_Wheels,
            eLicenseType i_LicenseType,
            int i_EngineCapacity)
            : base(i_MotorcycleModel, i_LicenseNumber, i_EnergyPercentage, i_Wheels)
        {
            m_EngineCapacity = i_EngineCapacity;
            m_LicenseType = i_LicenseType;
        }

    }
}
