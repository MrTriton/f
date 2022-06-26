using System.Collections;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    [SerializeField] private bool isDoingPeriodicDamage = false;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent(out PlayerHealth playerHealth))
            StartCoroutine(DealDamageRoutine(playerHealth));
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out PlayerHealth playerHealth))
            StartCoroutine(DealDamageRoutine(playerHealth));
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out PlayerHealth _))
            StopAllCoroutines();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerHealth _))
            StopAllCoroutines();
    }

    private IEnumerator DealDamageRoutine(PlayerHealth playerHealth)
    {
        if (!isDoingPeriodicDamage)
        {
            playerHealth.TakeDamage(damage);
            yield break;
        }

        while (true)
        {
            playerHealth.TakeDamage(damage);
            yield return new WaitForSeconds(1);
        }
    }
}