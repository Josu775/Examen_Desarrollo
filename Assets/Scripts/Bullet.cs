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
        if (tag == "Ground" || tag == "Enemy" || tag == "Obstacle") // puedes añadir más tags
        {
            // Sonido
            if (impactAudio != null)
                impactAudio.Play();

            // Efecto visual
            if (explosionPrefab != null)
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            // Destruye con pequeño retraso si hay audio
            Destroy(gameObject, impactAudio != null ? 0.2f : 0f);
        }
    }
}
