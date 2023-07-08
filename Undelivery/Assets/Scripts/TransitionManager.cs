using UnityEngine;
using UnityEngine.SceneManagement;

using System.Collections;

public class SceneTransition : MonoBehaviour
{
    public string nextSceneName = "Level1Yard";
    public float transitionDelay = 3f;

    private void Start()
    {
        // Start the coroutine to delay the scene transition
        StartCoroutine(TransitionToNextScene());
    }

    private IEnumerator TransitionToNextScene()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(transitionDelay);

        // Load the next scene
        SceneManager.LoadScene(nextSceneName);
    }
}
