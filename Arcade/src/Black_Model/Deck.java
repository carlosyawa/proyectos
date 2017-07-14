package Black_Model;


import Black_Model.Card;
import Black_Controller.Constants;

/*
 * Deck of BlackJack Game
 *  - Holds collection of Cards
 */
public class Deck {
	Card[] cards;
	int top;
	
	// Init Deck
	public Deck() {
		cards = new Card[52];
		ResetCards();
	}
	
	/*
	 * Reset the Cards
	 */
	private void ResetCards() {
		top = 0;
		int j, k = 0;
		for (int i = 0; i < 4; i++) {
			for (j = 0; j < 13; j ++) {				
				cards[k] = new Card(Constants.Suits[i], Constants.Ranks[j]);
				k += 1;
			}
		}
	}
	
	/*
	 * Shuffles the Cards
	 */
	public void Shuffle() {
		ResetCards();
		for (int i = 0; i < cards.length; i++) {
			// Generate an index randomly 15
			int index = (int)(Math.random() * cards.length);
			Card temp = cards[i];
			cards[i] = cards[index];
			cards[index] = temp;
		}
	}

	/*
	 * Remove and Returns the Topmost Card from Collection
	 */
	public Card Deal() {
		top += 1;
		return cards[top - 1];
	}
}