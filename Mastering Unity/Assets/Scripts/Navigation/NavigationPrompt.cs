using UnityEngine;

public class NavigationPrompt : MonoBehaviour {
	bool showDialogue;

	void DialogueVisible(bool visibility) {
		showDialogue = visibility;
		MessagingManager.Instance.BroadcastUIEvent(visibility);
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (NavigationManager.CanNavigate(this.tag)) {
			DialogueVisible(true);
		}
	}

	void OnCollisionExit2D(Collision2D col) {
		DialogueVisible(false);
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (NavigationManager.CanNavigate(this.tag)) {
			DialogueVisible(true);
		}
	}

	void OnGUI() {
		if (showDialogue) {
			GUI.BeginGroup(new Rect(Screen.width / 2 - 150, 50, 300, 250));
			GUI.Box(new Rect(0, 0, 300, 250), "");
			GUI.Label(new Rect(15, 10, 300, 68), "Do you want to travel to " + NavigationManager.GetRouteInfo(this.tag) + "?");
			if (GUI.Button(new Rect(55, 100, 180, 40), "Travel")) {
				// yep
				DialogueVisible(false);
				NavigationManager.NavigateTo(this.tag);
				// loadLevel
			}

			if (GUI.Button(new Rect(55, 150, 180, 40), "Stay")) {
				// nope
				DialogueVisible(false);
			}

			GUI.EndGroup();
		}
	}
}
