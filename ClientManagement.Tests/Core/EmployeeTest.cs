﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClientManagement.Core.Models;

namespace ClientManagement.Core.Tests
{
    [TestClass]
    public class EmployeeTests
    {
        [TestMethod, TestCategory("Unit Test")]
        public void Should_Be_Able_To_Create_Employee_Instance()
        {
            var employee = new Employee();
        }
    }
}
