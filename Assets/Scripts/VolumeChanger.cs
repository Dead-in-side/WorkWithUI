using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent (typeof(Slider))]
public class VolumeChanger : MonoBehaviour
{
    private readonly string Volume = "Volume";

    [SerializeField] private AudioMixerGroup _mixer;

    private Slider _volumeSlider;
    private float _maxVolume = 0;
    private float _minVolume = -80;

    private void Awake()
    {
        _volumeSlider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _volumeSlider.onValueChanged.AddListener(SlideVolume);
    }

    private void OnDisable()
    {
        _volumeSlider.onValueChanged.RemoveListener(SlideVolume);
    }

    private void Start()
    {
        _volumeSlider.value = 1;
        _mixer.audioMixer.SetFloat(_mixer.name + Volume, _maxVolume);
    }

    public void SlideVolume(float volume)
    {
        if (volume == 0)
        {
            _mixer.audioMixer.SetFloat(_mixer.name + Volume, _minVolume);
        }
        else
        {
            _mixer.audioMixer.SetFloat(_mixer.name + Volume, Mathf.Log10(volume) * 20);
        }
    }
}
