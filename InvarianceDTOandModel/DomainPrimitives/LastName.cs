using System.Text.RegularExpressions;

namespace ValidateTheNameModelBinding.DomainPrimitives
{
    public class LastName
    {
        private string value;

        public LastName(string name)
        {
            validateName(name);
            value = name;
        }

        public string GetValue()
        {
            return value;
        }

        private void validateName(string name)
        {
            if (name.Length < 2)
            {
                throw new Exception("Last name is too short");
            }

            if (name.Length > 20)
            {
                throw new Exception("Last name is too long");
            }

            string pattern = @"^[a-zA-ZÀ-ÖØ-öø-ÿ]+([ '-][a-zA-ZÀ-ÖØ-öø-ÿ]+)*$";

            if (!Regex.IsMatch(name, pattern))
            {
                throw new Exception("Last name must be alphabetic with a few exact special signs allowed");
            }
        }
    }
}
