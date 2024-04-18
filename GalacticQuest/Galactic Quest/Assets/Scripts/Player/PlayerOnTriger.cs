using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnTriger : MonoBehaviour
{
    private PlayerMovement playerMovementScript;
    private PlayerAttack playerAttackeScript;
    private PlayerHealth playerHealthScript;

    [Header("Power Up Timers")]
    [SerializeField] private float sbTimer;
    [SerializeField] private float trippleShotTimer;

    [Header("Audio")]
    [SerializeField] private AudioClip[] audioClips;
    private AudioSource audio;

    private void Awake()
    {
        playerMovementScript = GetComponent<PlayerMovement>();
        playerAttackeScript = GetComponent<PlayerAttack>();
        playerHealthScript = GetComponent<PlayerHealth>();
        audio = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {


        if (other != null)
        {
            if (other.tag == "SpeedBoost")
            {
                StartCoroutine(SpeedBoostTimer());
                audio.clip = audioClips[0];
                audio.Play();
                Destroy(other.gameObject);
            }

            if (other.tag == "Shield")
            {

                transform.GetChild(1).gameObject.SetActive(true);
                playerHealthScript.PlayerShields(true);
                audio.clip = audioClips[0];
                audio.Play();

                Destroy(other.gameObject);

            }

            if (other.tag == "TrippleShot")
            {
                StartCoroutine(TrippleShot());
                audio.clip = audioClips[0];
                audio.Play();
                Destroy(other.gameObject);
            }

            if (other.tag == "Astroid")
            {
                
                playerHealthScript.PlayerDamage(1);
            }
        }


    }

    IEnumerator SpeedBoostTimer()
    {
        playerMovementScript.SpeedBoost(2);
        yield return new WaitForSeconds(sbTimer);
        playerMovementScript.SpeedBoost(1);
    }

    IEnumerator TrippleShot()
    {
        playerAttackeScript.TrippleShotActivateDeactivate(true);
        yield return new WaitForSeconds(trippleShotTimer);
        playerAttackeScript.TrippleShotActivateDeactivate(false);
    }



}
