using UnityEngine;

public class StoneController : MonoBehaviour
{
	private DieRoller _dieRoller;
	private TurnController _turnController;

	public Tile StartingTile;
	
	public Tile _currentTile;

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
		
		

		for (int i = 0; i < _dieRoller.CurrentRoll; i++)
		{
			if (_currentTile == null)
			{
				_currentTile = StartingTile;
			}
			else
			{
				_currentTile = _currentTile.NextTileForPlayer(PlayerNumber);
			}

			if (_currentTile == null)
			{
				// TODO: Move stone off board
				return;
			}
		}
		
		Debug.Log(_currentTile.transform.position);
		transform.position = _currentTile.transform.position;
		
		// For testing, end the turn now
		_turnController.EndTurn();
	}
}
