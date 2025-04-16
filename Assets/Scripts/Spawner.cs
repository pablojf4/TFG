using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Configuracion del Spawn")]
    public GameObject objetoASpawnear; // Prefab del objeto a generar
    public float tiempoEntreSpawn = 2f; // Tiempo entre cada spawn
    public float tiempoDeVidaObjeto = 3f; // Tiempo antes de destruir el objeto spawnedo

    [Header("Zona de Spawn")]
    public bool usarAreaRectangular = false;
    public Vector2 areaMinima = new Vector2(-5f, -5f); // L�mites minimos (x, y)
    public Vector2 areaMaxima = new Vector2(5f, 5f);   // L�mites maximos (x, y)
    public float radioSpawn = 5f; // Radio si se usa zona circular

    private float tiempoSiguienteSpawn;

    void Start()
    {
        tiempoSiguienteSpawn = Time.time + tiempoEntreSpawn;
    }

    void Update()
    {
        if (Time.time >= tiempoSiguienteSpawn)
        {
            SpawnearObjeto();
            tiempoSiguienteSpawn = Time.time + tiempoEntreSpawn;
        }
    }

    void SpawnearObjeto()
    {
        // Calcula posicion aleatoria
        Vector3 posicionAleatoria = CalcularPosicionAleatoria();

        // Instancia el objeto
        GameObject nuevoObjeto = Instantiate(
            objetoASpawnear,
            posicionAleatoria,
            Quaternion.identity
        );

        // Destruye el objeto despues de un tiempo
        Destroy(nuevoObjeto, tiempoDeVidaObjeto);
    }

    Vector3 CalcularPosicionAleatoria()
    {
        if (usarAreaRectangular)
        {
            float x = Random.Range(areaMinima.x, areaMaxima.x);
            float y = Random.Range(areaMinima.y, areaMaxima.y);
            return new Vector3(x, y, 0);
        }
        else
        {
            Vector2 puntoAleatorio = Random.insideUnitCircle * radioSpawn;
            return transform.position + new Vector3(puntoAleatorio.x, puntoAleatorio.y, 0);
        }
    }

    // Dibuja gizmos para visualizar la zona de spawn en el Editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;

        if (usarAreaRectangular)
        {
            Vector3 centro = new Vector3(
                (areaMinima.x + areaMaxima.x) / 2,
                (areaMinima.y + areaMaxima.y) / 2,
                0
            );
            Vector3 tamano = new Vector3(
                areaMaxima.x - areaMinima.x,
                areaMaxima.y - areaMinima.y,
                0.1f
            );
            Gizmos.DrawWireCube(centro, tamano);
        }
        else
        {
            Gizmos.DrawWireSphere(transform.position, radioSpawn);
        }
    }
}