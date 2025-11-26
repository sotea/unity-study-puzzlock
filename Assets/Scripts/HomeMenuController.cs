using UnityEngine;
using UnityEngine.InputSystem;

public class HomeMenuController : MonoBehaviour
{
    [SerializeField] private GameObject optionMenuPanel;
    [SerializeField] private bool startOpened = false;

    private bool _isOpen;

    private void Start()
    {
        _isOpen = startOpened;
        if (optionMenuPanel != null)
        {
            optionMenuPanel.SetActive(_isOpen);
        }
    }

    private void Update()
    {
        // 新Input System のキーボード入力を直接使用
        if (Keyboard.current == null) return;

        if (Keyboard.current.tabKey.wasPressedThisFrame)
        {
            ToggleMenu();
        }
    }

    public void ToggleMenu()
    {
        if (optionMenuPanel == null) return;

        _isOpen = !_isOpen;
        optionMenuPanel.SetActive(_isOpen);
    }

    // 「閉じる」ボタンなどから直接呼べるようにしておく
    public void CloseMenu()
    {
        if (optionMenuPanel == null) return;
        if (!_isOpen) return;

        _isOpen = false;
        optionMenuPanel.SetActive(false);
    }
}


