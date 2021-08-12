using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    class Vehicle
    {
        private string m_ModelName;
        private string m_LicenseNumber;
        private float m_EnergyPercentage;
        protected List<Wheel> m_ListOfWheels;

        public Vehicle(string i_ModelName, string i_LicenseNumber,float i_EnergyPercentage, List<Wheel> i_ListOfWheels)
        {
            m_ModelName = i_ModelName;
            m_LicenseNumber = i_LicenseNumber;
                m_EnergyPercentage = i_EnergyPercentage;
                m_ListOfWheels = i_ListOfWheels;
        }




    }
}
