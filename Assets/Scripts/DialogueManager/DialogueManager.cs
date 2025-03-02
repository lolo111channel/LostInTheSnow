using System.IO;
using CBStuff.DialogueSystem;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json.Linq;
using System;

namespace LostInTheSnow
{
    public class DialogueManager : MonoBehaviour
    {
        public delegate void DialogueEvent();
        public event DialogueEvent DialogueStarted;
        public event DialogueEvent DialogueFinished;
        public event DialogueEvent DialoguePaused;
        public event DialogueEvent DialogueUnpaused;

        public delegate void DialogueNextLine(DialogueLineType currentLine);
        public event DialogueNextLine NewCurrentLine;

        public bool IsDialogueRunning { get; private set; } = false;
        public DialogueLineType CurrentLine { get; private set; } = null;

        private DialogueLineType[][] _dialoguesLines = new DialogueLineType[10][];
        private int[] _currentIndexes = new int[10];
        private int _dialoguesLinesDimmension = 0;

        [SerializeField] private ReferencesForDialogue _referencesForDialogue;

        private bool _isDialogueStopped = false;
        private float _dialogueStoppedMaxTime = 0.0f;


        public void StartDialogue(string path, string headerName)
        {
            string pathCombined = Application.dataPath + "/" + path;
            if (!File.Exists(pathCombined))
            {
                return;
            }

            if (IsDialogueRunning)
            {
                return;
            }

            _dialoguesLinesDimmension = 0;
            _currentIndexes[_dialoguesLinesDimmension] = 0;
            _dialoguesLines[_dialoguesLinesDimmension] = GetDialogues.FromJsonFile(pathCombined, headerName);

            CurrentLine = _dialoguesLines[_dialoguesLinesDimmension][GetCurrentIndex()];


            IsDialogueRunning = true;
            DialogueStarted?.Invoke();
            NewCurrentLine?.Invoke(CurrentLine);


            MakeAction();

        }

        public void NextLine()
        {
            if (_isDialogueStopped)
            {
                return;
            }

            if (!IsDialogueRunning)
            {
                return;
            }

            if (_currentIndexes[_dialoguesLinesDimmension] < _dialoguesLines[_dialoguesLinesDimmension].Length  - 1)
            {
                _currentIndexes[_dialoguesLinesDimmension]++;
                CurrentLine = _dialoguesLines[_dialoguesLinesDimmension][GetCurrentIndex()];
                NewCurrentLine?.Invoke(CurrentLine);
                MakeAction();
                return;
            }

            if (_dialoguesLinesDimmension > 0)
            {
                _dialoguesLinesDimmension--;

                CurrentLine = _dialoguesLines[_dialoguesLinesDimmension][GetCurrentIndex()];
                return;
            }

            IsDialogueRunning = false;
            CurrentLine = null;
            _dialoguesLines = new DialogueLineType[10][];
            DialogueFinished?.Invoke();
        }

        private void FinishDialogue()
        {
            IsDialogueRunning = false;
            DialogueFinished?.Invoke();
        }

        private void MakeNewDialogueDimmension(string json, string headerName)
        {
            DialogueLineType[] dialogues = DialogueDeseralization.GetDialogues(json, headerName);
            _dialoguesLines[_dialoguesLinesDimmension] = dialogues;
            _currentIndexes[_dialoguesLinesDimmension] = 0;
            CurrentLine = _dialoguesLines[_dialoguesLinesDimmension][GetCurrentIndex()];
            NewCurrentLine?.Invoke(CurrentLine);

            if (!(CurrentLine is DialogueLine))
            {
                MakeAction();
            }
        }

        private object[] ChangeArgumentsOnArgumentsWithReference(object[] args)
        {
            List<object> newArgs = new();
            foreach (object arg in args)
            {
                if (((JValue)arg).Value is string)
                {
                    string argStr = arg.ToString();
                    string[] subs = argStr.Split(":");

                    if (subs.Length > 1 && subs[0] == "ref") 
                    {
                        GameObject reference = _referencesForDialogue.GetReference(subs[1]);
                        newArgs.Add(reference);
                        continue;
                    
                    }
                }

                newArgs.Add(arg);
            }

            return newArgs.ToArray();
        }

        private void MakeAction()
        {
            if (CurrentLine is DialogueAction)
            {
                DialogueAction dialogueAction = (DialogueAction)CurrentLine;
                object[] dialogueArgs = ChangeArgumentsOnArgumentsWithReference(dialogueAction.Arguments);
                dialogueAction.Func.Action(dialogueArgs);
                
                if (dialogueAction.Seconds > 0)
                {
                    StopDialogue(dialogueAction.Seconds);
                    return;
                }
                NextLine();
            }
            else if (CurrentLine is DialogueCondition)
            {
                DialogueCondition dialogueCondition = (DialogueCondition)CurrentLine;
                object[] dialogueArgs = ChangeArgumentsOnArgumentsWithReference(dialogueCondition.Arguments);
                if (dialogueCondition.Func.Condition(dialogueArgs))
                {
                    _dialoguesLinesDimmension++;
                    MakeNewDialogueDimmension(dialogueCondition.Dialogue, "lines");
                    return;
                }

                NextLine();

            }
            else if (CurrentLine is DialogueEnd)
            {
                FinishDialogue();
            }

        }

        private void StopDialogue(float time)
        {
            _isDialogueStopped = true;
            _dialogueStoppedMaxTime = time;
            DialoguePaused?.Invoke();
            Invoke("UnpauseDialoge", time);
        }

        private void UnpauseDialoge()
        {
            _isDialogueStopped = false;
            _dialogueStoppedMaxTime = 0;
            DialogueUnpaused?.Invoke();
            NextLine();
        }

        private int GetCurrentIndex() => _currentIndexes[_dialoguesLinesDimmension];
    }
}
