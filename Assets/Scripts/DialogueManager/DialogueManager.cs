using System.IO;
using CBStuff.DialogueSystem;
using NUnit.Framework;
using UnityEngine;

namespace LostInTheSnow
{
    public class DialogueManager : MonoBehaviour
    {
        public delegate void DialogueEvent();
        public event DialogueEvent DialogueStarted;
        public event DialogueEvent DialogueFinished;

        public delegate void DialogueNextLine(DialogueLineType currentLine);
        public event DialogueNextLine NewCurrentLine;

        public bool IsDialogueRunning { get; private set; } = false;
        public DialogueLineType CurrentLine { get; private set; } = null;

        private DialogueLineType[][] _dialoguesLines = new DialogueLineType[10][];
        private int[] _currentIndexes = new int[10];
        private int _dialoguesLinesDimmension = 0;

        public void StartDialogue(string path, string headerName)
        {
            string pathCombined = Application.dataPath + "/" + path;
            if (!File.Exists(pathCombined))
            {
                return;
            }

            if (IsDialogueRunning && _dialoguesLinesDimmension < 1)
            {
                return;
            }

            _currentIndexes[_dialoguesLinesDimmension] = 0;
            _dialoguesLines[_dialoguesLinesDimmension] = GetDialogues.FromJsonFile(pathCombined, headerName);

            CurrentLine = _dialoguesLines[_dialoguesLinesDimmension][_currentIndexes[_dialoguesLinesDimmension]];


            IsDialogueRunning = true;
            DialogueStarted?.Invoke();
            NewCurrentLine?.Invoke(CurrentLine);
            
        }

        public void NextLine()
        {
            if (_currentIndexes[_dialoguesLinesDimmension] < _dialoguesLines[_dialoguesLinesDimmension].Length  - 1)
            {
                _currentIndexes[_dialoguesLinesDimmension]++;
                CurrentLine = _dialoguesLines[_dialoguesLinesDimmension][_currentIndexes[_dialoguesLinesDimmension]];
                NewCurrentLine?.Invoke(CurrentLine);
                MakeAction();
                return;
            }

            if (_dialoguesLinesDimmension > 0)
            {
                //_dialoguesLines = new DialogueLineType[_dialoguesLinesDimmension][];
                _dialoguesLinesDimmension--;

                CurrentLine = _dialoguesLines[_dialoguesLinesDimmension][_currentIndexes[_dialoguesLinesDimmension]];
                return;
            }

            IsDialogueRunning = false;
            CurrentLine = null;
            _dialoguesLines = new DialogueLineType[_dialoguesLinesDimmension][];
            DialogueFinished?.Invoke();
        }

        private void MakeNewDialogueDimmension(string json, string headerName)
        {
            DialogueLineType[] dialogues = DialogueDeseralization.GetDialogues(json, headerName);
            _dialoguesLines[_dialoguesLinesDimmension] = dialogues;
            _currentIndexes[_dialoguesLinesDimmension] = 0;
            CurrentLine = _dialoguesLines[_dialoguesLinesDimmension][_currentIndexes[_dialoguesLinesDimmension]];
            NewCurrentLine?.Invoke(CurrentLine);
        }

        private void MakeAction()
        {
            if (CurrentLine is DialogueAction)
            {
                DialogueAction dialogueAction = (DialogueAction)CurrentLine;
                dialogueAction.Func.Action(dialogueAction.Arguments);
            }
            else if (CurrentLine is DialogueCondition)
            {
                DialogueCondition dialogueCondition = (DialogueCondition)CurrentLine;
                if (dialogueCondition.Func.Condition(dialogueCondition.Arguments))
                {
                    _dialoguesLinesDimmension++;
                    MakeNewDialogueDimmension(dialogueCondition.Dialogue, "lines");
                }
            }
        }
    }
}
