using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class SpawnEffects : MonoBehaviour
{
    public ScreenLimitBottom screenLimitBottom;
    private int SerotoninMissed;
    PostProcessVolume m_Volume;
    Grain m_Grain;
    Bloom m_Bloom;
    public bool EnemyCollision;

    void Start()
    {
        m_Grain = ScriptableObject.CreateInstance<Grain>();
        m_Grain.enabled.Override(true);
        m_Grain.intensity.Override(1f);

         m_Bloom = ScriptableObject.CreateInstance<Bloom>();
        m_Bloom.enabled.Override(true);
        m_Bloom.intensity.Override(10f);

        m_Volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, m_Grain);
        m_Volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, m_Bloom);
        
    }

    void Update()
    {
        SerotoninMissed = screenLimitBottom.EnemiesLeft;
        m_Grain.intensity.value = SerotoninMissed/5;

        if (EnemyCollision == true) {
            m_Bloom.intensity.value = 20f;
            EnemyCollision = false;
        }
    }

    void OnDestroy()
    {
        RuntimeUtilities.DestroyVolume(m_Volume, true, true);
    }
}