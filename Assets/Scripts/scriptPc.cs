using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Jobs;

public class scriptPc : MonoBehaviour
{
    private bool direita = true;
    float elapsedTime = 0f;
    float jumpTime = 0f;
    public LayerMask deteccao;
    public GameObject pe;
    private bool chao;
    private Rigidbody2D rbd;
    private Animator anim;
    public float fallingThreshold = -16f;
    private bool isFalling = false;
    private bool isJumping = false;
    private bool isRunning = false;
    public float vel;
    public float pulo;

    AudioManager audioManager;
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        vel = 9;
        pulo = 900;
        rbd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        float x = Input.GetAxis("Horizontal");

        rbd.velocity = new Vector2(x * vel, rbd.velocity.y);

        if(x == 0)
        {
            anim.SetBool("moving", false);
            anim.SetBool("running", false);
            if (chao)
            {
                audioManager.StopSFX();
            }
        } else
        {
            if (chao)
            {
                anim.SetBool("moving", true);
                if(!Input.GetKey(KeyCode.V))
                    audioManager.PlayWalkingSFX();
            }
            else
                audioManager.StopSFX();
        }

        if(Input.GetKeyDown(KeyCode.Space) && chao)
        {
            rbd.AddForce(new Vector2(0, pulo));

            anim.SetBool("jumping", true);
            audioManager.StopSFX();
            audioManager.PlaySFX(audioManager.jump);
            isJumping = true;
            jumpTime = elapsedTime;
        }

        if(elapsedTime - jumpTime >= 0.3f && chao)
        {
            anim.SetBool("jumping", false);
            isJumping = false;
        }

        if (elapsedTime - jumpTime >= 0.8f && !chao && rbd.velocity.y < fallingThreshold)
        {
            anim.SetBool("jumping", false);
            anim.SetBool("running", false);
            isJumping = false;
            anim.SetBool("falling", true);
            isFalling = true;
        }

        if (Input.GetKey(KeyCode.V) && !isJumping && !isFalling)
        {
            vel = 18;
            isRunning = true;
            if (x != 0)
            {
                anim.SetBool("moving", false);
                anim.SetBool("running", true);
                audioManager.PlayRunningSFX();
            }
        } else if (!isJumping && !isFalling)
        {
            vel = 9;
            anim.SetBool("running", false);
            isRunning = false;
        }

        if (x < 0 && direita || x > 0 && !direita)
        {
            transform.Rotate(new Vector2(0, 180));
            direita = !direita;
        }

        if (rbd.velocity.y < fallingThreshold && !isFalling && !isJumping)
        {
            isFalling = true;
            anim.SetBool("falling", true);
        } else if (chao && isFalling && !isJumping)
        {
            isFalling = false;
            anim.SetBool("falling", false);
        }

        if (rbd.velocity.y < -2 && rbd.velocity.y > fallingThreshold && !isJumping && !isRunning)
        {
            anim.SetBool("smallfall", true);
        } else
        {
            anim.SetBool("smallfall", false);
        }

        RaycastHit2D hit = Physics2D.Raycast(pe.transform.position, Vector2.down, 0.3f, deteccao);

        if(hit.collider == null)
        {
            chao = false;
            transform.parent = null;
        }
        else
        {
            chao = true;
            transform.parent = hit.collider.transform;
        }
    }

    //private void OnCollisionEnter2D(Collision2D other)
    //{
     //   if(other.gameObject.tag == "NPC" && (isJumping || isFalling))
     //   {
     //       Destroy(other.gameObject);
     //   }
    //}
}
    
