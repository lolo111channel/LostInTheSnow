using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBStuff.DialogueSystem
{
    [DialogueId("test")]
    public class TestDialogueCondition : IDialogueConditionFunc
    {
        public bool Condition(object[] args)
        {
            if (args.Length > 0)
            {
                var arg1 = Convert.ToBoolean(args[0].ToString());
                return arg1;
            }
            return false;
        }
    }
}
