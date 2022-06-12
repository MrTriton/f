using System.Collections;
using UnityEngine;

public class DestroyablePlatform : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            StartCoroutine(DestroyPlatform());
    }

    IEnumerator DestroyPlatform()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}