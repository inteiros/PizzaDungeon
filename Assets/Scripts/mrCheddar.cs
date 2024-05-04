using UnityEngine;
using UnityEngine.SceneManagement;

public class mrCheddar : MonoBehaviour
{
    private Rigidbody2D rbd;
    public float vel = 3;
    public GameObject a;
    public GameObject b;
    private Animator anim;
    private Transform pontoAtual;
    private bool isDead = false;
    private Collider2D col;

    AudioManager audioManager;

    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        rbd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        pontoAtual = b.transform;
        col = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (!isDead)
        {
            if (pontoAtual == b.transform)
            {
                rbd.velocity = new Vector2(vel, 0);
            }
            else
            {
                rbd.velocity = new Vector2(-vel, 0);
            }

            if (Vector2.Distance(transform.position, pontoAtual.position) < 1.5f && pontoAtual == b.transform)
            {
                girar();
                pontoAtual = a.transform;
            }
            if (Vector2.Distance(transform.position, pontoAtual.position) < 1.5f && pontoAtual == a.transform)
            {
                girar();
                pontoAtual = b.transform;
            }
        }
    }

    private void girar()
    {
        Vector3 escalaLocal = transform.localScale;
        escalaLocal.x *= -1;
        transform.localScale = escalaLocal;
    }
    private void LoadMenuScene()
    {
        SceneManager.LoadSceneAsync(0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isDead)
        {
            if (collision.contacts[0].normal.y < -0.5f)
            {
                audioManager.PlaySFX(audioManager.ratdeath);
                isDead = true;
                anim.SetBool("isDead", true);
                rbd.velocity = Vector2.zero;
                rbd.AddForce(Vector2.up * 700f);
                col.enabled = false;
                Destroy(gameObject, 10f);
            }
            else
            {
                Animator pcAnim = collision.gameObject.GetComponent<Animator>();
                audioManager.PlaySFX(audioManager.death);
                pcAnim.SetBool("playerdeath", true);
                Rigidbody2D pcRbd = collision.gameObject.GetComponent<Rigidbody2D>();
                if (pcRbd != null)
                {
                    pcRbd.velocity = Vector2.zero;
                    pcRbd.AddForce(Vector2.up * 900f);
                }
                Collider2D pcCol = collision.gameObject.GetComponent<Collider2D>();
                pcCol.enabled = false;
                Invoke("LoadMenuScene", 2f);
            }
        }
    }
}
