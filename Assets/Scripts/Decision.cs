using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Decision : MonoBehaviour {

	private float currentLocation = 5;

	private bool enumRunning = false;
	private bool winningRunning = false;

	private Vector3 loc1;
	private Vector3 loc2;
	private Vector3 loc3;
	private Vector3 loc4;
	private Vector3 loc5;
	private Vector3 loc6;
	private Vector3 loc7;
	private Vector3 loc8;
	private Vector3 loc9;

	private float xLocation1;
	private float xLocation2;
	private float xLocation3;
	private float xLocation4;
	private float xLocation5;

	private float oLocation1;
	private float oLocation2;
	private float oLocation3;
	private float oLocation4;

	private float tieCountdown;

	public GameObject choice;
	public GameObject X;
	public GameObject O;

	public GameObject xWin;
	public GameObject oWin;
	public GameObject tieWin;

	public AudioSource beep;

	Vector3 currentLoc;

	void Start() {
		loc1 = new Vector3(1f, 2.1f, 0f);
		loc2 = new Vector3(3.1f, 2.1f, 0f);
		loc3 = new Vector3(5.2f, 2.1f, 0f);
		loc4 = new Vector3(1f, 0f, 0f);
		loc5 = new Vector3(3.1f, 0f, 0f);
		loc6 = new Vector3(5.2f, 0f, 0f);
		loc7 = new Vector3(1f, -2.15f, 0f);
		loc8 = new Vector3(3.1f, -2.15f, 0f);
		loc9 = new Vector3(5.2f, -2.15f, 0f);
	}

	void Update () {

		if(enumRunning == true) {
			choice.GetComponent<Animator>().enabled = false;
			choice.GetComponent<SpriteRenderer>().GetComponent<Renderer>().enabled = false;
		} else {
			choice.GetComponent<Animator>().enabled = true;
			choice.GetComponent<SpriteRenderer>().GetComponent<Renderer>().enabled = true;
		}

		currentLoc = transform.position;

		Move();

		if(Input.GetKeyDown(KeyCode.S) == true || Input.GetKeyDown(KeyCode.Keypad5)) {
			Enter();
		}

		transform.position = currentLoc;
	}

	void Move() {

		if(enumRunning == false) {
			if(Input.GetKeyDown(KeyCode.W) == true || Input.GetKeyDown(KeyCode.Keypad8) == true) 
			{
				if(currentLocation != 1 && currentLocation != 2 && currentLocation != 3)
				{
					currentLocation -= 3;
				}
			}

			if(Input.GetKeyDown(KeyCode.A) == true || Input.GetKeyDown(KeyCode.Keypad4) == true) 
			{
				if(currentLocation != 1 && currentLocation != 4 && currentLocation != 7)
				{
					currentLocation -= 1;
				}
			}

			if(Input.GetKeyDown(KeyCode.D) == true || Input.GetKeyDown(KeyCode.Keypad6) == true) 
			{
				if(currentLocation != 3 && currentLocation != 6 && currentLocation != 9)
				{
					currentLocation += 1;
				}
			}

			if(Input.GetKeyDown(KeyCode.X) == true || Input.GetKeyDown(KeyCode.Keypad2) == true) 
			{
			if(currentLocation != 7 && currentLocation != 8 && currentLocation != 9) 
				{
					currentLocation += 3;
				}
			}
		}

		if(currentLocation == 1) {
			currentLoc = loc1;
		}
		if(currentLocation == 2) {
			currentLoc = loc2;
		}
		if(currentLocation == 3) {
			currentLoc = loc3;
		}
		if(currentLocation == 4) {
			currentLoc = loc4;
		}
		if(currentLocation == 5) {
			currentLoc = loc5;
		}
		if(currentLocation == 6) {
			currentLoc = loc6;
		}
		if(currentLocation == 7) {
			currentLoc = loc7;
		}
		if(currentLocation == 8) {
			currentLoc = loc8;
		}
		if(currentLocation == 9) {
			currentLoc = loc9;
		}
	}

	void Enter() {
		
		if(enumRunning == false && currentLocation != xLocation1 && currentLocation != xLocation2 && currentLocation != xLocation3 && currentLocation != xLocation4 && currentLocation != xLocation5 && currentLocation != oLocation1 && currentLocation != oLocation2 && currentLocation != oLocation3 && currentLocation != oLocation4 ) {
			tieCountdown += 1;
			Instantiate(X, currentLoc, transform.rotation);
			beep.Play();
			
			if(xLocation5 == 0) {
				if(xLocation4 == 0) {
					if(xLocation3 == 0) {
						if(xLocation2 == 0) {
							if(xLocation1 == 0) {
								xLocation1 = currentLocation;
							} else {xLocation2 = currentLocation;}
						} else {xLocation3 = currentLocation;}
					} else {xLocation4 = currentLocation;}
				} else {xLocation5 = currentLocation;}
			}

			StartCoroutine (xWinCondition());
			currentLocation = 5;
		}
	}

	IEnumerator AI() {

		float newOLocation;
		newOLocation = Random.Range(1,9);
		Vector3 oLoc = loc5;

		if(newOLocation == 1) {
			oLoc = loc1;
		}
		if(newOLocation == 2) {
			oLoc = loc2;
		}
		if(newOLocation == 3) {
			oLoc = loc3;
		}
		if(newOLocation == 4) {
			oLoc = loc4;
		}
		if(newOLocation == 5) {
			oLoc = loc5;
		}
		if(newOLocation == 6) {
			oLoc = loc6;
		}
		if(newOLocation == 7) {
			oLoc = loc7;
		}
		if(newOLocation == 8) {
			oLoc = loc8;
		}
		if(newOLocation == 9) {
			oLoc = loc9;
		}

		if(newOLocation == xLocation1 || newOLocation == xLocation2 ||newOLocation == xLocation3 ||newOLocation == xLocation4 || newOLocation == xLocation5 || newOLocation == oLocation1 || newOLocation == oLocation2 || newOLocation == oLocation3 || newOLocation == oLocation4){
			StartCoroutine(AI());
		} else {
			enumRunning = true;
			yield return new WaitForSeconds(1f);
			Instantiate(O, oLoc, transform.rotation);
			beep.Play();
			yield return new WaitForSeconds(0.4f);
			enumRunning = false;
			if(oLocation4 == 0) {
				if(oLocation3 == 0) {
					if(oLocation2 == 0) {
						if(oLocation1 == 0) {
							oLocation1 = newOLocation;
							StartCoroutine(oWinCondition());
						} else {oLocation2 = newOLocation; StartCoroutine(oWinCondition());}
					} else {oLocation3 = newOLocation; StartCoroutine(oWinCondition());}
				} else {oLocation4 = newOLocation; StartCoroutine(oWinCondition());}
			}
		}
	}

	IEnumerator xWinCondition() {

		if(tieCountdown != 5) {
			if(xLocation1 == 1 || xLocation2 == 1 || xLocation3 == 1 || xLocation4 == 1 || xLocation5 == 1) {
				if(xLocation1 == 2 || xLocation2 == 2 || xLocation3 == 2 || xLocation4 == 2 || xLocation5 == 2) {
					if(xLocation1 == 3 || xLocation2 == 3 || xLocation3 == 3 || xLocation4 == 3 || xLocation5 == 3) {
						enumRunning = true;
						winningRunning = true;
						xWin.GetComponent<Animator>().enabled = true;
						yield return new WaitForSeconds(3.0f);
						SceneManager.LoadScene("Menu");
					}
				}
			}
			if(xLocation1 == 4 || xLocation2 == 4 || xLocation3 == 4 || xLocation4 == 4 || xLocation5 == 4) {
				if(xLocation1 == 5 || xLocation2 == 5 || xLocation3 == 5 || xLocation4 == 5 || xLocation5 == 5) {
					if(xLocation1 == 6 || xLocation2 == 6 || xLocation3 == 6 || xLocation4 == 6 || xLocation5 == 6) {
						enumRunning = true;
						winningRunning = true;
						xWin.GetComponent<Animator>().enabled = true;
						yield return new WaitForSeconds(3.0f);
						SceneManager.LoadScene("Menu");
					}
				}
			}
			if(xLocation1 == 7 || xLocation2 == 7 || xLocation3 == 7 || xLocation4 == 7 || xLocation5 == 7) {
				if(xLocation1 == 8 || xLocation2 == 8 || xLocation3 == 8 || xLocation4 == 8 || xLocation5 == 8) {
					if(xLocation1 == 9 || xLocation2 == 9 || xLocation3 == 9 || xLocation4 == 9 || xLocation5 == 9) {
						enumRunning = true;
						winningRunning = true;
						xWin.GetComponent<Animator>().enabled = true;
						yield return new WaitForSeconds(3.0f);
						SceneManager.LoadScene("Menu");
					}
				}
			}
			if(xLocation1 == 1 || xLocation2 == 1 || xLocation3 == 1 || xLocation4 == 1 || xLocation5 == 1) {
				if(xLocation1 == 5 || xLocation2 == 5 || xLocation3 == 5 || xLocation4 == 5 || xLocation5 == 5) {
					if(xLocation1 == 9 || xLocation2 == 9 || xLocation3 == 9 || xLocation4 == 9 || xLocation5 == 9) {
						enumRunning = true;
						winningRunning = true;
						xWin.GetComponent<Animator>().enabled = true;
						yield return new WaitForSeconds(3.0f);
						SceneManager.LoadScene("Menu");
					}
				}
			}
			if(xLocation1 == 2 || xLocation2 == 2 || xLocation3 == 2 || xLocation4 == 2 || xLocation5 == 2) {
				if(xLocation1 == 5 || xLocation2 == 5 || xLocation3 == 5 || xLocation4 == 5 || xLocation5 == 5) {
					if(xLocation1 == 8 || xLocation2 == 8 || xLocation3 == 8 || xLocation4 == 8 || xLocation5 == 8) {
						enumRunning = true;
						winningRunning = true;
						xWin.GetComponent<Animator>().enabled = true;
						yield return new WaitForSeconds(3.0f);
						SceneManager.LoadScene("Menu");
					}
				}
			}
			if(xLocation1 == 3 || xLocation2 == 3 || xLocation3 == 3 || xLocation4 == 3 || xLocation5 == 3) {
				if(xLocation1 == 6 || xLocation2 == 6 || xLocation3 == 6 || xLocation4 == 6 || xLocation5 == 6) {
					if(xLocation1 == 9 || xLocation2 == 9 || xLocation3 == 9 || xLocation4 == 9 || xLocation5 == 9) {
						enumRunning = true;
						winningRunning = true;
						xWin.GetComponent<Animator>().enabled = true;
						yield return new WaitForSeconds(3.0f);
						SceneManager.LoadScene("Menu");
					}
				}
			}
			if(xLocation1 == 3 || xLocation2 == 3 || xLocation3 == 3 || xLocation4 == 3 || xLocation5 == 3) {
				if(xLocation1 == 5 || xLocation2 == 5 || xLocation3 == 5 || xLocation4 == 5 || xLocation5 == 5) {
					if(xLocation1 == 7 || xLocation2 == 7 || xLocation3 == 7 || xLocation4 == 7 || xLocation5 == 7) {
						enumRunning = true;
						winningRunning = true;
						xWin.GetComponent<Animator>().enabled = true;
						yield return new WaitForSeconds(3.0f);
						SceneManager.LoadScene("Menu");
					}
				}
			}
			if(xLocation1 == 1 || xLocation2 == 1 || xLocation3 == 1 || xLocation4 == 1 || xLocation5 == 1) {
				if(xLocation1 == 4 || xLocation2 == 4 || xLocation3 == 4 || xLocation4 == 4 || xLocation5 == 4) {
					if(xLocation1 == 7 || xLocation2 == 7 || xLocation3 == 7 || xLocation4 == 7 || xLocation5 == 7) {
						enumRunning = true;
						winningRunning = true;
						xWin.GetComponent<Animator>().enabled = true;
						yield return new WaitForSeconds(3.0f);
						SceneManager.LoadScene("Menu");
					}
				}
			}
		}

		if(tieCountdown == 5) {
			if(xLocation1 == 1 || xLocation2 == 1 || xLocation3 == 1 || xLocation4 == 1 || xLocation5 == 1) {
				if(xLocation1 == 2 || xLocation2 == 2 || xLocation3 == 2 || xLocation4 == 2 || xLocation5 == 2) {
					if(xLocation1 == 3 || xLocation2 == 3 || xLocation3 == 3 || xLocation4 == 3 || xLocation5 == 3) {
						enumRunning = true;
						winningRunning = true;
						xWin.GetComponent<Animator>().enabled = true;
						yield return new WaitForSeconds(3.0f);
						SceneManager.LoadScene("Menu");
					}
				}
			}
			if(xLocation1 == 4 || xLocation2 == 4 || xLocation3 == 4 || xLocation4 == 4 || xLocation5 == 4) {
				if(xLocation1 == 5 || xLocation2 == 5 || xLocation3 == 5 || xLocation4 == 5 || xLocation5 == 5) {
					if(xLocation1 == 6 || xLocation2 == 6 || xLocation3 == 6 || xLocation4 == 6 || xLocation5 == 6) {
						enumRunning = true;
						winningRunning = true;
						xWin.GetComponent<Animator>().enabled = true;
						yield return new WaitForSeconds(3.0f);
						SceneManager.LoadScene("Menu");
					}
				}
			}
			if(xLocation1 == 7 || xLocation2 == 7 || xLocation3 == 7 || xLocation4 == 7 || xLocation5 == 7) {
				if(xLocation1 == 8 || xLocation2 == 8 || xLocation3 == 8 || xLocation4 == 8 || xLocation5 == 8) {
					if(xLocation1 == 9 || xLocation2 == 9 || xLocation3 == 9 || xLocation4 == 9 || xLocation5 == 9) {
						enumRunning = true;
						winningRunning = true;
						xWin.GetComponent<Animator>().enabled = true;
						yield return new WaitForSeconds(3.0f);
						SceneManager.LoadScene("Menu");
					}
				}
			}
			if(xLocation1 == 1 || xLocation2 == 1 || xLocation3 == 1 || xLocation4 == 1 || xLocation5 == 1) {
				if(xLocation1 == 5 || xLocation2 == 5 || xLocation3 == 5 || xLocation4 == 5 || xLocation5 == 5) {
					if(xLocation1 == 9 || xLocation2 == 9 || xLocation3 == 9 || xLocation4 == 9 || xLocation5 == 9) {
						enumRunning = true;
						winningRunning = true;
						xWin.GetComponent<Animator>().enabled = true;
						yield return new WaitForSeconds(3.0f);
						SceneManager.LoadScene("Menu");
					}
				}
			}
			if(xLocation1 == 2 || xLocation2 == 2 || xLocation3 == 2 || xLocation4 == 2 || xLocation5 == 2) {
				if(xLocation1 == 5 || xLocation2 == 5 || xLocation3 == 5 || xLocation4 == 5 || xLocation5 == 5) {
					if(xLocation1 == 8 || xLocation2 == 8 || xLocation3 == 8 || xLocation4 == 8 || xLocation5 == 8) {
						enumRunning = true;
						winningRunning = true;
						xWin.GetComponent<Animator>().enabled = true;
						yield return new WaitForSeconds(3.0f);
						SceneManager.LoadScene("Menu");
					}
				}
			}
			if(xLocation1 == 3 || xLocation2 == 3 || xLocation3 == 3 || xLocation4 == 3 || xLocation5 == 3) {
				if(xLocation1 == 6 || xLocation2 == 6 || xLocation3 == 6 || xLocation4 == 6 || xLocation5 == 6) {
					if(xLocation1 == 9 || xLocation2 == 9 || xLocation3 == 9 || xLocation4 == 9 || xLocation5 == 9) {
						enumRunning = true;
						winningRunning = true;
						xWin.GetComponent<Animator>().enabled = true;
						yield return new WaitForSeconds(3.0f);
						SceneManager.LoadScene("Menu");
					}
				}
			}
			if(xLocation1 == 3 || xLocation2 == 3 || xLocation3 == 3 || xLocation4 == 3 || xLocation5 == 3) {
				if(xLocation1 == 5 || xLocation2 == 5 || xLocation3 == 5 || xLocation4 == 5 || xLocation5 == 5) {
					if(xLocation1 == 7 || xLocation2 == 7 || xLocation3 == 7 || xLocation4 == 7 || xLocation5 == 7) {
						enumRunning = true;
						winningRunning = true;
						xWin.GetComponent<Animator>().enabled = true;
						yield return new WaitForSeconds(3.0f);
						SceneManager.LoadScene("Menu");
					}
				}
			}
			if(xLocation1 == 1 || xLocation2 == 1 || xLocation3 == 1 || xLocation4 == 1 || xLocation5 == 1) {
				if(xLocation1 == 4 || xLocation2 == 4 || xLocation3 == 4 || xLocation4 == 4 || xLocation5 == 4) {
					if(xLocation1 == 7 || xLocation2 == 7 || xLocation3 == 7 || xLocation4 == 7 || xLocation5 == 7) {
						enumRunning = true;
						winningRunning = true;
						xWin.GetComponent<Animator>().enabled = true;
						yield return new WaitForSeconds(3.0f);
						SceneManager.LoadScene("Menu");
					}
				}
			}
			
			if(winningRunning == false) {
				enumRunning = true;
				tieWin.GetComponent<Animator>().enabled = true;
				yield return new WaitForSeconds(3.0f);
				SceneManager.LoadScene("Menu");
			}
		} else {
			StartCoroutine (AI());
		}
	}

	IEnumerator oWinCondition() {

		if(oLocation1 == 1 || oLocation2 == 1 || oLocation3 == 1 || oLocation4 == 1) {
			if(oLocation1 == 2 || oLocation2 == 2 || oLocation3 == 2 || oLocation4 == 2) {
				if(oLocation1 == 3 || oLocation2 == 3 || oLocation3 == 3 || oLocation4 == 3) {
					enumRunning = true;
					oWin.GetComponent<Animator>().enabled = true;
					yield return new WaitForSeconds(3.0f);
					SceneManager.LoadScene("Menu");
				}
			}
		}
		if(oLocation1 == 4 || oLocation2 == 4 || oLocation3 == 4 || oLocation4 == 4) {
			if(oLocation1 == 5 || oLocation2 == 5 || oLocation3 == 5 || oLocation4 == 5) {
				if(oLocation1 == 6 || oLocation2 == 6 || oLocation3 == 6 || oLocation4 == 6) {
					enumRunning = true;
					oWin.GetComponent<Animator>().enabled = true;
					yield return new WaitForSeconds(3.0f);
					SceneManager.LoadScene("Menu");
				}
			}
		}
		if(oLocation1 == 7 || oLocation2 == 7 || oLocation3 == 7 || oLocation4 == 7) {
			if(oLocation1 == 8 || oLocation2 == 8 || oLocation3 == 8 || oLocation4 == 8) {
				if(oLocation1 == 9 || oLocation2 == 9 || oLocation3 == 9 || oLocation4 == 9) {
					enumRunning = true;
					oWin.GetComponent<Animator>().enabled = true;
					yield return new WaitForSeconds(3.0f);
					SceneManager.LoadScene("Menu");
				}
			}
		}
		if(oLocation1 == 1 || oLocation2 == 1 || oLocation3 == 1 || oLocation4 == 1) {
			if(oLocation1 == 4 || oLocation2 == 4 || oLocation3 == 4 || oLocation4 == 4) {
				if(oLocation1 == 7 || oLocation2 == 7 || oLocation3 == 7 || oLocation4 == 7) {
					enumRunning = true;
					oWin.GetComponent<Animator>().enabled = true;
					yield return new WaitForSeconds(3.0f);
					SceneManager.LoadScene("Menu");
				}
			}
		}
		if(oLocation1 == 2 || oLocation2 == 2 || oLocation3 == 2 || oLocation4 == 2) {
			if(oLocation1 == 5 || oLocation2 == 5 || oLocation3 == 5 || oLocation4 == 5) {
				if(oLocation1 == 8 || oLocation2 == 8 || oLocation3 == 8 || oLocation4 == 8) {
					enumRunning = true;
					oWin.GetComponent<Animator>().enabled = true;
					yield return new WaitForSeconds(3.0f);
					SceneManager.LoadScene("Menu");
				}
			}
		}
		if(oLocation1 == 3 || oLocation2 == 3 || oLocation3 == 3 || oLocation4 == 3) {
			if(oLocation1 == 6 || oLocation2 == 6 || oLocation3 == 6 || oLocation4 == 6) {
				if(oLocation1 == 9 || oLocation2 == 9 || oLocation3 == 9 || oLocation4 == 9) {
					enumRunning = true;
					oWin.GetComponent<Animator>().enabled = true;
					yield return new WaitForSeconds(3.0f);
					SceneManager.LoadScene("Menu");
				}
			}
		}
		if(oLocation1 == 1 || oLocation2 == 1 || oLocation3 == 1 || oLocation4 == 1) {
			if(oLocation1 == 5 || oLocation2 == 5 || oLocation3 == 5 || oLocation4 == 5) {
				if(oLocation1 == 9 || oLocation2 == 9 || oLocation3 == 9 || oLocation4 == 3) {
					enumRunning = true;
					oWin.GetComponent<Animator>().enabled = true;
					yield return new WaitForSeconds(3.0f);
					SceneManager.LoadScene("Menu");
				}
			}
		}
		if(oLocation1 == 3 || oLocation2 == 3 || oLocation3 == 3 || oLocation4 == 3) {
			if(oLocation1 == 5 || oLocation2 == 5 || oLocation3 == 5 || oLocation4 == 5) {
				if(oLocation1 == 7 || oLocation2 == 7 || oLocation3 == 7 || oLocation4 == 7) {
					enumRunning = true;
					oWin.GetComponent<Animator>().enabled = true;
					yield return new WaitForSeconds(3.0f);
					SceneManager.LoadScene("Menu");
				}
			}
		}
	}
}
