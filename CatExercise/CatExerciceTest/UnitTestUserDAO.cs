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
        [TestMethod]
        public void insertTestUser()
        {
            IUserDAO userDAO = DAOFactory.getInstanceOfUser();
            int num = new Random().Next();
            UserView test = new UserView()
            {
                Login = "TATA"+num,
                Password = "Pa$$w0rd",
                UserID = 110,
                Pseudo = "-Tatasse",
                Banish = false,
                Seclevel = 0,
                Creationdate = new DateTime().AddDays(1).AddMonths(5).AddYears(1999)
            };

            var result = userDAO.Insert(test);
            Assert.IsTrue(result);
            CatDB model = new CatDB();
            Assert.AreEqual(model.Users.Where(c => c.Login == "TATA"+num).First().Login, "TATA"+num);
        }        
    }
}
