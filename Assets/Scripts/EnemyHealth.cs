using  System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField] float health = 100;
    [SerializeField] int scoreValue = 150;

    [Header ("Enemy Shooting")]
    [SerializeField] float shotCounter;
    [SerializeField] float mintimeBetweenShots = 0.5f;
    [SerializeField] float maxtimeBetweenShots = 2f;
    [SerializeField] GameObject projectile;
    [SerializeField] float projectileSpeed = 10f;
    
    [Header ("Sound Effects")]
    [SerializeField] GameObject deathVFX;
    [SerializeField] AudioClip deathSFX;
    [SerializeField] [Range(0,1)] float deathVolume = 0.75f;   //ranges from 0 to 1
    [SerializeField] AudioClip shootSFX;
    [SerializeField] [Range(0, 1)] float shootVolume = 0.25f;

    public void Start()
    {
        shotCounter = Random.Range( mintimeBetweenShots,maxtimeBetweenShots);
    }

    public void Update()
    {
        CountDownAndShoot();
    }

    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if(shotCounter <= 0f)
        {
            Fire();
            shotCounter = Random.Range(mintimeBetweenShots, maxtimeBetweenShots);
        }

    }

    private void Fire()
    {
        GameObject laser = Instantiate(projectile,transform.position,Quaternion.identity )as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
        AudioSource.PlayClipAtPoint(shootSFX, Camera.main.transform.position, shootVolume);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if(health <= 0)
        {
            FindObjectOfType<GameSession>().AddToScore(scoreValue);
            Destroy(gameObject);
            GameObject explosion = Instantiate(deathVFX, transform.position, Quaternion.identity);
            Destroy(explosion, 1f);
            AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, deathVolume);
        }
    }

}
