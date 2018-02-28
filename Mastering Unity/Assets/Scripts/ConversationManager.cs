using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationManager : Singleton<ConversationManager> {
	bool isTalking = false;
	ConversationEntry currentConversationLine;
	int fontSpacing = 7;
	int conversationTextWidth;
	int dialogueHeight = 78;

	public int displayTextureOffset = 70;
	Rect scaledTextureRect;

	protected ConversationManager() {}

	IEnumerator DisplayConversation(Conversation conversation) {
		isTalking = true;
		foreach (var line in conversation.ConversationLines) {
			currentConversationLine = line;
			conversationTextWidth = currentConversationLine.ConversationText.Length * fontSpacing;

			scaledTextureRect = new Rect(
				currentConversationLine.DisplayPic.textureRect.x / currentConversationLine.DisplayPic.texture.width,
				currentConversationLine.DisplayPic.textureRect.y / currentConversationLine.DisplayPic.texture.height,
				currentConversationLine.DisplayPic.textureRect.width / currentConversationLine.DisplayPic.texture.width,
				currentConversationLine.DisplayPic.textureRect.height / currentConversationLine.DisplayPic.texture.height
			);

			yield return new WaitForSeconds(3);
		}

		isTalking = false;
		yield return null;
	}

	void OnGUI() {
		if (isTalking) {
			GUI.BeginGroup(new Rect(Screen.width / 2 - conversationTextWidth / 2, 50, conversationTextWidth + displayTextureOffset + 10, dialogueHeight));
			GUI.Box(new Rect(0, 0, conversationTextWidth + displayTextureOffset + 10, dialogueHeight), "");

			// name
			GUI.Label(new Rect(displayTextureOffset, 10, conversationTextWidth + 30, 20), currentConversationLine.SpeakingCharacterName);
			// text
			GUI.Label(new Rect(displayTextureOffset, 30, conversationTextWidth + 30, 20), currentConversationLine.ConversationText);
			GUI.DrawTextureWithTexCoords(new Rect(10, 10, 50, 50), currentConversationLine.DisplayPic.texture, scaledTextureRect);

			GUI.EndGroup();
		}
	}

	public void StartConversation(Conversation conversation) {
		if (!isTalking) {
			StartCoroutine(DisplayConversation(conversation));
		}
	}
}
