using UnityEngine;

public class CambioEscena : MonoBehaviour
{
    public static CambioEscena Instance;
    [SerializeField] private int sceneToLoad;

    private void Awake() //Esta es la primera ejecución del código. 
    {
        Instance = this;
    }

    private void Start() //Esta es la segunda ejecución del código. Referencia esta instancia del objeto, al GameManager(es donde se administra el sistema de monedas)
    {
        GameManager.Instance.SetCambioEscena(this.gameObject);
    }

    public void ChangeLevel() //Aquí se reinicia el contador de las monedas, y se llama al cambio la escena. 
    {
        GameManager.Instance.SetCoins(0); 
        GameManager.Instance.LoadSceneByIndex(sceneToLoad);
    }
}