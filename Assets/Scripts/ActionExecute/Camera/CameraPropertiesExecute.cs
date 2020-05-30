using System.Collections;
using FLOW;
using FLOW.Exetue;
using UnityEngine;

public class CameraPropertiesExecute : IActionExecute
{
    IEnumerator IActionExecute.ExecuteAction(ActionInfo info, Transform player)
    {
        Camera camera = player.GetComponentInChildren<Camera>();
        GameObject obj = camera.gameObject;
        obj.transform.position = info.position;
        obj.transform.rotation = Quaternion.Euler(info.rotation);
        camera.fieldOfView = info.floatNumber;
        yield return null;
        info.finishInfo.isPlaying = false;
    }

    void IActionExecute.FinishAction(ActionInfo info, Transform player)
    {
        Camera camera = player.GetComponentInChildren<Camera>();
        GameObject obj = camera.gameObject;
        obj.transform.position = info.position;
        obj.transform.rotation = Quaternion.Euler(info.rotation);
        camera.fieldOfView = info.floatNumber;
    }
}
