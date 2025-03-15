using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentInformationSystem.BussinessLogic.ISevices;
using StudentInformationSystem.BussinessLogic.Services;
using StudentInformationSystem.Infrastructure.Entities;
using StudentInformationSystem.Infrastructure.Repository;
using StudentInformationSystem.Infrastructure.Repository.Interfaces;
using StudentInformationSystem.Utilities.CommonMethod;
using StudentInformationSystem.Utilities.Dto;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using static StudentInformationSystem.Utilities.Constrant.Constant;

namespace StudentInformationSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IStudent _student;
        private readonly ISessionManagement _session;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly TokenService _tokenService;
        private readonly IEmailService _emailService;

        public AccountController(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            //RoleManager<IdentityRole> roleManager
            IStudent student, ISessionManagement session, IHttpContextAccessor httpContextAccessor, TokenService tokenService, IEmailService emailService
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            //_roleManager = roleManager;
            _student = student;
            _session = session;
            _httpContextAccessor = httpContextAccessor;
            _tokenService = tokenService;
            _emailService = emailService;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto model)
        {
            
            if (ModelState.IsValid)
            {
                var data = await _student.GetEntityWithSpec(x => x.CollegeID.Equals(model.CollegeId) && x.Password.Equals(model.Password));
                if (data != null)
                {
                    // Handle successful login
                    _session.StoreSession("CollegeID", data.CollegeID);
                    _session.StoreSession("StudentId", data.Id.ToString());
                    _session.StoreSession("Email", data.Email);
                    _session.StoreSession("UserName", data.UserName);
                    _session.StoreSession("DepartmentId", data.DepartmentId.ToString());
                    return RedirectToAction(nameof(DashboardController.Index), "Dashboard");

                    ////////////////////////////////////////////////////////////////////////////////////////////
                    //var result = await _signInManager.PasswordSignInAsync(data.Email, model.Password,false, lockoutOnFailure: false);
                    //if (result.Succeeded)
                    //{
                    //    // Handle successful login
                    //    _session.StoreSession("CollegeID", data.CollegeID);
                    //    _session.StoreSession("StudentId", data.Id.ToString());
                    //    _session.StoreSession("Email", data.Email);
                    //    _session.StoreSession("UserName", data.UserName);
                    //    _session.StoreSession("DepartmentId", data.DepartmentId.ToString());
                    //    //_session.StoreSession("DepartmentId", data.DepartmentId);
                    //    return RedirectToAction(nameof(DashboardController.Index), "Dashboard");

                    //}
                    //if (result.RequiresTwoFactor)
                    //{
                    //    // Handle two-factor authentication case
                    //}
                    //if (result.IsLockedOut)
                    //{
                    //    // Handle lockout scenario
                    //}
                    //else
                    //{
                    //    // Handle failure
                    //    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    //    return View(model);
                    //}
                }
                else 
                {
                    // Handle failure
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }
            }
            // If we got this far, something failed, redisplay form
            return View(model);
        }

        public IActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordDto forgetPasswordDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var User = await _student.GetEntityWithSpec(x => x.Email == forgetPasswordDto.Email);

                    if (User != null)
                    {
                        string resetToken = _tokenService.GenerateResetToken(forgetPasswordDto.Email, out DateTime expirationTime);
                        User.ForgetPasswordRequestOn = expirationTime;
                        _student.Update(User);
                        _student.Complete();

                        // Generate reset link with token
                        var request = _httpContextAccessor.HttpContext.Request;
                        string resetPasswordLink = $"{request.Scheme}://{request.Host}/Account/UpdatePassword?token={resetToken}";

                        // Get email template
                        string emailBody = _emailService.GetEmailTemplate(EmailTemplate.ForgotPasswordEmail, out string imageUrl);
                        if (!string.IsNullOrEmpty(emailBody))
                        {
                            // Customize the HTML email body
                            emailBody = emailBody.Replace("[insert first name]", User.UserName);
                            emailBody = emailBody.Replace("[INSERT PASSWORD CHANGE LINK]", resetPasswordLink);

                            // Send email
                            await _emailService.SendEmailAsync(User.Email, "Password Reset Request for Your Student Account", emailBody, User.Id, imageUrl);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return View();
        }

        public async Task<IActionResult> UpdatePassword(string token)
        {
            if (!string.IsNullOrEmpty(token))
            {
                UpdatePasswordDto request = new UpdatePasswordDto();
                string Message = ValidateUpdatePasswordView(token, request);
                if (Message == "Success")
                {
                    return View(request);
                }
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePassword(UpdatePasswordDto request)
        {
            try
            {
                string Message = await UpdatePasswordMethod(request);
                if (Message == "Success")
                {
                    TempData["Notification"] = "Password updated successfully.";
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    TempData["Error"] = "Error updating password: " + Message;
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = "An error occurred: " + ex.Message;
            }
            return View(request);
        }

        private string ValidateUpdatePasswordView(string token, UpdatePasswordDto request)
        {
            string Message = string.Empty;
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jsonToken = tokenHandler.ReadToken(token) as JwtSecurityToken;
                if (jsonToken != null)
                {
                    var expirationClaim = jsonToken.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Expiration)?.Value;
                    var emailClaim = jsonToken.Claims.FirstOrDefault(claim => claim.Type == "email")?.Value;

                    if (expirationClaim != null && emailClaim != null && DateTime.TryParse(expirationClaim, out DateTime expirationTime))
                    {
                        if (DateTime.Now <= expirationTime)
                        {
                            request.ResetToken = token;
                            request.EmailAddress = emailClaim;
                            Message = "Success";
                        }
                        else
                        {
                            Message = "Token has expired.";
                        }
                    }
                    else
                    {
                        Message = "Invalid or missing expiration claim.";
                    }
                }
                else
                {
                    Message = "Invalid reset token.";
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
            return Message;
        }

        public async Task<string> UpdatePasswordMethod(UpdatePasswordDto requestDto)
        {
            string Message = string.Empty;
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jsonToken = tokenHandler.ReadToken(requestDto.ResetToken) as JwtSecurityToken;
                if (jsonToken != null)
                {
                    var emailClaim = jsonToken.Claims.FirstOrDefault(claim => claim.Type == "email")?.Value;
                    if (!string.IsNullOrEmpty(emailClaim))
                    {
                        requestDto.EmailAddress = emailClaim;
                        if (_tokenService.ValidateResetToken(requestDto.ResetToken, requestDto.EmailAddress, out DateTime expirationTime))
                        {
                            // Check if the token is still valid (not expired)
                            if (DateTime.Now <= expirationTime)
                            {
                                // Reset token is valid, update the user's password
                                var user = await _student.GetEntityWithSpec(x => x.Email == requestDto.EmailAddress);

                                if (user != null)
                                {
                                    // Reset password logic...
                                    user.Password = requestDto.NewPassword;
                                    user.ForgetPasswordRequestOn = null;
                                    _student.Update(user);  
                                    _student.Complete();
                                    Message = "Success";
                                }
                                else
                                {
                                    Message = "Invalid User.";
                                }
                            }
                            else
                            {
                                Message = "Reset token has expired.";
                            }
                        }
                        else
                        {
                            Message = "Invalid reset token.";
                        }
                    }
                    else
                    {
                        Message = "Invalid token claim.";
                    }
                }
                else
                {
                    Message = "Invalid reset token.";
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
            return Message;
        }
    }
}
