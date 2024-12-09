using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo : MonoBehaviour
{

    [SerializeField] float rotationSpeed = -11.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        // Gira el obstaculo cuando cae
        transform.Rotate(0, 0, rotationSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject); //destruye el gatete
            GameManager.Instance.GameOver(); // puedo llamara  esta clase porque es una instancia,
                                             // mira la firma de la clase

        }

        if(collision.gameObject.tag == "Ground")
        {
            //has tocado el suelo
            Destroy(gameObject);
            GameManager.Instance.IncrementScore();// como has sobrevivido, sube un punto
        }
    }
}
