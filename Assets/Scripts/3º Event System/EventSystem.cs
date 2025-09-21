using UnityEngine;
using System;

public class EventSystem : MonoBehaviour
{
	#region Properties
	#endregion

	#region Fields
	[SerializeField] private Points _points;
	[SerializeField] private Health _payerHealth;
	[SerializeField] private UIController _ui;
	[SerializeField] private SoundController _sound;
	[SerializeField] private InputSystem _inputs;
	#endregion

	#region Unity Callbacks
	// Start is called before the first frame update
	void Start()
    {
		//Event Listener
		_payerHealth.OnGetDamage += OnGetDamage;
		_payerHealth.OnGetHeal += OnGetHeal;
		_payerHealth.OnDie += OnDie;
        _inputs.OnKeyDamage += OnKeyDamage;
        _inputs.OnKeyHeal += OnKeyHeal;
        _inputs.OnKeyPoints += OnKeyPoints;
        _inputs.OnKeyAddLevel += OnKeyLevel;
        _points.OnGetPoints += OnAddPoints;
		_points.OnAddLevel += OnAddLevel;
    }

    private void Update()
    {
        OnKeyDamage();
        OnKeyHeal();
        OnKeyPoints();
        OnKeyLevel();

    }

    #endregion

    #region Private Methods
    private void OnGetDamage()
	{
        _sound.PlayDamageSound();
		_ui.UpdateSliderLife(_payerHealth.CurrentHealth);
	}
	private void OnGetHeal()
	{
		_ui.UpdateSliderLife(_payerHealth.CurrentHealth);
	}
	private void OnDie()
	{
		_sound.PlayDieSound();
        Destroy(_payerHealth.gameObject);
	}
	private void OnAddPoints()
	{
		_ui.UpdatePoints(_points.CurrentPoints);
	}
    private void OnAddLevel()
    {
        _ui.UpdateLevel(_points.CurrentLevel);
    }

    // INPUTS

    private void OnKeyDamage()
	{
		if(_payerHealth == null) 
			return;
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            Debug.Log("¡Te ha hecho daño! Tu vida actual es: " + _payerHealth.CurrentHealth);
            _payerHealth.GetDamage(20);
        }

    }
    private void OnKeyHeal()
	{
        if (_payerHealth == null)
            return;
        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            _payerHealth.GetHeal(20);
            Debug.Log("¡Te has curado! Tu vida actual es: " + _payerHealth.CurrentHealth);
        }
    }
	private void OnKeyPoints()
	{
        if (_payerHealth == null)
            return;
        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            _points.AddPoints(200);
            Debug.Log("¡Has ganado puntos! Tu puntuación actual es: " + _points.CurrentPoints);
        }
    }
	private void OnKeyLevel()
	{
        if (_payerHealth == null)
            return;
        if (Input.GetKeyUp(KeyCode.Alpha4))
        {
            _points.AddLevel(1);
            Debug.Log("¡Ha subido de nivel! Tu puntuación actual es: " + _points.CurrentLevel);
        }
    }
	#endregion
}
