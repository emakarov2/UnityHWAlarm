using UnityEngine;

public class Home : MonoBehaviour
{
    [SerializeField] private SneakerDetecter _detecter;
    [SerializeField] private Syren _syren;

    private void OnEnable()
    {
        _detecter.InfiltrationStatusChanged += OnInfiltrationStatusChanged;
    }

    private void OnDisable()
    {
        _detecter.InfiltrationStatusChanged -= OnInfiltrationStatusChanged;
    }

    private void OnInfiltrationStatusChanged(bool isActive)
    {
        if (isActive)
        {
            _syren.SwitchOn();
        }
        else
        {
            _syren.SwitchOff();
        }
    }
}
