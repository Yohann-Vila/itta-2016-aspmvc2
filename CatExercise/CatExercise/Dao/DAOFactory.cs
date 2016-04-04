using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CatExercise.Dao {
    public static class DAOFactory {
    private static String _SOURCE = "Entity";

    public static IUserDAO getInstanceOfUser() {
        switch (_SOURCE) {
            case "Entity":
                throw new NotImplementedException();
            default:
                throw new NotImplementedException();
        }
    }
    public static ICatThreadDAO getInstanceOfCatThread() {
        switch (_SOURCE) {
            case "Entity":
                return new CatThreadDAO();
            default:
                return new CatThreadDAO();
        }
    }
    public static ICommentDAO getInstanceOfComment() {
        switch (_SOURCE) {
            case "Entity":
                return new CommentDAO();
            default:
                return new CommentDAO();
        }
    }
    }
}