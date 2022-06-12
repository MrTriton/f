using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class TrampolinePlatform : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out PlayerMovement playerMovement))
            playerMovement.Jump();
    }
}