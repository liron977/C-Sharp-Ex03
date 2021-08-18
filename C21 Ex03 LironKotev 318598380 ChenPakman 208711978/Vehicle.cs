using System.Collections.Generic;

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

        protected Vehicle(
            string i_ModelName,
            string i_LicenseNumber,
            float i_EnergyPercentage,
            List<Wheel> i_ListOfWheels,
            Engine i_EngineType)
        {
            m_ModelName = i_ModelName;
            r_LicenseNumber = i_LicenseNumber;
            m_EnergyPercentage = i_EnergyPercentage;
            m_ListOfWheels = i_ListOfWheels;
            m_EngineType = i_EngineType;
            UpdatePercent();
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
        public void UpdatePercent()
        {
            m_EnergyPercentage = (m_EngineType.CurrentEnginePower / m_EngineType.MaxEnginePower) * 100;
        }
        public override string ToString()
        {

            string vehicleDetails = string.Format(
                $@" 
The model is: {m_ModelName} 
The license number is: {r_LicenseNumber} 
The number of wheels is: {(int)m_NumOfWheels} 
The energy percentage amount is: {m_EnergyPercentage} %
{m_ListOfWheels[0].ToString()}
{m_EngineType.ToString()}");

            return vehicleDetails;

        }
       

    }
}
