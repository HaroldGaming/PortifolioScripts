using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public float moveSpeed, jumpHeight;
    public bool allowMove;
    private bool jumped;
    public AudioClip flap;
    public Rigidbody2D rig2D;
    private SoundManager soundManager;
	
	void Start () {//sets the rigidbody of the player
        jumped = true;
        allowMove = true;
        rig2D = GetComponent<Rigidbody2D>();
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
    }
	
	void Update () {
        if (allowMove) {// for if you need to disable the player movement
            if (!jumped) {
                Jump();
            }
            Move();
        }
	}

    void Jump() {
        if (Input.GetButtonDown("Jump")) {
            soundManager.PlaySound(flap, 0.7F);
            rig2D.velocity = new Vector2(0, jumpHeight);
            jumped = true;
        }
    }

    void OnCollisionEnter2D(Collision2D col) {
        if(col.transform.tag == "Platform") {
            jumped = false;
        }
    }

    void Move() {
        if (Input.GetAxis("Horizontal") < 0) {
            transform.Translate(Vector3.right * moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime);
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else {
            transform.Translate(Vector3.left * moveSpeed * -Input.GetAxis("Horizontal") * Time.deltaTime);
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }
}
