using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomFadePanel : MonoBehaviour
{
    float fadeWeight = 0.025f;
    float frameSpeed = 0.025f;
    Image fadeInOutPanel;

    void Awake()
    {
        fadeInOutPanel = GetComponent<Image>();
    }

    public void FadeInFinish() => fadeInOutPanel.color = Color.clear;

    public void FadeOutFinish() => fadeInOutPanel.color = Color.black;


    public IEnumerator FadeIn(float time)
    {
        Color fadeColor = Color.black;
        fadeInOutPanel.color = fadeColor;
        while (fadeColor.a > 0)
        {
            fadeColor.a -= fadeWeight;
            fadeInOutPanel.color = fadeColor;
            yield return new WaitForSeconds(0.025f);
        }
    }
    public IEnumerator FadeOut(float time)
    {
        Color fadeColor = Color.clear;
        fadeInOutPanel.color = fadeColor;
        while (fadeColor.a < 1)
        {
            fadeColor.a += fadeWeight;
            fadeInOutPanel.color = fadeColor;
            yield return new WaitForSeconds(0.025f);
        }
    }
}
