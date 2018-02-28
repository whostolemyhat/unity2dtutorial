using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessagingClientReceiver : MonoBehaviour {

	// Use this for initialization
	void Start () {
		MessagingManager.Instance.Subscribe(PlayerTryingToLeave);
	}
	
	void PlayerTryingToLeave() {
		var dialogue = GetComponent<ConversationComponent>();
		if (dialogue != null) {
			if (dialogue.Conversations != null && dialogue.Conversations.Length > 0) {
				var conversation = dialogue.Conversations[0];
				if (conversation != null) {
					ConversationManager.Instance.StartConversation(conversation);
				}
			}
		}
		Debug.Log("I'm leaving " + tag.ToString());
	}
}
