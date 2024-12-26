

public interface IEmployeeService
{
    List<Employee> GetEmployees();
    Employee GetEmployee(int id);

    Employee AddEmployee(Employee employee);
    Employee UpdateEmployee(Employee employee);
    Employee DeleteEmployee(int id);

    Employee GetEmployeeByFirstName(string firstName);
    Employee GetEmployeeByLastName(string lastName);

    Employee GetEmployeeByEmailAddress(string email);
}