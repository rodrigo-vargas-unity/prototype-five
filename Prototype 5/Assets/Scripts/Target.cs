using UnityEngine;

public class Target : MonoBehaviour
{
    public int pointValue;
    public ParticleSystem explosion;


    private Rigidbody targetBody;
    private GameManager gameManager;

    private const int minSpeed = 12;
    private const int maxSpeed = 16;


    // Start is called before the first frame update
    void Start()
    {
        targetBody = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        targetBody.AddForce(
            GenerateRandomForce(),
            ForceMode.Impulse
        );

        targetBody.AddTorque(
            GenerateRandomTorque(),
            GenerateRandomTorque(),
            GenerateRandomTorque(),
            ForceMode.Impulse
        );

        transform.position = new Vector3(Random.Range(-4, 4), -6);
    }

    private static Vector3 GenerateRandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    private static int GenerateRandomTorque()
    {
        return Random.Range(-10, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
        gameManager.UpdateScore(pointValue);
        Instantiate(explosion, transform.position, explosion.transform.rotation);
    }
}
