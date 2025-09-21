using UnityEngine;
using System;

public class Health : MonoBehaviour
{    
    #region Properties
	public float CurrentHealth { 
		get 
		{
			return _currentHealth;
		}
		set 
		{
			_currentHealth = value;

			if (value < 0)
			{
				_currentHealth = 0;
				Die();
			}

			if (value > _maxHealth)
				_currentHealth = _maxHealth;
		} 
	}

	public event Action OnGetDamage;
	public event Action OnGetHeal;
	public event Action OnDie;

	#endregion

	#region Fields

	[SerializeField] private float _maxHealth = 100;
	[SerializeField] private float _currentHealth;
	[SerializeField] private bool _die = false;

	#endregion

	#region Unity Callbacks
	// Start is called before the first frame update
	void Start()
    {
		CurrentHealth = _maxHealth;
	}

	//Update is called once per frame

	void Update()
	{

	}
	#endregion

	#region Public Methods
	public void GetDamage(float damage)
	{
		if (!_die)
		{
			//Damage Event Emiter
			CurrentHealth -= damage;
			OnGetDamage?.Invoke();

		}
	}
	public void GetHeal(float life)
	{
		if (!_die)
		{
			CurrentHealth += life;
			//Heal Event Emiter
			OnGetHeal?.Invoke();
		}
	}
	#endregion

	#region Private Methods

	private void Die()
	{
		if (!_die)
		{
			_die = true;
			//Die Event Emiter
			OnDie?.Invoke();
		}
	}
	#endregion
}
