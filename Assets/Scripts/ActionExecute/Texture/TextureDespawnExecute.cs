using System.Collections;
using FLOW;
using FLOW.Exetue;
using UnityEngine;

public class TextureDespawnExecute : IActionExecute
{
    IEnumerator IActionExecute.ExecuteAction(ActionInfo info, Transform player)
    {
        GameObject obj = GameObject.Find(info.name);
        if (obj)
            obj.SetActive(false);
        yield return null;
        info.finishInfo.isPlaying = false;
    }

    void IActionExecute.FinishAction(ActionInfo info, Transform player)
    {
        GameObject obj = GameObject.Find(info.name);
        if (obj)
            obj.SetActive(false);
    }
}
