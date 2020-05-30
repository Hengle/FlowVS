using FLOW;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomDialogueContainer : MonoBehaviour
{
    float typingSpeed = 0.025f;

    public GameObject dialogueBox;
    public Image talkerImage;
    public Text talkerName;
    public Text context;
    public GameObject fullStop;

    public Text CreateText(ActionInfo info)
    {
        GameObject textObject = new GameObject("Text");
        textObject.transform.parent = transform;
        textObject.AddComponent<Text>();

        Text text = textObject.GetComponent<Text>();

        RectTransform rectTransform = text.GetComponent<RectTransform>();
        rectTransform.localPosition = info.position;
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(1, 1);

        text.fontSize = info.textTemplate.size;
        text.color = info.textTemplate.color;
        text.font = info.textTemplate.font;
        text.alignment = TextAnchor.MiddleLeft;
        if (info.textTemplate.isBold)
            text.fontStyle = FontStyle.Bold;
        return text;
    }

    public IEnumerator Converse(ActionInfo info)
    {
        dialogueBox.SetActive(true);

        talkerName.fontSize = info.conversationTemplate.nameTemplate.size;
        talkerName.color = info.conversationTemplate.nameTemplate.color;
        talkerName.font = info.conversationTemplate.nameTemplate.font;
        if (info.conversationTemplate.nameTemplate.isBold)
            talkerName.fontStyle = FontStyle.Bold;

        context.fontSize = info.conversationTemplate.contextTemplate.size;
        context.color = info.conversationTemplate.contextTemplate.color;
        context.font = info.conversationTemplate.contextTemplate.font;
        if (info.conversationTemplate.contextTemplate.isBold)
            context.fontStyle = FontStyle.Bold;

        foreach (var dialougue in info.conversationTemplate.dialougues)
        {
            context.text = "";
            fullStop.SetActive(false);
            talkerName.text = dialougue.talkerName;
            talkerImage.sprite = dialougue.talkerImage;
            if (info.conversationTemplate.contextTemplate.isTyping)
            {
                for (int i = 0; i < dialougue.context.Length; i++)
                {
                    context.text += dialougue.context[i];
                    yield return new WaitForSeconds(typingSpeed);
                }
            }
            else
                context.text = dialougue.context;

            fullStop.SetActive(true);

            while (true)
            {
                yield return null;
                if (Input.anyKeyDown)
                    break;
            }
        }
        dialogueBox.SetActive(false);
    }
}

