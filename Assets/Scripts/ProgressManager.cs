using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    private static ProgressManager _instance;
    public static ProgressManager I
    {
        get
        {
            if (_instance == null) CreateOrGet();
            return _instance;
        }
    }

    public StageProgressData Data { get; private set; }
    private readonly HashSet<string> _clearedSet = new HashSet<string>();

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Bootstrap()
    {
        CreateOrGet();
    }

    private static void CreateOrGet()
    {
        if (_instance != null) return;
        var go = new GameObject("ProgressManager");
        _instance = go.AddComponent<ProgressManager>();
        DontDestroyOnLoad(go);
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        Load();
    }

    private void Load()
    {
        Data = SaveSystem.Load();
        _clearedSet.Clear();
        if (Data.clearedStageIds != null)
        {
            for (int i = 0; i < Data.clearedStageIds.Count; i++)
            {
                _clearedSet.Add(Data.clearedStageIds[i]);
            }
        }
    }

    private void Flush()
    {
        Data.clearedStageIds = _clearedSet.ToList();
        SaveSystem.Save(Data);
    }

    // 進捗データを初期化し、セーブファイルも削除する
    public void ResetAllProgress()
    {
        _clearedSet.Clear();
        Data = new StageProgressData();
        SaveSystem.Delete();
    }

    public bool IsCleared(string stageId)
    {
        if (string.IsNullOrEmpty(stageId)) return false;
        return _clearedSet.Contains(stageId);
    }

    public bool MarkCleared(string stageId)
    {
        if (string.IsNullOrEmpty(stageId)) return false;
        if (_clearedSet.Add(stageId))
        {
            Flush();
            return true;
        }
        return false;
    }
}


