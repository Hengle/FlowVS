using System.Collections.Generic;
using FLOW;
using FLOW.Player;

public class CustomPlayer : FlowPlayer
{
    protected override void AddActionList()
    {
        actions["Character/Translate"] = new CharacterTranslateExecute();
        actions["Character/Animation"] = new CharacterAnimationExecute();
        actions["Character/Properties"] = new CharacterPropertiesExecute();
        actions["Character/Rotate"] = new CharacterRotateExecute();
        actions["Character/Despawn"] = new CharacterDespawnExecute();

        actions["Scene/Transition"] = new SceneTransitionExecute();
        actions["Scene/Additive"] = new SceneAdditiveExecute();
        actions["Scene/FadeIn"] = new SceneFadeInExecute();
        actions["Scene/FadeOut"] = new SceneFadeOutExecute();

        actions["Text/Conversation"] = new TextConversationExecute();
        actions["Text/Create"] = new TextCreateExecute();

        actions["Particle/Create"] = new ParticleCreateExecute();
        actions["Particle/DestroySeconds"] = new ParticleDestroySecondsExecute();

        actions["Texture/Create"] = new TextureCreateExecute();
        actions["Texture/Properties"] = new TexturePropertiesExecute();
        actions["Texture/Translate"] = new TextureTranslateExecute();
        actions["Texture/Rotate"] = new TextureRotateExecute();
        actions["Texture/Despawn"] = new TextureDespawnExecute();
        actions["Texture/Filed"] = new TextureFiledExecute();
        actions["Texture/Blink"] = new TextureBlinkExecute();

        actions["Camera/Properties"] = new CameraPropertiesExecute();
        actions["Camera/Translate"] = new CameraTranslateExecute();
        actions["Camera/Rotate"] = new CameraRotateExecute();

        actions["Hierarchy/Load"] = new HierarchyLoadExecute();

        actions["Unity/Exit"] = new UnityExitExecute();
    }
    protected override void AddConditionList()
    {
        conditions["Countdown"] = new CountdownConditionExecute();
        conditions["None"] = new NoneConditionExecute();
        conditions["Anykey"] = new AnykeyConditionExecute();
        conditions["Button"] = new ButtonConditionExecute();
        conditions["FinishAction"] = new FinishActionConditionExecute();
    }
    public void SetFinish(FlowHierarchy flowHierarchy)
    {
        Queue<FlowNode> flowNodes = new Queue<FlowNode>();
        FlowNode startNode = flowHierarchy.flowNodes.Find(x => x.ID == flowHierarchy.startNodeID);
        FlowNode currentNode;
        flowNodes.Enqueue(startNode);

        while (flowNodes.Count != 0)
        {
            currentNode = flowNodes.Dequeue();
            foreach (var branch in currentNode.branches)
                flowNodes.Enqueue(flowHierarchy.flowNodes.Find(x => x.ID == branch.nextFlowNodeID));
        }

        foreach (var node in flowNodes)
        {
            foreach (var action in node.actions)
                actions[action.actionName].FinishAction(action, transform);
        }
        Destroy(gameObject);
    }
}
