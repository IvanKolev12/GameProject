using UnityEngine;

public class Bird : MonoBehaviour
{
    public float upForce;                   //Upward force of the "flap".
    private bool isDead = false;            //Has the player collided with a wall or the ground?

    private Animator anim;                  //Reference to the Animator component.
    private Rigidbody2D rb2d;               //Holds a reference to the Rigidbody2D component of the bird.
    private AudioControl ac;                //Holds a reference to the Audio Controller.

    void Start()
    {
        //Get reference to the Animator component attached to this GameObject.
        anim = GetComponent<Animator>();
        //Get and store a reference to the Rigidbody2D attached to this GameObject.
        rb2d = GetComponent<Rigidbody2D>();
        //Get and store a reference to the AudioControl attached to this GameObject.
        ac = GetComponent<AudioControl>();
    }

    void Update()
    {
        if (isDead == false)
        {
            //Look for input to trigger a flap.
            if (Input.GetMouseButtonDown(0))
            {
                //Trigger the flap animation.
                anim.SetTrigger("Flap");
                //Zero out the bird's current y velocity. 
                rb2d.velocity = Vector2.zero;
                //Giving the bird upward force and play the flap sound.
                rb2d.AddForce(new Vector2(0, upForce));
                ac.PlayFlapSound();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // Zero out the bird's velocity.
        rb2d.velocity = Vector2.zero;

        // If the bird collides with column or the ground the bird is dead and isDead is set to true.
        isDead = true;
        //Trigger the die animation.
        anim.SetTrigger("Die");
        
        //Play game over sound and trigger the game over screen.
        ac.PlayDieSound();
        GameControl.instance.BirdDied();
    }
}