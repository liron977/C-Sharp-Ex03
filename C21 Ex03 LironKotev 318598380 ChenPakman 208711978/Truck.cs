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

        public Truck(
            string i_TruckModel,
            string i_LicenseNumber,
            float i_EnergyPercentage,
            List <Wheel> i_Wheels,
           bool i_IsCarrierDangerousMaterials,
            float i_MaxCarryingAmount)
           : base(i_TruckModel, i_LicenseNumber, i_EnergyPercentage, i_Wheels)
        {
            m_IsCarrierDangerousMaterials = i_IsCarrierDangerousMaterials;
            m_MaxCarryingAmount = i_MaxCarryingAmount;
        }
        public override string ToString()
        {
            string truckDetails=string.Format($@"{base.ToString()} 
The Truck information:
Is truck carriers dangerous materials ?: {m_IsCarrierDangerousMaterials};
The max carrying amount is : {m_MaxCarryingAmount}
");
            return truckDetails;
        }

    }
}
