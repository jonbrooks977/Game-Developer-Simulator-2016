using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerCompany : MonoBehaviour 
{
	public Company PlayerCo = new Company();

	public void StartGame(string CompanyName)
	{
		PlayerCo.title = CompanyName;
		PlayerCo.balance = 0;
		PlayerCo.fans = 0;
		Debug.Log("Company Created: " + PlayerCo.title + " with $" + PlayerCo.balance + " and " + PlayerCo.fans + " fans" );
	}

	public GameObject PreDevUI;
	public GameObject ProgressSlider;

	public void PreDevelopGame()
	{
		PreDevUI.SetActive(true);
		ProgressSlider.SetActive(true);
		ProgressSlider.GetComponent<Slider>().value = 0;
	}

	public void DevelopGame()
	{
		
	}
	
}