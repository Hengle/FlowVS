﻿using System.Collections;
using FLOW;
using FLOW.Exetue;
using UnityEngine;
using UnityEngine.UI;

public class TextureRotateExecute : IActionExecute
{
    IEnumerator IActionExecute.ExecuteAction(ActionInfo info, Transform player)
    {
        GameObject obj = GameObject.Find(info.name);
        if (obj)
        {
            obj.GetComponent<Image>().enabled = true;
            var current = 0f;
            Vector3 originPos = obj.transform.eulerAngles;
            if (info.floatNumber == 0)
                info.floatNumber = 0.1f;
            while (current < info.floatNumber)
            {
                current += Time.deltaTime;
                obj.transform.eulerAngles = Vector3.Lerp(originPos, info.rotation, info.animationCurve.Evaluate(current / info.floatNumber));
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
        obj.transform.eulerAngles = info.rotation;
    }
}
