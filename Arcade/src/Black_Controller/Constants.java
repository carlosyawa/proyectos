package Black_Controller;

import java.awt.Color;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;

/*
 * Class to Hold Global Objects as Static Members
 */
public class Constants {
   
	// List of Suits of Cards
	public static char[] Suits = new char[] {'C', 'S', 'H', 'D'};
	
	// Array of Ranks of Cards
	public static char[] Ranks = new char[] {'A', '2', '3', '4', '5', '6', '7', '8', '9', 'T', 'J', 'Q', 'K'};
	
	// Array of Values of Cards Correspond to Ranks Array
	public static int[] Values = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10};
	

	// Message to Show When User Wins
	public static String winMessage = "Congratulations, You Won!";
	// Message to Show When User Lost
	public static String lostMessage = "Sorry, You Lost!";
	// Message to Show When User Busts and Lost
	public static String bustLostMessage = "Bust! Sorry, You Lost!";
	// Message to Show when User Busts
	public static String bustMessage = "Bust!";
	// Message to Show when Opponent Busts
	public static String dealerBustMessage = "Dealer Bust! You Won!";
	
	// Background Color
	public static Color Background = new Color(51,51,255);
       
         private static JFrame frame;
 

}