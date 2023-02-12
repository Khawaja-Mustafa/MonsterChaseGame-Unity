using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //As the access specifiers are private, hence using [SerializeFeild] for gettin accessing to object values in panel like public
    [SerializeField]
    private float moveforce = 10f;
    [SerializeField]
    private float jumpforce = 11f;
    //public float maximumvelocity = 22f;
    private float movementX;

    private bool isGrounded = true;
    private string Ground_Tag = "Ground";

    private string ENEMY_TAG = "Enemy";

    [SerializeField]
    private Rigidbody2D mybody;

    private SpriteRenderer sr;

    private Animator anim;

    private string WALK_ANIMATION = "Walk";

    //Awake function is the first function before start function, and it is usually used for initialization and declaration
    private void Awake()
    {
        //We are getting the component of rigid body through code in mybody object
        mybody = GetComponent<Rigidbody2D>();

        //Getting component of Animator declared in anim
        anim = GetComponent<Animator>();

        //Getting component of SpriteRender initialized in sr
        sr = GetComponent<SpriteRenderer>();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame and it is called in every framce
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
        PlayerJump();
    }

    // FixedUpdate is called not in every time framce, it is called on specific time frames. Usually it is used for physic calculations and while using rigid body
    private void FixedUpdate()
    {
        //PlayerJump();
    }

    void PlayerMoveKeyboard()
    {
        //Input.GetAxixRaw provides 3 input values -1,0,1,
        //Input.GetAxis also provide between values in points
        //movementX would contain the Axix values in float
        movementX = Input.GetAxisRaw("Horizontal");

        transform.position += new Vector3(movementX, 0f, 0f) * moveforce * Time.deltaTime;
    }
  
    //This function aids in
    void AnimatePlayer()
    {
        //to move right
        if (movementX > 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        }
        else if(movementX < 0) //to move left
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true; //flips the animation towards leftside
        }
        else //to stay Idle
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
    }
    //Add jumping capability
    void PlayerJump()
    {
        //Input.GetButtonDown("Jump") is device dependent, it would operate when button is pressed according to the device, like spacebar for pc, button for mobile, etc.
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            mybody.AddForce(new Vector2(0f, jumpforce), ForceMode2D.Impulse);
            //Debug.Log("Jumped Pressed");
        }
    }
    //This adds capability of jumping only once, and avoid jumping in midair, as it checks for collision with ground and initilized is_ground==true
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Ground_Tag))
        {
            isGrounded = true;
            //Debug.Log("We have landed on ground");
        }
        if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
            //hello
        }
    }
}
