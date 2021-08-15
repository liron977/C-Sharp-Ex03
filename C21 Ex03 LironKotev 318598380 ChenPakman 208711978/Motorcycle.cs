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

        public struct Constants
        {
            public const int k_NumOfWheels = 2;
            public const float k_MotorcycleMaxAirPressure = 30.0f;
            public const FuelEngine.eFuelType k_FuelType = FuelEngine.eFuelType.Octan95;
            public const float k_MaxBatreryTime = 1.2f;
            public const float k_MaxFuelCapacity = 7f;
        }

        public Motorcycle(
            string i_MotorcycleModel,
            string i_LicenseNumber,
            float i_EnergyPercentage,
            List<Wheel> i_Wheels,
             Engine i_EnginType,
            eLicenseType i_LicenseType,
            int i_EngineCapacity)
            : base(i_MotorcycleModel, i_LicenseNumber, i_EnergyPercentage, i_Wheels, i_EnginType)
        {
            m_EngineCapacity = i_EngineCapacity;
            m_LicenseType = i_LicenseType;
        }

        /*public override float GetMaxPower(VehicleManufacturing.eEngineType i_EnergyType)
        {
            if (i_EnergyType == VehicleManufacturing.eEngineType.Gas)
            {
                return Constants.k_MaxFuelCapacity;
            }
            else
            {
                return Constants.k_MaxBatreryTime;
            }
        }*/
        public override string ToString()
        {
            string MotorcycleDetails= string.Format($@"{base.ToString()} 
The motorcycle information:
The license type: {m_LicenseType};
The engine Capacity: {m_EngineCapacity}
");
            return MotorcycleDetails;
        }
        public static void GetDynamicParameter(Dictionary<string, Type> io_DynamicParams)
        {
            io_DynamicParams.Add("License type", typeof(eLicenseType));
            io_DynamicParams.Add("Engine volume", typeof(int));
        }

    }
}
