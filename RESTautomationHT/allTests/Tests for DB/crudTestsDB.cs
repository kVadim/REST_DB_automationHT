using NUnit.Framework;
using System;
using System.Collections.Generic;
using RESTautomationHT.validators;

namespace RESTautomationHT.allTests.Tests_for_DB
{
    public class CrudTestsDB: TestBaseDB
    {
        [Test]
        public void DB_GetAlltasks()
        {
            Console.WriteLine("------> getAllitems <------");
            Console.WriteLine("Get all Lists");
            List<Dictionary<string, object>> allTasks = client.getAllTasks();
            Console.WriteLine("Validate that all tasks collection is not null.");
            Assert.IsTrue(allTasks != null, "Result should not be null even if there are no data in the table");
        }

        [Test]
        public void DB_CreateNewTask()
        {
            Console.WriteLine("------> createNewTaskTest <------");
            Console.WriteLine("Create new task");
            string taskName = "NewTask_" + random.Next(100, 1000);
            DateTime taskDate = DateTime.Today; 
            bool isCreated = client.createNewTask(taskName, taskDate);
            Assert.IsTrue(isCreated, "Task is not created");
            Console.WriteLine("Verify if task can be found by Date filter.");
            List<Dictionary<string, object>> createdTask = client.getUniqueTask(taskName, taskDate);
            Assert.IsTrue(ResultSetValidator.validate(taskName, taskDate, createdTask),"Actual result doesn't match expected result");
        }

        [Test]
        public void DB_DeleteTask()
        {
            Console.WriteLine("------> deleteListTest <------");
            Console.WriteLine("Create new task");
            string taskName = "NewTask_" + random.Next(100, 1000);
            DateTime taskDate = DateTime.Today;
            client.createNewTask(taskName, taskDate);
            Console.WriteLine("Delete task -> {0} : {1}", taskName, taskDate.ToString("yyyy-MM-dd"));
            bool isDeleted = client.deleteTask(taskName, taskDate);
            Assert.IsTrue(isDeleted, "Task is not deleted");
            Console.WriteLine("Verify if task -> {0} : {1} can not be selected anymore", taskName, taskDate.ToString("yyyy-MM-dd"));
            List<Dictionary<string, object>> deletedTask = client.getUniqueTask(taskName, taskDate);
            Assert.IsTrue(deletedTask.Count==0, "Result should be empty");
        }
    }
}

