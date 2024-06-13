using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Observers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserValidator _userValidator;
        private readonly IUserRepository _userRepository;
        private readonly IObservable _observable;

        public UserController(IUserValidator userValidator, IUserRepository userRepository, IObservable observable)
        {
            _userValidator = userValidator;
            _userRepository = userRepository;
            _observable = observable;
        }

        [HttpPost("validate")]
        public IActionResult Validate(User user)
        {
            if (!_userValidator.Validate(user))
            {
                return Forbid();
            }

            return Ok();
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_userValidator.Validate(user))
            {
                return BadRequest("Invalid user data.");
            }

            _userRepository.CreateUser(user);
            return Ok("User created successfully.");
        }

        [HttpPost("registerObserver")]
        public IActionResult RegisterObserver([FromBody] IUserObserver observer)
        {
            _observable.Attach(observer);
            return Ok();
        }
    }
}
