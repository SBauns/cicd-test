using System.Text.RegularExpressions;

namespace ValidateTheNameModelBinding.DomainPrimitives
{
    public class FirstName
    {
        private string value;

        public FirstName(string name)
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
            if(name == null){
                throw new ArgumentNullException("Name must be filled out");
            }
            if (name.Length < 2)
            {
                throw new ArgumentOutOfRangeException("First name is too short");
            }

            if (name.Length > 20)
            {
                throw new ArgumentOutOfRangeException("First name is too long");
            }

            string pattern = @"^[a-zA-ZÀ-ÖØ-öø-ÿ]+([ '-][a-zA-ZÀ-ÖØ-öø-ÿ]+)*$";

            if (!Regex.IsMatch(name, pattern))
            {
                throw new InvalidDataException("First name must be alphabetic with a few exact special signs allowed");
            }
        }
    }
}
