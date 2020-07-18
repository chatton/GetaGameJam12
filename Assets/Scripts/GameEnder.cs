using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnder : MonoBehaviour
{

    public void EndGame() {
        StartCoroutine(DoEndGame());
    }
    

    private IEnumerator DoEndGame() {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(0);
    }
}
