using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
   public class VehicleManufacturing
    {
        private enum eVehicleType
        {
            GasMototorcycle=1,
            ElectricMototorcycle,
            GasCar,
           ElectricCar,
            Truck

        }
        public void CreateVehicle(int i_VehicleToCreate,string i_LicenseNumber,string i_VehicleModelName,)
        {
            Vehicle vehicleToReturn;
            switch (i_VehicleToCreate)
            {

                case 1:
                    {
                        vehicleToReturn =new Motorcycle(i_VehicleModelName,i_LicenseNumber,)
                    }
                   




            }

        }
    }
}
