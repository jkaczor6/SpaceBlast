using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Shooting SFX")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0f, 1f)] float shootingVolume = 1f;
    [Header("Explosion SFX")]
    [SerializeField] AudioClip explosionClip;
    [SerializeField] [Range(0f, 1f)] float explosionVolume = 1f;

    public void PlayShootingSFX()
    {
        if(shootingClip != null)
        {
            AudioSource.PlayClipAtPoint(shootingClip, Camera.main.transform.position, shootingVolume);
        }
    }
    public void PlayExplosionSFX()
    {
        if(explosionClip != null)
        {
            AudioSource.PlayClipAtPoint(explosionClip, Camera.main.transform.position, explosionVolume);
        }
    }
}
