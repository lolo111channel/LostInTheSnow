using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBStuff.DialogueSystem
{
    public interface IDialogueActionFunc
    {
        public void Action(object[] args);
    }
}
