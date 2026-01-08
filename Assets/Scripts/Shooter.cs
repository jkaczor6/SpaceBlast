using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("Base Variables")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 5f;
    [SerializeField] float baseFiringRate = 0.4f;
    [Header("AI Variables")]
    [SerializeField] bool useAI;
    [SerializeField] float minFireRate = 0.2f;
    [SerializeField] float fireRateVariance = 0f;

    [HideInInspector] public bool isFiring = false;
    Coroutine fireCoroutine;
    AudioManager audioManager;

    void Start()
    {
        audioManager = FindFirstObjectByType<AudioManager>();
        if(useAI)
        {
            isFiring = true;
        }
    }

    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if(isFiring && fireCoroutine == null)
        {
            fireCoroutine = StartCoroutine(FireContinuously());
        }
        else if (!isFiring && fireCoroutine != null)
        {
            StopCoroutine(fireCoroutine);
            fireCoroutine = null;
        }
    }

    IEnumerator FireContinuously()
    {
        while(isFiring)
        {
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

            projectile.transform.rotation = transform.rotation;

            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

            rb.linearVelocity = transform.up * projectileSpeed;

            Destroy(projectile, projectileLifetime);

            float waitTime = Random.Range(baseFiringRate - fireRateVariance, baseFiringRate + fireRateVariance);
            waitTime = Mathf.Clamp(waitTime, minFireRate, float.MaxValue);

            audioManager.PlayShootingSFX();

            yield return new WaitForSeconds(waitTime);
        }
    }
}
