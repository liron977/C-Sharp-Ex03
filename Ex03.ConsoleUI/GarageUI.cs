using System;
using System.Collections.Generic;
using System.Linq;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class GarageUI
    {

        public enum eMenuChoice
        {
            InsertVehicleToTheGarage = 1,
            PresentVehicleLicenseNumber,
            ChangeVehicleStatus,
            PumbAirWheelsToMax,
            RefuleVehicle,
            ChargeVehicle,
            PresentInformationOfvehicle,
            Exit
        }

        public static void StartMenu()
        {
            string userMenuChoice;
            int userMenuChoiceNumber;
            bool continueShowingMenu = true;
            Garage garage = new Garage();

            while (continueShowingMenu == true)
            {
                try
                {
                    PrintMenu();
                    userMenuChoice = Console.ReadLine();
                    bool isParsingWorked = int.TryParse(userMenuChoice, out userMenuChoiceNumber);
                    CheckUserChoice(userMenuChoiceNumber, isParsingWorked);

                    if (userMenuChoiceNumber == (int)eMenuChoice.Exit)
                    {
                        PrintExit();
                        continueShowingMenu = false;
                    }

                    else
                    {
                        HandleUserChoice(garage, userMenuChoiceNumber);
                    }

                }

                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

        }

        public static void CheckUserChoice(int i_UserChoice, bool i_IsValidChoice)
        {
            if (i_UserChoice < (int)eMenuChoice.InsertVehicleToTheGarage || i_UserChoice > (int)eMenuChoice.Exit || i_IsValidChoice == false)
            {
                throw new FormatException("Invalid option! please try again");
            }
        }

        public static void PrintMenu()
        {
            Console.WriteLine(Environment.NewLine);
            string messageMenu = String.Format(
                @"Hello, welcome to Liron and Chen garage! 
Please make a choice: 

1 - Insert vehicle to the garage.
2 - Present all license numbers of all vehicles in the garage.
3 - Change status of a vehicle in the garage.
4 - Inflate tires of vehicle in the garage.
5 - Refuel a vehicle.
6 - Charge a vehicle.
7 - Present all the details of a vehicle.
8 - Exit.
");
            Console.WriteLine(messageMenu);
        }

        public static void PrintExit()
        {
            Console.WriteLine("Thank you! There is no warranty for the repair. Hope you have another malfunction in the vehicle and we will see you again!");
        }
        
        public static void HandleUserChoice(Garage i_Garage, int i_UserChoice)
        {
            switch ((eMenuChoice)i_UserChoice)
            {
                case eMenuChoice.InsertVehicleToTheGarage:
                    InsertVehicleToGarage(i_Garage);
                    break;
                case eMenuChoice.PresentVehicleLicenseNumber:
                    ShowAllLicenseNumbers(i_Garage);
                    break;
                case eMenuChoice.ChangeVehicleStatus:
                    ChangeVehicleStatus(i_Garage);
                    break;
                case eMenuChoice.PumbAirWheelsToMax:
                    AddAirToWheels(i_Garage);
                    break;
                case eMenuChoice.RefuleVehicle:
                    AddGasToVehicle(i_Garage);
                    break;
                case eMenuChoice.ChargeVehicle:
                    AddElectricityToCar(i_Garage);
                    break;
                case eMenuChoice.PresentInformationOfvehicle:
                    PrintCarByLicenseNumber(i_Garage);
                    break;
            }
        }

        public static void InsertVehicleToGarage(Garage i_Garage)
        {
            bool askAgain = true;
            while (askAgain == true)
            {
                try
                {
                    Console.WriteLine(@"Please enter the vehicle license number.");
                    string licenseNumber = Console.ReadLine();
                    CheckValidityLicenseNumber(licenseNumber);

                    if (i_Garage.IsVehicleExistByLicense(licenseNumber) == true)
                    {
                        i_Garage.ChangeStatusOfVehicle(licenseNumber, VehicleDetails.eVehicleStatus.Repair);
                        Console.WriteLine("The vehicle already exists in the garage so it has been moved to repair.");
                    }
                    else
                    {
                        InsertNewVehicleToGarage(i_Garage, licenseNumber);

                    }

                    askAgain = false;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Please try again.");
                }
            }
        }

        public static void InsertNewVehicleToGarage(Garage i_Garage, string i_LicenseNumber)
        {
            Vehicle vehicle = CreateNewVehicle(i_LicenseNumber);
            string vehicleOwnerName = GetVehicleOwnerName();
            string vehicleOwnerPhone = GetVehicleOwnerPhone();

            VehicleDetails newVehicleInGarage = VehicleManufacturing.CreateVehicleWithFullInformation(vehicle, vehicleOwnerName, vehicleOwnerPhone);
            i_Garage.AddVehicleToGarage(newVehicleInGarage);
        }

        public static string GetVehicleOwnerPhone()
        {
            bool isValidPhoneNumberInput = false;
            string ownerPhone = null;

            while (!isValidPhoneNumberInput)
            {
                Console.WriteLine("Enter the vehicle owner's phone");
                ownerPhone = Console.ReadLine();


                isValidPhoneNumberInput = isValidOwnerPhone(ownerPhone);
                if(!isValidPhoneNumberInput)
                {
                    Console.WriteLine("Wrong format please try again.");
                }
            }

            return ownerPhone;
        }

        private static bool isValidOwnerPhone(string i_userPhoneNumberInput)
        {
            long phoneInInt;
            bool isValidOwnerPhone = false;

            if (i_userPhoneNumberInput.Length == 10 && long.TryParse(i_userPhoneNumberInput, out phoneInInt))
            {
                isValidOwnerPhone = true;
            }
            return isValidOwnerPhone;

        }

        public static string GetVehicleOwnerName()
        {
            bool isValidOwnerNameInput = false;
            string ownerName=String.Empty;

            while (!isValidOwnerNameInput)
            {
                Console.WriteLine("Enter vehicle owner's name");
                ownerName = Console.ReadLine();
                isValidOwnerNameInput = isValidOwnerName(ownerName);

                if (!isValidOwnerNameInput)
                {
                    Console.WriteLine("Invalid input! Please enter a name that contains only letters and its length is not less than 2.");
                }
            }
            return ownerName;
        }

        private static bool isValidOwnerName(string i_userNameInput)
        {
            bool isValidOwnerName = true;
            if (i_userNameInput.Length >= 2)
            {
                for (int i = 0; i < i_userNameInput.Length; i++)
                {
                    if (char.IsDigit(i_userNameInput[i]))
                    {
                        isValidOwnerName = false;
                    }
                }
            }
            else
            {
                isValidOwnerName = false;
            }

            return isValidOwnerName;
        }
        public static Vehicle CreateNewVehicle(string i_LicenseNumber)
        {
            int energyType = 1;
            int vehicleType=0;
            string modelOfVehicle;
            float currentAmountOfEnergySource;
            float currAirPressure;
            string wheelsManufacturer;
            List<Wheel> vehicleWheels;
            Vehicle newVehicle;
            Dictionary<string, Type> dynamicParams = new Dictionary<string, Type>();
            Dictionary<string, object> dynamicObject = new Dictionary<string, object>();

            Console.WriteLine("Please enter the vehicle type");
            vehicleType = getUserEnumInput(typeof(VehicleManufacturing.eVehicleType));
            if (vehicleType == 1 || vehicleType == 2)
            {
                Console.WriteLine("Please enter the vehicle energy source:");
                energyType = getUserEnumInput(typeof(VehicleManufacturing.eEngineType));
            }

            Console.WriteLine("Please enter the model of the vehicle");
            modelOfVehicle = Console.ReadLine();
            currentAmountOfEnergySource = GetCurrentAmountOfEnergySource((VehicleManufacturing.eVehicleType)vehicleType,
                (VehicleManufacturing.eEngineType)energyType);

            Engine power = VehicleManufacturing.CreateEnergySource(
                (VehicleManufacturing.eVehicleType)vehicleType,
                (VehicleManufacturing.eEngineType)energyType,
                currentAmountOfEnergySource);

            Console.WriteLine("Please enter the manufacturer of the wheels");
            wheelsManufacturer = Console.ReadLine();

            currAirPressure = GetAirPressure((VehicleManufacturing.eVehicleType)vehicleType,
                (VehicleManufacturing.eEngineType)energyType);

            vehicleWheels = VehicleManufacturing.CreateWheels(
                (VehicleManufacturing.eVehicleType)vehicleType,
                wheelsManufacturer,
                currAirPressure);

            VehicleManufacturing.GetRequiredVehicleParameters(vehicleType, dynamicParams);
            getDynamicParametersDataFromUser(dynamicParams, dynamicObject);
           newVehicle = VehicleManufacturing.CreateVehicle((VehicleManufacturing.eVehicleType)vehicleType, modelOfVehicle, i_LicenseNumber, power, vehicleWheels, dynamicObject);

            return newVehicle;
        }

        public static float GetCurrentAmountOfEnergySource(VehicleManufacturing.eVehicleType i_VehicleType, VehicleManufacturing.eEngineType i_EnergyType)
        {
            float inputInFloat = 0;

            
                Console.WriteLine(@"How much power is your vehicle left? ");
                string inputFromUser = Console.ReadLine();

            float.TryParse(inputFromUser, out inputInFloat);
                
                    /*if (inputInFloat <= maxPower)
                    {
                        askAgain = false;
                    }

                    else
                    {
                        Console.WriteLine("The value you entered is too big please try again");
                    }
                }*/


            return inputInFloat;
        }

        public static float GetAirPressure(VehicleManufacturing.eVehicleType i_VehicleType, VehicleManufacturing.eEngineType i_EnergyType)
        {
            bool isValidAirPressure = false;
            float inputInFloat=0;

            while (!isValidAirPressure) {
                Console.WriteLine("Please enter current air pressure");
                string inputFromUser = Console.ReadLine();
                if(float.TryParse(inputFromUser, out inputInFloat))
                {
                    isValidAirPressure = true;
                }
                else
                {
                    Console.WriteLine("Please enter only numbers");
                }

            }
            return inputInFloat;
        }

        public static void ChangeVehicleStatus(Garage i_Garage)
        {
            bool askAgain = false;

            while (askAgain == false)
            {
                try
                {
                    Console.WriteLine("Please enter license number");
                    string licenseNumber = Console.ReadLine();
                    CheckValidityLicenseNumber(licenseNumber);
                    Console.WriteLine(
                        @"Please enter the new vehicle status:
1 - Repair
2 - Fixed
3 - Paid");
                    string newStatus = Console.ReadLine();
                    //PrintLine();
                    CheckValidityStatus(newStatus);
                    if (i_Garage.IsVehicleExistByLicense(licenseNumber))
                    {
                        i_Garage.ChangeStatusOfVehicle(
                            licenseNumber,
                            (VehicleDetails.eVehicleStatus)int.Parse(newStatus));
                        Console.WriteLine("The status has changed successfully");
                    }
                    else
                    {
                        PrintTheLicenseDoseNotExist();
                    }

                    askAgain = true;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Please try again.");
                }
            }
        }

        public static void CheckValidityLicenseNumber(string i_LicenseNumber)
        {
            if (!(i_LicenseNumber.All(char.IsNumber)))
            {
                throw new FormatException("Invalid format of license number");
            }
        }

        public static void CheckValidityStatus(string i_NewStatus)
        {
            if (i_NewStatus != "1" && i_NewStatus != "2" && i_NewStatus != "3")
            {
                throw new FormatException("Invalid status of vehicle");
            }
        }

        public static void AddAirToWheels(Garage i_Garage)
        {
            bool askAgain = false;
            while (askAgain == false)
            {
                try
                {
                    Console.WriteLine("Please enter license number");
                    string licenseNumber = Console.ReadLine();
                    CheckValidityLicenseNumber(licenseNumber);
                    if (i_Garage.IsVehicleExistByLicense(licenseNumber))
                    {
                        i_Garage.inflationAirToMaximum(licenseNumber);
                        Console.WriteLine($@"The Wheels are full till the end: {i_Garage.VehiclesInGarage[licenseNumber].Vehicle.ListOfWheels[0].CurrentAirPressure}");

                    }
                    else
                    {
                        PrintTheLicenseDoseNotExist();
                    }

                    askAgain = true;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Please try again.");
                }
            }
        }

        public static void PrintTheLicenseDoseNotExist()
        {
            Console.WriteLine("Sorry, the license does not exist. You are returned to the main menu");
        }

        public static void ShowAllLicenseNumbers(Garage i_Garage)
        {
            Console.WriteLine(
                @"Do you want to filter the license numbers by the status of condition?
1 - for yes
2 - for no");
            string isFilter = Console.ReadLine();
            if (isFilter == "1")
            {
                ShowAllLicenseNumbersFilter(i_Garage);
            }
            else
            {
                ShowAllLicenseNumbersByRealOrder(i_Garage);
            }
        }

        public static void ShowAllLicenseNumbersFilter(Garage i_Garage)
        {
            int howManyCars = 0;
            Console.WriteLine(
                @"Please enter the filter for show license numbers:");
            int filterType = getUserEnumInput(typeof(VehicleDetails.eVehicleStatus));
            Console.WriteLine();

            foreach (KeyValuePair<string, VehicleDetails> entry in i_Garage.VehiclesInGarage)
            {
                if ((VehicleDetails.eVehicleStatus)filterType == entry.Value.VehicleStatus)
                {
                    Console.WriteLine(entry.Key);
                    howManyCars++;
                }
            }

            if (howManyCars == 0)
            {
                Console.WriteLine("There are no vehicles by this filter in the garage");
            }
        }

        public static void ShowAllLicenseNumbersByRealOrder(Garage i_Garage)
        {
            if (i_Garage.VehiclesInGarage.Count == 0)
            {
                Console.WriteLine("There are no vehicles in the garage currently, please try later");
            }
            else
            {
                foreach (KeyValuePair<string, VehicleDetails> entry in i_Garage.VehiclesInGarage)
                {
                    Console.WriteLine(entry.Key);
                }
            }
        }

        public static void PrintCarByLicenseNumber(Garage i_Garage)
        {
            bool askAgain = false;
            while (askAgain == false)
            {
                try
                {
                    Console.WriteLine("Please enter license number");
                    string licenseNumber = Console.ReadLine();
                    CheckValidityLicenseNumber(licenseNumber);

                    if (i_Garage.IsVehicleExistByLicense(licenseNumber))
                    {
                        string informationOfVehicle = i_Garage.PrintSpecificVehicle(licenseNumber);
                        Console.WriteLine(informationOfVehicle);
                    }
                    else
                    {
                        PrintTheLicenseDoseNotExist();
                    }

                    askAgain = true;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Please try again.");
                }
            }
        }

        public static void AddGasToVehicle(Garage i_Garage)
        {
            bool askAgain = false;
            while (askAgain == false)
            {
                try
                {
                    Console.WriteLine("Please enter license number");
                    string licenseNumber = Console.ReadLine();
                    CheckValidityLicenseNumber(licenseNumber);

                    if (i_Garage.IsVehicleExistByLicense(licenseNumber))
                    {
                        i_Garage.IsVehicleCanBeFueled(licenseNumber);
                        Console.WriteLine("Please enter the liter of gas to add:");
                        string amountOfGas = Console.ReadLine();
                        Console.WriteLine(
                            @"Please enter the type of gas to add:");
                        int typeOfGas = getUserEnumInput(typeof(FuelEngine.eFuelType));

                        i_Garage.VehicleRefueling(licenseNumber, (FuelEngine.eFuelType)typeOfGas, float.Parse(amountOfGas));
                        Console.WriteLine($@"The vehicle has been fueled till: { i_Garage.VehiclesInGarage[licenseNumber].Vehicle.EngineType.CurrentEnginePower}");

                    }
                    else
                    {
                        PrintTheLicenseDoseNotExist();
                    }
                    askAgain = true;
                }


                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Please try again.");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Please try again.");
                }
                /*catch (ValueOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Please try again.");
                }*/

            }
        }
        public static void AddElectricityToCar(Garage i_Garage)
        {
            bool askAgain = false;
            while (askAgain == false)
            {
                try
                {
                    Console.WriteLine("Please enter license number");
                    string licenseNumber = Console.ReadLine();
                    CheckValidityLicenseNumber(licenseNumber);

                    if (i_Garage.IsVehicleExistByLicense(licenseNumber))
                    {
                        i_Garage.IsVehicleCanBeCharged(licenseNumber);
                        Console.WriteLine("Please enter the amount of electricity to add:");
                        string amountOfElectricity = Console.ReadLine();

                        i_Garage.VehicleCharging(licenseNumber, float.Parse(amountOfElectricity));
                        Console.WriteLine($@"The vehicle has been charged till: { i_Garage.VehiclesInGarage[licenseNumber].Vehicle.EngineType.CurrentEnginePower}");

                    }
                    else
                    {
                        PrintTheLicenseDoseNotExist();
                    }

                    askAgain = true;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Please try again.");
                }
                /*catch (ValueOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Please try again.");
                }*/
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Please try again.");
                }
            }
        }


        private static void getDynamicParametersDataFromUser(Dictionary<string, Type> i_VehicleDynamicTypes, Dictionary<string, object> io_VehicleDynamicObjects)
        {
            foreach (string currentParam in i_VehicleDynamicTypes.Keys)
            {
                if (i_VehicleDynamicTypes[currentParam] == typeof(bool))
                {
                    getBoolParameter(currentParam, io_VehicleDynamicObjects);
                }
                else if (i_VehicleDynamicTypes[currentParam] == typeof(int))
                {
                    getIntParameter(currentParam, io_VehicleDynamicObjects);
                }
                else if (i_VehicleDynamicTypes[currentParam] == typeof(float))
                {
                    getFloatParameter(currentParam, io_VehicleDynamicObjects);
                }
                else if (i_VehicleDynamicTypes[currentParam].IsEnum)
                {
                    getEnumParameter(currentParam, io_VehicleDynamicObjects, i_VehicleDynamicTypes[currentParam]);
                }
            }
        }


        // $G$ CSS-013 (-3) Bad variable name (should be in the form of: i_CamelCase).
        private static void getIntParameter(string i_CurrentParam, Dictionary<string, object> i_DynamicOjects)
        {
            Console.WriteLine($@"Please enter {i_CurrentParam} as a positive number");
            i_DynamicOjects.Add(i_CurrentParam, getIntInput());
        }


        private static void getFloatParameter(string i_CurrentParam, Dictionary<string, object> io_DynamicObjects)
        {
            Console.WriteLine($@"Please enter {i_CurrentParam} as a positive number");
            io_DynamicObjects.Add(i_CurrentParam, getFloatInput());
        }

        private static int getUserEnumInput(Type i_Enum)
        {
            Array valuesOfEnum = Enum.GetValues(i_Enum);
            string indexOfEnum;
            int numberOfEnum = valuesOfEnum.Length;
            bool isParseNumber;
            bool isValidInput = false;
            int indexOfEnumValue = 0;
            int currentValueIndex = 1;

            while (!isValidInput)
            {
                currentValueIndex = 1;
                Console.WriteLine("Choose an option from the menu below: ");
                foreach (object enumValue in valuesOfEnum)
                {
                    Console.WriteLine(string.Format("({0})-{1}", currentValueIndex, enumValue));
                    currentValueIndex++;
                }

                indexOfEnum = Console.ReadLine();
                isParseNumber = int.TryParse(indexOfEnum, out indexOfEnumValue);
                if (indexOfEnumValue <= numberOfEnum && isParseNumber && indexOfEnumValue >= 1)
                {
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid Choice,please enter option that exist in the menu.");
                }
            }

            return indexOfEnumValue;
        }


        private static void getEnumParameter(string i_EnumParam, Dictionary<string, object> io_DynamicParams, Type i_EnumType)
        {
            Console.WriteLine($@"Please enter { i_EnumParam}.");
            io_DynamicParams.Add(i_EnumParam, getUserEnumInput(i_EnumType));
        }


        private static void getBoolParameter(string i_BoolParam, Dictionary<string, object> io_DynamicParams)
        {
            string userInput;
            int userInputAsInt;
            bool isValidBool = false;
            Console.WriteLine($@"Choose {i_BoolParam}? Press 1 for 'True' ,press 2 for 'False'.");

            while (isValidBool == false)
            {
                userInput = Console.ReadLine();
                bool success = int.TryParse(userInput, out userInputAsInt);
                if (success && (userInputAsInt == 1 || userInputAsInt == 2))
                {
                    bool boolValue = (userInputAsInt == 1);
                    io_DynamicParams.Add(i_BoolParam, boolValue);
                    isValidBool = true;
                }
                else
                {
                    Console.WriteLine("Not a boolean option , please try again ");
                }
            }
        }

        private static float getFloatInput()
        {
            string inputOfuser;
            bool parsingWorked = false;
            float inputOfUserFloat = 0;

            while (parsingWorked == false)
            {

                inputOfuser = Console.ReadLine();
                parsingWorked = float.TryParse(inputOfuser, out inputOfUserFloat);

                if (parsingWorked == true)
                {
                    if (inputOfUserFloat < 0)
                    {
                        Console.WriteLine("Please only enter positive numbers, try again");
                        parsingWorked = false;
                    }
                }
                else
                {

                    Console.WriteLine("Wrong format, please try again");

                }
            }
            return inputOfUserFloat;
        }

        private static int getIntInput()
        {
            string inputOfuser;
            bool parsingWorked = false;
            int inputOfUserInt = 0;

            while (parsingWorked == false)
            {

                inputOfuser = Console.ReadLine();
                parsingWorked = int.TryParse(inputOfuser, out inputOfUserInt);

                if (parsingWorked == true)
                {
                    if (inputOfUserInt < 0)
                    {
                        Console.WriteLine("Please only enter positive numbers, try again");
                        parsingWorked = false;
                    }
                }
                else
                {
                    Console.WriteLine("Wrong format, please try again");
                }
            }
            return inputOfUserInt;
        }
    }
}
