using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{
    [SerializeField] private float score = 0;

    [SerializeField] private BallController ball;
    [SerializeField] private GameObject pinCollection;

    [SerializeField] private Transform pinAnchor;
    [SerializeField] private InputManager inputManager;

    [SerializeField] private TextMeshProUGUI scoreText;
    private FallTrigger[] fallTriggers;
    private GameObject pinObjects;

    private void Start()
    {
        //Adding the HandleReset function as a listener to our newly added OnResetPressedEvent
        inputManager.OnResetPressed.AddListener(HandleReset);
        SetPins();
    }

    private void HandleReset()
    {
        ball.ResetBall();
        SetPins();
    }

    private void SetPins()
    {   
        if(pinObjects)
        {
            foreach(Transform child in pinObjects.transform)
            {
                Destroy(child.gameObject);
            }
            Destroy(pinObjects);
        }

        //Instatitate a new set of pins to our pin anchor transform
        pinObjects = Instantiate(pinCollection, pinAnchor.transform.position, Quaternion.identity, transform);

        //Find all objects of type FallTrigger
        fallTriggers = FindObjectsByType<FallTrigger>(FindObjectsInactive.Include, FindObjectsSortMode.None);

        foreach (FallTrigger pin in fallTriggers)
        {
            pin.OnPinFall.AddListener(IncrementScore);
        }
    }

    private void IncrementScore()
    {
        score++;
        scoreText.text = $"Score: {score}";
    }
}