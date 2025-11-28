using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour
{
    private Button _button;
    private TextMeshProUGUI _buttonText;
    private Image _image;

    void Start()
    {
        _button = GetComponent<Button>();
        _buttonText = GetComponentInChildren<TextMeshProUGUI>();
        _buttonText.text = gameObject.name;
        // ボタン本体の Image ではなく、子階層の「マーク用」Image を取得する
        _image = null;
        var images = GetComponentsInChildren<Image>(true);
        foreach (var img in images)
        {
            if (img.gameObject != _button.gameObject)
            {
                _image = img;
                break;
            }
        }

        // 完了済みの可視化（簡易表示）
        if (_image != null)
            _image.enabled = ProgressManager.I.IsCompleted(gameObject.name);
        _button.onClick.AddListener(OnStageButton);
    }

    void OnStageButton()
    {
        SceneManager.LoadScene(gameObject.name);
    }
}
