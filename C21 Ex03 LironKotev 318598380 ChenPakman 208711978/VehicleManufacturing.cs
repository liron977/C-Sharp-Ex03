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
        /*public void CreateVehicle(int i_VehicleToCreate,string i_LicenseNumber,string i_VehicleModelName,)
        {
            Vehicle vehicleToReturn;
            switch (i_VehicleToCreate)
            {

                case 1:
                    {
                        vehicleToReturn =new Motorcycle(i_VehicleModelName,i_LicenseNumber,)
                    }
                   




            }*/
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
