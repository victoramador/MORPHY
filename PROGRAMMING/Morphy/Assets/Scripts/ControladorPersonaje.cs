using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ControladorPersonaje : MonoBehaviour
{

    public float fuerzaSalto = 100f;
    public bool enSuelo = true;
    public float move = 0f;
    private bool muerto = false;
    private Animator animator;
    public float maxS = 11f;
    private bool flipped = false;
    private Vector3 iniPos;
    public bool isrunning = false;
    public bool issliding=false;
    public bool isattacking = false;
    //public Collider2D coldeslizarse;
    public Collider2D colnormal;
    public AudioSource salto;
    public AudioSource muerte;
    public AudioSource ataque;
    public AudioSource deslizarse;
    public bool onAir;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        iniPos.x = -28;
        iniPos.y = -4;
        //iniPos = transform.position;
        transform.position = iniPos;
        //coldeslizarse.gameObject.SetActive(false);
    }

    // Use this for initialization
    private void OnTriggerEnter2D(  Collider2D col) {
        if (col.gameObject.tag == "suelo")
        {
            enSuelo = true;
            //animator.SetBool("Jump", false);
        }
        else
        {
            enSuelo = false;
            //animator.SetBool("Jump", true);
        }
        if (col.gameObject.tag == "cantjump")
        {
            enSuelo = false;
            //animator.SetBool("Jump", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Kill")
        {
            muerto = true;
            muerte.Play();
            //animator.SetTrigger("Die");
            //Invoke( "Alive",0.5f);
        }
        if (collision.gameObject.tag == "suelo")
        {
            enSuelo = true;
            onAir = false;
            //animator.SetBool("Jump", false);
        }
       
        if (collision.gameObject.tag == "GameOver")
        {
            //muerte.Play();
            Invoke("Alive", 0.2f);
        }
        if (collision.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene("WinStage");
        }
    }
    
        void FixedUpdate() {
        if (Input.GetKeyDown(KeyCode.P))
        {
            MyGameManager.getInstance().Pausa();
        }
        if (MyGameManager.getInstance().pause == true)
        {
            if (onAir == true)
            {
                //animator.SetBool("Jump", true);
            }
            if (muerto == false)
            {
                move = Input.GetAxis("Horizontal");
                GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxS, GetComponent<Rigidbody2D>().velocity.y);
                if (GetComponent<Rigidbody2D>().velocity.x > 0.001f || GetComponent<Rigidbody2D>().velocity.x < -0.001f)
                {
                    if ((GetComponent<Rigidbody2D>().velocity.x < -0.001f && !flipped) || (GetComponent<Rigidbody2D>().velocity.x > -0.001f && flipped))
                    {
                        flipped = !flipped;

                        this.transform.rotation = Quaternion.Euler(0, flipped ? 180 : 0, 0);
                    }
                    //animator.SetBool("Walking", true);
                    if (issliding == true)
                    {
                        //animator.SetBool("Sliding", true);

                    }
                    else if (issliding == false)
                    {
                        //animator.SetBool("Sliding", false);
                    }
                    isrunning = true;
                }
                else if (enSuelo == false)
                {
                    //animator.SetBool("Walking", false);
                    isrunning = false;
                    issliding = false;
                    //animator.SetBool("Jump", true);

                }
                else
                {
                    //animator.SetBool("Walking", false);
                    isrunning = false;
                    issliding = false;
                }

                if (Input.GetButtonDown("Jump") && enSuelo == true && onAir == false)
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, fuerzaSalto);
                    enSuelo = false;
                    if (enSuelo == false)
                    {
                        //animator.SetBool("Jump", true);
                        //salto.Play();
                    }
                }
                if (Input.GetButtonDown("Fire1") && enSuelo == true)
                {
                    //animator.SetBool("Attacking", true);
                    isattacking = true;
                    //ataque.Play();
                    Invoke("Attack", 0.8f);

                }
                if (Input.GetButtonDown("Fire2") && enSuelo == true && isrunning == true)
                {
                    issliding = true;
                    //deslizarse.Play();
                    colnormal.gameObject.SetActive(false);
                    //coldeslizarse.gameObject.SetActive(true);
                    Invoke("Slide", 4);
                }

            }
        }
    }
    void Slide()
    {
        issliding = false;
        colnormal.gameObject.SetActive(true);
        //coldeslizarse.gameObject.SetActive(false);
    }
    void Alive()
    {
        transform.position = iniPos;
        MyGameManager.getInstance().Loselife();
        muerto = false;
        //Invoke("Vivo", 0.05f);
    }
    void Attack()
    {
        isattacking = false;
        //animator.SetBool("Attacking", false);
    }
    void Vivo()
    {
        //animator.SetTrigger("Alive");
    }
}
