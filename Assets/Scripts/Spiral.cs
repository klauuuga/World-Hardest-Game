using UnityEngine;

public class Spiral : MonoBehaviour
{
    [SerializeField] private float velocidadRotacion;
    [SerializeField] private Vector3 direccionRotacion;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(direccionRotacion *(velocidadRotacion * Time.deltaTime), Space.World);
    }
}
