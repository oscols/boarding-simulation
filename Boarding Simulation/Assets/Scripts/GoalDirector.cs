using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalDirector : MonoBehaviour {

	public enum SeatingMethod{
		wilma,
		block,
		random,
		steffen,
		backToFront
	}

	internal List<string> blockOne = new List<string>() {"Seat49", "Seat50", "Seat51", "Seat52", "Seat53", "Seat54", "Seat55", "Seat56", "Seat57", "Seat58", "Seat59", "Seat60", "Seat61",
	"Seat62", "Seat63", "Seat64", "Seat65", "Seat66", "Seat67", "Seat68", "Seat69", "Seat70", "Seat71", "Seat72"};
	internal List<string> blockTwo = new List<string>() {"Seat1", "Seat2", "Seat3", "Seat4", "Seat5", "Seat6", "Seat7", "Seat8", "Seat9", "Seat10", "Seat11", "Seat12", "Seat13",
	"Seat14", "Seat15", "Seat16", "Seat17", "Seat18", "Seat19", "Seat20", "Seat21", "Seat22", "Seat23", "Seat24"};
	internal List<string> blockThree = new List<string>() {"Seat25", "Seat26", "Seat27", "Seat28", "Seat29", "Seat30", "Seat31", "Seat32", "Seat33", "Seat34", "Seat35", "Seat36", "Seat37",
	"Seat38", "Seat39", "Seat40", "Seat41", "Seat42", "Seat43", "Seat44", "Seat45", "Seat46", "Seat47", "Seat48"};

	internal List<string> random = new List<string>() {"Seat1", "Seat2", "Seat3", "Seat4", "Seat5", "Seat6", "Seat7", "Seat8", "Seat9", "Seat10", "Seat11", "Seat12", "Seat13",
	"Seat14", "Seat15", "Seat16", "Seat17", "Seat18", "Seat19", "Seat20", "Seat21", "Seat22", "Seat23", "Seat24", "Seat25", "Seat26", "Seat27", "Seat28", "Seat29", "Seat30",
	"Seat31", "Seat32", "Seat33", "Seat34", "Seat35", "Seat36", "Seat37", "Seat38", "Seat39", "Seat40", "Seat41", "Seat42", "Seat43", "Seat44", "Seat45", "Seat46", "Seat47", 
	"Seat48", "Seat49", "Seat50", "Seat51", "Seat52", "Seat53", "Seat54", "Seat55", "Seat56", "Seat57", "Seat58", "Seat59", "Seat60", "Seat61",
	"Seat62", "Seat63", "Seat64", "Seat65", "Seat66", "Seat67", "Seat68", "Seat69", "Seat70", "Seat71", "Seat72"};

	internal List<string> wilmaOne = new List<string>() {"Seat1", "Seat6", "Seat7", "Seat12", "Seat13", "Seat18", "Seat19", "Seat24", "Seat25", "Seat30", "Seat31", "Seat36", "Seat37",
	"Seat42", "Seat43", "Seat48", "Seat49", "Seat54", "Seat55", "Seat60", "Seat61", "Seat66", "Seat67", "Seat72"};

	internal List<string> wilmaTwo = new List<string>() {"Seat2", "Seat5", "Seat8", "Seat11", "Seat14", "Seat17", "Seat20", "Seat23", "Seat26", "Seat29", "Seat32", "Seat35", "Seat38",
	"Seat41", "Seat44", "Seat47", "Seat50", "Seat53", "Seat56", "Seat59", "Seat62", "Seat65", "Seat68", "Seat71"};

	internal List<string> wilmaThree = new List<string>() {"Seat3", "Seat4", "Seat9", "Seat10", "Seat15", "Seat16", "Seat21", "Seat22", "Seat27", "Seat28", "Seat33", "Seat34", "Seat39",
	"Seat40", "Seat45", "Seat46", "Seat51", "Seat52", "Seat57", "Seat58", "Seat63", "Seat64", "Seat69", "Seat70"};

	internal List<string> steffen = new List<string>() {"Seat67", "Seat55", "Seat43", "Seat31", "Seat19", "Seat7", "Seat72", "Seat60", "Seat48", "Seat36", "Seat24", "Seat12", "Seat61",
    "Seat49", "Seat37", "Seat25", "Seat13", "Seat1", "Seat66", "Seat54", "Seat42", "Seat30", "Seat18", "Seat6", "Seat68", "Seat56", "Seat44", "Seat32", "Seat20", "Seat8",
    "Seat71", "Seat59", "Seat57", "Seat35", "Seat23", "Seat11", "Seat62", "Seat50", "Seat38", "Seat26", "Seat14", "Seat2", "Seat65", "Seat53", "Seat41", "Seat29", "Seat17", 
    "Seat5", "Seat69", "Seat57", "Seat45", "Seat33", "Seat21", "Seat9", "Seat70", "Seat58", "Seat46", "Seat34", "Seat22", "Seat10", "Seat63",
    "Seat51", "Seat39", "Seat27", "Seat15", "Seat3", "Seat64", "Seat52", "Seat40", "Seat28", "Seat16", "Seat4"};

	internal List<string> backToFront = new List<string>() {"Seat67", "Seat72", "Seat68", "Seat71", "Seat69", "Seat70", "Seat61", "Seat66", "Seat62", "Seat65", "Seat63", "Seat64", "Seat55",
    "Seat60", "Seat56", "Seat59", "Seat57", "Seat58", "Seat49", "Seat54", "Seat50", "Seat53", "Seat51", "Seat52", "Seat43", "Seat48", "Seat44", "Seat47", "Seat45", "Seat46",
    "Seat37", "Seat42", "Seat38", "Seat41", "Seat39", "Seat40", "Seat31", "Seat36", "Seat32", "Seat35", "Seat33", "Seat34", "Seat25", "Seat30", "Seat26", "Seat29", "Seat27", 
    "Seat28", "Seat19", "Seat24", "Seat20", "Seat23", "Seat21", "Seat22", "Seat13", "Seat18", "Seat14", "Seat17", "Seat15", "Seat16", "Seat7",
    "Seat12", "Seat8", "Seat11", "Seat9", "Seat10", "Seat1", "Seat6", "Seat2", "Seat5", "Seat3", "Seat4"};

	public SeatingMethod method;

	public string getSeat(ref List<string> seats) {
		int seat = Random.Range(0, seats.Count);
		string seatName = seats[seat];
		seats.RemoveAt(seat);
		return seatName;
	}

	public string getFirstSeat(ref List<string> seats) {
		string seatName = seats[0];
		seats.RemoveAt(0);
		return seatName;
	}

	public CustomNode getGoal() {
		string seatName = "Seat1";
		
		switch(method) {
		case SeatingMethod.block:
			if (blockOne.Count > 0)
				seatName = getSeat(ref blockOne);
			else if (blockTwo.Count  > 0)
				seatName = getSeat(ref blockTwo);
			else if (blockThree.Count  > 0)
				seatName = getSeat(ref blockThree); 
			break;
		case SeatingMethod.wilma:
			if (wilmaOne.Count > 0)
				seatName = getSeat(ref blockOne);
			else if (wilmaTwo.Count  > 0)
				seatName = getSeat(ref blockTwo);
			else if (wilmaThree.Count  > 0)
				seatName = getSeat(ref blockThree); 
			break;
		case SeatingMethod.steffen:
			if (steffen.Count > 0)
				seatName = getFirstSeat(ref steffen);
			break;
		case SeatingMethod.backToFront:
			if(backToFront.Count > 0)
				seatName = getFirstSeat(ref backToFront);
			break;
		default: // random
			if (random.Count > 0)
				seatName = getSeat(ref random);
			break;
		}

		return GameObject.Find(seatName).GetComponent<CustomNode>();
	}

}
