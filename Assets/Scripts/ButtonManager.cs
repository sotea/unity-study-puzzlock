using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void HomeScene()
    {
        StageManager.IsSceneChanging = true;
        SceneManager.LoadScene("HomeScene");
    }

    public void RestartScene()
    {
        StageManager.IsSceneChanging = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // セーブデータ削除ボタン用
    public void DeleteSaveData()
    {
        // 進捗をリセットし、セーブファイルも削除
        ProgressManager.I.ResetAllProgress();

        // 必要であればホームシーン等を再読み込み
        // SceneManager.LoadScene("HomeScene");
    }
}
