using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public static class InputManager
{

    private static GameControls _gameControls;
    public static void Init(Player myPlayer)
    {
        _gameControls = new GameControls();
       
        _gameControls.Permanent.Enable();

        _gameControls.InGame.Movement.performed += hi => 
        { 
            myPlayer.SetMovementDirection(hi.ReadValue<Vector3>());
        };

    }

    public static void SetGameControls()
    {
        _gameControls.InGame.Enable();
        _gameControls.UI.Disable();
        
    }

    public static void UIMode()
    {
        _gameControls.InGame.Disable();
        _gameControls.UI.Enable();
    }
}
