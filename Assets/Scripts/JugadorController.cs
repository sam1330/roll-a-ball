using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class JugadorController : MonoBehaviour
{
    private Rigidbody rb;
    public float velocidad;
    private int contador;
    public Text textoContador, textoGanar;
    public Button nextLevelButton, quitButton;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        contador = 0;
        
        setTextoContador();
        textoGanar.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        //Estas variables nos capturan el movimiento en horizontal y vertical de nuestro teclado
        float movimientoH = Input.GetAxis("Horizontal");
        float movimientoV = Input.GetAxis("Vertical");
        //Un vector 3 es un trío de posiciones en el espacio XYZ, en este caso el que corresponde al movimiento
        Vector3 movimiento = new Vector3(movimientoH, 0.0f, movimientoV);
        //Asigno ese movimiento o desplazamiento a mi RigidBody
        rb.AddForce(movimiento * velocidad);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coleccionable"))
        {
            other.gameObject.SetActive(false);
            contador = contador + 1;
            setTextoContador();
        }

        if (other.gameObject.CompareTag("FallDetector"))
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            // Reload the current scene
            SceneManager.LoadScene(currentSceneIndex);
        }
    }

    void setTextoContador(){
        textoContador.text = "Contador: " + contador.ToString();
        if (contador >= 12){
        textoGanar.text = "¡Ganaste!";
        nextLevelButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
    }
}
}
