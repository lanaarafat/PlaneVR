using UnityEngine;
using UnityEngine.UI;
using TMPro; // If using TextMeshPro

public class NotesSlide: MonoBehaviour
{
    public Image noteImage;
    public TextMeshProUGUI noteText;
    public Button nextButton, prevButton;

    [System.Serializable]
    public class Note
    {
        public Sprite image;
        [TextArea] public string text;
    }

    public Note[] notes;
    private int currentIndex = 0;

    void Start()
    {
        nextButton.onClick.AddListener(NextNote);
        prevButton.onClick.AddListener(PrevNote);

        // Display the first note
        UpdateNote();
    }

    void NextNote()
    {
        if (currentIndex < notes.Length - 1)
        {
            currentIndex++;
            UpdateNote();
        }
    }

    void PrevNote()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
            UpdateNote();
        }
    }

    void UpdateNote()
    {
        noteImage.sprite = notes[currentIndex].image; // Set image
        noteText.text = notes[currentIndex].text; // Set text

        // Enable/Disable buttons at first/last slide
        prevButton.interactable = currentIndex > 0;
        nextButton.interactable = currentIndex < notes.Length - 1;
    }
}
