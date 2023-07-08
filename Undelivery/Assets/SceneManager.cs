using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeTriggerer : MonoBehaviour
{

void OnTriggerEnter2D(Collider2D ChangeScene)
{
      SceneManager.LoadScene("Level1Yard");
}

}
