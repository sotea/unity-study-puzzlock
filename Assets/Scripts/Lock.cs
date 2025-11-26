using UnityEngine;

public class Lock : MonoBehaviour
{
    [SerializeField] GameObject effect;
    [SerializeField] AudioClip unlockSound;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string keyColor = collision.gameObject.name.Replace("Key", "");
        string lockColor = gameObject.name.Replace("Lock", "");

        if (keyColor == lockColor)
        {
            if (unlockSound != null)
            {
                float volume = 1f;
                if (BgmManager.I != null)
                {
                    volume = BgmManager.I.SfxVolume;
                }
                AudioSource.PlayClipAtPoint(unlockSound, transform.position, volume);
            }

            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
