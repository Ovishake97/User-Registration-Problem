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
            Console.ReadKey();
        }
    }

    public class ValidateUser {
        public string firstName;
        public string lastName;
        public string email;
        public double phoneNo;
        public string passWord;

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

    }
}
