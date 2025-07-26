using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TextControl : MonoBehaviour
{
    [SerializeField] Text txt;
    [SerializeField] Image click;
    [SerializeField] PortalControl pC;

    private TouchControl tC;
    public Vector2 pos;

    void Awake()
    {
        tC = new TouchControl();  
    }

    void OnEnable()
    {
        tC.Enable();

        // Subscribe to touch events
        tC.TouchControls.Touch.started += StartTouch;
        tC.TouchControls.Touch.canceled += EndTouch;
    }

    void OnDisable()
    {
        // Unsubscribe to avoid memory leaks
        tC.TouchControls.Touch.started -= StartTouch;
        tC.TouchControls.Touch.canceled -= EndTouch;

        tC.Disable();
        pC.despawnPortal(); // just in case
    }

    void StartTouch(InputAction.CallbackContext context)
    {
        pos = context.ReadValue<Vector2>();
        txt.text = "User touched me at " + pos;

        click.transform.position = pos;
        pC.spawnPortal(); // Spawn portal on touch
    }

    void EndTouch(InputAction.CallbackContext context)
    {
        txt.text = "User isn't touching";

        pC.despawnPortal(); // Despawn portal on release
    }

    void Start()
    {
        txt.text = "App Started";
    }
}
