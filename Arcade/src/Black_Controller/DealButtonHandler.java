package Black_Controller;


import Black_View.BlackJack;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

/*
 * Deal Button Click Event Listener
 */
public class DealButtonHandler implements ActionListener {
	
	BlackJack ui;
	public DealButtonHandler(BlackJack ui ) {
		this.ui = ui;
	}

	@Override
	public void actionPerformed(ActionEvent arg0) {
		// Calls the Deal Method of Main UI Object
		ui.DoDeal();
	}
}