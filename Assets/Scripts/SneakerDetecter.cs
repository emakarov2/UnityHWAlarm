using System;
using UnityEngine;

public class SneakerDetecter : MonoBehaviour
{
    [SerializeField] private Collider _houseTrigger;

    private int _infiltratorsCount = 0;
    private int _minInfiltratorsToAlarm = 1;

    private bool _isInfiltrated;

    public event Action<bool> InfiltrationStatusChanged;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Sneaker>(out _))
        {
            _infiltratorsCount++;
        }

        if (_infiltratorsCount == _minInfiltratorsToAlarm)
        {
            _isInfiltrated = true;
     
            InfiltrationStatusChanged?.Invoke(_isInfiltrated);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Sneaker>(out _))
        {
            _infiltratorsCount--;
        }

        if (_infiltratorsCount < _minInfiltratorsToAlarm)
        {
            _isInfiltrated = false;
            InfiltrationStatusChanged?.Invoke(_isInfiltrated);
        }
    }
}