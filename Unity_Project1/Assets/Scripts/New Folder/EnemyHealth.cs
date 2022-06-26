using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] [Min(0)] private int amountOfHealth = 1;

    public void TakeDamage(int amountOfDamage)
    {
        amountOfHealth -= Mathf.Max(0, amountOfDamage);
        
        if(amountOfHealth <= 0)
            Destroy(gameObject);
    }
}
