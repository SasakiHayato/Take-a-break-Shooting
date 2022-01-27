using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionSettings : MonoBehaviour
{
    [SerializeField] Slider _bgmSlider;
    [SerializeField] Slider _seSlider;
    [SerializeField] Slider _rightSlider;

    void Update()
    {
        SoundManager.Instance.BGMVolume = _bgmSlider.value;
        SoundManager.Instance.SEVolume = _seSlider.value;
        UIManager.Instance.UpdateRightPanel(_rightSlider.value);
    }
}
