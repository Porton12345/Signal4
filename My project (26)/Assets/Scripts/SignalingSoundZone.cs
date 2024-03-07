using UnityEngine;

public class SignalingSoundZone : MonoBehaviour
{       
    [SerializeField] private SignalingSound _signalingSound;     

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<SignalingListener>() == false)
            return;    
        
        _signalingSound.FadeIn();           
    }

    private void OnTriggerExit2D(Collider2D other)
    {              
        _signalingSound.FadeOut();        
    }
}
