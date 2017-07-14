package Black_Main;




import Black_View.BlackJack;
import java.util.Scanner;

/*
 * Entry Point of Game
 */
public class Program {
	public static void main(String[] args) {
        
        // Get users name from command line
        Scanner keyboard = new Scanner(System.in);
     
        
        // System.out.println("Please enter your name: ");	
        // name = keyboard.nextLine();
        
        // Create new instance of Game Table
        BlackJack ui =  new BlackJack();
		ui.setVisible(true); // Show the Form
	}
}