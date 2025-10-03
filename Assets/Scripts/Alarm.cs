using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _alarmSound;
    [SerializeField] private SneakerDetecter _detecter;

    private float _maxVolume = 1.0f;
    private float _zeroVolume = 0f;
    private float _minVolume = 0.01f;
    private float _fadeSpeed = 0.5f;
    private float _targetVolume = 0f;

    private void Start()
    {
        _alarmSound.volume = 0f;
        _alarmSound.loop = true;
        _alarmSound.playOnAwake = false;

        _detecter.InfiltrationStatusChanged += OnInfiltrationStatusChanged;
    }


    private void Update()
    {
        UpdateVolume();
        SwitchPlaying();
    }

    private void OnInfiltrationStatusChanged(bool isActive)
    {
        _targetVolume = isActive ? _maxVolume : _zeroVolume;
    }

    private void UpdateVolume()
    {
        _alarmSound.volume = Mathf.MoveTowards(_alarmSound.volume, _targetVolume, _fadeSpeed * Time.deltaTime);
    }

    private void SwitchPlaying()
    {
        if (_alarmSound.volume > _minVolume && _alarmSound.isPlaying == false)
        {
            _alarmSound.Play();
        }
        else if (_alarmSound.volume < _minVolume && _alarmSound.isPlaying)
        {
            _alarmSound.Stop();
        }
    }
}