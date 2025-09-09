using server.Core.Interfaces.Services;
using System.Text.RegularExpressions;

namespace server.Services;

public class PasswordService : IPasswordService
{
    public string CheckPassword(string password)
    {
        var passwordWarning = string.Empty;
        if (string.IsNullOrEmpty(password))
        {
            passwordWarning = "The password must not be empty.";
            return passwordWarning;
        }

        var warnings = new List<string>();

        if (password.Length < 8)
            warnings.Add("• At least 8 characters");

        if (!Regex.IsMatch(password, "[a-zа-я]"))
            warnings.Add("• At least one letter");

        if (!Regex.IsMatch(password, "[A-ZА-Я]"))
            warnings.Add("• At least one capital letter");

        if (!Regex.IsMatch(password, "[!@#$%^&*()_+\\-=\\[\\]{};':\"\\\\|,.<>\\/?]"))
            warnings.Add("• At least one special character (!@#$%^&* etc.)");

        if (!Regex.IsMatch(password, "[0-9]"))
            warnings.Add("• At least one digit");

        if (warnings.Count == 0)
        {
            return string.Empty;
        }
        else
        {
            passwordWarning = "The password must be:\n" + string.Join("\n", warnings);
            return passwordWarning;
        }
    }
}
