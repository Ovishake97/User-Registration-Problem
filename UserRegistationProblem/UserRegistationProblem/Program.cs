using System;
using System.Text.RegularExpressions;

namespace UserRegistationProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            ValidateUser validateUser = new ValidateUser();
            Console.WriteLine("Enter the firstname");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter the lastname");
            string lastName = Console.ReadLine();
            Console.WriteLine(validateUser.ValidateName(firstName, lastName));
            Console.WriteLine("Enter email");
            string email = Console.ReadLine();
           Console.WriteLine(validateUser.ValidateEmail(email));
            Console.WriteLine("Enter phone no");
            string phoneNo = Console.ReadLine();
            Console.WriteLine(validateUser.ValidateMobileNumber(phoneNo));
            Console.WriteLine("Enter password");
            string passWord = Console.ReadLine();
           Console.WriteLine(validateUser.ValidatePassword(passWord));
            Console.ReadKey();
        }
    }

    public class ValidateUser
    {
        public string firstName;
        public string lastName;
        public string email;
        public double phoneNo;
        public string passWord;

        public string ValidateName(string firstName, string lastName)
        {
            Regex regex = new Regex("^[A-Z]{1}[a-z]{2,}");
            string printMessage=null;
            Boolean flag1 = regex.IsMatch(firstName);
            Boolean flag2 = regex.IsMatch(lastName);
            if (flag1 == true && flag2 == true)
            {
                printMessage="Valid firstname and lastname";
            }
            else if (flag1 == true && flag2 == false)
            {
                printMessage= "Valid firstname but invalid lastname";
            }
            else if (flag1 == false && flag2 == true)
            {
                printMessage = "Invalid firstname but valid lastname";
            }
            else
            {
                printMessage= "Invalid firstname and lastname";
            }
            return printMessage;
        }

        //Method to validate the email id
        public string ValidateEmail(string email)
        {
            Regex reg = new Regex("^[a-zA-Z0-9]+([+-_.][a-zA-Z0-9]+)*[@][a-zA-Z0-9]+[.][a-zA-Z]+([.][a-zA-Z]{2})*$");
            
            if (reg.IsMatch(email))
            {
                return "Valid emailid";
            }
            else
            {
                return "Invalid emailid";
            }
        }

        //Method to validate the mobile number
        public string ValidateMobileNumber(string phoneNo)
        {
            Regex rgx = new Regex("^[0-9]{2}[ ][0-9]{10}");
            if (rgx.IsMatch(phoneNo))
            {
                return "Valid mobile number";
            }
            else
            {
                return "Invalid mobile number";
            }
        }

        //Method to validate password
        public string ValidatePassword(string passWord)
        {
            Regex rx = new Regex("^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?!.*[^0-9a-zA-Z].*[^0-9a-zA-Z]).{8,}$");
            if (rx.IsMatch(passWord))
            {
                return "Valid password";
            }
            else
            {
                return "Invalid password";
            }
        }

    }
}
