using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] [Min(0)] private float speed = 5;
    [SerializeField] private Transform patrolPos1;
    [SerializeField] private Transform patrolPos2;

    [SerializeField] private bool isChasingPlayer = false;

    private bool isGoingTowardsPos1 = true;

    private void Start()
    {
        StartCoroutine(isChasingPlayer ? FollowPlayerRoutine() : PatrolRoutine());
    }

    private IEnumerator PatrolRoutine()
    {
        while (true)
        {
            if (isGoingTowardsPos1)
            {
                if (Vector3.Distance(transform.position, patrolPos1.position) < .1f)
                    isGoingTowardsPos1 = false;
                
                transform.position = Vector3.Lerp(transform.position, patrolPos1.position, speed * Time.deltaTime);
            }
            else
            {
                if (Vector3.Distance(transform.position, patrolPos2.position) < .1f)
                    isGoingTowardsPos1 = true;
                
                transform.position = Vector3.Lerp(transform.position, patrolPos2.position, speed * Time.deltaTime);
            }

            yield return null;
        }
    }
    
    private IEnumerator FollowPlayerRoutine()
    {
        while (true)
        {
            transform.position = Vector3.Lerp(transform.position, PlayerHealth.Instance.transform.position, speed * Time.deltaTime);

            yield return null;
        }
    }
}