using System;
using System.Collections.Generic;


namespace Ex03.GarageLogic
{
    class Motorcycle : Vehicle
    {
        public enum eLicenseType
        {
            A=1,
            B1,
            AA,
            BB
        }
        private readonly eLicenseType r_LicenseType;
        private readonly int r_EngineCapacity;

        public Motorcycle(
            string i_MotorcycleModel,
            string i_LicenseNumber,
            float i_EnergyPercentage,
            List<Wheel> i_Wheels,
             Engine i_EngineType,
            eLicenseType i_LicenseType,
            int i_EngineCapacity)
            : base(i_MotorcycleModel, i_LicenseNumber, i_EnergyPercentage, i_Wheels, i_EngineType)
        {
            r_EngineCapacity = i_EngineCapacity;
            r_LicenseType = i_LicenseType;
        }

      
        public override string ToString()
        {
            string motorcycleDetails= string.Format($@"{base.ToString()} 
The motorcycle information:
The license type: {r_LicenseType}
The engine Capacity: {r_EngineCapacity}
");
            return motorcycleDetails;
        }
        public static void GetDynamicParameter(Dictionary<string, Type> o_DynamicParams)
        {
            o_DynamicParams.Add("License type", typeof(eLicenseType));
            o_DynamicParams.Add("Engine volume", typeof(int));
        }

    }
}
