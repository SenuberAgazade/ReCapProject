using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string MessageAdded = "Added successfully";
        public static string MessageUpdated = "Updated successfully";
        public static string MessageDeleted = "Deleted successfully";
        public static string CarNameInvalid = "Name must be at least 2 characters";
        public static string DailyPriceInvalid = "Daily price must be greater than zero";
        public static string MessageListed = "Listed successfully";
        public static string MessageReturnDate = "The process is not completed because of return date";
        public static string CarImagesOfCarLimitExceeded = "Image count of car can't be greater than 5";
    }
}
