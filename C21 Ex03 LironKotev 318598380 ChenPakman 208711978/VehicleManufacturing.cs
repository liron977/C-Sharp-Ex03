using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
   public abstract class VehicleManufacturing
    {
        public  enum eVehicleType
        {
            GasMototorcycle=1,
            ElectricMotorcycle,
            GasCar,
           ElectricCar,
            Truck

        }
        public void CreateVehicle(float[] currentAirPressure, List<string> i_VehicleInformation, eVehicleType i_TypeOfVehicle, string i_LicenseNumber)
        {
            Vehicle vehicleToReturn;
            float energyPersantage;
            switch (i_TypeOfVehicle)
            {

                case eVehicleType.GasMototorcycle:
                    {
                        energyPersantage = float.Parse(i_VehicleInformation[1]);
                        vehicleToReturn = new Motorcycle((string)i_VehicleInformation[0], i_LicenseNumber, energyPersantage,,)
                            break;
                    }
                   




            }
        public static List<string> ConvertUserChoiceToTypeOfVehicle(eVehicleType i_UserChoiceForVehicle)
        {
            List<string> vehicleDataMembers = new List<string>();

            switch (i_UserChoiceForVehicle)
            {
                case eVehicleType.GasMototorcycle: case eVehicleType.ElectricMotorcycle:
                    {
                        Motorcycle.GetListOfDataMembers(ref vehicleDataMembers);
                        break;
                    }

                case eVehicleType.GasCar: case eVehicleType.ElectricCar:
                    {
                        Car.GetListOfDataMembers(ref vehicleDataMembers);
                        break;
                    }
                case eVehicleType.Truck:
                    {
                        Truck.GetListOfDataMembers(ref vehicleDataMembers);
                        break;
                    }
                    
            }
            Engine.GetListOfDataMembers(ref vehicleDataMembers);
            return vehicleDataMembers;
        }

    }
    }
}
