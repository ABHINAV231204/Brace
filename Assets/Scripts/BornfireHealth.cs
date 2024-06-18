using System.Collections;
using UnityEngine;

public class BornfireHealth : MonoBehaviour
{
    [SerializeField]
    float rate = 20f; // Healing rate per second

    PlayerCombat pc;
    public Fire action;

    [SerializeField]
    float wait = 2f; // Delay before healing starts

    private bool isHealing = false;
    public ParticleSystem healingParticles;

    public AudioClip healSound;
    public AudioSource SFXspeaker;

    [SerializeField]
    float soundInterval = 1f; // Interval between heal sounds

    void Start()
    {
        pc = gameObject.GetComponent<PlayerCombat>();
    }

    void Update()
    {
        Debug.Log("do player health and max health match = " + (pc.playerHealth == pc.playermaxHealth));
        Debug.Log("status of action.isSitting = " + action.isSitting);

        if (action.isSitting && pc.playerHealth < pc.playermaxHealth && !isHealing)
        {
            StartCoroutine(StartHealing());
        }
        else
        { 
            var em = healingParticles.emission;
            em.rateOverTime = 0;
        }
    }

    IEnumerator StartHealing()
    {
        isHealing = true;
        yield return new WaitForSeconds(wait); // Wait for 2 seconds

        StartCoroutine(PlayHealSoundRepeatedly());

        while (action.isSitting && pc.playerHealth < pc.playermaxHealth)
        {
            var em = healingParticles.emission;
            em.rateOverTime = 5f;

            pc.playerHealth += (int)(rate * Time.deltaTime);
            pc.hb.setHealth(pc.playerHealth);
            Debug.Log(pc.playerHealth);

            yield return null; // Wait for the next frame
        }

        isHealing = false;
        StopCoroutine(PlayHealSoundRepeatedly());
    }

    IEnumerator PlayHealSoundRepeatedly()
    {
        while (isHealing)
        {
            SFXspeaker.PlayOneShot(healSound);
            yield return new WaitForSeconds(soundInterval);
        }
    }
}
