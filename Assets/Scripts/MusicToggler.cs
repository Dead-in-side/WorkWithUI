using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Toggle))]
public class MusicToggler : MonoBehaviour
{
    [SerializeField] private AudioListener _listener;

    private Toggle _toggler;

    private void Awake()
    {
        _toggler = GetComponent<Toggle>();
    }

    private void OnEnable()
    {
        _toggler.onValueChanged.AddListener(ToggleVolume);
    }

    private void OnDisable()
    {
        _toggler.onValueChanged.RemoveListener(ToggleVolume);
    }

    public void ToggleVolume(bool isMute)=> _listener.enabled = !isMute;
}
