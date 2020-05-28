using UnityEngine;

namespace FLOW
{
    [System.Serializable]
    public class Dialougue
    {
        public Sprite talkerImage;
        public string talkerName;
        [TextArea(3, 5)]
        public string context;
    }

    [CreateAssetMenu(fileName = "ConversationTemplate", menuName = "Template/ConversationTemplate")]
    public class ConversationTemplate : ScriptableObject
    {
        public TextTemplate nameTemplate;
        public TextTemplate contextTemplate;
        public Dialougue[] dialougues;
    }
}
