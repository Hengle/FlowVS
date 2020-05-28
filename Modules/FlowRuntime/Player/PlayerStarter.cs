using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FLOW.Player
{
    public class PlayerStarter : MonoBehaviour
    {
        public List<FlowHierarchy> hierarchies;
        IEnumerator Start()
        {
            foreach (var hierarchy in hierarchies)
            {
                var player = Instantiate(hierarchy.hierarchyPlayer);
                yield return player.GetComponent<FlowPlayer>().Play(hierarchy);
            }
        }
    }
}
