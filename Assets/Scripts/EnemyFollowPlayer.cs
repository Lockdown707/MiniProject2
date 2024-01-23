using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour
{
    public float speed;
    private Rigidbody enemyRb;
   public GameObject player;
    public Vector3 lookDirection;
    public SFX sfx;
    public ParticleSystem explosionParticle;
    public GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        sfx = GameObject.Find("SFX").GetComponent<SFX>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
       lookDirection = (player.transform.position - transform.position).normalized;
       enemyRb.AddForce(lookDirection * speed);
    }
    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("Projectile"))
        {
            sfx.ImpactSound();
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            Destroy(gameObject);
            Destroy(other.gameObject);
            gameManager.UpdateScore(1);

        }

    }
}
