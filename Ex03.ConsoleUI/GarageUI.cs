using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class GarageUI
    {
       public void runGarage()
        {
            try
            {
                string userInputChoice;
                int userChoice;
                userInputChoice = Console.ReadLine();
                int.TryParse(userInputChoice, out userChoice);


            }
            catch
            {

            }

        }

        private void manageUserChoice(int userInputChoice)
        {
            switch (userInputChoice)
            {
                case 1:
                    {
                        insertVehicleToGarage();
                        break;
                    }
                case 2:
                    {
                        changeVehicleStatus();
                        break;
                    }

            }

        }

        private void changeVehicleStatus()
        {

        }
        private void insertVehicleToGarage()
        {
            List<string> messagesForTheUserList;
            List<string> userInputList;
            string userVehicleChoice;
            int userVehicleChoiceNumber;
            printVehicleOptionsMenu();
            userVehicleChoice = Console.ReadLine();
            int.TryParse(userVehicleChoice, out userVehicleChoiceNumber);
            messagesForTheUserList = VehicleManufacturing.ConvertUserChoiceToTypeOfVehicle((VehicleManufacturing.eVehicleType)userVehicleChoiceNumber);


        }
        
        private void printVehicleOptionsMenu()
        {
            string menuOptionsMessage = string.Format(@"1:Gas mototorcycle.
            2: Electric mototorcycle.
            3:Gas car.
            4:Electric car.
            5:Truck.");
            Console.WriteLine(menuOptionsMessage);


        }
        private void printMenu()
        {
           string menuMessage= string.Format(@"1: Insert vehicle to the garage.
2: Present license number list.
3: Change vehicle status.
4: Pump wheels air pressure to maximum.
5: Refuel a vehicle that runs on fuel.
6: Charge electricity vehicle.
7: Present vehicle details.
");
            Console.WriteLine(menuMessage);
        }
    }
}
