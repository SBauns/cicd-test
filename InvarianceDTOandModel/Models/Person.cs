using System.Text.RegularExpressions;
using ValidateTheNameModelBinding.DomainPrimitives;

namespace ValidateTheNameModelBinding.Models
{
    public class Person
    {
        private FirstName firstName;
        private LastName lastName;

        public Person(FirstName firstName, LastName lastName)
        {
            IsNotNull(firstName);
            IsNotNull(lastName);

            //isFirstNameValid(firstName);
            //isLastNameValid(lastName);

            this.firstName = firstName; 
            this.lastName = lastName;
        }

        private void IsNotNull(object _object)
        {
            if (_object == null)
            {
                throw new Exception("Object was null");
            }
        }

        private void isFirstNameValid(string name)
        {
            isNameNull(name);
            isNameToLong(name);
            isNameToShort(name);
            isNameAlphabetic(name);
        }
        private void isLastNameValid(string name)
        {
            isNameNull(name);
            isNameToLong(name);
            isNameToShort(name);
            isNameAlphabetic(name);
        }

        private bool isNameNull(string name)
        {
            if (name == null)
            {
                throw new Exception("Name is not allowed to be null");
            }
            return true;
        }
        private bool isNameToLong(string name)
        {
            if (name.Length > 20)
            {
                throw new Exception("Name is too long");
            }
            return true;
        }

        private bool isNameToShort(string name)
        {
            if (name.Length < 2)
            {
                throw new Exception("Name is too Short");
            }
            return true;
        }
        private bool isNameAlphabetic(string name)
        {
            string pattern = @"^[a-zA-ZæøåÆØÅ]+$";

            bool isMatch = Regex.IsMatch(name, pattern);

            if (!isMatch)
            {
                throw new Exception("Name has invalid characters");
            }
            return true;
        }
    }
}
