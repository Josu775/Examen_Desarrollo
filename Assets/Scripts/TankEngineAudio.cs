using UnityEngine;

public class TankEngineAudio : MonoBehaviour
{
    public AudioSource idleAudio;     // motor parado
    public AudioSource drivingAudio;  // motor en marcha

    void Update()
    {
        float moveInput = Input.GetAxis("Vertical");

        if (Mathf.Abs(moveInput) > 0.1f)
        {
            if (!drivingAudio.isPlaying)
            {
                idleAudio.Stop();
                drivingAudio.Play();
            }
        }
        else
        {
            if (!idleAudio.isPlaying)
            {
                drivingAudio.Stop();
                idleAudio.Play();
            }
        }
    }
}
