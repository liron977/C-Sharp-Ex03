using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
   public abstract class Vehicle
    {
        public enum eNumOfWheels
        {
            Motorcycle = 2,
            Car = 4,
            Truck = 16
        }
        protected string m_ModelName;
        protected readonly string r_LicenseNumber;
        protected float m_EnergyPercentage;
        protected List<Wheel> m_ListOfWheels;
        protected eNumOfWheels m_NumOfWheels;
        public Engine m_EngineType;

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

        public eNumOfWheels NumOfWheels
        {
            get
            {
                return m_NumOfWheels;
            }
            set
            {
                m_NumOfWheels = value;
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

        public override string ToString()
        {

            string vehicelDetails = string.Format(
                $@"
The model is: {m_ModelName} 
The license number is: {r_LicenseNumber}    
The energy ercentage is: {m_EnergyPercentage}
{m_ListOfWheels[0].ToString()}
{m_EngineType.ToString()}");

            return vehicelDetails;

        }

        public static void GetListOfDataMembers(ref List<string> io_DataMemberList)
        {
            io_DataMemberList.Add("Module Name");
            io_DataMemberList.Add("Current energy in vehicle");
        }

    }
}
