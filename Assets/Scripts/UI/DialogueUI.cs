using System;
using CBStuff.DialogueSystem;
using TMPro;
using UnityEngine;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private UI _ui;
    [SerializeField] private GameObject _dialogeuPanel;
    [SerializeField] private TMP_Text _dialogueWhoTalk;
    [SerializeField] private TMP_Text _dialogueContent;

    private void OnEnable()
    {
        _ui.DialogueManager.DialogueStarted += DialogueStarted;
        _ui.DialogueManager.DialogueFinished += DialogueFinished;
        _ui.DialogueManager.NewCurrentLine += NewCurrentLine;
    }

    private void OnDisable()
    {
        _ui.DialogueManager.DialogueStarted -= DialogueStarted;
        _ui.DialogueManager.DialogueFinished -= DialogueFinished;
        _ui.DialogueManager.NewCurrentLine -= NewCurrentLine;
    }

    private void DialogueStarted()
    {
        _dialogeuPanel.SetActive(true);
    }

    private void DialogueFinished()
    {
        _dialogeuPanel.SetActive(false);
    }

    private void NewCurrentLine(DialogueLineType currentLine)
    {
        if (!(currentLine is DialogueLine))
        {
            return;
        }

        _dialogeuPanel.SetActive(true);
        DialogueLine line = (DialogueLine)currentLine;


        _dialogueWhoTalk.text = line.Arguments[0];
        _dialogueContent.text = line.Arguments[1];
    }
}
