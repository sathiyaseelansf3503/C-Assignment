using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccinatioDrives
{
    class Beneficiary
    {
        //Creating a list field.....

        private List<Vaccination> _vaccinationDetail = new List<Vaccination>();

        //Creating Properties....

        private static int _referenceNumber = 1001;
        public string BenifitiryName { get; set; }
        public long PhoneNumber { get; set; }
        public string CityName { get; set; }
        public int BenifitiryAge { get; set; }
        public string Gender { get; set; }
        public List<Vaccination> VaccinationDetail
        {
            get
            {
                return _vaccinationDetail;
            }
            set
            {
                _vaccinationDetail = value;
            }
        }
        public int ReferenceNumber { get; set; }

        //Creating a parameterized Constructor....

        public Beneficiary(string benifitiryName, long mobileNumber, string cityName, int Age, string gender, List<Vaccination> beneficiariesDetails)
        {
            this.BenifitiryName = benifitiryName;
            this.PhoneNumber = mobileNumber;
            this.CityName = cityName;
            this.BenifitiryAge = Age;
            this.Genders = gender;
            this.ReferenceNumber = _referenceNumber++;
            this.VaccinationDetail = new List<Vaccination>(beneficiariesDetails);
        }
        
        //Display the the total number of Vaccination details....
        public void DisplayVaccinationDetails(DateTime dosagedate,int dosageNumber,string dosageType)
        {
            Console.WriteLine("Dosage Type : {0}", dosageType);
            Console.WriteLine("Dosage Date : {0}", dosagedate.Date);
            Console.WriteLine("Number of Dosage : {0}", dosageNumber);
            Console.WriteLine("************************************************");
        } 

        //Calculating the next due date....
        public void NextDueDate(DateTime dosageDate)
        {
            DateTime newDateForDosage = dosageDate.AddDays(30);
            Console.WriteLine("The Next Dosage Date is {0}", newDateForDosage);
            Console.WriteLine("************************************************");
        }
        
        //Display the ennum of genders.....
        public string Genders
        {
            get
            {
                return Gender;
            }
            set
            {
                if (value == "1")
                {
                    Gender = GenderName.Male.ToString();
                }
                else if (value == "2")
                {
                    Gender = GenderName.Female.ToString();
                }
                else if (value == "3")
                {
                    Gender = GenderName.Others.ToString();
                }

                else
                {
                    Gender = "Enter the valide input";
                }
            }
        }


    }
}

//Create the Enum for gender...
public enum GenderName
{
    Male = 1,
    Female = 2,
    Others = 3
}