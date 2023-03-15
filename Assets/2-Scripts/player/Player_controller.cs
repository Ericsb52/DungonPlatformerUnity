using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_controller : MonoBehaviour
{
    [Header("player modifieres")]
    public int curHp;
    public int maxHp;
    public int score;
    public float jump_force;
    public float move_speed;
    public int maxJumps;
    private int jumps_available;
    private float curMoveInput;
    public List<GameObject> curStandingGameObjects;


    [Header("Sound effects")]
    public AudioClip[] sound_fx;

    [Header("Components")]
    public Rigidbody2D rig;
    public Animator animator;
    public AudioSource audio;
    public Transform muzzle;

    [Header("animation states")]
    public bool is_idle;
    public bool is_walking;
    public bool is_jumping;
    public bool is_running;
    public bool is_attacking;
    public bool is_dead;
    public bool is_hurt;




    //unity methods
    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        muzzle = GetComponentInChildren<Muzzle>().GetComponent<Transform>();
        
    }


    // Start is called before the first frame update
    void Start()
    {
        curHp = maxHp;
        jumps_available = maxJumps;
    }

    private void FixedUpdate()
    {
        move();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //collision methods
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].point.y<transform.position.y)
        {
            jumps_available = maxJumps;
            is_jumping = false;
            animator.SetBool("is_jumping", false);
            if (!curStandingGameObjects.Contains(collision.gameObject))
                curStandingGameObjects.Add(collision.gameObject);
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        
    }


    public void jump()
    {
        is_jumping = true;
        animator.SetTrigger("is_jumping");

        rig.velocity = new Vector2(rig.velocity.x, 0);
        rig.AddForce(Vector2.up * jump_force, ForceMode2D.Impulse);
    }

    public void move()
    {

        
        rig.velocity = new Vector2(curMoveInput * move_speed, rig.velocity.y);
        if(curMoveInput != 0.0f)
        {
            
            transform.localScale = new Vector3(curMoveInput > 0 ? 1 : -1, 1, 1);
            if ( !is_jumping )
            {
                animator.SetBool("is_walking", true);
                animator.SetBool("is_idle", false);
            }
            
        }
        else
        {
            animator.SetBool("is_idle", true);
            animator.SetBool("is_walking", false);

        }
   


    }

    public void take_dmg(int dmg)
    {
        animator.SetTrigger("is_hurt");
        curHp -= dmg;
        if(curHp <= 0)
        {
            die();
        }
    }

    public void die()
    {
        print("player has died");
    }

    public void respawn()
    {

    }

    public void attack_std()
    {
        animator.SetTrigger("is_attacking");
    }
    public void attack_strong()
    {

    }

    public void attack_shoot()
    {

    }



    // input methods
    public void onMoveInput(InputAction.CallbackContext context)
    {
        curMoveInput = context.ReadValue<float>();
    }

    public void onJumpInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed) {
        if(jumps_available > 0)
            {
                jumps_available--;
                jump();
            }
        
        }

    }
    public void onAttackInputStd(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            attack_std();
        }
    }










}
