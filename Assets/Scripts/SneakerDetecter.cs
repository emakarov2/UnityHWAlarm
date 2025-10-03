using System;
using UnityEngine;

public class SneakerDetecter : MonoBehaviour
{
    [SerializeField] private Collider[] _houseTriggers;

    private bool _hasInfiltrators = false;

    public event Action<bool> InfiltrationStatusChanged;

    private void Update()
    {
        CheckForSneakers();
    }

    private void CheckForSneakers()
    {
        bool isSneakersFound = false;

        foreach (Collider triggerCollider in _houseTriggers)
        {
            Collider[] collidersInHouse = Physics.OverlapBox
                (
                triggerCollider.bounds.center,
                triggerCollider.bounds.extents,
                triggerCollider.transform.rotation
                );


            foreach (Collider colliderInHouse in collidersInHouse)
            {
                if (colliderInHouse.TryGetComponent<Sneaker>(out _))
                {
                    isSneakersFound = true;
                    break;
                }
            }
        }

        if (isSneakersFound != _hasInfiltrators)
        {
            _hasInfiltrators = isSneakersFound;

            InfiltrationStatusChanged?.Invoke(_hasInfiltrators);
        }
    }
}