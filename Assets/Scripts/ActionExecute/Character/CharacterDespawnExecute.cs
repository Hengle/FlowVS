using System.Collections;
using FLOW;
using FLOW.Exetue;
using UnityEngine;

public class CharacterDespawnExecute : IActionExecute
{
    IEnumerator IActionExecute.ExecuteAction(ActionInfo info, Transform player)
    {
        if (info.objectTemplate != null)
        {
            GameObject obj = GameObject.Find(info.objectTemplate.name);
            if (obj)
                Object.Destroy(obj);
            yield return null;
        }
        info.finishInfo.isPlaying = false;
    }

    void IActionExecute.FinishAction(ActionInfo info, Transform player)
    {
        if (info.objectTemplate != null)
        {
            GameObject obj = GameObject.Find(info.objectTemplate.name);
            if (obj)
                Object.Destroy(obj);
        }
    }
}
