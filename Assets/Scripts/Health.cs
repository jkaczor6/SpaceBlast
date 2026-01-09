using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 100;
    [SerializeField] ParticleSystem hitParticles;
    [SerializeField] bool applyCameraShake;
    [SerializeField] bool isEnemy;
    [SerializeField] int scoreValue = 50;
    CameraShake cameraShake;
    AudioManager audioManager;
    ScoreKeeper scoreKeeper;

    void Start()
    {
        audioManager = FindFirstObjectByType<AudioManager>();
        cameraShake = Camera.main.GetComponent<CameraShake>();
        scoreKeeper = FindFirstObjectByType<ScoreKeeper>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        if (damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            PlayHitParticles();
            damageDealer.Hit();
            if (applyCameraShake)
            {
                cameraShake.Play();
            }
            audioManager.PlayExplosionSFX();
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (isEnemy)
        {
            scoreKeeper.SetScore(scoreValue);
            Debug.Log(scoreKeeper.GetScore());
        }
        Destroy(gameObject);
    }

    void PlayHitParticles()
    {
        if (hitParticles != null)
        {
            ParticleSystem particles = Instantiate(hitParticles, transform.position, Quaternion.identity);
            Destroy(particles, particles.main.duration + particles.main.startLifetime.constantMax);
        }
    }
}
