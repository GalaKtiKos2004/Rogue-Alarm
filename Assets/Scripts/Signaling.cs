using UnityEngine;

public class Signaling : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _volumeScalingSpeed = 1f;

    private float _targetValue = 0f;

    private void Update()
    {
        _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _targetValue, _volumeScalingSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerMover mover))
            _targetValue = 1f;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PlayerMover mover))
            _targetValue = 0f;
    }
}
