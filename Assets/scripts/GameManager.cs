using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    bool gameOver = false;
    public Text marcador;
    private int puntuacion = 0;
    public GameObject panel;



    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GameOver()
    {
        gameOver = true;
        //busca el obstacle spawner, de sus componentes, usa el script, de la clase, usa el m�todo p�blico stop
        GameObject.Find("ObstacleSpawner").GetComponent<ObstacleSpawner>().StopSpawning();
        marcador.text = ""; // Vacía el marcador
        panel.SetActive(true);



    }


    public void IncrementScore()
    {
        if (!gameOver)
        {
            puntuacion++; // Incrementar puntuación
            print(puntuacion);
            marcador.text = puntuacion.ToString(); // Actualiza el marcador con la nueva puntuación
            if (puntuacion % 5 == 0) {
                // Si la puntuación es un multiplo de 5, decirle al ObstacleSpawner de incrementar la velocidad
                GameObject.Find("ObstacleSpawner").GetComponent<ObstacleSpawner>().IncrementarVelocidad();
            }
        }
    }

    public void Restart()
    {
        // Recarga el juego
        SceneManager.LoadScene("Game");
    }

    public void Menu()
    {
        // Carga el menu
        SceneManager.LoadScene("Menu");
    }
}
