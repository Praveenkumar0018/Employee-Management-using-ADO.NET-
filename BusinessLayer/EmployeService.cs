using DataAccessLayer;
using System;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class EmployeeService
    {
        private readonly EmployeeRepository _repository;

        public EmployeeService()
        {
            _repository = new EmployeeRepository();
        }

        public void AddEmployee(Employee employee)
        {
            if (!Validation.IsValidEmail(employee.Email) || !Validation.IsValidPhoneNumber(employee.PhoneNumber) || !Validation.IsValidAge(employee.Age))
            {
                Logger.Error("Invalid Employee Data");
                throw new ArgumentException("Invalid Employee Data");
            }

            _repository.Add(employee);
            Logger.Info($"Employee {employee.Name} added successfully.");
        }

        public void UpdateEmployee(Employee employee)
        {
            if (!Validation.IsValidEmail(employee.Email) || !Validation.IsValidPhoneNumber(employee.PhoneNumber) || !Validation.IsValidAge(employee.Age))
            {
                Logger.Error("Invalid Employee Data");
                throw new ArgumentException("Invalid Employee Data");
            }

            _repository.Update(employee);
            Logger.Info($"Employee ID {employee.Id} updated successfully.");
        }

        public void DeleteEmployee(int id)
        {
            _repository.Delete(id);
            Logger.Info($"Employee ID {id} deleted successfully.");
        }

        public List<Employee> GetAllEmployees()
        {
            Logger.Info("Fetched all employees.");
            return _repository.GetAll();
        }
    }
}
