using System.Collections;
using FLOW;
using FLOW.Exetue;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionExecute : IActionExecute
{
    IEnumerator IActionExecute.ExecuteAction(ActionInfo info, Transform player)
    {
        if (string.IsNullOrEmpty(info.name))
            Debug.Log(info.name + " Scene을 찾을 수 없습니다.");
        else
            SceneManager.LoadScene(info.name);
        yield return null;
        info.finishInfo.isPlaying = false;
    }

    void IActionExecute.FinishAction(ActionInfo info, Transform player)
    {
        if (string.IsNullOrEmpty(info.name))
            Debug.Log(info.name + " Scene을 찾을 수 없습니다.");
        else
            SceneManager.LoadScene(info.name);
    }
}

