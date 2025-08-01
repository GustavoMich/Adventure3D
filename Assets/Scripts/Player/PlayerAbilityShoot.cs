using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbilityShoot : PlayerAbilityBase
{
  

    public GunBase gunBase;
    public GunBase secondGunBase;
    public Transform gunPosition;

    private GunBase _currentGun;


    protected override void Init()
    {
        base.Init();

        CreateGun();
        
       

        inputs.Gameplay.Shoot.performed += ctx => StartShoot();
        inputs.Gameplay.Shoot.canceled += ctx => CancelShoot();

        inputs.Gameplay.ChangeGun1.performed += ctx => CreateGun();
        inputs.Gameplay.ChangeGun2.performed += ctx => CreateSecondGun();

    }


    private void CreateGun()
    {
        if (_currentGun != null)
            Destroy(_currentGun.gameObject);

        _currentGun = Instantiate(gunBase, gunPosition);

        _currentGun.transform.localPosition = _currentGun.transform.localEulerAngles = Vector3.zero;
    }

    private void CreateSecondGun()
    {
        if (_currentGun != null)
            Destroy(_currentGun.gameObject);

        _currentGun = Instantiate(secondGunBase, gunPosition);

        _currentGun.transform.localPosition = _currentGun.transform.localEulerAngles = Vector3.zero;
    }


    private void StartShoot()
    {
        _currentGun.StartShoot();
        Debug.Log("Shoot");
    }

    private void CancelShoot()
    {
        Debug.Log("Cancel Shoot");
        _currentGun.StopShoot();
    }
}
