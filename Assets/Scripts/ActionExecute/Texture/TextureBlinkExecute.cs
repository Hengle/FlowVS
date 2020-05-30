using System.Collections;
using FLOW;
using FLOW.Exetue;
using UnityEngine;
using UnityEngine.UI;

public class TextureBlinkExecute : IActionExecute
{
    IEnumerator IActionExecute.ExecuteAction(ActionInfo info, Transform player)
    {
        GameObject obj = GameObject.Find(info.name);
        if (obj)
        {
            var customTextureContainer = player.GetComponentInChildren<CustomTextureContainer>();
            var image = obj.GetComponent<Image>();
            image.enabled = true;
            customTextureContainer.StartBlick(info, image);
            yield return null;
        }
        info.finishInfo.isPlaying = false;
    }

    void IActionExecute.FinishAction(ActionInfo info, Transform player)
    {
        GameObject obj = GameObject.Find(info.name);
        if (!obj)
            return;
        var customTextureContainer = player.GetComponentInChildren<CustomTextureContainer>();
        var image = obj.GetComponent<Image>();
        image.enabled = true;
        customTextureContainer.StartBlick(info, image);
        obj.transform.localPosition = info.position;
    }

    
}
