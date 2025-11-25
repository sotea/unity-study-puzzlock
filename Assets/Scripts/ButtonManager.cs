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
}
