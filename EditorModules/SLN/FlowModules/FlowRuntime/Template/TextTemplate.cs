using UnityEngine;

namespace FLOW
{
    [CreateAssetMenu(fileName = "TextTemplate", menuName = "Template/TextTemplate")]
    public class TextTemplate : ScriptableObject
    {
        public int size;
        public Color color = new Color(0, 0, 0, 1f);
        public Font font;
        public bool isTyping;
        public bool isBold;
    }
}
