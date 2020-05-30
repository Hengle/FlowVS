using System.Collections;
using FLOW;
using FLOW.Exetue;
using UnityEngine;

public class CharacterAnimationExecute : IActionExecute
{
    IEnumerator IActionExecute.ExecuteAction(ActionInfo info, Transform player)
    {
        if (info.objectTemplate != null)
        {
            GameObject obj = GameObject.Find(info.objectTemplate.name);
            if (!obj)
                obj = CreateCharacter(info.objectTemplate);

            obj.GetComponentInChildren<Animator>().Play(info.name);
            yield return null;
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
    }

    GameObject CreateCharacter(ObjectTemplate objectTemplate)
    {
        GameObject obj = Object.Instantiate(objectTemplate.obj, objectTemplate.position, Quaternion.Euler(objectTemplate.rotation));
        obj.name = objectTemplate.name;
        return obj;
    }
}

