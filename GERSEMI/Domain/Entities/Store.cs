using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Store
    {
        public int Id { get; private set; }

        public string Name { get; private set; }
        public string City { get; private set; }
        public string Street { get; private set; }

        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        // Pracownicy przypisani do tego sklepu
        private readonly List<Employee> _employees = new();
        public IReadOnlyCollection<Employee> Employees => _employees;

        private Store() { }

        public Store(string name, string city, string street)
        {
            Name = name;
            City = city;
            Street = street;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public void AddEmployee(Employee employee)
        {
            _employees.Add(employee);
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
