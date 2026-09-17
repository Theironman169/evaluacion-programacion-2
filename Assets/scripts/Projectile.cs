using UnityEngine;
public class Projectil : MonoBehaviour
{
    [SerializeField] private int damage = 20;
    [SerializeField] private float lifeTime = 5f;
    public string tipoProyectil = "Player"; // "Player" o "Enemy"
    void Start()
    {
        Destroy(gameObject, lifeTime); // Red de seguridad
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (tipoProyectil == "Enemy" && collision.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}