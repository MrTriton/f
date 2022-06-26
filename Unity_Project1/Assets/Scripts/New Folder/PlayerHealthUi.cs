using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUi : MonoBehaviour
{
    public static PlayerHealthUi Instance;

    [SerializeField] private Image[] healthImages;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
    }

    public void SetAmountOfHealth(int amountOfHealth)
    {
        for (var i = 0; i < healthImages.Length; i++) 
            healthImages[i].gameObject.SetActive(i < amountOfHealth);
    }
}