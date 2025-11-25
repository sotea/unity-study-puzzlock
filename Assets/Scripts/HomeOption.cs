using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeOption : MonoBehaviour
{
    // セーブデータ削除ボタン用
    public void DeleteSaveData()
    {
        // 進捗をリセットし、セーブファイルも削除
        ProgressManager.I.ResetAllProgress();

        // 必要であればホームシーン等を再読み込み
        StageManager.IsSceneChanging = true;
        SceneManager.LoadScene("HomeScene");
    }
}
