public class InputManager
{
    private static InputManager instance;
    private PlayerControls controls = new PlayerControls();

    private InputManager()
    {
        Enable("gameplay");
    }

    public static InputManager GetInstance()
    {
        if (instance == null)
            instance = new InputManager();

        return instance;
    }

    public void Enable(string typeOfControl)
    {
        switch (typeOfControl)
        {
            case "gameplay":
                controls.Gameplay.Enable();
                controls.Event.Disable();
                break;
            case "event":
                controls.Gameplay.Disable();
                controls.Event.Enable();
                break;
            case "disable":
                controls.Gameplay.Disable();
                controls.Event.Disable();
                break;
        }
    }

    public bool IsInteracting() => controls.Event.Interact.IsPressed();
    public bool ActivateEvent() => controls.Gameplay.ActivateEvent.IsPressed();
    public bool IsRunning() => controls.Gameplay.Run.IsPressed();
    public bool IsAttacking() => controls.Gameplay.Attack.IsPressed();
    public float GetInputX() => controls.Gameplay.InputX.ReadValue<float>();
    public float GetInputY() => controls.Gameplay.InputY.ReadValue<float>();
}
