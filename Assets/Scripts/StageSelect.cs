using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour
{
    private Button _button;
    private TextMeshProUGUI _buttonText;

    void Start()
    {
        _button = GetComponent<Button>();
        _buttonText = GetComponentInChildren<TextMeshProUGUI>();
        _buttonText.text = gameObject.name;
        _button.onClick.AddListener(OnStageButton);
    }

    void OnStageButton()
    {
        SceneManager.LoadScene(gameObject.name);
    }
}
