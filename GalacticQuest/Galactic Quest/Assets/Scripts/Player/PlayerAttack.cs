using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Attack Atributes")]
    [SerializeField] private float countDown;
    [SerializeField] private GameObject playerBullet;
    [SerializeField] private GameObject trippleBullet;
    [SerializeField] private Transform firePoint;
    private bool bulletCooldown = true;
    private bool trippleshotActive = false;

    


    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            OnFire();

        }
    }

    public void OnFire()
    {

        if (bulletCooldown)
        {
            
            if (!trippleshotActive)
            {
                Instantiate(playerBullet, firePoint.position, Quaternion.identity);
                bulletCooldown = false;
                StartCoroutine(BulletCoolDownTimer());
            }
            else
            {
                Instantiate(trippleBullet, firePoint.position, Quaternion.identity);
                bulletCooldown = false;
                StartCoroutine(BulletCoolDownTimer());
            }


        }
    }

    IEnumerator BulletCoolDownTimer()
    {
        yield return new WaitForSeconds(countDown);
        bulletCooldown = true;
    }


    public void TrippleShotActivateDeactivate(bool _activate)
    {
        trippleshotActive = _activate;
    }
}
