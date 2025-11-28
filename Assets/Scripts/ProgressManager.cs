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
    private readonly HashSet<string> _completedSet = new HashSet<string>();

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
        _completedSet.Clear();
        if (Data.completedStageIds != null)
        {
            for (int i = 0; i < Data.completedStageIds.Count; i++)
            {
                _completedSet.Add(Data.completedStageIds[i]);
            }
        }
    }

    private void Flush()
    {
        Data.completedStageIds = _completedSet.ToList();
        SaveSystem.Save(Data);
    }

    // 進捗データを初期化し、セーブファイルも削除する
    public void ResetAllProgress()
    {
        _completedSet.Clear();
        Data = new StageProgressData();
        SaveSystem.Delete();
    }

    public bool IsCompleted(string stageId)
    {
        if (string.IsNullOrEmpty(stageId)) return false;
        return _completedSet.Contains(stageId);
    }

    public bool MarkCompleted(string stageId)
    {
        if (string.IsNullOrEmpty(stageId)) return false;
        if (_completedSet.Add(stageId))
        {
            Flush();
            return true;
        }
        return false;
    }
}


