using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
//Aquí esta todo el cambio de escena, interfaz de cada nivel, el texto de monedas, el boton de quit, ...
    [SerializeField] private TMP_Text textoScore;
    [SerializeField] private GameObject cambioEscena;
    [SerializeField] private int moneda = 0;
    [SerializeField] private GameObject[] menus; 

    private void Awake()//Esta es la primera ejecución del código.  
    {
        Instance = this;
    }

    private void Start()//Esta es la segunda ejecución del código. Aquí se inicia el seteo de lo necesario para iniciar el juego. 
    {
        ToggleMainMenu(0); //cambio de interfaz dependiendo de la escena 
        SetCoins(0); //el contador de las monedas esté a 0
        UpdateCoinsUI(); //actualiza la interfaz de las monedas 
    }

    public void ToggleMainMenu(int index) //dependiendo del index(que funciona como un índice), se aplicaría una interfaz/menu u otra
    {
        foreach (GameObject menu in menus) //menus es la lista de los menús disponibles y menu(titulo juego, counter monedas, botones,... ) es cada menu disponible 
        {
            menu.SetActive(false);
        }
        menus[index].SetActive(true);
        

    }

    public void SetCambioEscena(GameObject go) //aplica la linea de meta por nivel (el cubo verde)
    {
        cambioEscena = go;
        cambioEscena.SetActive(false);
    }

    public TMP_Text GetScoreText() {  return textoScore; } //le da la opción de leer el objeto privado, desde otro script externo

    public int GetCoins() { return moneda; } //le da la opción de leer el objeto privado, desde otro script externo
    public void SetCoins(int nuevasMonedas) { moneda = nuevasMonedas; } //le da la opción de escribir(set) el objeto privado, desde otro script externo
    public void AddCoins(int addedCoins) // es una función para añadir monedas
    {
        moneda += addedCoins;
        UpdateCoinsUI();
        CheckCoins();
    }
    private void UpdateCoinsUI() //es el texto en pantalla de las monedas
    {
        textoScore.text = $"Coins: {moneda}";
    }
    private void CheckCoins() //comprobar si el jugador tiene las monedas necesarias para pasar de nivel
    {
        if (moneda >= 2)
        {
            cambioEscena.SetActive(true);
        }
    }
    public void LoadSceneByIndex(int index) //cambiar la escena 
    {
        if (index == 4)
        {
            ToggleMainMenu(2);
        }
        SceneManager.LoadScene(index);
        
    }
    public void AplicationQuit() //para cerrar el juego mediante un botón 
    {
        Application.Quit();
    }
    
}