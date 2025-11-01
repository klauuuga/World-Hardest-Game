using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour
{
    public static CambioEscena Instance;
    [SerializeField] private int sceneToLoad;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        GameManager.Instance.SetCambioEscena(this.gameObject);
    }

    public void LoadSceneByIndex()
    {
        GameManager.Instance.SetCoins(0);
        SceneManager.LoadScene(sceneToLoad);
    }
}