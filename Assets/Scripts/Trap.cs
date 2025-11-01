using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] Vector3 direccionInicial;
    [SerializeField] float tiempoA;
    private Vector3 direcciónActual;
    private float timer;
    void Start()
    {
        direcciónActual = direccionInicial;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        transform.Translate(direcciónActual * velocidad * Time.deltaTime);
        if (timer >= 2f)
        {
            direcciónActual *= -1; 
            timer = 0;
        }
       
    }     
}