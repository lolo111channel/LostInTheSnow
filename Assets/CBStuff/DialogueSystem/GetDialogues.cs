using System;
using System.IO;


namespace CBStuff.DialogueSystem
{
    public class GetDialogues
    {
        public static DialogueLineType[] FromJsonFile(string path, string header)
        {
            string json = File.ReadAllText(path);
            return DialogueDeseralization.GetDialogues(json, header);
        }

    }
}
