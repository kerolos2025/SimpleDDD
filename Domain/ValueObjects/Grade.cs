using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public record Grade
    {
        public int Value { get; }

        private Grade(int value) => Value = value;

        public static Grade Create(int value)
        {
            if (value < 0 || value > 100)
                throw new ArgumentException("Grade must be between 0 and 100");

            return new Grade(value);
        }
    }
}
