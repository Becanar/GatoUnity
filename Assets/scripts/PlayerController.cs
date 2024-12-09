using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer rbSprite;
    public float moveSpeed=4f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rbSprite = rb.GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {        
    }

    // Update is called once per frame
    void Update()
    {
        print("hola");
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            if(Input.mousePosition.x < Screen.width / 2)
            {
                // si se ha pulsado de la mitad de la pantalla para izquierda o derecha
                rb.velocity = Vector2.left * moveSpeed;
                //que se de la vuelta
                //gameObject.transform.localScale = new Vector3(-0.4f, 0.4f, 0.4f);
                rbSprite.flipX = true;
            } 
            else
            { 
                rb.velocity = Vector2.right * moveSpeed;
                //que se de la vuelta
                //gameObject.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
                rbSprite.flipX = false;
            }
        }

    }
}
