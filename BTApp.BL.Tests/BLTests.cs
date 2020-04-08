using BTApp.DataAccess.DAL;
using BTApp.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BTApp.BL.Tests
{
    public class BLTests
    {

        private readonly Mock<IRepository> _repoMock = new Mock<IRepository>();
        private readonly IPasswordBL _passwordBL;
        public BLTests()
        {
            _passwordBL = new PasswordBL(_repoMock.Object);
        }

        [Fact]
        public void CheckValidity_GoodInputData_ReturnsValidPassword()
        {
            // Arrange
            DateTime date = DateTime.Now;
            UserPassword userPassword = new UserPassword { UserID = 1, Password = "4ORMN", ValideFrom= date, ValideTo = date.AddSeconds(30) };
            _repoMock.Setup(x => x.GetUserPassword(userPassword.Id, userPassword.Password)).Returns(userPassword);

            // Act
            string validity = _passwordBL.CheckValidity(userPassword.Id, userPassword.Password);

            // Assert
            Assert.Equal("Password Is valid", validity);
        }

        [Fact]
        public void CheckValidity_GoodInputData_ReturnsPasswordExpired()
        {
            // Arrange
            DateTime date = DateTime.Now.AddDays(-1);
            UserPassword userPassword = new UserPassword { UserID = 1, Password = "4ORMN", ValideFrom = date, ValideTo = date.AddSeconds(30) };
            _repoMock.Setup(x => x.GetUserPassword(userPassword.Id, userPassword.Password)).Returns(userPassword);

            // Act
            string validity = _passwordBL.CheckValidity(userPassword.Id, userPassword.Password);

            // Assert
            Assert.Equal("Password expired", validity);
        }

        [Fact]
        public void CheckValidity_BadInputData_ThrowsNullReferenceException()
        {
            // Arrange
            DateTime date = DateTime.Now.AddDays(-1);
            UserPassword userPassword = new UserPassword { UserID = 16666, Password = "4ORMN", ValideFrom = date, ValideTo = date.AddSeconds(30) };
            // Assert
            Assert.Throws<NullReferenceException>(() => _passwordBL.CheckValidity(userPassword.Id, userPassword.Password));
        }
       
    }
}
