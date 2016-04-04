using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CatExercise.Dao;

namespace CatExerciceTest {
    [TestClass]
    public class UnitTestDAO {
        [TestMethod]
        public void AddUserTest() {
            ICommentDAO commentDAO = DAOFactory.getInstanceOfComment();
            
        }
    }
}
