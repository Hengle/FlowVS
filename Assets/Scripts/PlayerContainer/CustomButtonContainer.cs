using FLOW;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomButtonContainer : MonoBehaviour
{
    List<GameObject> buttonList = new List<GameObject>();
    public GameObject CreateButton(FinishInfo finishInfo)
    {
        GameObject buttonObject = new GameObject("button");
        buttonObject.transform.parent = transform;

        Image buttonImage = buttonObject.AddComponent<Image>();
        buttonImage.sprite = finishInfo.subSprite;

        
        Button button = buttonObject.AddComponent<Button>();

        RectTransform rectTransform = buttonObject.GetComponent<RectTransform>();
        rectTransform.localPosition = finishInfo.subPosition;
        rectTransform.sizeDelta = finishInfo.subRotation;

        if(finishInfo.subRotation==Vector3.zero)
            buttonImage.SetNativeSize();

        GameObject textObject = new GameObject("Text");
        textObject.transform.parent = buttonObject.transform;
        textObject.AddComponent<Text>();

        Text text = textObject.GetComponent<Text>();
        text.GetComponent<RectTransform>().localPosition = Vector3.zero;
        text.text = finishInfo.subString;
        text.fontSize = finishInfo.subTextTemplate.size;
        text.color = finishInfo.subTextTemplate.color;
        text.font = finishInfo.subTextTemplate.font;
        text.alignment = TextAnchor.MiddleCenter;
        buttonList.Add(buttonObject);
        return buttonObject;
    }
    public void DestroyAllButton()
    {
        foreach (var a in buttonList)
            Destroy(a);
        buttonList.Clear();
    }
}
