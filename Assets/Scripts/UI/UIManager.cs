using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private UIWindow overlayBackground;

    [SerializeField]
    private UIWindow currentOverlay;

    public static UIManager Instance { get; private set; }

    [SerializeField]
    private UIWindow currentWindow;

    [SerializeField] private UIWindow mainMenu;

    private void Awake()
    {
        Instance = this;
    }

    public void SwitchWindow(UIWindow window)
    {
        if (window != null)
        {
            if (window.IsOverlay)
            {
                OpenOverlay(window);
            }
            else
            {
                if (currentWindow != null)
                {
                    currentWindow.OnClose(() => 
                    {
                        window.OnOpen();

                        currentWindow = window;
                    });
                }
            }
        }
    }

    private void OpenOverlay(UIWindow overlay)
    {
        CloseOverlay();

        overlayBackground.OnOpen();
        overlay.OnOpen();
        currentOverlay = overlay;
    }

    private void CloseOverlay()
    {
        if (currentOverlay != null)
        {
            overlayBackground.OnClose();
            currentOverlay.OnClose();
            currentOverlay = null;
        }
    }
}