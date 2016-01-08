using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Manager : MonoBehaviour 
{
	PlayerCompany PlayerScript;
	Company PlayerCo;

	public GameObject CreateCompanyUI;
	public GameObject GameDevUI;
	public Text CreateName;
	public GameObject Player;

	void Update()
	{
		if(Input.GetKey("p"))
		{
			Time.timeScale = 10;
		}
		else
		{
			Time.timeScale = 1;
		}
	}

	void Start()
	{
		PlayerScript = gameObject.GetComponent<PlayerCompany>();
		PlayerCo = PlayerScript.PlayerCo;
		CreateCompanyUI.SetActive(true);
		Player.SetActive(false);
		GameDevUI.SetActive(false);
	}

	void StartGame()
	{
		CreateCompanyUI.SetActive(false);
		Player.SetActive(true);
		GameDevUI.SetActive(true);
		Debug.Log("Starting Week");
		InvokeRepeating("Week", 1, 30);
		InvokeRepeating("WeekCountdown", 1, 1);
	}

	public int WeeklyMoney;
	public int WeeklySales;
	public int WeeklyCosts;
	public int WeeklyFans;
	private int WeekSeconds;
	public Text ReportText;
	private int TotalWeeks;

	public Text WeekCountText;

	void Week()
	{
		WeekSeconds = 30;
		Debug.Log("Week Started");
		WeeklyMoney = WeeklySales - WeeklyCosts;
		PlayerCo.balance += WeeklyMoney;
		PlayerCo.fans += WeeklyFans + ( PlayerCo.fans > 5 ? Random.Range(-5 * TotalWeeks, 5 * TotalWeeks) : 0);

		if(WeeklyMoney >= 0 && WeeklyFans < 0)
		{
			Debug.Log(PlayerCo.title + " gained $" + WeeklyMoney + " and lost " + (WeeklyFans * -1) + " fans this week.");
		}
		else if(WeeklyMoney < 0 && WeeklyFans >= 0)
		{
			Debug.Log(PlayerCo.title + " lost $" + (WeeklyMoney * -1) + " and gained " + WeeklyFans + " fans this week.");
		}
		else if(WeeklyMoney >= 0 && WeeklyFans >= 0)
		{
			Debug.Log(PlayerCo.title + " gained $" + WeeklyMoney + " and " + WeeklyFans + " fans this week.");
		}
		else if(WeeklyMoney < 0 && WeeklyFans < 0)
		{
			Debug.Log(PlayerCo.title + " lost $" + (WeeklyMoney * -1) + " and " + (WeeklyFans * -1) + " fans this week.");
		}

		ReportText.text = PlayerCo.Report();

		WeeklyMoney = 0;
		WeeklyFans = 0;
		WeeklyCosts = 0;
		WeeklySales = 0;
		TotalWeeks++;
		WeekCountText.text = "Week " + TotalWeeks;
	}

	public Text CountDownText;

	void WeekCountdown()
	{
		WeekSeconds--;
		CountDownText.text = (Input.GetKey("p") ? WeekSeconds / Time.timeScale : WeekSeconds) + " until the weekly report";
		if(WeekSeconds <= 0)
		{
			WeekSeconds = 30;
		}
	}

	public void SetCompanyName()
	{
		PlayerScript.StartGame(CreateName.text);
		StartGame();
	}
}
