using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(AudioSource),typeof(Button))]
public class MusicButton : MonoBehaviour
{
    private AudioSource _sound;
    private Button _button;

    private void Awake()
    {
        _sound = GetComponent<AudioSource>();
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button?.onClick.AddListener(_sound.Play);
    }

    private void OnDisable()
    {
        _button?.onClick.RemoveListener(_sound.Play);
    }
}
