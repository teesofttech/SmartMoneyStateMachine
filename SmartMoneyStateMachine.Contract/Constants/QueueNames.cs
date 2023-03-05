using SmartMoneyStateMachine.Contract.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMoneyStateMachine.Contract.Constants
{
    public class QueueNames
    {
        private const string rabbitUri = "queue:";
        public static Uri GetMessageUri(string key)
        {
            return new Uri(rabbitUri + key.PascalToKebabCaseMessage());
        }
        public static Uri GetActivityUri(string key)
        {
            var kebabCase = key.PascalToKebabCaseActivity();
            if (kebabCase.EndsWith('-'))
            {
                kebabCase = kebabCase.Remove(kebabCase.Length - 1);
            }
            return new Uri(rabbitUri + kebabCase + '_' + "execute");
        }
    }
}
