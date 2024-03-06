using System;
using System.Collections;
using UnityEngine;

public class SignalingSound : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField, Min(0)] private float _countSecondsBeforeSignal;

    private Single _currentVolume = 0f;
    private float _minVolume = 0f;
    private float _maxVolume = 1f;    
    private float _recoveryRate = 0.2f;    

    public void SetSignaling(AudioClip clip)
    {
        StopAllCoroutines();
        var wait = new WaitForSeconds(_countSecondsBeforeSignal);
        StartCoroutine(StartSignaling(wait, clip));        
    }

    public void StopSignaling(AudioClip clip)
    {
        StopAllCoroutines();
        var wait = new WaitForSeconds(_countSecondsBeforeSignal);
        StartCoroutine(StopSignaling(wait, clip));
    }

    private IEnumerator StartSignaling(WaitForSeconds wait, AudioClip clip)
    {
        while (true)
        {
            _currentVolume = Mathf.MoveTowards(_currentVolume, _maxVolume, _recoveryRate);
            _audioSource.PlayOneShot(clip, _currentVolume);
            Debug.Log(_currentVolume);
            yield return wait;
        }
    }

    private IEnumerator StopSignaling(WaitForSeconds wait, AudioClip clip)
    {       
        while (true)
        {
            _currentVolume = Mathf.MoveTowards(_currentVolume, _minVolume, _recoveryRate);
            _audioSource.PlayOneShot(clip, _currentVolume);
            Debug.Log(_currentVolume);
            yield return wait;
        }
    }
}
