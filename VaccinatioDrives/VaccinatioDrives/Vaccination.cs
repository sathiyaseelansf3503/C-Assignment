using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccinatioDrives
{
    class Vaccination
    {
        //Creating Properties.....

        public string DosageType;
        public int DosageNumber;
        public DateTime DosageDate;

        //Creating a parameterized constructor.....

        public Vaccination(string dosageType, int dosageNumber, DateTime dosageDate)
        {
            this.DosageTypes = dosageType;
            this.DosageNumber = dosageNumber;
            this.DosageDate = dosageDate.Date;
        }
        
        //Display the ennum ....
        public string DosageTypes
        {
            get
            {
                return DosageType;
            }
            set
            {
                if (value == "1")
                {
                    DosageType = TypeOfDosage.Covaxin.ToString();
                }
                else if (value == "2")
                {
                    DosageType = TypeOfDosage.CovidShield.ToString();
                }

            }
        }
    }
}
//Dispaly the Enum.....
public enum TypeOfDosage
{
    Covaxin = 1,
    CovidShield = 2,

}