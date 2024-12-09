using System.Collections; // Para trabajar con colecciones
using System.Collections.Generic; // Para trabajar con colecciones genéricas
using UnityEngine; // Para usar las funcionalidades de Unity

public class Obstaculo : MonoBehaviour
{
    // Velocidad de rotación del obstáculo, se puede modificar desde el Inspector de Unity
    [SerializeField] float rotationSpeed = -11.0f;

    // Este método se llama una vez cuando el objeto es creado o activado
    void Start()
    {
        // Aquí podrías inicializar otros valores si fuera necesario (actualmente está vacío)
    }

    // Este método se llama una vez por cada frame de actualización
    void Update()
    {
        // El método Update está vacío porque no se usa en este caso
        // Si quisieras hacer algo cada frame, lo pondrías aquí
    }

    // Este método se llama a una tasa fija de actualización (físicas) que no depende de la tasa de frames
    private void FixedUpdate()
    {
        // Gira el objeto (el obstáculo) alrededor del eje Z a la velocidad especificada
        transform.Rotate(0, 0, rotationSpeed);
    }

    // Este método se llama cuando el obstáculo entra en contacto con otro objeto que tiene un Collider2D
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica si el objeto que colisionó tiene la etiqueta "Player"
        if(collision.gameObject.tag == "Player")
        {
            // Si colisiona con el jugador (etiquetado como "Player"), destruye al jugador (el gato)
            Destroy(collision.gameObject);

            // Llama al método GameOver del GameManager para finalizar el juego
            GameManager.Instance.GameOver();
        }

        // Verifica si el objeto que colisionó tiene la etiqueta "Ground"
        if(collision.gameObject.tag == "Ground")
        {
            // Si colisiona con el suelo, destruye el obstáculo
            Destroy(gameObject);

            // Llama al método IncrementScore del GameManager para aumentar la puntuación
            GameManager.Instance.IncrementScore();
        }
    }
}
