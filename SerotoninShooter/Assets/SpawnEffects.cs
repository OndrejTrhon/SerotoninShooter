using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class SpawnEffects : MonoBehaviour
{
    public ScreenLimitBottom screenLimitBottom;
    private int SerotoninMissed;
    PostProcessVolume m_Volume;
    Grain m_Grain;

    void Start()
    {
        m_Grain = ScriptableObject.CreateInstance<Grain>();
        m_Grain.enabled.Override(true);
        m_Grain.intensity.Override(1f);

        m_Volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, m_Grain);
    }

    void Update()
    {
        SerotoninMissed = screenLimitBottom.EnemiesLeft;
        m_Grain.intensity.value = SerotoninMissed/3;
    }

    void OnDestroy()
    {
        RuntimeUtilities.DestroyVolume(m_Volume, true, true);
    }
}