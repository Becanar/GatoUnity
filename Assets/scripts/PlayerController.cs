using System.Collections; // Para trabajar con colecciones (no se usa en este caso, pero podría ser útil en el futuro)
using System.Collections.Generic; // Para trabajar con colecciones genéricas (también no se usa en este caso)
using UnityEngine; // Para acceder a las funcionalidades de Unity (físicas, UI, etc.)

public class PlayerController : MonoBehaviour
{
    // Referencias a los componentes del objeto
    Rigidbody2D rb; // Para manipular la física del jugador (el cuerpo rígido 2D)
    SpriteRenderer rbSprite; // Para controlar la representación gráfica del jugador (el sprite)
    
    // Velocidad de movimiento del jugador, ajustable desde el Inspector de Unity
    public float moveSpeed = 4f;

    // Este método se llama cuando se carga el script
    private void Awake()
    {
        // Obtiene el componente Rigidbody2D del GameObject para manipular su física
        rb = GetComponent<Rigidbody2D>();
        
        // Obtiene el componente SpriteRenderer para controlar el sprite visual del jugador
        rbSprite = rb.GetComponent<SpriteRenderer>();
    }

    // Start se llama una vez cuando el objeto es inicializado
    void Start()
    {
        // Este método está vacío, pero aquí podrías inicializar valores si es necesario
    }

    // Update se llama una vez por cada frame (cada fotograma de la animación)
    void Update()
    {
        // Para depuración, imprime "hola" en la consola cada frame
        // Esto se usa para verificar si la actualización está funcionando correctamente
        print("hola");
    }

    // FixedUpdate se llama a intervalos fijos y es ideal para trabajar con física
    private void FixedUpdate()
    {
        // Comprueba si el jugador hace clic o mantiene presionado el botón izquierdo del ratón
        if (Input.GetMouseButton(0)) 
        {
            // Si la posición del ratón en el eje X está en la mitad izquierda de la pantalla
            if (Input.mousePosition.x < Screen.width / 2)
            {
                // Establece la velocidad del jugador para moverse hacia la izquierda (Vector2.left)
                rb.velocity = Vector2.left * moveSpeed;
                
                // Da la vuelta al jugador, cambiando el eje X de la escala del objeto
                // Esto se puede usar para invertir la dirección visual del jugador
                // Se comenta porque actualmente se usa `flipX` en lugar de cambiar la escala
                //gameObject.transform.localScale = new Vector3(-0.4f, 0.4f, 0.4f);

                // Utiliza `flipX` en el SpriteRenderer para voltear el sprite hacia la izquierda
                rbSprite.flipX = true;
            }
            else // Si la posición del ratón está en la mitad derecha de la pantalla
            {
                // Establece la velocidad del jugador para moverse hacia la derecha (Vector2.right)
                rb.velocity = Vector2.right * moveSpeed;
                
                // Da la vuelta al jugador, cambiando el eje X de la escala del objeto
                // Este código está comentado y no es necesario si se usa `flipX`
                //gameObject.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);

                // Utiliza `flipX` en el SpriteRenderer para voltear el sprite hacia la derecha
                rbSprite.flipX = false;
            }
        }
    }
}
