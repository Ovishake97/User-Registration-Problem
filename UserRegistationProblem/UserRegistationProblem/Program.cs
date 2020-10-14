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
            string[] sample = {"abc@yahoo.com","abc-100@yahoo.com","abc.100@yahoo.com","abc11@abc.com","abc-100@abc.net","abc.100@abc.com.au",
            "abc@1.com","abc@gmail.com.com","abc@.com",".abc@abc.com","abc123@com","abc@.com.com","abc()@gmail.com","abc@%*.com",
            "abc..2002@gmail.com","abc.@gmail.com","abc@gmail.com.1a"};
         Console.WriteLine(validateUser.EmailSamples(sample));
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

        public string ValidateName (string firstName, string lastName)
        {
            Regex regex = new Regex("^[A-Z]{1}[a-z]{2,}");
            
            Boolean flag1 = regex.IsMatch(firstName);
            Boolean flag2 = regex.IsMatch(lastName);

            try
            {
                if (firstName.Equals(string.Empty) || lastName.Equals(string.Empty))
                {

                    throw new UserRegistrationCustomException(UserRegistrationCustomException.ExceptionType.EMPTY_EXCEPTION, "Names cannot be empty");
                }
                if (flag1 == true && flag2 == true)
                {
                    return "Valid firstname and lastname";
                }

                else
                {
                    throw new UserRegistrationCustomException(UserRegistrationCustomException.ExceptionType.INVALID_EXCEPTION, "Invalid firstname and lastname");
                }
            }
            catch (NullReferenceException)
            {
                throw new UserRegistrationCustomException(UserRegistrationCustomException.ExceptionType.NULL_EXCEPTION, "Null reference");
            }


        }

        //Method to validate the email id
        public string ValidateEmail(string email)
        {
            Regex reg = new Regex("^[a-zA-Z0-9]+([+-_.][a-zA-Z0-9]+)*[@][a-zA-Z0-9]+[.][a-zA-Z]+([.][a-zA-Z]{2})*$");

            try
            {
                if (email.Equals(string.Empty))
                {
                    throw new UserRegistrationCustomException(UserRegistrationCustomException.ExceptionType.EMPTY_EXCEPTION, "Email cannot be empty");
                }
                if (reg.IsMatch(email))
                {
                    return "Valid emailid";
                }

                else
                {
                    throw new UserRegistrationCustomException(UserRegistrationCustomException.ExceptionType.INVALID_EXCEPTION, "Invalid email id");
                }
            }
            catch (NullReferenceException) {
                throw new UserRegistrationCustomException(UserRegistrationCustomException.ExceptionType.NULL_EXCEPTION, "Null reference");
            }
            
        }

        //Method to validate the mobile number
        public string ValidateMobileNumber(string phoneNo)
        {
            Regex rgx = new Regex("^[0-9]{2}[ ][0-9]{10}");

            try
            {
                if (phoneNo.Equals(string.Empty))
                {
                    throw new UserRegistrationCustomException(UserRegistrationCustomException.ExceptionType.EMPTY_EXCEPTION, "Mobile number cannot be empty");
                }
                if (rgx.IsMatch(phoneNo))
                {
                    return "Valid mobile number";
                }

                else
                {
                    throw new UserRegistrationCustomException(UserRegistrationCustomException.ExceptionType.INVALID_EXCEPTION, "Invalid mobile number");
                }

            }
            catch (NullReferenceException) {
                throw new UserRegistrationCustomException(UserRegistrationCustomException.ExceptionType.NULL_EXCEPTION, "Null reference");
            }
        }

        //Method to validate password
        public string ValidatePassword(string passWord)
        {
            Regex rx = new Regex("^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?!.*[^0-9a-zA-Z].*[^0-9a-zA-Z]).{8,}$");

            try
            {
                if (passWord.Equals(string.Empty))
                {
                    throw new UserRegistrationCustomException(UserRegistrationCustomException.ExceptionType.EMPTY_EXCEPTION, "Password cannot be empty");
                }
                if (rx.IsMatch(passWord))
                {
                    return "Valid password";
                }

                else
                {
                    throw new UserRegistrationCustomException(UserRegistrationCustomException.ExceptionType.INVALID_EXCEPTION, "Invalid password");
                }
            }
            catch (NullReferenceException)
            {
                throw new UserRegistrationCustomException(UserRegistrationCustomException.ExceptionType.NULL_EXCEPTION, "Null reference");
            }

        }

        public string EmailSamples(string[] samples)
        {
            Regex regx = new Regex("^[a-zA-Z0-9]+([+-_.][a-zA-Z0-9]+)*[@][a-zA-Z0-9]+[.][a-zA-Z]+([.][a-zA-Z]{2})*$");
            int valid = 0, invalid = 0;
            foreach (string data in samples)
            {
                if (regx.IsMatch(data))
                {
                    Console.WriteLine($"Valid- " + data);
                    valid++;
                }
                else
                {
                    Console.WriteLine($"Invalid- " + data);
                    invalid++;
                }
            }
            return "Hence, valid email ids are " + valid + " and invalid email ids are " + invalid;
        }
    }

    

    public class UserRegistrationCustomException : Exception {

        public enum ExceptionType { 
        EMPTY_EXCEPTION,
        INVALID_EXCEPTION,
        NULL_EXCEPTION
        }
        public readonly ExceptionType type;

        public UserRegistrationCustomException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }

    }
}
