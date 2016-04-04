using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CatExercise.Dao;
using CatExercise.Models;
using CodeFirstCat;
using System.Linq;


namespace CatExerciceTest
{
    [TestClass]
    public class UnitTestUserDAO
    {
        [TestMethod]
        public void findTestUser()
        {
            IUserDAO userDAO = DAOFactory.getInstanceOfUser();
            Assert.IsNotNull(userDAO.Find("test"));
        }         
    }
}
