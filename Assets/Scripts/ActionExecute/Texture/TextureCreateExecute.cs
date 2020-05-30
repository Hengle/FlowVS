using System.Collections;
using FLOW;
using FLOW.Exetue;
using UnityEngine;

public class TextureCreateExecute : IActionExecute
{
    IEnumerator IActionExecute.ExecuteAction(ActionInfo info, Transform player)
    {
        if (info.sprite != null)
        {
            GameObject obj = GameObject.Find(info.name);
            if (!obj)
            {
                var customTextureContainer = player.GetComponentInChildren<CustomTextureContainer>();
                customTextureContainer.CreateTexture(info, customTextureContainer.transform);
            }
            yield return null;
        }
        info.finishInfo.isPlaying = false;
    }

    void IActionExecute.FinishAction(ActionInfo info, Transform player)
    {
        if (info.sprite != null)
        {
            GameObject obj = GameObject.Find(info.name);
            if (!obj)
            {
                var customTextureContainer = player.GetComponentInChildren<CustomTextureContainer>();
                customTextureContainer.CreateTexture(info, customTextureContainer.transform);
            }
        }
    }
}
