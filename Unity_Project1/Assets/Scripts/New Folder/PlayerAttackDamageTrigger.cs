using UnityEngine;

public class PlayerAttackDamageTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent(out EnemyHealth enemyHealth))
            enemyHealth.TakeDamage(1);
    }
}