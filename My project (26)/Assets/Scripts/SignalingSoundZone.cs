using UnityEngine;

public class SignalingSoundZone : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;    
    [SerializeField] private SignalingSound _signalingSound;     

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<SignalingListener>() == false)
            return;    
        
        _signalingSound.SetSignaling(_clip);           
    }

    private void OnTriggerExit2D(Collider2D other)
    {              
        _signalingSound.StopSignaling(_clip);        
    }
}
