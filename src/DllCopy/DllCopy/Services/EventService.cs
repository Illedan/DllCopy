using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCopy.Services
{
    static class EventService
    {
        private static readonly Dictionary<string, List<Action<object>>> m_subscriptions = new Dictionary<string, List<Action<object>>>();
        public static void Subscribe(string type, Action<object> invoke)
        {
            if(!m_subscriptions.ContainsKey(type))
            {
                m_subscriptions.Add(type, new List<Action<object>>());
            }
            m_subscriptions [type].Add(invoke);
        }

        public static void Unsubscribe(string type, Action<object> invoke)
        {
            if(m_subscriptions.ContainsKey(type))
            {
                m_subscriptions [type].Remove(invoke);
            }
        }

        public static void Publish(string type, object message = null)
        {
            if(m_subscriptions.ContainsKey(type))
            {
                foreach(var action in m_subscriptions [type])
                {
                    action(message);
                }
            }
        }
    }
}
