using UnityEngine;
namespace FLOW
{
    [CreateAssetMenu(fileName = "ObjectTemplate", menuName = "Template/ObjectTemplate")]
    public class ObjectTemplate : ScriptableObject
    {
        public GameObject obj;
        public Vector3 position;
        public Vector3 rotation;
    }
}
