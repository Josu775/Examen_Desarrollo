using UnityEngine;

public class Bullet : MonoBehaviour
{
    public AudioSource impactAudio;
    public GameObject explosionPrefab;

    void Start()
    {
        // Por si no choca con nada, se destruye tras 5 segundos
        Destroy(gameObject, 5f);
    }

    void OnCollisionEnter(Collision collision)
    {
        string tag = collision.gameObject.tag;

        // Se destruye si toca suelo, enemigo o cualquier objeto
        if (tag == "Ground" || tag == "Enemy" || tag == "Obstacle") // puedes a�adir m�s tags
        {
            // Sonido
            if (impactAudio != null)
                impactAudio.Play();

            // Efecto visual
            if (explosionPrefab != null)
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            // Destruye con peque�o retraso si hay audio
            Destroy(gameObject, impactAudio != null ? 0.2f : 0f);
        }
    }
}
