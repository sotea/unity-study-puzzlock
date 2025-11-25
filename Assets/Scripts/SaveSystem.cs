using System.IO;
using UnityEngine;

public static class SaveSystem
{
    private const string FileName = "progress.json";

    private static string GetPath()
    {
        return Path.Combine(Application.persistentDataPath, FileName);
    }

    public static StageProgressData Load()
    {
        var path = GetPath();
        if (!File.Exists(path))
        {
            return new StageProgressData();
        }

        try
        {
            var json = File.ReadAllText(path);
            var data = JsonUtility.FromJson<StageProgressData>(json);
            return data ?? new StageProgressData();
        }
        catch
        {
            // 壊れた場合は初期化（実運用ではバックアップ復元などを検討）
            return new StageProgressData();
        }
    }

    public static void Save(StageProgressData data)
    {
        if (data == null) return;
        var json = JsonUtility.ToJson(data);
        File.WriteAllText(GetPath(), json);
    }

    // セーブデータファイルを削除する
    public static void Delete()
    {
        var path = GetPath();
        if (File.Exists(path))
        {
            File.Delete(path);
            Debug.Log($"SaveSystem: deleted save file at {path}");
        }
    }
}


