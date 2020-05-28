using UnityEngine;

namespace FLOW
{
    [System.Serializable]
    public class FinishInfo
    {
        public string subString;
        public Vector3 subPosition;
        public Vector3 subRotation;
        public float subFloat;
        public bool subBool;
        public Sprite subSprite;
        public TextTemplate subTextTemplate;
        public bool isPlaying;
    }
}
