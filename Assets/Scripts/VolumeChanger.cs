using UnityEngine;
using UnityEngine.Audio;

public class VolumeChanger : MonoBehaviour
{
    private readonly string Volume = "Volume";

    [SerializeField] private AudioMixerGroup _mixer;

    private float _maxVolume = 0;
    private float _minVolume = -80;

    public void ToggleVolume(bool isMute)
    {
        if (isMute)
        {
            _mixer.audioMixer.SetFloat(_mixer.name + Volume, _minVolume);
        }
        else
        {
            _mixer.audioMixer.SetFloat(_mixer.name + Volume, _maxVolume);
        }
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
