using System;
using System.Collections;
using UnityEngine;

public class SignalingSound : MonoBehaviour
{    
    [SerializeField] private AudioSource _audioSource;
    [SerializeField, Min(0)] private float _countSecondsBeforeSignal;

    private Single _currentVolume = 0f;       
    private float _recoveryRate = 0.2f;    

    public void FadeIn()
    {
        float targetValue = 1f;
        StopAllCoroutines();
        var wait = new WaitForSeconds(_countSecondsBeforeSignal);
        StartCoroutine(Signaling(wait, targetValue));        
    }

    public void FadeOut()
    {
        float targetValue = 0f;
        StopAllCoroutines();
        var wait = new WaitForSeconds(_countSecondsBeforeSignal);
        StartCoroutine(Signaling(wait, targetValue));
    }   

    private IEnumerator Signaling(WaitForSeconds wait, float targetValue)
    {
        while (true)
        {
            _currentVolume = Mathf.MoveTowards(_currentVolume, targetValue, _recoveryRate);
            _audioSource.volume = _currentVolume;
            _audioSource.Play();            
            yield return wait;
        }
    }
}
