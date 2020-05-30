using System.Collections;
using FLOW;
using FLOW.Exetue;
using UnityEngine;

public class CharacterRotateExecute : IActionExecute
{
    IEnumerator IActionExecute.ExecuteAction(ActionInfo info, Transform player)
    {
        if (info.objectTemplate != null)
        {
            GameObject obj = GameObject.Find(info.objectTemplate.name);
            if (!obj)
                obj = CreateCharacter(info.objectTemplate);

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
        if (info.objectTemplate == null)
            return;
        GameObject obj = GameObject.Find(info.objectTemplate.name);
        if (!obj)
            obj = CreateCharacter(info.objectTemplate);
        obj.transform.eulerAngles = info.rotation;
    }

    GameObject CreateCharacter(ObjectTemplate objectTemplate)
    {
        GameObject obj = Object.Instantiate(objectTemplate.obj, objectTemplate.position, Quaternion.Euler(objectTemplate.rotation));
        obj.name = objectTemplate.name;
        return obj;
    }
}
