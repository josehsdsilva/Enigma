using UnityEngine;

public class BackgroundMusicManager : MonoBehaviour
{
    public AudioClip[] backgroundMusicClips; // Array of background music clips for different rooms or areas
    public string[] roomNames; // Names of rooms or areas corresponding to each background music clip
    public AudioSource audioSource; // Reference to the AudioSource component

    private string currentRoom; // Current room or area

    void Start()
    {
        // Initialize the current room
        currentRoom = GetCurrentRoom();

        // Play the background music for the current room
        PlayBackgroundMusic(currentRoom);
    }

    void Update()
    {
        // Check if the player has changed rooms
        string newRoom = GetCurrentRoom();
        if (newRoom != currentRoom)
        {
            // If the player has entered a new room, change the background music
            PlayBackgroundMusic(newRoom);
            currentRoom = newRoom;
        }
    }

    string GetCurrentRoom()
    {
        return "Room2";
    }

    void PlayBackgroundMusic(string room)
    {
        // Find the index of the room in the roomNames array
        int index = System.Array.IndexOf(roomNames, room);

        // Check if the room index is valid
        if (index >= 0 && index < backgroundMusicClips.Length)
        {
            // Stop any currently playing music
            audioSource.Stop();

            // Assign and play the background music for the current room
            audioSource.clip = backgroundMusicClips[index];
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("Background music not found for room: " + room);
        }
    }
}
