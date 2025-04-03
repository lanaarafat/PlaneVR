using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject welcomePanel, mainMenuPanel, planeSelectPanel, notesPanel;
    public RawImage fadePanel; // UI Image for fade effect

    private void Start()
    {
        ShowPanel(welcomePanel); // Start with Welcome Panel
    }

    public void ShowMainMenu()
    {
        ShowPanel(mainMenuPanel);
    }

    public void ShowPlaneSelect()
    {
        ShowPanel(planeSelectPanel);
    }

    public void ShowNotes()
    {
        ShowPanel(notesPanel);
    }

    public void SelectPlane()
    {
        SceneManager.LoadScene("PlanePOV");
    }

    private void ShowPanel(GameObject panel)
    {
        welcomePanel.SetActive(false);
        mainMenuPanel.SetActive(false);
        planeSelectPanel.SetActive(false);
        notesPanel.SetActive(false);

        panel.SetActive(true);
    }

    /*private IEnumerator FadeToPlane(GameObject planeSeat)
    {
        yield return StartCoroutine(FadeScreen(1)); // Fade out
        Camera.main.transform.position = planeSeat.transform.position; // Move player to seat
        yield return StartCoroutine(FadeScreen(0)); // Fade in
    }

    private IEnumerator FadeScreen(float targetAlpha)
    {
        float duration = 1.0f;
        float startAlpha = fadePanel.color.a;
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / duration);
            fadePanel.color = new Color(0, 0, 0, newAlpha);
            yield return null;
        }
    }*/
}
