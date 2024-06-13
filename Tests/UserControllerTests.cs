using Domain.Entities;
using Domain.Interfaces;
using Moq;
using API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Observers.Interfaces;

namespace Tests
{
    public class UserControllerTests
    {
        private readonly UserController _controller;
        private readonly Mock<IUserValidator> _mockValidator;
        private readonly Mock<IUserRepository> _mockRepository;
        private readonly Mock<IObservable> _mockObservable;
        private readonly Mock<IUserObserver> _mockUserObserver;

        public UserControllerTests()
        {
            _mockValidator = new Mock<IUserValidator>();
            _mockRepository = new Mock<IUserRepository>();
            _mockObservable = new Mock<IObservable>();
            _mockUserObserver = new Mock<IUserObserver>();
            _controller = new UserController(_mockValidator.Object, _mockRepository.Object, _mockObservable.Object);
        }

        [Fact]
        public void Validate_ValidUser_ReturnsOk()
        {
            var user = new User { Email = "test@example.com", Name = "Test User", Password = "Password123" };
            _mockValidator.Setup(v => v.Validate(user)).Returns(true);

            var result = _controller.Validate(user);

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void Validate_InvalidUser_ReturnsForbid()
        {
            var user = new User { Email = "invalid-email", Name = "Test User", Password = "Password123" };
            _mockValidator.Setup(v => v.Validate(user)).Returns(false);

            var result = _controller.Validate(user);

            Assert.IsType<ForbidResult>(result);
        }

        [Fact]
        public void Create_ValidUser_ReturnsOk()
        {
            var user = new User { Email = "test@example.com", Name = "Test User", Password = "Password123" };
            _mockValidator.Setup(v => v.Validate(user)).Returns(true);

            var result = _controller.Create(user);

            Assert.IsType<OkObjectResult>(result);
            Assert.Equal("User created successfully.", (result as OkObjectResult).Value);
        }

        [Fact]
        public void Create_InvalidUser_ReturnsBadRequest()
        {
            var user = new User { Email = "invalid-email", Name = "Test User", Password = "Password123" };
            _mockValidator.Setup(v => v.Validate(user)).Returns(false);

            var result = _controller.Create(user);

            Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Invalid user data.", (result as BadRequestObjectResult).Value);
        }

        [Fact]
        public void RegisterObserver_ValidObserver_AttachesObserver()
        {
            var result = _controller.RegisterObserver(_mockUserObserver.Object);

            _mockObservable.Verify(o => o.Attach(_mockUserObserver.Object), Times.Once);
            Assert.IsType<OkResult>(result);
        }
    }
}
