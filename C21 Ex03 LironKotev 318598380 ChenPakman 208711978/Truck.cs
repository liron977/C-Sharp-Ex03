using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
   public class Truck :Vehicle
    {
        private bool m_IsCarrierDangerousMaterials;
        private float m_MaxCarryingAmount;
        public struct Constants
        {
            public const int k_NumOfWheels = 16;
            public const float k_TruckMaxAirPressure = 28.0f;
            public const FuelEngine.eFuelType k_FuelType = FuelEngine.eFuelType.Soler;
            public const float k_MaxFuelCapacity = 120f;
        }

        public Truck(
            string i_TruckModel,
            string i_LicenseNumber,
            float i_EnergyPercentage,
            List <Wheel> i_Wheels,
             Engine i_EngineType,
           bool i_IsCarrierDangerousMaterials,
            float i_MaxCarryingAmount)
           : base(i_TruckModel, i_LicenseNumber, i_EnergyPercentage, i_Wheels, i_EngineType)
        {
            m_IsCarrierDangerousMaterials = i_IsCarrierDangerousMaterials;
            m_MaxCarryingAmount = i_MaxCarryingAmount;
        }

        /*public override float GetMaxPower(VehicleManufacturing.eEngineType i_EnergyType)
        {
            return Constants.k_MaxFuelCapacity;

        }*/
        public override string ToString()
        {
            string truckDetails=string.Format($@"{base.ToString()} 
The Truck information:
Is truck carriers dangerous materials ?: {m_IsCarrierDangerousMaterials};
The max carrying amount is : {m_MaxCarryingAmount}
");
            return truckDetails;
        }

        public static void GetDynamicParameter(Dictionary<string, Type> io_DynamicParams)
        {
            io_DynamicParams.Add("Dangerous Materials", typeof(bool));
            io_DynamicParams.Add("Cargo Volume", typeof(float));
        }

    }
}
