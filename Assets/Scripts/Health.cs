using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float PHealth = 100f;

    public void TakeDamage(float damage)
    {
        PHealth -= damage;
        if (PHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
