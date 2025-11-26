using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class BgmManager : MonoBehaviour
{
    public static BgmManager I { get; private set; }

    private const string BgmVolumeKey = "BgmVolume";
    private const string SfxVolumeKey = "SfxVolume";

    [SerializeField] private AudioClip bgmHome;
    [SerializeField] private AudioClip bgmStage;
    [SerializeField, Range(0f, 1f)] private float defaultBgmVolume = 1f;
    [SerializeField, Range(0f, 1f)] private float defaultSfxVolume = 1f;

    private AudioSource _audioSource;


    private void Awake()
    {
        if (I != null && I != this)
        {
            Destroy(gameObject);
            return;
        }

        I = this;
        DontDestroyOnLoad(gameObject);

        _audioSource = GetComponent<AudioSource>();
        _audioSource.loop = true;

        // セーブ済みBGM音量があればそれを使う
        if (PlayerPrefs.HasKey(BgmVolumeKey))
        {
            defaultBgmVolume = Mathf.Clamp01(PlayerPrefs.GetFloat(BgmVolumeKey, defaultBgmVolume));
        }
        _audioSource.volume = defaultBgmVolume;

        // 初回シーン用に一度だけ呼んでおく
        SwitchBgmForScene(SceneManager.GetActiveScene());
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SwitchBgmForScene(scene);
    }

    public float BgmVolume
    {
        get
        {
            if (_audioSource == null) return defaultBgmVolume;
            return _audioSource.volume;
        }
        set
        {
            defaultBgmVolume = Mathf.Clamp01(value);
            if (_audioSource != null)
            {
                _audioSource.volume = defaultBgmVolume;
            }

            // 音量を永続化
            PlayerPrefs.SetFloat(BgmVolumeKey, defaultBgmVolume);
            PlayerPrefs.Save();
        }
    }

    public float SfxVolume
    {
        get
        {
            // セーブ済み値があればそれを優先（起動後に直接参照される場合も考慮）
            if (PlayerPrefs.HasKey(SfxVolumeKey))
            {
                defaultSfxVolume = Mathf.Clamp01(PlayerPrefs.GetFloat(SfxVolumeKey, defaultSfxVolume));
            }
            return defaultSfxVolume;
        }
        set
        {
            defaultSfxVolume = Mathf.Clamp01(value);
            PlayerPrefs.SetFloat(SfxVolumeKey, defaultSfxVolume);
            PlayerPrefs.Save();
        }
    }

    private void SwitchBgmForScene(Scene scene)
    {
        if (scene.name == "HomeScene")
        {
            PlayBgm(bgmHome);
        }
        else if (scene.name.StartsWith("Stage"))
        {
            PlayBgm(bgmStage);
        }
        else
        {
            // 必要なら他シーン用の分岐を追加
        }
    }

    private void PlayBgm(AudioClip clip)
    {
        if (_audioSource == null || clip == null) return;

        if (_audioSource.clip == clip && _audioSource.isPlaying)
        {
            // すでに同じ曲を再生中なら何もしない
            return;
        }

        _audioSource.clip = clip;
        _audioSource.Play();
    }
}


