using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance;

    [SerializeField] [Min(0)] private int amountOfHealth = 5;

    private PlayerMovement playerMovement;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
        
        playerMovement = GetComponent<PlayerMovement>();
    }

    public void TakeDamage(int amountOfDamage)
    {
        amountOfDamage = Math.Max(0, amountOfDamage);
        amountOfHealth -= amountOfDamage;

        PlayerHealthUi.Instance.SetAmountOfHealth(amountOfHealth);
        if(amountOfHealth <= 0)
            Die();
    }

    private void Die()
    {
        playerMovement.Die();
        
        StartCoroutine(DieRoutine());
    }

    private IEnumerator DieRoutine()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}