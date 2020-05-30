using System.Collections;
using FLOW;
using FLOW.Exetue;
using UnityEngine;

public class CameraTranslateExecute : IActionExecute
{
    IEnumerator IActionExecute.ExecuteAction(ActionInfo info, Transform player)
    {
        Camera camera = player.GetComponentInChildren<Camera>();
        GameObject obj = camera.gameObject;

        var current = 0f;
        Vector3 originPos = obj.transform.position;
        if (info.floatNumber == 0)
            info.floatNumber = 0.1f;
        while (current < info.floatNumber)
        {
            current += Time.deltaTime;
            obj.transform.position = Vector3.Lerp(originPos, info.position, info.animationCurve.Evaluate(current / info.floatNumber));
            yield return null;
        }
        info.finishInfo.isPlaying = false;
    }

    void IActionExecute.FinishAction(ActionInfo info, Transform player)
    {
        Camera camera = player.GetComponentInChildren<Camera>();
        GameObject obj = camera.gameObject;
        obj.transform.position = info.position;
    }
}
