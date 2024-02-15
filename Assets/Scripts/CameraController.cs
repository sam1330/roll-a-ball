using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CammeraController : MonoBehaviour
{
    public GameObject jugador;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - jugador.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = jugador.transform.position + offset;
    }

    public void LoadMainMenu()
    {
        // Replace "MainMenu" with the name or index of your main menu scene
        SceneManager.LoadScene(0);
    }

    public void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
