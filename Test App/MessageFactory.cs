using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace testerApp
{
    public static class MessageFactory
    {
        public static  SubMessage CreateMessage(string type)
        {
           switch(type)
           {
               case "login":
                   return new LoginMessage();
               case "get_foods":
                   return new GetFoodsMsg();

           }

            return null;
        }
    }
}
