using System;
using System.Text.RegularExpressions;

namespace MvvmAspire.Helpers
{
    public class Validator
    {
        public static bool IsEmailValid(string email)         {             Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");             Match match = regex.Match(email);             return match.Success;         }     }
}
