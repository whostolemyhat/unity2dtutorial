using System.Collections.Generic;

public struct Route {
	public string RouteDescription;
	public bool CanTravel;
}

public static class NavigationManager {
	public static Dictionary<string, Route> RouteInformation = new Dictionary<string, Route>() {
		{ "World", new Route { RouteDescription = "The big open world", CanTravel = true } },
		{ "Cave", new Route { RouteDescription = "A dank and cold cave", CanTravel = false } },
		{ "Home", new Route { RouteDescription = "Home sweet home", CanTravel = true } },
		{ "Citadel", new Route { RouteDescription = "The great citadel", CanTravel = true } },
		{ "Kirkidw", new Route { RouteDescription = "The great city of Kirkidw", CanTravel = true } }
	};

	public static string GetRouteInfo(string destination) {
		return RouteInformation.ContainsKey(destination) ? RouteInformation[destination].RouteDescription : null;
	}

	public static bool CanNavigate(string destination) {
		return RouteInformation.ContainsKey(destination) ? RouteInformation[destination].CanTravel : false;
	}

	public static void NavigateTo(string destination) {
		// loadLevel
	}
}
