using System.Collections.Generic;

public static class NavigationManager {
	public static Dictionary<string, string> RouteInformation = new Dictionary<string, string>() {
		{ "World", "The big open world" },
		{ "Cave", "A dank and cold cave" }
	};

	public static string GetRouteInfo(string destination) {
		return RouteInformation.ContainsKey(destination) ? RouteInformation[destination] : null;
	}

	public static bool CanNavigate(string destination) {
		return true;
	}

	public static void NavigateTo(string destination) {
		// loadLevel
	}
}
