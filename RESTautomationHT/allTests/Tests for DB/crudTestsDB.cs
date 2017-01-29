﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTautomationHT.allTests.Tests_for_DB
{
    public class CrudTestsDB: TestBaseDB
    {
        [Test]
        public void GetAlltasksDB()
        {
            Console.WriteLine("------> getAllitems <------");
            Console.WriteLine("Get all Lists");
            DataTable allTasks = client.getAllTasks();
            Console.WriteLine("Validate that all tasks collection is not null.");
            Assert.IsTrue(allTasks != null, "Result should not be null even if there are no data in the table");
        }

        [Test]
        public void createNewTaskDB()
        {
            Console.WriteLine("------> createNewListTest <------");
            Console.WriteLine("Create new List Item");
            string taskName = "NewTask_" + random.Next(1, 1000);
            string taskDate = today.ToString("yyyy-MM-dd");
            client.createNewTask(taskName, taskDate);
            Console.WriteLine("Verify if task can be found by Date filter.");
        }

        [Test]
        public void deleteTaskDB()
        {
            Console.WriteLine("------> deleteListTest <------");
            Console.WriteLine("Create new List Item");
            string taskName = "NewTask_" + random.Next(1, 1000);
            string taskDate = today.ToString("yyyy-MM-dd");
            client.createNewTask(taskName, taskDate);
            Console.WriteLine("Delete List Item -> {0} : {1}", taskName, taskDate);
            client.deleteTask(taskName, taskDate);

            Console.WriteLine("Verify if task can be found by Date filter.");

        }

//        System.out.println(String.format("Verify that list item -> %s : %s cannot be selected anymore", new Object[]{listName, listDate}));
//        List myNewlyDeletedTask = client.getUniqueTask(listName, listDate);
//        Assert.assertTrue("Result should be empty", myNewlyDeletedTask.isEmpty());
    }
}

//package tests.db;

//import java.util.List;
//import org.junit.Assert;
//import org.junit.Test;
//import tests.db.DbTestBase;
//import validators.ResultSetValidator;

//public class ToDoListDbCrudTests extends DbTestBase {
//    public ToDoListDbCrudTests() {
//    }

//    @Test
//    public void getAllListsTest() throws Exception {
//        System.out.println("------> getAllListsTest <------");
//        System.out.println("Get all Lists");
//        List allTasks = client.getAllTasks();
//        System.out.println("Validate that all tasks collection is not null.");
//        Assert.assertTrue("Result should not be null even if there are no data in the table", allTasks != null);
//    }

//    @Test
//    public void createNewListTest() throws Exception {
//        System.out.println("------> createNewListTest <------");
//        System.out.println("Create new List Item");
//        String listName = "NewList_" + this.random.nextInt();
//        String listDate = "2016-01-01";
//        client.createNewTask(listName, listDate);
//        System.out.println("Verify if list can be found by Date filter.");
//        List myNewlyCreatedTask = client.getUniqueTask(listName, listDate);
//        Assert.assertTrue("Actual result doesn\'t match expected result.", ResultSetValidator.validate(listName, listDate, myNewlyCreatedTask));
//    }

//    @Test
//    public void deleteListTest() throws Exception {
//        System.out.println("------> deleteListTest <------");
//        System.out.println("Create new List Item");
//        String listName = "NewList_" + this.random.nextInt();
//        String listDate = "2016-01-01";
//        client.createNewTask(listName, listDate);
//        System.out.println(String.format("Delete List Item -> %s : %s", new Object[]{listName, listDate}));
//        client.deleteTask(listName, listDate);
//        System.out.println(String.format("Verify that list item -> %s : %s cannot be selected anymore", new Object[]{listName, listDate}));
//        List myNewlyDeletedTask = client.getUniqueTask(listName, listDate);
//        Assert.assertTrue("Result should be empty", myNewlyDeletedTask.isEmpty());
//    }
//}