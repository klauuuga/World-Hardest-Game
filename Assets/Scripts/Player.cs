using TMPro;
using UnityEngine;
public class Player : MonoBehaviour
{
    [SerializeField] private TMP_Text textoScore;
    [SerializeField] float velocidad;
    [SerializeField] private int puntos = 2;
    private Vector3 posicionInicial;


    void Start()
    {
        textoScore = GameManager.Instance.GetScoreText();
        posicionInicial = transform.position;
        gameObject.transform.position = posicionInicial;
        //Establece uns rotacion con grados Euler
        this.gameObject.transform.rotation = Quaternion.Euler(0,0,0);
    }

  
    void Update()
    {
        PlayerMovement();
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {        
        if (other.gameObject.CompareTag("Moneda")) //Comparación de Tag
        {
            GameManager.Instance.AddCoins(1);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Trampa")) //Comparación de Tag
        {
            transform.position = posicionInicial;
        }
        else if (other.gameObject.CompareTag("condicionPasada"))
        {
            CambioEscena.Instance.ChangeLevel();
        }
    }

    private void PlayerMovement()
    {
        float hInput = Input.GetAxisRaw("Horizontal"); //Esto puede darte -1/0/1
        float vInput =Input.GetAxisRaw("Vertical");

        Vector3 vectorM = new Vector3(hInput,vInput,0).normalized;
        //gameObject.transform.position += vectorM * (velocidad * Time.deltaTime);
        transform.Translate(vectorM * (velocidad * Time.deltaTime),Space.World); //Pensado para hacer translaciones
    }
} 