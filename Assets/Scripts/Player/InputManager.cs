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
                controls.Almanac.Disable();
                break;
            case "event":
                controls.Gameplay.Disable();
                controls.Event.Enable();
                controls.Almanac.Disable();
                break;
            case "almanac":
                controls.Gameplay.Disable();
                controls.Event.Disable();
                controls.Almanac.Enable();
                break;
            default:
                controls.Gameplay.Disable();
                controls.Event.Disable();
                controls.Almanac.Disable();
                break;
        }
    }

    public bool CloseAlmanac() => controls.Almanac.CloseAlmanac.IsPressed();
    public bool IsInteracting() => controls.Event.Interact.IsPressed();
    public bool ActivateEvent() => controls.Gameplay.ActivateEvent.IsPressed();
    public bool ActivateAlmanac() => controls.Gameplay.ActivateAlmanac.IsPressed();
    public bool IsRunning() => controls.Gameplay.Run.IsPressed();
    public bool IsAttacking() => controls.Gameplay.Attack.IsPressed();
    public float GetInputX() => controls.Gameplay.InputX.ReadValue<float>();
    public float GetInputY() => controls.Gameplay.InputY.ReadValue<float>();
}
