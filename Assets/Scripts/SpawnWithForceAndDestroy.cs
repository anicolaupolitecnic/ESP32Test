using UnityEngine;

public class SpawnWithForceAndDestroy : MonoBehaviour
{
    public GameObject objectToSpawn; // The GameObject to spawn
    public float spawnForce = 10f; // The force to apply when spawning
    public Vector3 spawnDirection = Vector3.forward; // The forward direction to apply force
    public float destroyDelay = 5f; // Time to wait before destroying the spawned object

    void Update()
    {
        // Check for spacebar input or touch input
        if (Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 0 || Input.GetMouseButtonDown(0))
        {
            SpawnObject();
        }
    }

    void SpawnObject()
    {
        // Instantiate the object
        GameObject spawnedObject = Instantiate(objectToSpawn, transform.position, Quaternion.identity);

        // Apply force using the local forward direction
        Rigidbody rb = spawnedObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Apply force to the spawned object
            rb.AddForce(transform.forward * spawnForce, ForceMode.Impulse);
        }

        // Destroy the spawned object after delay
        Destroy(spawnedObject, destroyDelay);
    }
}