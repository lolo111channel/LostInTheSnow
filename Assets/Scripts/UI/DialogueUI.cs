using System;
using CBStuff.DialogueSystem;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private UI _ui;
    [SerializeField] private GameObject _dialogeuPanel;
    [SerializeField] private TMP_Text _dialogueWhoTalk;
    [SerializeField] private TMP_Text _dialogueContent;

    private void OnEnable()
    {
        _dialogueWhoTalk.text = "";
        _dialogueContent.text = "";

        _ui.DialogueManager.DialogueStarted += DialogueStarted;
        _ui.DialogueManager.DialogueFinished += DialogueFinished;
        _ui.DialogueManager.NewCurrentLine += NewCurrentLine;
        _ui.DialogueManager.DialoguePaused += DialoguePaused;
        _ui.DialogueManager.DialogueUnpaused += DialogueUnpaused;
    }

    private void OnDisable()
    {
        _ui.DialogueManager.DialogueStarted -= DialogueStarted;
        _ui.DialogueManager.DialogueFinished -= DialogueFinished;
        _ui.DialogueManager.NewCurrentLine -= NewCurrentLine;
        _ui.DialogueManager.DialoguePaused -= DialoguePaused;
        _ui.DialogueManager.DialogueUnpaused -= DialogueUnpaused;
    }

    private void DialogueUnpaused()
    {
        //_dialogeuPanel.SetActive(true);
    }

    private void DialoguePaused()
    {
        _dialogeuPanel.SetActive(false);
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

        string whoTalk = LocalizationSettings.StringDatabase.GetLocalizedString("dialogues", line.Arguments[0]);
        string content = LocalizationSettings.StringDatabase.GetLocalizedString("dialogues", line.Arguments[1]);

        _dialogueWhoTalk.text = whoTalk;
        _dialogueContent.text = content;
    }
}
