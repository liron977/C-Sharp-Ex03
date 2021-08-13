using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
   public abstract class Vehicle
    {
        protected string m_ModelName;
        protected readonly string r_LicenseNumber;
        protected float m_EnergyPercentage;
        protected List<Wheel> m_ListOfWheels;
        protected Engine m_EngineType;

        public Vehicle(string i_ModelName, string i_LicenseNumber,float i_EnergyPercentage, List<Wheel> i_ListOfWheels)
        {
            m_ModelName = i_ModelName;
            r_LicenseNumber = i_LicenseNumber;
                m_EnergyPercentage = i_EnergyPercentage;
                m_ListOfWheels = i_ListOfWheels;
        }
        public void inflationWheelsAirToMaximum()
        {
            float airLeftToFill = 0;

            foreach (Wheel element in m_ListOfWheels)
            {

                airLeftToFill = element.MaxAirPressure - element.CurrentAirPressure;
                element.InflationAction(airLeftToFill);
            }

        }
        public string ModelName
        {
            get
            {
                return m_ModelName;
            }
            set
            {
                m_ModelName = value;
            }
        }

        public string LicenseNumber
        {
            get
            {
                return r_LicenseNumber;
            }

        }

        public float EnergyPercentage
        {
            get
            {
                return m_EnergyPercentage;
            }
            set
            {
                m_EnergyPercentage = value;
            }
        }

        public List<Wheel> ListOfWheels
        {
            get
            {
                return m_ListOfWheels;
            }
            set
            {
                m_ListOfWheels = value;
            }
        }

        public Engine EngineType
        {
            get
            {
                return m_EngineType;
            }
            set
            {
                m_EngineType = value;
            }
        }




    }
}
