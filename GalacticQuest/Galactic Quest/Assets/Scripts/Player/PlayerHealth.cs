using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private CanvasMain canvasMainScript;
    [SerializeField] private GameObject canvasObject;

    [Header("Health Atributes")]
    [SerializeField] private float maxHealth;
    [SerializeField] private GameObject playerExplosion;
    private float currentHealth;

    private bool shieldsUp = false;
    private bool invunerable = false;

    private void Awake()
    {

        canvasMainScript = canvasObject.GetComponent<CanvasMain>();
    }
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Player damage
    public void PlayerDamage(float damage)
    {



        if (!shieldsUp)
        {
            if (!invunerable)
            {
                currentHealth -= damage;
                invunerable = true;
                StartCoroutine(Invunerability());
                canvasMainScript.PlayerLivesUpdate(currentHealth);
                if (currentHealth < 0)
                {
                    Instantiate(playerExplosion, transform.position, Quaternion.identity);
                  
                }
            }
            
            
        }
        else
        {
            shieldsUp = false;
            transform.GetChild(1).gameObject.SetActive(false);
        }


    }

    public void PlayerShields(bool _shieldsUp)
    {
        shieldsUp = _shieldsUp;
    }

    IEnumerator Invunerability()
    {
        yield return new WaitForSeconds(1);
        invunerable = false;

    }
}
