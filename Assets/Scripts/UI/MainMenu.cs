using UnityEngine;
using System.Collections;
using TeamUtility.IO;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour {

	private GameObject player1JoiningBox, player2JoiningBox, player3JoiningBox, player4JoiningBox;
	private bool player1Joined, player2Joined, player3Joined, player4Joined;
	private GameObject playerJoiningBackButton;

	private float navTimer;

	// Use this for initialization
	void Start () {
		player1JoiningBox = GameObject.Find("Player1Box");
		player2JoiningBox = GameObject.Find("Player2Box");
		player3JoiningBox = GameObject.Find("Player3Box");
		player4JoiningBox = GameObject.Find("Player4Box");

		playerJoiningBackButton = GameObject.Find("PlayerJoiningBackButton");
	}
	
	// Update is called once per frame
	void Update () {
		if(GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("SplashLoop")
			&& Input.anyKeyDown) {
			GetComponent<Animator>().SetTrigger("SplashToMainMenu");
		}
		if(GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("MainMenuToPlayerJoin")
			&& !GetComponent<Animator>().IsInTransition(0)) {
			Debug.Log(player1Joined + " " + player1JoiningBox.transform.FindChild("P1_Press_A_Text").GetComponent<Text>().color.a);
			if(InputManager.GetButtonDown("Action_P1", PlayerID.One) && !player1Joined) {
				player1Joined = true;
				player1JoiningBox.transform.FindChild("P1_Press_A_Text").GetComponent<Text>().CrossFadeAlpha(0,1f,false);
			} else if(!player1Joined && player1JoiningBox.transform.FindChild("P1_Press_A_Text").GetComponent<CanvasRenderer>().GetColor().a == 0) {
				player1JoiningBox.transform.FindChild("P1_Press_A_Text").GetComponent<Text>().CrossFadeAlpha(1,1f,false);
			}
			if (InputManager.GetButtonDown("B_P1", PlayerID.One) && player1Joined) {
				player1Joined = false;
			} else if (InputManager.GetButtonDown("B_P1", PlayerID.One)) {
				ExecuteEvents.Execute(playerJoiningBackButton, new PointerEventData(EventSystem.current), ExecuteEvents.submitHandler);
			}
			if(InputManager.GetButton("Action_P2", PlayerID.Two)) {

			}
			if(InputManager.GetButton("Action_P3", PlayerID.Three)) {

			}
			if(InputManager.GetButton("Action_P4", PlayerID.Four)) {

			}
		} else {
			navTimer -= Time.deltaTime;
			if(InputManager.GetButton("Action_P1", PlayerID.One)) {
				EventSystem cur = EventSystem.current;
				GameObject curSelectedGameObject = EventSystem.current.currentSelectedGameObject;
				ExecuteEvents.Execute(curSelectedGameObject, new PointerEventData(cur), ExecuteEvents.submitHandler);
			}
//			Debug.Log(InputManager.GetAxis("Vertical_P1", PlayerID.One));
			if((InputManager.GetAxis("Vertical_P1", PlayerID.One) == 1f
				|| InputManager.GetAxis("DPADVertical_P1", PlayerID.One) == 1f
				|| InputManager.GetButtonDown("DPADUp_P1", PlayerID.One)) && navTimer < 0) {
				navTimer = 0.1f;
				EventSystem cur = EventSystem.current;
				GameObject curSelectedGameObject = EventSystem.current.currentSelectedGameObject;
				Selectable sel = curSelectedGameObject.GetComponent<Selectable>();
				Selectable up = sel.FindSelectableOnUp();
				if(up) {
					cur.SetSelectedGameObject(up.gameObject);
				}
			} else if((InputManager.GetAxis("Vertical_P1", PlayerID.One) == -1f
				|| InputManager.GetAxis("DPADVertical_P1", PlayerID.One) == -1f
				|| InputManager.GetButtonDown("DPADDown_P1", PlayerID.One)) && navTimer < 0) {
				navTimer = 0.1f;
				EventSystem cur = EventSystem.current;
				GameObject curSelectedGameObject = EventSystem.current.currentSelectedGameObject;
				Selectable sel = curSelectedGameObject.GetComponent<Selectable>();
				Selectable down = sel.FindSelectableOnDown();
				if(down) {
					cur.SetSelectedGameObject(down.gameObject);
				}
			}
		}
	}

	public void GoToPlayerJoin() {
		GetComponent<Animator>().SetTrigger("MainMenuToPlayerJoin");
	}

	public void PlayerJoinToMainMenu() {
		GetComponent<Animator>().SetTrigger("PlayerJoinToMainMenu");
		player1Joined = false;
		player2Joined = false;
		player3Joined = false;
		player4Joined = false;
	}
}
