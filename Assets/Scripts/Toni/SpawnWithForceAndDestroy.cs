using UnityEngine;

public class SpawnWithForceAndDestroy : MonoBehaviour
{
    public GameObject objectToSpawn; // The GameObject to spawn
    public float spawnForce = 30f; // The force to apply when spawning
    public Vector3 spawnDirection = Vector3.forward; // The forward direction to apply force
    public float destroyDelay = 3f; // Time to wait before destroying the spawned object

    private float timer = 0f;
    private float delay = 1f;

    void Update()
    {
        timer += Time.deltaTime;

        // Check for spacebar input or touch input
        if (Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 0 || Input.GetMouseButtonDown(0))
        {
            if (timer >= delay)
            {
                Shoot();
                timer = 0f;
            }
        }
    }

    void Shoot()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit))
        {
            if (hit.collider.gameObject.name == "Diana") 
            {

            }
        }
    }
}