using System;
using System.Linq;

namespace Username_and_Password_Verifier
{
    internal class UserAccount
    {
        // Data fields.
        private string mUsername;

        private string mPassword;
        private bool mIsValid;

        // Validation Criteria
        private static readonly char[] UpAlpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

        private static readonly char[] LoAlpha = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        private static readonly char[] Symbols = "!@#$%^*_=+.?-".ToCharArray();
        private static readonly char[] Numbers = "0123456789".ToCharArray();

        // Constructors.
        public UserAccount()
        {
            mUsername = "user1";
            mPassword = "P@ssword1";
            //mIsValid = true;
        }

        // Chain Invocation using This keyword.
        public UserAccount(string username, string password) : this()
        {
            mUsername = username;
            mPassword = password;
        }

        public UserAccount(string username, string password, bool validInput) : this(username, password)
        {
            Username = username;
            Password = password;
            IsValid = validInput;
        }

        // Properties.
        public string Username
        {
            get { return mUsername; }
            set
            {
                if (ValidateUsername(value) && value != null)
                {
                    mUsername = value;
                }
            }
        }

        public string Password
        {
            get { return mPassword; }
            set
            {
                if (ValidatePassword(value) == true && value != null)
                {
                    mPassword = value;
                }
            }
        }

        public bool IsValid
        {
            get { return mIsValid; }
            set
            {
                if (mPassword.Contains(Username, StringComparison.OrdinalIgnoreCase))
                {
                    throw new Exception("Invalid password format!\nThe password cannot contain your username.\n");
                }
                else
                    mIsValid = value;
            }
        }

        private static bool ValidateUsername(string username)
        {
            string UnScoreOnly = "!@#$%^*=+.?-";
            bool validUsername;

            char[] validSyms = new char['\0'];

            validSyms = UnScoreOnly.ToCharArray();

            validUsername = ValidNameLength(username);
            if (username.IndexOfAny(validSyms) != -1)
                throw new Exception("Invalid username format!\nThe username may use only the characters: Aa-Zz, 0-9, -_ .\n");
            else
                validUsername = true;

            return validUsername;
        }

        // Compare each character in password to criteria level.
        private static bool ValidatePassword(string password)
        {
            bool validPassword;
            if (password == null) { throw new ArgumentNullException("No password or Default is a security risk."); }
            else
                validPassword = ValidPassLength(password);
            validPassword = HasLetter(password);
            validPassword = HasNumber(password);
            validPassword = HasSymbol(password);

            return validPassword;
        }

        private static bool ValidNameLength(string username)
        {
            const int MIN = 3;
            const int MAX = 15;
            bool validLength;

            if (username.Length >= MIN && username.Length <= MAX)
                validLength = true;
            else
                throw new Exception("Invalid username format!\nThe username must between 3 to 15 characters.\n");

            return validLength;
        }

        private static bool ValidPassLength(string password)
        {
            const int MIN = 8;
            const int MAX = 80;
            bool validLength;

            if (password.Length >= MIN && password.Length <= MAX)
                validLength = true;
            else
                throw new Exception("Invalid username format!\nThe password must between 8 to 80 characters.\n");

            foreach (char ch in password)
            {
                if (char.IsWhiteSpace(ch))
                    throw new Exception("Invalid password format!\nThe password cannot contain spaces.");
            }

            return validLength;
        }

        private static bool HasLetter(string password)
        {
            bool hasLetter;
            //password.Equals(password.ToLower());

            if (hasLetter = password.IndexOfAny(UpAlpha) != -1
                && password.IndexOfAny(LoAlpha) != -1)
            { hasLetter = true; }
            else
                throw new Exception("Invalid password format!\nThe password must contain at least:" +
                                   "\n\nOne lowercase letter.\nOne uppercase letter.\n");

            return hasLetter;
        }

        private static bool HasNumber(string password)
        {
            bool hasNumber;

            if (password.IndexOfAny(Numbers) != 1) { hasNumber = true; }
            else
                throw new Exception("Invalid password format!\nThe password must contain at least: One digit.");

            return hasNumber;
        }

        private static bool HasSymbol(string password)
        {
            bool hasSymbol;

            if (password.IndexOfAny(Symbols) != -1) { hasSymbol = true; }
            else
                throw new Exception("Invalid password format!\nThe password must contain at least:" +
                                   "\nOne special character (! @ # $ % ^ * _ = + . ? -).\n");

            return hasSymbol;
        }

        public override string ToString()
        {
            return "Username: " + mUsername + ", Password: " + mPassword;
        }
    }

    public static class StringExtension
    {
        public static bool Contains(this string username, string password, StringComparison comparison)
        {
            return username.IndexOf(password, comparison) != -1;
        }
    }
}