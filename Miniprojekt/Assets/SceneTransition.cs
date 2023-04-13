using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string nextSceneName;

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")) {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
