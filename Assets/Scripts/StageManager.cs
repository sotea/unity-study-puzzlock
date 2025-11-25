using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    [SerializeField] GameObject telop;
    [SerializeField] PlayerController player;
    public static bool IsSceneChanging { get; set; } = false;
    private int _keyCount = 0;

    private void Awake()
    {
        IsSceneChanging = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Key"))
        {
            _keyCount++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (IsSceneChanging) return;
        if (collision.gameObject.CompareTag("Key"))
        {
            _keyCount--;
            if (_keyCount == 0)
            {
                GameClear();
            }
        }
    }

    private void GameClear()
    {
        // 停止中の後片付けの最中にアクセスされるのを防ぐ
        if (telop != null) telop.SetActive(true);
        if (player != null) player.CheerUp();

        // 進捗を記録（ステージIDはシーン名を使用）
        var stageId = SceneManager.GetActiveScene().name;
        Debug.Log("GameClear: " + stageId);
        ProgressManager.I.MarkCleared(stageId);
    }
}
