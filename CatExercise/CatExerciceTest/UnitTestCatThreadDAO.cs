using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CatExercise.Dao;
using CatExercise.Models;

namespace CatExerciceTest
{
    [TestClass]
    public class UnitTestCatThreadDAO
    {
        [TestMethod]
        public void FactoryTest()
        {
            ICatThreadDAO dao = DAOFactory.getInstanceOfCatThread();
            Assert.IsNotNull(dao);
        }

        [TestMethod]
        public void OnlyOneAtStartTest()
        {
            ICatThreadDAO dao = DAOFactory.getInstanceOfCatThread();
            Assert.AreEqual(dao.GetAll(true).Count, 1);
        }

        [TestMethod]
        public void CreateAThreadTest()
        {
            ICatThreadDAO dao = DAOFactory.getInstanceOfCatThread();
            int count1 = dao.GetAll(false).Count;
            dao.Insert(new CatThreadView());
            int count2 = dao.GetAll(false).Count;
            Assert.IsTrue(count1 < count2);
        }

        //[TestMethod]
        //public void ActiveOptionTest()
        //{
            
        //}

        [TestMethod]
        public void GetThreadFromInexistingUserTest()
        {
            ICatThreadDAO dao = DAOFactory.getInstanceOfCatThread();
            Assert.AreEqual(dao.FindByLogin("inexisting login").Count, 0);
        }
    }
}
