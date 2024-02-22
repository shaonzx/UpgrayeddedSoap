using System.ServiceModel;
using UpgrayeddedSoap.Helpers;
using UpgrayeddedSoap.Models;

namespace UpgrayeddedSoap.SoapCalls
{
    [ServiceContract]
    public interface ICustomerService
    {
        [OperationContract]
        string GetCustomer();

        [OperationContract]
        string SetCustomer(string xmlCustomer);
    }

    public class CustomerService : ICustomerService
    {
        public string GetCustomer()
        {
            Customer aCustomer = new Customer
            {
                Name = "Abul",
                Age = 29,
                Address = "Unknown"
            };

            string serializedString = CandyDataFormatter.Serialize(aCustomer);

            return serializedString;
        }

        public string SetCustomer(string xmlCustomer)
        {
            var customer = CandyDataFormatter.Deserialize<Customer>(xmlCustomer);

            return $"Information for {customer.Name} received";
        }
    }
}
