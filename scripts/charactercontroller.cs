using System.Net.Security;
using UnityEngine;

public class charactercontroller : MonoBehaviour
{
    public float velocidad;
    public float fuerzasalto;
    public LayerMask capasuelo;
    private Rigidbody2D rigidbody;
    private BoxCollider2D boxCollider;
    private bool mirandoderecha = true;
    private Animator animator;

    void Start()
    {

        rigidbody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();

    }
    void Update()
    {
        procesarmovimiento();
        procesarsalto();
    }
    bool EstaEnSuelo()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, new Vector2(boxCollider.bounds.size.x, boxCollider.bounds.size.y), 0f, Vector2.down, 0.2f, capasuelo);
        return raycastHit.collider != null;
    }
    void procesarsalto()
    {
        if (Input.GetKeyDown(KeyCode.Space)&& EstaEnSuelo())
        {
            rigidbody.AddForce(Vector2.up * fuerzasalto, ForceMode2D.Impulse);
        }
    }
    void procesarmovimiento()
    {
        float inputmovimiento = Input.GetAxis("Horizontal");
        if (inputmovimiento != 0f)
        {
            animator.SetBool("isruning", true);
        }
        else
        {
            animator.SetBool("isruning", false);
        }

        rigidbody.linearVelocity = new Vector2(inputmovimiento * velocidad, rigidbody.linearVelocityY);
        gestionarorientacion(inputmovimiento);
    }
    void gestionarorientacion(float inputmovimiento)
    {
        if ((mirandoderecha == false && inputmovimiento<0)||(mirandoderecha==true && inputmovimiento>0))
        {
            mirandoderecha = !mirandoderecha;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    } 
}
