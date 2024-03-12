using UnityEngine;

public class SignalingSoundZone : MonoBehaviour
{       
    [SerializeField] private SignalingSound _signalingSound;    

    private void OnTriggerEnter2D(Collider2D other)
    {        
        if (other.TryGetComponent(out SignalingListener signalingListener) == false)
            return;
               
        _signalingSound.FadeIn(other);           
    }

    private void OnTriggerExit2D(Collider2D other)
    {        
        _signalingSound.FadeOut(other);        
    }
}
