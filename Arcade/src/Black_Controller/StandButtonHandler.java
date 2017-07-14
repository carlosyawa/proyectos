package Black_Controller;


import Black_View.BlackJack;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

/*
 * Action Listener for Stand Button
 */
public class StandButtonHandler implements ActionListener {
	
	BlackJack ui;
	public StandButtonHandler(BlackJack ui) {
		this.ui = ui;
	}
	
	@Override
	public void actionPerformed(ActionEvent arg0) {
		// Calls the DoStand of main UI
		ui.DoStand();
	}
}