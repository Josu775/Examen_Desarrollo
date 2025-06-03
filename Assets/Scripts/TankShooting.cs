using UnityEngine;

public class TankShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootPoint;

    public float minForce = 5f;
    public float maxForce = 20f;
    public float chargeSpeed = 10f;

    public AudioSource shootAudio;
    public AudioSource reloadAudio;

    private float currentForce;
    private bool charging;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            charging = true;
            currentForce = minForce;
            reloadAudio.Play();
        }

        if (Input.GetKey(KeyCode.Space) && charging)
        {
            currentForce += chargeSpeed * Time.deltaTime;
            currentForce = Mathf.Min(currentForce, maxForce);
        }

        if (Input.GetKeyUp(KeyCode.Space) && charging)
        {
            Fire();
            charging = false;
            reloadAudio.Stop();
        }
    }

    void Fire()
    {
        shootAudio.Play();
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(shootPoint.forward * currentForce, ForceMode.Impulse);
    }
}
