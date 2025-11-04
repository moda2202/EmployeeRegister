using Xunit;
using EmployeeRegister;

namespace EmployeeRegister.Tests
{
    public class EmployeeRegistryTests
    {
        [Fact]
        public void AddEmployee_ShouldAdd_WhenNameIsUnique()
        {

            var registry = new EmployeeRegistry();

            bool result = registry.AddEmployee("Mounir", 35000);

            Assert.True(result);
            Assert.Equal(1, registry.Count);
        }

        [Fact]
        public void AddEmployee_ShouldNotAdd_WhenDuplicateName()
        {
            var registry = new EmployeeRegistry();
            registry.AddEmployee("Mounir", 35000);

            bool result = registry.AddEmployee("Mounir", 40000);

            Assert.False(result);
            Assert.Equal(1, registry.Count);
        }

        [Fact]
        public void FindEmployeeByName_ShouldReturnNull_WhenNotFound()
        {
            var registry = new EmployeeRegistry();

            var employee = registry.FindEmployeeByName("Unknown");

            Assert.Null(employee);
        }

        [Fact]
        public void DeleteEmployee_ShouldRemove_WhenExists()
        {
            var registry = new EmployeeRegistry();
            registry.AddEmployee("Feras", 20000);

            bool deleted = registry.DeleteEmployee("Feras");

            Assert.True(deleted);
            Assert.Equal(0, registry.Count);
        }
    }
}
