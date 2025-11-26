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

    // ゲーム終了ボタン用
    public void QuitGame()
    {
#if UNITY_EDITOR
        // エディタ上では再生を止める
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // ビルド後はアプリケーションを終了
        Application.Quit();
#endif
    }
}
