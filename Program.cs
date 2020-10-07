using System;
using System.Text.RegularExpressions;


namespace UserRegistrationProblem
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
            validateUser.ValidateName(firstName,lastName);
            Console.WriteLine("Enter email id");
            string emailid = Console.ReadLine();
            validateUser.ValidateEmail(emailid);
            Console.WriteLine("Enter the mobile number");
            string phoneNo = Console.ReadLine();
            validateUser.ValidateMobileNumber(phoneNo);
            Console.WriteLine("Enter the password");
            string passWord = Console.ReadLine();
            validateUser.ValidatePassword(passWord);
            Console.ReadKey();
        }
    }

    //Class to define methods to validate different data provided by the users
    public class ValidateUser {
        public string firstName;
        public string lastName;
        public string email;
        public string phoneNo;
        public string passWord;

        //Method to validate the name
        public void ValidateName(string firstName, string lastName) {
            Regex regex = new Regex("^[A-Z]{1}[a-z]{2,}");
            Boolean flag1 = regex.IsMatch(firstName);
            Boolean flag2 = regex.IsMatch(lastName);
            if (flag1 == true && flag2 == true)
            {
                Console.WriteLine("Valid firstname and lastname");
            }
            else if (flag1 == true && flag2 == false)
            {
                Console.WriteLine("Valid firstname but invalid lastname");
            }
            else if (flag1 == false && flag2 == true)
            {
                Console.WriteLine("Invalid firstname but valid lastname");
            }
            else {
                Console.WriteLine("Invalid firstname and lastname");
            }
        }

        //Method to validate the email id
        public void ValidateEmail(string email) {
            Regex reg = new Regex("^[a-zA-Z0-9]+([+-_.][a-zA-Z0-9]+)*[@][a-zA-Z0-9]+[.][a-zA-Z]+([.][a-zA-Z]{2})*$");
            if (reg.IsMatch(email))
            {
                Console.WriteLine("Valid emailid");
            }
            else {
                Console.WriteLine("Invalid emailid");
            }
        }

        //Method to validate the mobile number
        public void ValidateMobileNumber(string phoneNo) {
            Regex rgx = new Regex("^[0-9]{2}[ ][0-9]{10}");
            if (rgx.IsMatch(phoneNo))
            {
                Console.WriteLine("Valid mobile number");
            }
            else {
                Console.WriteLine("Invalid mobile number");
            }
        }

        //Method to validate password
        public void ValidatePassword(string passWord) {
            Regex rx = new Regex("^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?!.*[^0-9a-zA-Z].*[^0-9a-zA-Z]).{8,}$");
            if (rx.IsMatch(passWord))
            {
                Console.WriteLine("Valid password");
            }
            else {
                Console.WriteLine("Invalid password");
            }
        }

    }
}
