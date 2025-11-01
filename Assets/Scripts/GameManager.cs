using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private TMP_Text textoScore;
    [SerializeField] private GameObject cambioEscena;
    [SerializeField] private int moneda = 0;

    private void Awake()
    {
        Instance = this;
    }

    public void SetCambioEscena(GameObject go)
    {
        cambioEscena = go;
        cambioEscena.SetActive(false);
    }

    public TMP_Text GetScoreText() {  return textoScore; }

    public int GetCoins() { return moneda; }
    public void SetCoins(int nuevasMonedas) { moneda = nuevasMonedas; }
    public void AddCoins(int addedCoins)
    {
        moneda += addedCoins;
        UpdateCoinsUI();
        CheckCoins();
    }
    private void UpdateCoinsUI()
    {
        textoScore.text = $"Coins: {moneda}";
    }
    private void CheckCoins()
    {
        if (moneda >= 2)
        {
            cambioEscena.SetActive(true);
        }
    }
}