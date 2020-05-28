using UnityEngine;

namespace FLOW
{
    [System.Serializable]
    public class ActionInfo
    {
        public string actionName;
        public string finishCondtionName;
        public int finishConditionIndex;

        public string name;
        public string context;
        public GameObject obj;
        public Vector3 position;
        public Vector3 rotation;
        public Vector2 size;
        public AnimationCurve animationCurve = new AnimationCurve();
        public float floatNumber = 1f;
        public int intNumber = 1;
        public int index;
        public bool boolean = true;
        public Sprite sprite;
        public ObjectTemplate objectTemplate;
        public TextTemplate textTemplate;
        public ConversationTemplate conversationTemplate;
        public FlowHierarchy flowHierarchy;

        public FinishInfo finishInfo = new FinishInfo();
        public ActionInfo(string name)
        {
            actionName = name;
        }
    }
}
