using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private GameObject menuItem;
    
    private float currentPos = 1;

    public AudioSource boop;

    private void Awake() {
        Screen.SetResolution(840, 480, false);
    }

    private void Update() {
        Screen.SetResolution(840, 480, false);
        if(Input.GetKeyDown(KeyCode.S) == true || Input.GetKeyDown(KeyCode.Keypad5)) {
			StartCoroutine(Enter());
		}
    }

    private void Move() {
        
    }

    IEnumerator Enter() {
        if(currentPos == 1) {
            boop.Play();
            yield return new WaitForSeconds(0.1f);
            SceneManager.LoadScene("TicTacToeGame");
        }
    }
}
