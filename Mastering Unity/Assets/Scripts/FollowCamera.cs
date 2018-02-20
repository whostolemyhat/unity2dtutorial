using UnityEngine;

public class FollowCamera : MonoBehaviour {
    public float xMargin = 1.5f;
    public float yMargin = 1.5f;
    public float xSmooth = 1.5f;
    public float ySmooth = 1.5f;
    private Vector2 maxXY;
    private Vector2 minXY;
    public Transform player;

    void Awake () {
        player = GameObject.Find("Player").transform;

        // size of bg
        // "background" matches name set in Unity Editor
        var backgroundBounds = GameObject.Find("background").GetComponent<Renderer>().bounds;
        
        Debug.Log(backgroundBounds.min.x);
        // camera bounds
        Camera camera = GetComponent<Camera>();
        var camTopLeft = camera.ViewportToWorldPoint(new Vector3(0, 0, 0));
        var camBottomRight = camera.ViewportToWorldPoint(new Vector3(1, 1, 0));

        minXY.x = backgroundBounds.min.x - camTopLeft.x;
        maxXY.x = backgroundBounds.max.x - camBottomRight.x;

        if (player == null) {
            Debug.LogError("Player object not found");
        }
    }

    void FixedUpdate() {
        float targetX = transform.position.x;
        float targetY = transform.position.y;

        if(CheckXMargin()) {
            targetX = Mathf.Lerp(transform.position.x, player.position.x, xSmooth * Time.fixedDeltaTime);
        }

        if(CheckYMargin()) {
            targetY = Mathf.Lerp(transform.position.y, player.position.y, ySmooth * Time.fixedDeltaTime);
        }

        targetX = Mathf.Clamp(targetX, minXY.x, maxXY.x);
        targetY = Mathf.Clamp(targetY, minXY.y, maxXY.y);

        transform.position = new Vector3(targetX, targetY, transform.position.z);
    }

    bool CheckXMargin() {
        return Mathf.Abs(transform.position.x - player.position.x) > xMargin;
    }

    bool CheckYMargin() {
        return Mathf.Abs(transform.position.y - player.position.y) > yMargin;
    }
}