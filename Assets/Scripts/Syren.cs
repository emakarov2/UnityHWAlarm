using System.Collections;
using UnityEngine;

public class Syren : MonoBehaviour
{
    [SerializeField] private AudioSource _alarmSound;

    private float _maxVolume = 1.0f;
    private float _zeroVolume = 0f;
    private float _fadeSpeed = 0.5f;
    private float _targetVolume = 0f;

    private Coroutine _fadeCoroutine;

    private void Start()
    {
        _alarmSound.volume = 0f;
        _alarmSound.loop = true;
        _alarmSound.playOnAwake = false;
    }

    public void SwitchOn()
    {       
        _targetVolume = _maxVolume;

        StartFadeCoroutine();
    }

    public void SwitchOff()
    {
        _targetVolume = _zeroVolume;

        StartFadeCoroutine();
    }

    private IEnumerator FadeVolume()
    {
        if (_alarmSound.isPlaying == false && _targetVolume > _zeroVolume)
        {
            _alarmSound.Play();
        }

        while (Mathf.Approximately(_alarmSound.volume, _targetVolume) == false)
        {
            _alarmSound.volume = Mathf.MoveTowards(
                _alarmSound.volume,
                _targetVolume,
                _fadeSpeed * Time.deltaTime
                );

            yield return null;
        }

        if (_alarmSound.isPlaying && Mathf.Approximately(_alarmSound.volume, 0f))
        {
            _alarmSound.Stop();
        }

        _fadeCoroutine = null;
    }

    private void StartFadeCoroutine()
    {
        if (_fadeCoroutine != null)
        {
            StopCoroutine(_fadeCoroutine);
        }

        _fadeCoroutine = StartCoroutine(FadeVolume());
    }
}