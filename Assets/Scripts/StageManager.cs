using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField] GameObject telop;
    [SerializeField] PlayerController player;
    private int _keyCount = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Key"))
        {
            _keyCount++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
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
    }
}
