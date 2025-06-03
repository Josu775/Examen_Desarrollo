using UnityEngine;

public class EnemyTank : MonoBehaviour
{
    public int health = 3;
    public float forceOnHit = 300f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            // Aplicar fuerza de repulsión
            Vector3 forceDirection = transform.position - other.transform.position;
            rb.AddForce(forceDirection.normalized * forceOnHit, ForceMode.Impulse);

            // Reducir vida
            health--;

            if (health <= 0)
            {
                Destroy(gameObject); // Eliminar tanque enemigo
            }

            Destroy(other.gameObject); // Destruir bala
        }
    }
}
