public class InputManager
{
    private static InputManager instance;
    private PlayerControls controls = new PlayerControls();

    private InputManager()
    {
        controls.Gameplay.Enable();
    }

    public static InputManager GetInstance()
    {
        if (instance == null)
            instance = new InputManager();

        return instance;
    }

    public bool IsRunning() => controls.Gameplay.Run.IsPressed();
    public float GetInputX() => controls.Gameplay.InputX.ReadValue<float>();
    public float GetInputY() => controls.Gameplay.InputY.ReadValue<float>();
}
