using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessagingClientReceiver : MonoBehaviour {

	// Use this for initialization
	void Start () {
		MessagingManager.Instance.Subscribe(PlayerTryingToLeave);
	}
	
	void PlayerTryingToLeave() {
		Debug.Log("I'm leaving " + tag.ToString());
	}
}
