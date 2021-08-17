using System;


namespace Ex03.GarageLogic
{
   public class  VehicleDetails
    {
        public enum eVehicleStatus
        {
            Repair=1,
            Fixed,
            Paid
        }
        private Vehicle m_Vehicle;
        private string m_OwnerName;
        private string m_OwnerPhoneNumber;
        public eVehicleStatus m_VehicleStatus;

        public VehicleDetails(Vehicle i_Vehicle,string i_OwnerName, string i_OwnerPhoneNumber)
        {
            m_Vehicle = i_Vehicle;
            m_OwnerName = i_OwnerName;
            m_OwnerPhoneNumber = i_OwnerPhoneNumber;
            m_VehicleStatus = eVehicleStatus.Repair;


        }


        public string OwnerName
        {
            get
            {
                return m_OwnerName;
            }
            set
            {
                m_OwnerName = value;
            }
        }

        public string OwnerPhoneNumber
        {
            get
            {
                return m_OwnerPhoneNumber;
            }
            set
            {
                m_OwnerPhoneNumber = value;
            }
        }
        public Vehicle Vehicle
        {
            get
            {
                return m_Vehicle;
            }
            set
            {
                m_Vehicle = value;
            }
        }

        public eVehicleStatus VehicleStatus
        {
            get
            {
                return m_VehicleStatus;
            }
            set
            {
                m_VehicleStatus = value;
            }
        }
        public override string ToString()
        {

            string vehicleDetails =  String.Format(
                $@"
The owner's name is: {m_OwnerName} 
The owner's phone number is: {m_OwnerPhoneNumber}    
The vehicle information is: 
{m_Vehicle.ToString()}
The status of the vehicle: {m_VehicleStatus.ToString()}");

            return vehicleDetails;

        }


    }
}
