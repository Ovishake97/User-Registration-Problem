using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Runtime.CompilerServices;
using UserRegistationProblem;

namespace MSTestForUser
{
    [TestClass]
    public class UnitTest1
    {
        private string actual;
        readonly UserRegistationProblem.ValidateUser validate = new ValidateUser();
        [TestMethod]
        public void TestName()
        {

            string firstName = "899", lastName = "jfjf ";
            //Act
            try
            {
                actual = validate.ValidateName(firstName, lastName);
            }

            //Assert
            catch (UserRegistrationCustomException exception)
            {
                Assert.AreEqual("Invalid firstname and lastname", exception.Message);
            }
        }
        [TestMethod]
        public void TestEmail() {
            try
            {
                //Act
                string actual = validate.ValidateEmail("num@00");
            }
            catch (UserRegistrationCustomException exception)
            {
                //Asert     
                Assert.AreEqual("Invalid email id", exception.Message);
            }
        }
        [TestMethod]
        public void TestMobileNumber() {

            try
            { //Act
                string actual = validate.ValidateMobileNumber("99jjjn");
            }
            //Assert
            catch (UserRegistrationCustomException exception)
            {
                Assert.AreEqual("Invalid mobile number", exception.Message);
            }
        }
        [TestMethod]
        public void TestPassword() {
            //Act
            try
            {
                string actual = validate.ValidatePassword("Aikjh89&okd");
            }
            //Assert
            catch (NullReferenceException exception)
            {
                Assert.AreEqual("Invalid password", exception.Message);
            }
        }
        [TestMethod]
        public void TestMultipleEmails() { 
            //Arrange
            string[] sample= {"abc@yahoo.com","abc-100@yahoo.com","abc.100@yahoo.com","abc11@abc.com","abc-100@abc.net","abc.100@abc.com.au",
            "abc@1.com","abc@gmail.com.com","abc@.com",".abc@abc.com","abc123@com","abc@.com.com","abc()@gmail.com","abc@%*.com",
            "abc..2002@gmail.com","abc.@gmail.com","abc@gmail.com.1a"};
            //Act
            string actual = validate.EmailSamples(sample);
            //Assert
            Assert.AreEqual("Hence, valid email ids are 7 and invalid email ids are 10", actual);
        }
    }
}
