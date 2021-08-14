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
            userInputList = GetUserInputList(messagesForTheUserList);

        }

        private static int getUserChoiceFromEnumValues(Type i_Enum)
        {
            Array enumValues = Enum.GetValues(i_Enum);
            int numOfEnumValues = enumValues.Length;
            int indexOfEnumValue = 0;
            bool isNumber, isValidEnum = false;
            string textualIndexOfEnumValue;

            while (!isValidEnum)
            {
                int currentValueIndex = 1;
               
                    Console.WriteLine("Choose one of the following: ");
                    foreach (object enumValue in enumValues)
                    {
                        Console.WriteLine(string.Format("{0}- {1}", currentValueIndex, enumValue));
                        currentValueIndex++;
                    }
                

                textualIndexOfEnumValue = Console.ReadLine();
                isNumber = int.TryParse(textualIndexOfEnumValue, out indexOfEnumValue);
                if (isNumber && indexOfEnumValue >= 1 && indexOfEnumValue <= numOfEnumValues)
                {
                    isValidEnum = true;
                }
                else
                {
                    Console.WriteLine("Wrong input, please try again");
                }
            }

            return indexOfEnumValue;
        }
        private void setVehicleDetails(out VehicleDetails o_VehicleInformation,Vehicle i_Vehicle)
        {
            string ownerName;
            string ownerPhoneNumber;
            Console.WriteLine("Please enter the owners name");
            ownerName = Console.ReadLine();
            Console.WriteLine("Please enter the owners phone number");
            ownerPhoneNumber = Console.ReadLine();

            o_VehicleInformation = new VehicleDetails(i_Vehicle, ownerName, ownerPhoneNumber, (VehicleDetails.eVehicleStatus)1);

        }
        private List<string> GetUserInputList(List<string> messagesForTheUserList)
        {
            List<string> userInputList = new List<string>();

            Console.Clear();
            foreach (string userInput in userInputList)
            {
                Console.WriteLine("Please enter " + userInput);
                userInputList.Add(Console.ReadLine());
            }

            return userInputList;
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
