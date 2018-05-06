using UnityEngine;
using UnityEngine.UI;

public class TurnController : MonoBehaviour
{
	private bool _playerOneTurn = true;
	
	public int PlayerTurn
	{
		get { return _playerOneTurn ? 1 : 2; }
	}

	private DieRoller _dieRoller;
	private Text _currentPlayerText;

	void Start()
	{
		_dieRoller = GameObject.FindObjectOfType<DieRoller>();
		_currentPlayerText = transform.GetChild(0).GetComponent<Text>();
	}

	public void EndTurn()
	{
		// Change player turn
		_playerOneTurn = !_playerOneTurn;

		_currentPlayerText.text = "Player " + (_playerOneTurn ? "One" : "Two") + "'s Turn";
		
		_dieRoller.TurnEnded();
	}
}
