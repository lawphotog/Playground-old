using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace CustomModelBinder.Models
{
    public class PersonModelBinder: IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var type = "employee";
            switch(type)
            {
                case "employee":
                    var employee = new Employee();
                    employee.Name = GetValue<string>(bindingContext, "Name");
                    employee.DateOfBirth = GetValue<string>(bindingContext, "DateOfBirth");
                    employee.DepartmentId = GetValue<string>(bindingContext, "DepartmentId");
                    employee.EmployeeId = GetValue<string>(bindingContext, "EmployeeId");
                    return employee;
                    
                case "customer":
                    var customer = new Customer();
                    customer.Name = GetValue<string>(bindingContext, "Name");
                    return customer;                    
            }

            return null;
        }

        private T GetValue<T>(ModelBindingContext bindingContext, string key)
        {
            ValueProviderResult valueResult;
            valueResult = bindingContext.ValueProvider.GetValue(key);
            bindingContext.ModelState.SetModelValue(key, valueResult);       
            return (T)valueResult.ConvertTo(typeof(T));
        }        
    }
}