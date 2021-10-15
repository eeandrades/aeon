using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aeon.Notifications
{
    internal static class MessageFormatter
    {
        public static string Format(string message, object parameters)
        {
            if (parameters == null)
            {
                return message;
            }

            var sbMessage = new StringBuilder(message);

            var props = parameters.GetType().GetProperties();

            foreach (var pi in props)
            {
                object value = pi.GetValue(parameters);
                sbMessage.Replace($"{{{pi.Name}}}", value?.ToString());
            }
            return sbMessage.ToString();
        }

    }
}
