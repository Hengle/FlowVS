using System.Collections;
using FLOW;
using FLOW.Exetue;
using UnityEngine;


public class TextConversationExecute : IActionExecute
{
    IEnumerator IActionExecute.ExecuteAction(ActionInfo info, Transform player)
    {
        if (info.conversationTemplate != null)
        {
            var dialogueContainer = player.GetComponentInChildren<CustomDialogueContainer>();
            yield return dialogueContainer.Converse(info);
        }
        info.finishInfo.isPlaying = false;
    }

    void IActionExecute.FinishAction(ActionInfo info, Transform player)
    {

    }
}

