using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using XUnitProject;

namespace CSharp11Features
{
    public class CalculatorTests
    {
        [Fact]
        public void AddTwoNumbers()
        {
           //arrange 
            double a = 2, b = 3, expected = 5;
            Calculator calculator = new Calculator();
          //act 
            double actual = calculator.Add(a, b);
          //assert
            Assert.Equal(expected, actual); 
        }
    }
}
