using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupplyChainManagement.Models
{
    public class GlobalVariables
    {
        //Global variables that you can use from anywhere in your program
        public static int messageCount;
        public static IEnumerable<Notification> messageList;
        public static string currentLoggedInEmail; 
    }
}
