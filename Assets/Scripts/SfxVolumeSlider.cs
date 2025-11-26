using UnityEngine;
using UnityEngine.UI;

public class SfxVolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider slider;

    private void Awake()
    {
        if (slider == null)
        {
            slider = GetComponent<Slider>();
        }
    }

    private void Start()
    {
        if (slider == null || BgmManager.I == null) return;

        slider.minValue = 0f;
        slider.maxValue = 1f;
        slider.value = BgmManager.I.SfxVolume;

        slider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    private void OnDestroy()
    {
        if (slider != null)
        {
            slider.onValueChanged.RemoveListener(OnSliderValueChanged);
        }
    }

    private void OnSliderValueChanged(float value)
    {
        if (BgmManager.I == null) return;
        BgmManager.I.SfxVolume = value;
    }
}


