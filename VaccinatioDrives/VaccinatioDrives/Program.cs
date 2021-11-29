using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccinatioDrives
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creating empty list.....

            List<Vaccination> vaccines = new List<Vaccination>();

            //Entering default Data.....

            Vaccination vaccination1 = new Vaccination("1", 1, new DateTime(2021, 11, 10));
            vaccines.Add(vaccination1);
            Beneficiary benifitiry1 = new Beneficiary("Samynathan", 8764093784, "Tirupur", 39, "1", vaccines);
            vaccines.Remove(vaccination1);

            Vaccination vaccination2 = new Vaccination("1", 1, new DateTime(2021, 11, 03));
            Vaccination vaccination21 = new Vaccination("1", 2, new DateTime(2021, 12, 03));
            vaccines.Add(vaccination2);
            vaccines.Add(vaccination21);
            Beneficiary benifitiry2 = new Beneficiary("Raman", 9896754382, "Vellore", 24, "1", vaccines);
            vaccines.Remove(vaccination2);
            vaccines.Remove(vaccination21);

            //Vaccination vaccination3 = new Vaccination(" ", 0, new DateTime());
            //vaccines.Add(vaccination3);
            Beneficiary benifitiry3 = new Beneficiary("Sarasvathy", 8394683984, "Chennai", 28, "2",vaccines);
            //vaccines.Remove(vaccination3);

            //Adding all the Object into single list...

            List<Beneficiary> benifitiriesList = new List<Beneficiary>();
            benifitiriesList.Add(benifitiry1);
            benifitiriesList.Add(benifitiry2);
            benifitiriesList.Add(benifitiry3);

            Console.WriteLine("*************************************************");
            Console.WriteLine("Vaccination Drive ");
            Console.WriteLine("*************************************************");
            string askToContinue = "";

            //Continuous iteration of the loop....
            //Untill the beneficiary tells No.....

            do
            {
            mains:
                Console.WriteLine("1. Beneficiary Registration. \n2. Vaccination \n3. Exit");
                Console.Write("Enter your choice : ");
                int userChoice = int.Parse(Console.ReadLine());
                switch (userChoice)
                {
                    case 1:
                        //Beneficiary registration details....

                        Console.WriteLine("************************************************");
                        Console.WriteLine("Beneficiary Registration");
                        Console.WriteLine("************************************************");
                        Console.WriteLine("The Beneficiary Details: ");
                        Console.Write("Enter the Beneficiaries name: ");
                        string citizenName = Console.ReadLine();
                        Console.Write("Enter the Beneficiaries Age: ");
                        int citizenAge = int.Parse(Console.ReadLine());
                        Console.WriteLine("Choose the corresponding Gender '1' if Male, '2' if Female, '3' if Others.");
                        Console.Write("Enter the Beneficiaries Gender: ");
                        string citizenGender = Console.ReadLine();
                        Console.Write("Enter the Beneficiaries Mobile number: ");
                        long citizennumber = long.Parse(Console.ReadLine());
                        Console.Write("Enter the Beneficiaries City: ");
                        string citizencity = Console.ReadLine();                      
                        Beneficiary newBeneficiarydetail = new Beneficiary(citizenName, citizennumber, citizencity, citizenAge, citizenGender, vaccines);
                        benifitiriesList.Add(newBeneficiarydetail);
                        Console.WriteLine("The Registration Details are created with the Reference number: {0}", newBeneficiarydetail.ReferenceNumber);
                        Console.WriteLine("************************************************");
                        break;

                    case 2:
                        //Get the details for vaccination.....
                        
                        Console.WriteLine("Vaccination");
                    back:
                        Console.Write("Enter the Reference Number: ");
                        int referenceNumber = int.Parse(Console.ReadLine());
                    front:
                        Vaccination vaccine;
                        bool trueOrFalse = false;
                        foreach (Beneficiary benifitiry in benifitiriesList)
                        { 
                            //Check if the reference number is correct or Not....

                            if (benifitiry.ReferenceNumber == referenceNumber)
                            {
                                
                                Console.WriteLine("What operation do you want to perform:");
                                Console.WriteLine("1. Take Vaccination\n2. Vaccination Histroy\n3. Next Due Date\n4. Exits");
                                Console.Write("Enter the choice: ");
                                int existingBeneficiaryChoice = int.Parse(Console.ReadLine());
                                switch (existingBeneficiaryChoice)
                                {
                                    case 1:
                                        //For taking the Vaccination....

                                        Console.WriteLine("************************************************");
                                        Console.WriteLine("Take Vaccination");
                                        Console.WriteLine("************************************************");
                                        int totalVaccine = benifitiry.VaccinationDetail.Count;
                                        Console.WriteLine(totalVaccine);
                                        
                                        //check the whether he vaccined...

                                        if(totalVaccine == 0)
                                        {
                                            Console.Write("Select any one of the type 1 if Covaxin and 2 if Covid Shield: ");
                                            string vaccineType = Console.ReadLine();
                                            DateTime CurrenyDate = DateTime.Now.Date;
                                            int dosagenumber = totalVaccine+1;
                                            vaccine = new Vaccination(vaccineType, dosagenumber, CurrenyDate);
                                            vaccines.Add(vaccine);
                                            benifitiry.VaccinationDetail = vaccines;
                                            

                                        }
                                        else if(totalVaccine == 1)
                                        {
                                            bool choice = false;
                                            Console.Write("Select any one of the type 1 if Covaxin and 2 if Covid Shield: ");
                                            string vaccineType = Console.ReadLine();
                                            foreach(Vaccination dosageType in benifitiry.VaccinationDetail)
                                            {
                                                if(dosageType.DosageType == vaccineType)
                                                {
                                                    choice = true;
                                                }
                                            }
                                            if(choice == true)
                                            {
                                                DateTime CurrenyDate = DateTime.Now.Date;
                                                int dosagenumber = totalVaccine++;
                                                vaccine = new Vaccination(vaccineType, dosagenumber, CurrenyDate);
                                                vaccines.Add(vaccine);
                                                benifitiry.VaccinationDetail = vaccines;
                                                
                                            }
                                            else
                                            {
                                                Console.WriteLine("You have Completed two Dosage Successfully....");
                                            }
                                            
                                        }
                                        Console.WriteLine("************************************************");
                                        goto front;
                                        break;
                                    case 2:
                                        //Display the histroy of the vaccination....

                                        Console.WriteLine("************************************************");
                                        Console.WriteLine("Vaccination Histroy");
                                        Console.WriteLine("************************************************");
                                        foreach (Vaccination vaccines1 in benifitiry.VaccinationDetail)
                                        {
                                            benifitiry.DisplayVaccinationDetails(vaccines1.DosageDate, vaccines1.DosageNumber, vaccines1.DosageType);
                                        }
                                        goto front;
                                        break;
                                    case 3:
                                        //Display the next due Date......
                                        Console.WriteLine("************************************************");
                                        Console.WriteLine("Next Due Date");
                                        Console.WriteLine("************************************************");
                                        int countValue = benifitiry.VaccinationDetail.Count;
                                        if(countValue == 0)
                                        {
                                            Console.WriteLine("Get the Vaccine imediately");
                                        }
                                        else if(countValue == 1)
                                        {
                                            foreach (Vaccination vaccines1 in benifitiry.VaccinationDetail)
                                            {
                                                benifitiry.NextDueDate(vaccines1.DosageDate);
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("You have Completed vaccination successfully");
                                        }
                                       goto front;
                                        break;
                                        
                                    case 4:
                                        //Go back to Main menu.....

                                        Console.WriteLine("************ Go Back to HomePage ************");
                                        goto mains;
                                        break;
                                }
                                trueOrFalse = true;
                            }
                        }
                        //display if the reference number is incorrect....

                        if (trueOrFalse == false)
                        {
                            Console.WriteLine("The reference number that you enter is incorrect..");
                            goto back;
                        }
                        break;
                    case 3:
                        //Exits the Application..... 

                        Console.WriteLine("************ Exits ************");
                        goto final;
                        break;
                }
                   
                do
                {
                    Console.Write("Do you want to continue (yes/no)? ");
                    askToContinue = Console.ReadLine().ToLower();
                    if (askToContinue != "yes" && askToContinue != "no")
                    {
                        Console.Write("Enter the correct choice: ");
                        askToContinue = Console.ReadLine();
                    }
                } while (askToContinue != "yes" && askToContinue != "no");
            } while (askToContinue == "yes");
            final:
            Console.ReadLine();
        }
    }
}
