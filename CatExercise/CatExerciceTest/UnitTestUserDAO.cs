using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CatExercise.Dao;
using CatExercise.Models;
using CodeFirstCat;
using System.Linq;

namespace CatExerciceTest
{
    [TestClass]
    class UnitTestUserDAO
    {
        [TestMethod]
        public void findTest()
        {
            IUserDAO userDAO = DAOFactory.getInstanceOfUser();
            Assert.IsNotNull(userDAO.UserDAO());
        }         
    }
}
