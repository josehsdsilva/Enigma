using UnityEngine;

public enum State
{
    Disabled,
    Waiting,
    Typing
}

public class DialogueSystem : MonoBehaviour
{
    [SerializeField] private string targetTag;
    [SerializeField] private string playerTag;

    public DialogueData dialogueData;

    public float proximityThreshold = 1f; // Threshold distance to consider them too close

    int currentText = 0;
    bool finished = false;
    GameObject[] targets;
    GameObject[] players;

    TypeTextAnimation typeText;
    DialogueUI dialogueUI;

    State state;
    private float distance;
    private Transform playerTransform; // Reference to the player's transform


    void Awake()
    {

        typeText = FindObjectOfType<TypeTextAnimation>();
        dialogueUI = FindObjectOfType<DialogueUI>();

        typeText.TypeFinished = OnTypeFinishe;

    }

    void Start()
    {
        players = GameObject.FindGameObjectsWithTag(playerTag);
        targets = GameObject.FindGameObjectsWithTag(targetTag);
        state = State.Disabled;
    }

    public void Next()
    {

        if (currentText == 0)
        {
            dialogueUI.Enable();
        }

        dialogueUI.SetName(dialogueData.talkScript[currentText].name);

        typeText.fullText = dialogueData.talkScript[currentText++].text;

        if (currentText == dialogueData.talkScript.Count) finished = true;

        typeText.StartTyping();
        state = State.Typing;

    }

    void Update()
    {
        //if (state == State.Disabled) return;

        switch (state)
        {
            case State.Disabled:
                Disabled();
                break;
            case State.Waiting:
                Waiting();
                break;
            case State.Typing:
                Typing();
                break;
        }

    }

    void OnTypeFinishe()
    {
        state = State.Waiting;
    }

    void Disabled()
    {
        // Iterate through each target
        foreach (GameObject player in players)
        {
            foreach (GameObject target in targets)
            {
                // Calculate the distance between this GameObject and the target
                float distance = Vector3.Distance(player.transform.position, target.transform.position);
                Debug.Log(distance);

                // Check if the distance is less than the proximity threshold
                if (distance < proximityThreshold)
                {
                    // Objects are too close, give a warning
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Next();
                    }
                }
            }
        }
    }

    void Waiting()
    {
        
        if (Input.GetKeyDown(KeyCode.E))
        {

            if (!finished)
            {
                Next();
            }
            else
            {
                Debug.Log("Waiting");
                dialogueUI.Disable();
                state = State.Disabled;
                currentText = 0;
                finished = false;
            }

        }
        
    }

    void Typing()
    {
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            typeText.Skip();
            state = State.Waiting;
        }
        
    }

}