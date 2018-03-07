using UnityEngine;
using System.Collections;

public class FadingManager : Singleton<FadingManager> {
    protected FadingManager() {}
    private Material fadeMaterial;
    private float fadeOutTime;
    private float fadeInTime;
    private Color fadeColour;
    private string navigateToLevelName = "";
    private int navigateToLevelIndex = 0;
    private bool fading = false;

    public static bool Fading {
        get { return Instance.fading; }
    }

    void Awake () {
        // default fading texture
        fadeMaterial = new Material("Shader \"Plane/No zTest\" {" +
            "SubShader { Pass { " +
            "    Blend SrcAlpha OneMinusSrcAlpha " +
            "    zWrite Off Cull Off Fog { Mode Off } " +
            "   BindChannels {" +
            "   Bind \"color\", color }" +
            "} } }"
        );
    }

    private IEnumerator Fade() {
        float t = 0.0f;
        while (t < 1.0f) {
            yield return new WaitForEndOfFrame();
            t = Mathf.Clamp01(t + Time.deltaTime / fadeOutTime);
            DrawingUtilites.DrawQuad(fadeMaterial, fadeColour, t);
        }

        if (navigateToLevelName != "") {
            Application.LoadLevel(navigateToLevelName);
        } else {
            Application.LoadLevel(navigateToLevelIndex);
        }

        while (t > 0.0f) {
            yield return new WaitForEndOfFrame();
            t = Mathf.Clamp01(t + Time.deltaTime / fadeInTime);
            DrawingUtilites.DrawQuad(fadeMaterial, fadeColour, t);
        }

        fading = false;
    }
}

public static class DrawingUtilites {
    public static void DrawQuad(Material material, Color colour, float alpha) {
        colour.a = alpha;
        material.SetPass(0);
        GL.PushMatrix();
        GL.LoadOrtho();
        GL.Begin(GL.QUADS);
        GL.Color(colour);
        GL.Vertex3(0, 0, -1);
        GL.Vertex3(0, 1, -1);
        GL.Vertex3(1, 1, -1);
        GL.Vertex3(1, 0, -1);
        GL.End();
        GL.PopMatrix();
    }
}