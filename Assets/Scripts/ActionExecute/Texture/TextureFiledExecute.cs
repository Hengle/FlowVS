using System.Collections;
using FLOW;
using FLOW.Exetue;
using UnityEngine;
using UnityEngine.UI;

public class TextureFiledExecute : IActionExecute
{
    IEnumerator IActionExecute.ExecuteAction(ActionInfo info, Transform player)
    {
        GameObject obj = GameObject.Find(info.name);
        if (obj)
        {
            var image = obj.GetComponent<Image>();
            image.enabled = true;
            image.type = Image.Type.Filled;
            image.fillMethod = Image.FillMethod.Horizontal;
            image.fillAmount = 0;

            var current = 0f;
            if (info.floatNumber == 0)
                info.floatNumber = 0.1f;
            while (current < info.floatNumber)
            {
                current += Time.deltaTime;
                image.fillAmount = info.animationCurve.Evaluate(current / info.floatNumber);
                yield return null;
            }
        }
        info.finishInfo.isPlaying = false;
    }

    void IActionExecute.FinishAction(ActionInfo info, Transform player)
    {
        GameObject obj = GameObject.Find(info.name);
        if (!obj)
            return;
        obj.GetComponent<Image>().enabled = true;
    }
}
