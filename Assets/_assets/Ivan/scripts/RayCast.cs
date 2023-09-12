using UnityEngine;

public class RayCast : MonoBehaviour
{
    public string targetTag = "InstaKill"; // El tag del objeto que quieres detectar
    public float raycastDistance = 10.0f; // La distancia máxima del rayo

    void Update()
    {
        // Crear un rayo desde la posición del objeto en la dirección hacia adelante (puede personalizar esto según tus necesidades)
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        Debug.DrawRay(ray.origin,ray.direction*raycastDistance,Color.blue);

        // Realizar el raycast y verificar si se ha impactado con un objeto que tenga el tag deseado
        if (Physics.Raycast(ray, out hit, raycastDistance, LayerMask.GetMask("enemy")))
        {
            // Verificar si el objeto impactado tiene el tag deseado
            if (hit.collider.CompareTag(targetTag))
            {
                GameObject enemigoDetectado = hit.collider.gameObject;
                hit.collider.GetComponent<enemyController>().Moved();
            }
        }
    }
}
