using System.Collections;
using UnityEngine;



public class Finish :MonoBehaviour{


[SerializeField] public GameObject PnelWin;


void OnTriggerEnter2D (Collider2D other) {


  if (other.tag == "Player") {
PnelWin.SetActive(true);
Time.timeScale = 0;
Debug.Log("work");
}
}
}
