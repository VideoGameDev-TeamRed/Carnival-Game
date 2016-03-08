using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour 
{
	public Image background;
	public Text countDownTimerText;
	public Button startButton;
	public Text scoreText;
	public Text highScoreText;
	public Text gameOverText;
	public Text restartGameText;
	public Button yesButton;
	public Button noButton;

	public AudioSource gameOverAudio;
	public AudioSource backgroundAudio;

	int currentTime;
	int maxTime = 60;

	int score, highScore;

	// Use this for initialization
	void Start () 
	{
		background.enabled = true;
		score = 0;
		highScore = PlayerPrefs.GetInt ("High Score");

		countDownTimerText.enabled = false;
		scoreText.enabled = false;
		highScoreText.enabled = false;
		gameOverText.enabled = false;
		restartGameText.enabled = false;
		currentTime = maxTime;
		yesButton.gameObject.SetActive(false);
		noButton.gameObject.SetActive(false);

		AudioSource[] audioSources = GetComponents<AudioSource>();
		gameOverAudio = audioSources[0];
		backgroundAudio = audioSources[1];
	}

	// Update is called once per frame
	void Update () 
	{

	}

	public void UpdateScore()
	{
		score += 10;
		scoreText.text = "Score: " + score;
	}

	void UpdateHighScore()
	{
		scoreText.enabled = false;
		countDownTimerText.enabled = false;

		if (score > highScore) 
		{
			highScore = score;
			PlayerPrefs.SetInt ("High Score", highScore);
			PlayerPrefs.Save ();
			highScoreText.text = "You made a new high score!\n HighScore: " + highScore;
		} 
		else 
		{
			highScoreText.text = "Your Score: " + score + "\nHigh Score: " + highScore;
		}
	}

	public void OnClickYesButton()
	{
		SceneManager.LoadScene ("CarnivalScene");
	}

	public void OnClickNoButton()
	{
		Application.Quit ();
	}

	IEnumerator StartTimer()
	{
		while (currentTime >= 0) 
		{
//			UpdateScore ();
//			UpdateScore ();
			countDownTimerText.text = "Time Left: " + currentTime;
			yield return new WaitForSeconds (1);
			currentTime -= 1;

			if (currentTime == 0) 
			{
				countDownTimerText.text = "Time Left: " + currentTime;
			
				backgroundAudio.Pause ();
				gameOverAudio.Play ();
				background.enabled = true;
				gameOverText.enabled = true;
				yesButton.gameObject.SetActive (true);
				noButton.gameObject.SetActive (true);

				UpdateHighScore ();
				highScoreText.enabled = true;

				restartGameText.enabled = true;
			}
		}
	}

	public void DisplayCountdown()
	{
		background.enabled = false;
		scoreText.enabled = true;
		countDownTimerText.enabled = true;

		StartCoroutine (StartTimer ());
		startButton.gameObject.SetActive (false);
	}
}
