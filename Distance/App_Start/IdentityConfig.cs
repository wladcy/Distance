using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Distance.Models;
using System.Net.Mail;
using System.Web.Configuration;
using System.Net;
using Distance.App_Start;
using System.IO.Ports;
using System.Threading;

namespace Distance
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            var fromAddress = new MailAddress(WebConfigurationManager.AppSettings["mailAccount"], "Company Cars Distance");
            var toAddress = new MailAddress(message.Destination);
            string fromPassword = WebConfigurationManager.AppSettings["mailPassword"];
            string subject = message.Subject;
            string body = message.Body;

            var smtp = new SmtpClient
            {
                Host = WebConfigurationManager.AppSettings["host"],
                Port = int.Parse(WebConfigurationManager.AppSettings["port"]),
                EnableSsl = bool.Parse(WebConfigurationManager.AppSettings["enableSsl"]),
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var mail = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                mail.IsBodyHtml = true;
                smtp.Send(mail);
            }
            return Task.FromResult(0);
        }
    }

    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            //port name depends on modem port
            SerialPort sp = new SerialPort("COM7", 19200);
            Thread.Sleep(1000);
            sp.Open();
            Thread.Sleep(1000);
            sp.Write("AT+CMGF=1\r\n");
            Thread.Sleep(1000);
            sp.Write("AT+CMGS=\"" + message.Destination + "\"\r\n");
            sp.Write(message.Body + "\x1A");
            Thread.Sleep(1000);
            sp.Close();
            return Task.FromResult(0);
        }
    }

    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context) 
        {
            var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<ApplicationDbContext>()));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<ApplicationUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = PasswordIdentityConfig.REQUIREDLENGTH,
                RequireNonLetterOrDigit = PasswordIdentityConfig.REQUIRENONLETTERORDIGITIDENTITY,
                RequireDigit = PasswordIdentityConfig.REQUIREDIGITIDENTITY,
                RequireLowercase = PasswordIdentityConfig.REQUIRELOWERCASEIDENTITY,
                RequireUppercase = PasswordIdentityConfig.REQUIREUPPERCASEIDENTITY,
            };

            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromHours(24);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug it in here.
            manager.RegisterTwoFactorProvider("Telefon", new PhoneNumberTokenProvider<ApplicationUser>
            {
                MessageFormat = "Twoj kod dostepu: {0}"
            });
            manager.RegisterTwoFactorProvider("Email", new EmailTokenProvider<ApplicationUser>
            {
                Subject = "Kod dostępu",
                BodyFormat = "Twój kod dostępu: {0}"
            });
            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = 
                    new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }

    // Configure the application sign-in manager which is used in this application.
    public class ApplicationSignInManager : SignInManager<ApplicationUser, string>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
        {
            return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
        }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        }
    }
}
