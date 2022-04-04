using Assets.Scripts.Scriptable_Objects;
using Assets.Scripts.Utilities;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class MainCamera : MonoBehaviour
{
    [SerializeField] GameSettings gameSettings;
    ColorGrading _colorGrading;

    private void Awake()
    {
        _colorGrading = GetComponent<PostProcessVolume>().profile.GetSetting<ColorGrading>();
    }

    public void OnHealthUpdate(GameEventArgs gameEventArgs)
    {
        OnHealthUpdateArgs args = (OnHealthUpdateArgs)gameEventArgs;
        float curveValue = gameSettings.HeartbeatMap.Evaluate(args.value);
        _colorGrading.saturation.value = -100 + curveValue * 100;
    }
}
