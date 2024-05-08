using System.Reflection;
using ValidatorLibraly;
namespace ValidatorLibralyTests
{
    [TestClass]
    public class ValidatorTests
    {
        private LoginValidator _loginValidator;
        private PasswordValidator _passwordValidator;

        [TestInitialize]
        public void Initialize()
        {
            _loginValidator = new LoginValidator();
            _passwordValidator = new PasswordValidator();
        }

        [TestMethod]
        [DataRow("johnDoe", true)]
        [DataRow("jD123", false)]
        public void TestLoginValidation(string login, bool expected)
        {
            bool result = _loginValidator.Validate(login);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(GetTestCases), DynamicDataSourceType.Method)]
        public void TestPasswordValidation(string password, bool expected)
        {
            bool result = _passwordValidator.Validate(password);
            Assert.AreEqual(expected, result);
        }

        public static IEnumerable<object[]> GetTestCases()
        {
            yield return new object[] { "Passw0rd!", true };
            yield return new object[] { "password", false };
        }

        [TestMethod]
        [DataRow("User123", true)]   // Правильный логин
        [DataRow("123456", false)]    // Некорректный логин (только цифры)
        [DataRow("User", false)]      // Некорректный логин (длина менее 6 символов)
        public void TestLoginValidation_2(string login, bool expected)
        {
            var validator = new LoginValidator();
            Assert.AreEqual(expected, validator.Validate(login));
        }

        [TestMethod]
        [DynamicData(nameof(GetPasswordTestData), DynamicDataSourceType.Method)]
        public void TestPasswordValidation_2(string password, bool expected)
        {
            var validator = new PasswordValidator();
            Assert.AreEqual(expected, validator.Validate(password));
        }

        public static IEnumerable<object[]> GetPasswordTestData()
        {
            yield return new object[] { "P@ssw0rd", true };     // Правильный пароль
            yield return new object[] { "password", false };    // Некорректный пароль (без спец. знака)
            yield return new object[] { "P@ssword", false };    // Некорректный пароль (без цифры)
        }
    }
}