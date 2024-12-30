using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBStuff.DialogueSystem
{
    [DialogueId("print")]
    public class PrintDialogueAction : IDialogueActionFunc
    {
        public void Action(object[] args)
        {
            if (args.Length > 0)
            {
                string arg1 = args[0].ToString();
                UnityEngine.Debug.Log(arg1);
            }
        }
    }
}
