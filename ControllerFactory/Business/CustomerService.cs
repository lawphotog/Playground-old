using System;
namespace ControllerFactory.Business
{
    public interface CustomerService
    {
        System.Collections.Generic.IEnumerable<Customer> Get();
    }
}
