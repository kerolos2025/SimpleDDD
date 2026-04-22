using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Student
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Email Email { get; private set; }
        public Grade Grade { get; private set; }
        public Address Address { get; private set; }
        // EF Core needs this
        private Student() { }

        public static Student Create(string name, string email, int grade
            ,string street, 
            string city,        // ← Address fields
            string zipCode)
        {
            return new Student
            {
                Id = Guid.NewGuid(),
                Name = name,
                Email = Email.Create(email),
                Grade = Grade.Create(grade),
                Address = Address.Create(street, city, zipCode)
            };
        }

        public void UpdateGrade(int newGrade)
        {
            Grade = Grade.Create(newGrade);
        }
    }
}
