using System;

namespace Garage3.Data.Exceptions
{
    public class GarageException : Exception
    {
        public GarageException()
        {
        }

        public GarageException(string message) : base(message)
        {
        }
    }
    
    public class MemberExistsInDbException : GarageException
    {
        
    }

    public class NotEmptyException : GarageException
    {
        public NotEmptyException(string message) : base(message + " field is empty")
        {
        }
    }

    public class CheckoutException : GarageException
    {
        public CheckoutException(string message) : base(message + " this vehicle has been checked out")
        {
        }
    }
    
    public class InvalidPersonalNumberException : GarageException
    {
        public string InvalidPersonalNumber { get; }

        public InvalidPersonalNumberException(string number) : base(number + " is invalid")
        {
            InvalidPersonalNumber = number;
        }
    }
}