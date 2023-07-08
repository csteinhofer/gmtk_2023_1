using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeTrigger : MonoBehaviour
{
      
public string sceneName = "Level1Yard";

void OnTriggerEnter2D(Collider2D ChangeScene)
{
      SceneManager.LoadScene(sceneName);
}

}
