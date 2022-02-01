using MvcToDoList.Models;
using Xunit;

namespace UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //Arrange
            var toDoList = new ToDoList();

            // Act
            var result = toDoList.Task = "Go for a jog";

            // Assert
            Assert.Contains("Go", result);
        }

        [Fact]
        public void TaskCharRange()
        {
            var toDoList = new ToDoList();

            var result = toDoList.Task = "This task not under 50 characters.";

            Assert.InRange(result.Length, 0, 50);
        }

        [Fact]
        public void DescriptionCharRange()
        {
            var toDoList = new ToDoList();

            var result = toDoList.Description = "This description is under 150 characters. This description is under 150 characters.";

            Assert.InRange(result.Length, 0, 150);
        }

        [Fact]
        public void SameValueCheck()
        {
            var toDoList = new ToDoList();

            var result = toDoList.Task = "Test Task";
            var result2 = toDoList.Description = "Test Task";

            Assert.Equal(result, result2);
        }
    }
}