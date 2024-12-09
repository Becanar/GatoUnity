using System.Collections;
using System.Collections.Generic;
using TMPro; // Para el uso de TextMeshPro (UI de texto)
using UnityEngine; // Para las funcionalidades principales de Unity
using UnityEngine.SocialPlatforms.Impl; // No parece ser necesario, se puede eliminar si no usas redes sociales
using UnityEngine.UI; // Para el uso de UI (interfaz de usuario)
using UnityEngine.SceneManagement; // Para la gestión de escenas (cargar nuevas escenas)

public class GameManager : MonoBehaviour
{
    // Instancia estática de este script para acceso global
    public static GameManager Instance;
    
    // Variable para controlar si el juego ha terminado
    bool gameOver = false;
    
    // Referencia al marcador de la UI (el texto que muestra la puntuación)
    public Text marcador;
    
    // Variable para almacenar la puntuación
    private int puntuacion = 0;
    
    // Panel de fin de juego que aparece cuando se termina
    public GameObject panel;

    // Este método se llama cuando el script se carga
    private void Awake()
    {
        // Establece la instancia de GameManager para acceder globalmente a él
        Instance = this;
    }

    // Este método se llama al inicio del juego
    void Start()
    {
        // Aquí puedes inicializar cualquier cosa si es necesario
    }

    // Este método se llama en cada frame
    void Update()
    {
        // Aquí puedes añadir lógica que se ejecuta constantemente durante el juego
    }

    // Método que se llama cuando el juego termina
    public void GameOver()
    {
        gameOver = true; // Marca el estado del juego como "terminado"
        
        // Busca el objeto "ObstacleSpawner" y llama al método StopSpawning de su script
        GameObject.Find("ObstacleSpawner").GetComponent<ObstacleSpawner>().StopSpawning();
        
        // Vacía el marcador de texto (lo deja en blanco)
        marcador.text = ""; 
        
        // Activa el panel de fin de juego (por ejemplo, para mostrar la puntuación final)
        panel.SetActive(true);
    }

    // Método que se llama para incrementar la puntuación cuando el jugador obtiene puntos
    public void IncrementScore()
    {
        // Solo permite incrementar la puntuación si el juego no ha terminado
        if (!gameOver)
        {
            puntuacion++; // Incrementa la puntuación en 1
            print(puntuacion); // Muestra la puntuación en la consola para depuración
            marcador.text = puntuacion.ToString(); // Actualiza el texto del marcador con la nueva puntuación
            
            // Si la puntuación es múltiplo de 5, incrementa la velocidad de los obstáculos
            GameObject.Find("ObstacleSpawner").GetComponent<ObstacleSpawner>().IncrementarVelocidad();
        }
    }

    // Método para reiniciar el juego (carga la escena del juego de nuevo)
    public void Restart()
    {
        SceneManager.LoadScene("Game"); // Recarga la escena "Game"
    }

    // Método para volver al menú principal (carga la escena del menú)
    public void Menu()
    {
        SceneManager.LoadScene("Menu"); // Carga la escena "Menu"
    }
}
