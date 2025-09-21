using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
	#region Properties
	#endregion

	#region Fields
	[SerializeField] private Slider _slider;
	[SerializeField] private TextMeshProUGUI _pointsText;
	[SerializeField] private TextMeshProUGUI _levelText; // Añadimos un campo para introducir el nivel del jugador
    #endregion

    #region Unity Callbacks
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	#endregion

	#region Public Methods
	public void UpdateSliderLife(float currentLife)
	{
		_slider.value = currentLife;
	}
	public void UpdatePoints(int currentPoints)
	{
		_pointsText.text = currentPoints.ToString();
	}
	public void UpdateLevel(int currentLevel)  //Método público para aumentar en nivel del jugador
	{
		_levelText.text = "Level " + currentLevel.ToString();
    }
	#endregion

	#region Private Methods
	#endregion
}
