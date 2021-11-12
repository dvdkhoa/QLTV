using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLTV.AppMVC.Services
{
    public class AppIdentityErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError ConcurrencyFailure()
        {
            return base.ConcurrencyFailure();
        }

        public override IdentityError DefaultError()
        {
            return base.DefaultError();
        }

        public override IdentityError DuplicateEmail(string email)
        {
            var err = base.DuplicateEmail(email);

            return new IdentityError() { Code = err.Code, Description = $"Email {email} đã tồn tại" };
        }

        public override IdentityError DuplicateRoleName(string role)
        {
            var err = base.DuplicateRoleName(role);

            return new IdentityError() { Code = err.Code, Description = $"Vai trò {role} đã tồn tại!" };
        }

        public override IdentityError DuplicateUserName(string userName)
        {
            var err = base.DuplicateUserName(userName);

            return new IdentityError() { Code = err.Code, Description = $"Tên đăng nhập {userName} đã tồn tại" };
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override IdentityError InvalidEmail(string email)
        {
            return base.InvalidEmail(email);
        }

        public override IdentityError InvalidRoleName(string role)
        {
            return base.InvalidRoleName(role);
        }

        public override IdentityError InvalidToken()
        {
            return base.InvalidToken();
        }

        public override IdentityError InvalidUserName(string userName)
        {
            return base.InvalidUserName(userName);
        }

        public override IdentityError LoginAlreadyAssociated()
        {
            return base.LoginAlreadyAssociated();
        }

        public override IdentityError PasswordMismatch()
        {
            return base.PasswordMismatch();
        }

        public override IdentityError PasswordRequiresDigit()
        {
            var err = base.PasswordRequiresDigit();
            return new IdentityError { Code = err.Code, Description = "Mật khẩu phải chứa ít nhất 1 số" };        }

        public override IdentityError PasswordRequiresLower()
        {
            var err = base.PasswordRequiresLower();
            return new IdentityError { Code = err.Code, Description = "Mật khẩu phải chứa ít nhất 1 ký tự thường (a-z)" };
        }

        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            var err = base.PasswordRequiresNonAlphanumeric();

            return new IdentityError { Code = err.Code, Description = "Mật khẩu phải chứa ít nhất 1 ký tự đặc biệt" };
        }

        public override IdentityError PasswordRequiresUniqueChars(int uniqueChars)
        {
            return base.PasswordRequiresUniqueChars(uniqueChars);
        }

        public override IdentityError PasswordRequiresUpper()
        {
            var err = base.PasswordRequiresUpper();
            return new IdentityError { Code = err.Code, Description = "Mật khẩu phải chứa ít nhất 1 ký tự in Hoa(A-Z)" };
        }

        public override IdentityError PasswordTooShort(int length)
        {
            return base.PasswordTooShort(length);
        }

        public override IdentityError RecoveryCodeRedemptionFailed()
        {
            return base.RecoveryCodeRedemptionFailed();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override IdentityError UserAlreadyHasPassword()
        {
            return base.UserAlreadyHasPassword();
        }

        public override IdentityError UserAlreadyInRole(string role)
        {
            return base.UserAlreadyInRole(role);
        }

        public override IdentityError UserLockoutNotEnabled()
        {
            return base.UserLockoutNotEnabled();
        }

        public override IdentityError UserNotInRole(string role)
        {
            return base.UserNotInRole(role);
        }
    }
}
