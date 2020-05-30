using System.Collections;
using FLOW;
using FLOW.Exetue;
using UnityEngine;

public class ParticleCreateExecute : IActionExecute
{
    IEnumerator IActionExecute.ExecuteAction(ActionInfo info, Transform player)
    {
        if (info.obj != null)
        {
            GameObject obj = Object.Instantiate(info.obj);
            obj.transform.position = info.position;
            obj.transform.rotation = Quaternion.Euler(info.rotation);
            obj.transform.localScale *= info.floatNumber;
            yield return null;
        }
        info.finishInfo.isPlaying = false;
    }

    void IActionExecute.FinishAction(ActionInfo info, Transform player)
    {
        if (info.obj == null)
            return;
        GameObject obj = Object.Instantiate(info.obj);
        obj.transform.position = info.position;
        obj.transform.rotation = Quaternion.Euler(info.rotation);
        obj.transform.localScale *= info.floatNumber;
    }
}
