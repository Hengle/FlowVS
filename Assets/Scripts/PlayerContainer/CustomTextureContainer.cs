using FLOW;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomTextureContainer : MonoBehaviour
{
    public GameObject CreateTexture(ActionInfo info, Transform parent)
    {
        GameObject textureObject = new GameObject(info.name);
        textureObject.transform.parent = parent;
        Image image = textureObject.AddComponent<Image>();
        image.sprite = info.sprite;
        image.type = Image.Type.Sliced;

        RectTransform rectTransform = textureObject.GetComponent<RectTransform>();
        rectTransform.localPosition = info.position;
        rectTransform.localRotation = Quaternion.Euler(info.rotation);
        rectTransform.sizeDelta = info.size;
        rectTransform.localScale *= info.floatNumber;

        if (info.size == Vector2.zero)
            image.SetNativeSize();
        if (info.boolean == false)
            image.enabled = false;

        return textureObject;
    }
    public void StartBlick(ActionInfo info, Image image) => StartCoroutine(CBlink(info, image));

    IEnumerator CBlink(ActionInfo info, Image image)
    {
        Color fadeColor = Color.white;
        image.color = fadeColor;
        while (true)
        {
            while (image.color.a > 0.2f)
            {
                fadeColor.a -= 0.05f;
                image.color = fadeColor;
                yield return new WaitForSeconds(info.floatNumber);
            }
            while (image.color.a < 0.8f)
            {
                fadeColor.a += 0.05f;
                image.color = fadeColor;
                yield return new WaitForSeconds(info.floatNumber);
            }
        }
    }
}
