using UnityEngine;
using System.Collections;

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

    public AudioClip[] dialogueAudioClips; // Array of audio clips to randomly choose from
    public DialogueData dialogueData;

    public float proximityThreshold = 1f; // Threshold distance to consider them too close

    int currentText = 0;
    bool finished = false;
    GameObject[] targets;
    GameObject[] players;

    TypeTextAnimation typeText;
    DialogueUI dialogueUI;

    State state;

    void Awake()
    {
        typeText = FindObjectOfType<TypeTextAnimation>();
        dialogueUI = FindObjectOfType<DialogueUI>();
        typeText.TypeFinished = OnTypeFinished;
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

        // Choose a random audio clip from the array and play it
        if (dialogueAudioClips != null && dialogueAudioClips.Length > 0)
        {
            AudioClip randomClip = dialogueAudioClips[Random.Range(0, dialogueAudioClips.Length)];
            AudioSource.PlayClipAtPoint(randomClip, transform.position);
        }
        else
        {
            Debug.LogWarning("No audio clips assigned for dialogue.");
        }
    }

    void Update()
    {
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

    void OnTypeFinished()
    {
        state = State.Waiting;
    }

    void Disabled()
    {
        foreach (GameObject player in players)
        {
            foreach (GameObject target in targets)
            {
                float distance = Vector3.Distance(player.transform.position, target.transform.position);

                if (distance < proximityThreshold && Input.GetKeyDown(KeyCode.E))
                {
                    Next();
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
