using System;
using System.Collections;
using UnityEngine;

public class SignalingSound : MonoBehaviour
{    
    [SerializeField] private AudioSource _audioSource;
    [SerializeField, Min(0)] private float _countSecondsBeforeSignal;

    private Single _currentVolume = 0f;       
    private float _recoveryRate = 0.2f;
    private Coroutine _coroutine;

    public void FadeIn(Collider2D other)
    {
        float targetValue = 1f;        
        var wait = new WaitForSeconds(_countSecondsBeforeSignal);

        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
        
        _coroutine = StartCoroutine(Signaling(wait, targetValue, other));                 
    }

    public void FadeOut(Collider2D other)
    {
        float targetValue = 0f;        
        var wait = new WaitForSeconds(_countSecondsBeforeSignal);

        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
        
        _coroutine = StartCoroutine(Signaling(wait, targetValue, other));
       
    }   

    private IEnumerator Signaling(WaitForSeconds wait, float targetValue, Collider2D other)
    {        
        while (other.TryGetComponent(out SignalingListener signalingListener))  
        {
            _currentVolume = Mathf.MoveTowards(_currentVolume, targetValue, _recoveryRate);
            _audioSource.volume = _currentVolume;
            _audioSource.Play();            
            yield return wait;
        }
    }   
}
