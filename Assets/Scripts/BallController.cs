using UnityEngine;

public class BallController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    [SerializeField] private float force = 1f;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private Transform ballAnchor;
    private Rigidbody ballRB;
    private bool isBallLaunched;
    void Start()
    {
        //Grabbing a reference to RigidBody
        ballRB = GetComponent<Rigidbody>();
        // Add a listener to the OnSpacePressed event.
        // When the space key is pressed the
        // LaunchBall method will be called.
        inputManager.OnSpacePressed.AddListener(LaunchBall);
        ballRB.isKinematic = true;
        transform.parent = ballAnchor;
        transform.localPosition = Vector3.up * 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LaunchBall()
    {
        
        // now your if check can be framed like a sentence
        // "if ball is launched, then simply return and do nothing"
        if (isBallLaunched) return;
        // "now that the ball is not launched, set it to true and launch the ball"
        isBallLaunched = true;
        transform.parent = null;
        ballRB.isKinematic = false;
        ballRB.AddForce(transform.forward * force, ForceMode.Impulse);
    }

}
