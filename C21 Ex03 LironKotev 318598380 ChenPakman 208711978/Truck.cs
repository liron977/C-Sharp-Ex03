using System;
using System.Collections.Generic;


namespace Ex03.GarageLogic
{
   public class Truck :Vehicle
    {
        private readonly bool r_IsCarrierDangerousMaterials;
        private readonly float r_MaxCarryingAmount;

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
            r_IsCarrierDangerousMaterials = i_IsCarrierDangerousMaterials;
            r_MaxCarryingAmount = i_MaxCarryingAmount;
            base.NumOfWheels = eNumOfWheels.Truck;
        }

        
        public override string ToString()
        {
            string truckDetails=string.Format($@"{base.ToString()} 
The Truck information:
Is truck carriers dangerous materials ? {r_IsCarrierDangerousMaterials}
The max carrying amount is : {r_MaxCarryingAmount}
");
            return truckDetails;
        }

        public static void GetDynamicParameter(Dictionary<string, Type> o_DynamicParams)
        {
            o_DynamicParams.Add("Dangerous Materials", typeof(bool));
            o_DynamicParams.Add("Cargo Volume", typeof(float));
        }

    }
}
