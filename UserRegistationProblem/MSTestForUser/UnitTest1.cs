using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserRegistationProblem;

namespace MSTestForUser
{
    [TestClass]
    public class UnitTest1
    {
       
        UserRegistationProblem.ValidateUser validate = new ValidateUser();
        [TestMethod]
        public void TestName()
        {
            //Act
            string actual = validate.ValidateName("Manash", "Das");
            //Assert
            Assert.AreEqual("Valid firstname and lastname", actual);
        }
        [TestMethod]
        public void TestEmail() {

            //Act
            string actual = validate.ValidateEmail("abc.xy@bl.co.in");
            //Asert     
            Assert.AreEqual("Valid emailid", actual);
        }
        [TestMethod]
        public void TestMobileNumber() {

            //Act
            string actual = validate.ValidateMobileNumber("91 8890822345");
            //Assert
            Assert.AreEqual("Valid mobile number", actual);
        }
        [TestMethod]
        public void TestPassword() {
            //Act
            string actual = validate.ValidatePassword("Aikjh89&okd");
            //Assert
            Assert.AreEqual("Valid password", actual);
        }
    }
}
