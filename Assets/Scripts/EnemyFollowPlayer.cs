using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour
{
    public float speed;
    private Rigidbody enemyRb;
    private GameObject player;
    

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
       Vector3 lookDirection = (player.transform.position - transform.forward).normalized;
       enemyRb.AddForce(lookDirection * speed);
    }
    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("Projectile"))
        {

            Destroy(gameObject);
            Destroy(other.gameObject);

        }

    }
}
