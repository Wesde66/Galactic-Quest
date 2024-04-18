using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;

    [Header("Player Movement")]
    [SerializeField] private float _speed;
    [SerializeField] private float speedBoost = 1;
    private Vector3 movementValues;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Movement and clampping postion
        transform.Translate(movementValues.x * (_speed * speedBoost) * Time.deltaTime, movementValues.y * (_speed * speedBoost) * Time.deltaTime, movementValues.z);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -9.5f, 9.5f), Mathf.Clamp(transform.position.y, -3.76f, 2), 0);

        //Player movement animations
        if (movementValues.x > 0.1f)
        {
            animator.SetBool("RightTurn", true);
        }
        else
        {
            animator.SetBool("RightTurn", false);
        }



        if (movementValues.x < -0.1f)
        {
            animator.SetBool("LeftTurn", true);
        }
        else
        {
            animator.SetBool("LeftTurn", false);
        }

    }

    //Player inputs via new input system
    public void OnMovement(InputValue inputValue)
    {
        Vector3 M = inputValue.Get<Vector3>();
        movementValues = M;

    }

    //Called from OnTrigger script to set speed boost
    public void SpeedBoost(float _multiplier) 
    {
        speedBoost =  _multiplier;
    }
}
