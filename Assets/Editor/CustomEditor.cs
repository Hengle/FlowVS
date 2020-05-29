using FLOW.Editor;
using UnityEditor;
using UnityEngine;

public class CustomEditor : FlowEditor
{
    [MenuItem("FlowHierarchy/Custom Editor")]
    static void ShowEditor()
    {
        GetWindow<CustomEditor>();
    }

    protected override void AddActionList()
    {
        actionList["Character/Translate"] = new CharacterTranslateView();
        actionList["Character/Rotate"] = new CharacterRotateView();
        actionList["Character/Properties"] = new CharacterPropertiesView();
        actionList["Character/Animation"] = new CharacterAnimationView();
        actionList["Character/Despawn"] = new CharacterDespawnView();

        actionList["Scene/Transition"] = new SceneTransitionView();
        actionList["Scene/Additive"] = new SceneAdditiveView();
        actionList["Scene/FadeIn"] = new SceneFadeInView();
        actionList["Scene/FadeOut"] = new SceneFadeOutView();

        actionList["Text/Conversation"] = new TextConversationView();
        actionList["Text/Create"] = new TextCreateView();

        actionList["Particle/Create"] = new ParticleCreateView();
        actionList["Particle/DestroySeconds"] = new ParticleDestroySecondsView();

        actionList["Texture/Create"] = new TextureCreateView();
        actionList["Texture/Properties"] = new TexturePropertiesView();
        actionList["Texture/Translate"] = new TextureTranslateView();
        actionList["Texture/Rotate"] = new TextureRotateView();
        actionList["Texture/Despawn"] = new TextureDespawnView();
        actionList["Texture/Filed"] = new TextureFiledView();
        actionList["Texture/Blink"] = new TextureBlinkView();

        actionList["Camera/Properties"] = new CameraPropertiesView();
        actionList["Camera/Translate"] = new CameraTranslateView();
        actionList["Camera/Rotate"] = new CameraRotateView();

        actionList["Hierarchy/Load"] = new HiearchyLoadView();

        actionList["Unity/Exit"] = new UnityExitView();
    }

    protected override void AddConditionList()
    {
        conditionList["None"] = new NoneConditionView();
        conditionList["Countdown"] = new CountdownConditionView();
        conditionList["Anykey"] = new AnykeyConditionView();
        conditionList["Button"] = new ButtonConditionView();
        conditionList["FinishAction"] = new FinishActionConditionView();
    }

    protected override void SetHierarchyPlayer()
    {
        flowHierarchy.hierarchyPlayer = Resources.Load<GameObject>("CustomPlayer");
    }
}
