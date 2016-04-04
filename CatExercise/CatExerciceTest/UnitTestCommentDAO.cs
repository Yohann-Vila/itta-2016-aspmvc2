using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CatExercise.Dao;
using CatExercise.Models;
using CodeFirstCat;
using System.Linq;
namespace CatExerciceTest {
    [TestClass]
    public class UnitTestCommentDAO {
        [TestMethod]
        public void getPostsFromThreadTest() {
            ICommentDAO commentDAO = DAOFactory.getInstanceOfComment();
            var result = commentDAO.getPostsFromThread(99999, true);
            Assert.AreEqual(0, result.Count);
        }
        [TestMethod]
        public void insertTest() {
            ICommentDAO commentDAO = DAOFactory.getInstanceOfComment();
            int num = new Random().Next();
            CommentView test = new CommentView() {
                CatThreadId = 1,
                Content = "TEST"+num,
                UserID = 1,
                Deleted = false,
                CreationDate = new DateTime().AddDays(25).AddMonths(12).AddYears(1984)
            };
            var result = commentDAO.insert(test);
            Assert.IsTrue(result);
            CatDB model = new CatDB();
            Assert.AreEqual(model.Comments.Where(c => c.Content == "TEST" + num).First().Content,"TEST" + num);
        }
        [TestMethod]
        public void findTest() {
            ICommentDAO commentDAO = DAOFactory.getInstanceOfComment();
            Assert.IsNotNull(commentDAO.findByID(1)); 
        }
    }
}
