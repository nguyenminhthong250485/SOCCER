using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AGENT_NEW
{
    public class BetManager
    {
        private static Hashtable hs = new Hashtable();

        public static void storeBet(string key, IFunction o)
        {
            hs.Add(key, o);
        }

        public static void updateStoreBet(string key, IFunction o)
        {
            hs[key] = o;
        }

        public static void clearHashTable()
        {
            hs.Clear();
        }

        public static IFunction GetAgentObj(string key)
        {
            return (IFunction)hs[key];
        }

        public static void CreatAgentObj(string type, string key,string username, string usd, string password = "Vvvv6868@")
        {
            if (type.ToUpper() == "SBO")
            {
                IFunction obj = new SboFunction(key, username, password, usd);
                if (hs.Contains(key))
                    updateStoreBet(key, obj);
                else
                    storeBet(key, obj);
            }
            else if (type.ToUpper() == "IBET")
            {
                IFunction obj = new IbetFunction(key, username, password, usd);
                if (hs.Contains(key))
                    updateStoreBet(key, obj);
                else
                    storeBet(key, obj);
            }
        }
    }
}
