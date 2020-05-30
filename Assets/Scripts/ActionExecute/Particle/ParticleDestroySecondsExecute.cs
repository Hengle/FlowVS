using System.Collections;
using FLOW;
using FLOW.Exetue;
using UnityEngine;

public class ParticleDestroySecondsExecute : IActionExecute
{
    IEnumerator IActionExecute.ExecuteAction(ActionInfo info, Transform player)
    {
        if (info.obj != null)
        {
            GameObject obj = Object.Instantiate(info.obj);
            obj.transform.position = info.position;
            obj.transform.rotation = Quaternion.Euler(info.rotation);
            obj.transform.localScale *= info.floatNumber;
            yield return new WaitForSeconds(info.floatNumber);
            Object.Destroy(obj);
        }
        info.finishInfo.isPlaying = false;
    }

    void IActionExecute.FinishAction(ActionInfo info, Transform player)
    {

    }
}
