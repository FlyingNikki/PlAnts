using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 20f;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        MoveForward();
    }

    private void MoveForward()
    {
        rb.velocity = transform.forward * bulletSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
