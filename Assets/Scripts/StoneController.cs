using UnityEngine;

public class StoneController : MonoBehaviour
{
	private DieRoller _dieRoller;
	private TurnController _turnController;

	public Tile StartingTile;
	
	private Tile _currentTile;

	public int PlayerNumber;
	
	void Start ()
	{
		_dieRoller = GameObject.FindObjectOfType<DieRoller>();
		_turnController = GameObject.FindObjectOfType<TurnController>();
	}

	void OnMouseUp()
	{
		// Don't allow clicks until it is your turn
		if (_turnController.PlayerTurn != PlayerNumber) return;
		
		// Don't allow clicks until the turn starts
		if (!_dieRoller.DiceRolled) return;
		
		// For testing, end the turn now
		_turnController.EndTurn();
	}
}
