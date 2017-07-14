package Black_Controller;


import Black_View.BlackJack;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

/*
 * Action Listener for Hit Button
 */
public class HitButtonHandler implements ActionListener {
	BlackJack ui;
	public HitButtonHandler(BlackJack ui) {
		this.ui = ui;
	}
	
	@Override
	public void actionPerformed(ActionEvent arg0) {
		// Calls the DoHit event of Game
		ui.DoHit();
	}
}