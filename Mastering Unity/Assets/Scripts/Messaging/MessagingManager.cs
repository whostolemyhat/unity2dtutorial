﻿using System;
using System.Collections.Generic;
using UnityEngine;

public class MessagingManager : Singleton<MessagingManager> {
	// public static MessagingManager Instance { get; private set; }
	private List<Action> subscribers = new List<Action>();
	private List<Action<bool>> uiEventSubscribers = new List<Action<bool>>();
	public ScriptingObjects waypoints;

	// void Awake() {
	// 	Debug.Log("Messaging manager started");

	// 	if (Instance != null && Instance != this) {
	// 		Destroy(gameObject);
	// 	}

	// 	Instance = this;
	// 	DontDestroyOnLoad(gameObject);
	// }

	public void Subscribe(Action subscriber) {
		Debug.Log("Subscriber added");
		subscribers.Add(subscriber);
	}

	public void Unsubscribe(Action subscriber) {
		Debug.Log("Subscriber removed");
		subscribers.Remove(subscriber);
	}

	public void ClearAllSubscribers() {
		Debug.Log("Remove all subscribers");
		subscribers.Clear();
	}

	public void Broadcast() {
		Debug.Log("Broadcasting to " + subscribers.Count + " subscribers");
		foreach(var subscriber in subscribers) {
			subscriber();
		}
	}

	public void SubscribeUIEvent(Action<bool> subscriber) {
		uiEventSubscribers.Add(subscriber);
	}

	public void BroadcastUIEvent(bool uiVisible) {
		Debug.Log("Broadcasting ui: " + uiVisible);
		foreach(var subscriber in uiEventSubscribers.ToArray()) {
			subscriber(uiVisible);
		}
	}

	public void UnsubscribeUIEvent(Action<bool> subscriber) {
		uiEventSubscribers.Remove(subscriber);
	}

	public void ClearAllUIEventSubscribers() {
		uiEventSubscribers.Clear();
	}
}
