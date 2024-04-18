using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject explosion;
    

    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < -9)
        {
            transform.position = new Vector3(transform.position.x, 9, transform.position.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other != null)
        {
            if(other.tag == "PlayerBullet")
            {

                
                Instantiate(explosion, transform.position,Quaternion.identity);
                Destroy(other.gameObject);
                Destroy(gameObject);

            }

            if (other.tag == "Player")
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }

            
           
        }
    }
}
