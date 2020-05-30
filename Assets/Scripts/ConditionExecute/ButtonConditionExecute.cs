using System.Collections;
using System.Collections.Generic;
using FLOW;
using FLOW.Exetue;
using FLOW.Player;
using UnityEngine;
using UnityEngine.UI;

class ButtonConditionExecute : IConditionExecute
{
    IEnumerator IConditionExecute.CheckCondition(FinishInfo info, Transform player)
    {
        var buttonContainer = player.GetComponentInChildren<CustomButtonContainer>();
        GameObject buttonObject = buttonContainer.CreateButton(info);
        buttonObject.GetComponent<Button>().onClick.AddListener(() => info.subBool = true);
        while (!info.subBool)
            yield return null;
        buttonContainer.DestroyAllButton();
    }
}

