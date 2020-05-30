using System.Collections;
using FLOW;
using FLOW.Exetue;
using UnityEngine;

public class TexturePropertiesExecute : IActionExecute
{
    IEnumerator IActionExecute.ExecuteAction(ActionInfo info, Transform player)
    {
        GameObject obj = GameObject.Find(info.name);
        if (obj)
        {
            var rectTransform = obj.GetComponent<RectTransform>();
            rectTransform.localPosition = info.position;
            rectTransform.localRotation = Quaternion.Euler(info.rotation);
            rectTransform.sizeDelta = info.size;
            rectTransform.localScale *= info.floatNumber;
            obj.GetComponent<UnityEngine.UI.Image>().enabled = info.boolean;
        }
        yield return null;
        info.finishInfo.isPlaying = false;
    }

    void IActionExecute.FinishAction(ActionInfo info, Transform player)
    {
        GameObject obj = GameObject.Find(info.name);
        if (obj)
        {
            var rectTransform = obj.GetComponent<RectTransform>();
            rectTransform.localPosition = info.position;
            rectTransform.localRotation = Quaternion.Euler(info.rotation);
            rectTransform.sizeDelta = info.size;
            rectTransform.localScale *= info.floatNumber;
        }
    }
}
