using System.Collections;
using FLOW;
using FLOW.Exetue;
using UnityEngine;


public class TextCreateExecute : IActionExecute
{
    IEnumerator IActionExecute.ExecuteAction(ActionInfo info, Transform player)
    {
        if (info.textTemplate)
        {
            var dialogueContainer = player.GetComponentInChildren<CustomDialogueContainer>();
            var text = dialogueContainer.CreateText(info);
            if (info.textTemplate.isTyping)
            {
                for (int i = 0; i < info.context.Length; i++)
                {
                    text.text += info.context[i];
                    yield return new WaitForSeconds(0.025f);
                }
            }
            else
                text.text = info.context;

            info.finishInfo.isPlaying = false;
        }
    }

    void IActionExecute.FinishAction(ActionInfo info, Transform player)
    {
        if (!info.textTemplate)
            return;
        var dialogueContainer = player.GetComponentInChildren<CustomDialogueContainer>();
        var text = dialogueContainer.CreateText(info);
        text.text = info.context;
    }
}

