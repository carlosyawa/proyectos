package Black_View;

import Black_Model.*;
import Black_Controller.*;
import TresRaya_Vista.interfaz;
import arcade.Register1;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.net.URL;
import javax.swing.*;

/*
 * Black Jack Game Table
 * 
 */
public final class BlackJack extends JFrame {
    

    private static final long serialVersionUID = 1L;
     MenuBar barra = new MenuBar();
     JButton menu;
    // Button With Label "Deal Hand"
    JButton dealButton;
    // Button with label "Hit"
    JButton hitButton;
    // Button with label "Stand"
    JButton standButton;
JLabel fondo;
    // Label showing User Score
    JLabel userScoreLabel;
    // Label showing Dealer Score
    JLabel dealerScoreLabel;
    // Label showing outcome i.e "You Win" etc
    JLabel outcomeLabel;

    JLabel userValueLabel;
    JLabel dealerValueLabel;

    // GUI Panel to show Player Cards
    JPanel playerCardTbl;

    // GUI Panel to show Dealer Cards
    JPanel dealerCardTbl;

    JPanel p1, p2;

    Deck deck;      // Game Deck
    Hand player;    // Player Object
    Hand dealer;    // Opponent Object

    boolean isPlaying;
    public int userScore=0;      // User Score
    int dealerScore;    // User Score

    // Default Constructor
    public BlackJack() {
        super("Black Jack Game"); // Calls the Base Class Constructor
        setLayout(new BorderLayout(5, 0));
     
        // Add New Game Button & Bind Event
        JButton b = new JButton("New Game");
        b.addActionListener(new StartOverHandler(this));

        //Add Menu Button & Bind Event
     menu = new JButton("menu");
    
     menu.addActionListener(new menu(this));
    
        // Add Deal Button & Bind Event
        dealButton = new JButton("Deal Hand");
        dealButton.addActionListener(new DealButtonHandler(this));

        // Add Hit Button & Bind Event
        hitButton = new JButton("Hit");
        hitButton.setVisible(false);
        hitButton.addActionListener(new HitButtonHandler(this));

        // Add Stand Button & Bind Event
        standButton = new JButton("Stand");
        standButton.setVisible(false);
        standButton.addActionListener(new StandButtonHandler(this));

        JPanel controlArea = new JPanel();		// Init Control Area
        controlArea.setBackground(Constants.Background);
        // Add Items Button in Control Area
        controlArea.add(dealButton);
        controlArea.add(hitButton);
        controlArea.add(standButton);
        controlArea.add(b);
        controlArea.add(menu);
         

        add(controlArea, BorderLayout.SOUTH);  // Add Control Area in UI Frame

        // Font used to display Player's name
        Font nameFont = new Font("Goudy Stout", Font.BOLD, 20);
        //Font used to display Labels
        Font font = new Font("Cooper Black", Font.PLAIN, 20);
        // Font used to display Info
        Font infoFont = new Font("Jokerman", Font.PLAIN, 30);

        // Main Panel of Game with blue Background
        JPanel playPanel = new JPanel();
        playPanel.setLayout(new BorderLayout());
        playPanel.setBackground(Constants.Background);
    


        // Top panel
        
        p1 = new JPanel();
        p1.setBackground(Constants.Background);
        p1.setLayout(new GridLayout(0, 2));
     
        JLabel optName = new JLabel("   PC");
        optName.setFont(nameFont);
        optName.setForeground(Color.WHITE);
        p1.add(optName, BorderLayout.NORTH);

        // Dealer Score Label
        dealerScoreLabel = new JLabel("Score:   0   ");
        dealerScoreLabel.setHorizontalAlignment(SwingConstants.RIGHT);
        dealerScoreLabel.setFont(font);
        dealerScoreLabel.setForeground(Color.WHITE);
        p1.add(dealerScoreLabel);

        playPanel.add(p1, BorderLayout.NORTH);

        // Bottom Visible Panel
       
        p2 = new JPanel();
        p2.setBackground(Constants.Background);
        p2.setLayout(new GridLayout(0, 2));

        JLabel plyrName = new JLabel("    YOU   " );
        plyrName.setFont(nameFont);
        plyrName.setForeground(Color.WHITE);
        p2.add(plyrName);

        // Score Label
        userScoreLabel = new JLabel("Score:   0   ");
        userScoreLabel.setHorizontalAlignment(SwingConstants.RIGHT);
        userScoreLabel.setFont(font);
        userScoreLabel.setForeground(Color.WHITE);
        p2.add(userScoreLabel);

        playPanel.add(p2, BorderLayout.SOUTH);

        // Play Area
        JPanel cardPanel = new JPanel();
        LayoutManager mgr = new GridLayout(3, 0);
        cardPanel.setLayout(mgr);
        cardPanel.setBackground(Constants.Background);
     
        dealerCardTbl = new JPanel();
        dealerCardTbl.setBackground(Constants.Background);
        cardPanel.add(dealerCardTbl);

        // Outcome Label
        JPanel p3 = new JPanel();
        p3.setBackground(Constants.Background);
        p3.setLayout(new BorderLayout());
        Font valueFont = new Font("Bauhaus 93", Font.PLAIN, 16);

        
        
        userValueLabel = new JLabel("Value: 0");
        userValueLabel.setHorizontalAlignment(SwingConstants.CENTER);
        userValueLabel.setForeground(Color.WHITE);
        userValueLabel.setFont(valueFont);
        p3.add(userValueLabel, BorderLayout.SOUTH);

        dealerValueLabel = new JLabel("Value: 0");
        dealerValueLabel.setHorizontalAlignment(SwingConstants.CENTER);
        dealerValueLabel.setForeground(Color.WHITE);
        dealerValueLabel.setFont(valueFont);
        p3.add(dealerValueLabel, BorderLayout.NORTH);

        outcomeLabel = new JLabel("Hit New Deal Button to Start");
        outcomeLabel.setHorizontalAlignment(SwingConstants.CENTER);
        outcomeLabel.setFont(infoFont);
        outcomeLabel.setForeground(Color.WHITE);

        p3.add(outcomeLabel, BorderLayout.CENTER);

        cardPanel.add(p3);

        playerCardTbl = new JPanel();
        playerCardTbl.setBackground(Constants.Background);
        cardPanel.add(playerCardTbl);

        playPanel.add(cardPanel, BorderLayout.CENTER);

        add(playPanel, BorderLayout.CENTER);

        // Pack the UI & Set Size
        this.pack();
        this.setSize(700, 600);
        this.setLocationRelativeTo(null); // Set the start location to center
        this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        this.setResizable(false);
        setIconImage(new ImageIcon(getClass().getResource("/Black_images/11111.jpg")).getImage());//icon for the aplication
       
        DoStartOver();
    }
    

    /*
	 * Update the Outcome Text in 'outcomeLabel'
     */
    void UpdateOutcome(String o) {
        outcomeLabel.setText(o);
    }

    /*
	 * Update Score Text in 'scoreLabel'
     */
    void UpdateScore(int change) {
        if (change > 0) {
            userScore = userScore + change;
            userScoreLabel.setText(String.format("Score : "
                    + String.valueOf(userScore)) + "    ");
        } else {
            dealerScore = dealerScore + (change * -1);
            dealerScoreLabel.setText(String.format("Score : "
                    + String.valueOf(dealerScore) + "    "));
        }
    }

    /*
	 * Helper function to get Path of image for specific Card
     */
    String getCardPath(Card c) {
        return "/Black_images/" + String.valueOf(c.getSuit()) + "/"
                + String.valueOf(c.getRank()) + ".gif";
    }

    /*
	 * Helper function to update the play state and perform action
	 * according to the state;
     */
    void UpdatePlayState(boolean v) {
        isPlaying = v;

        // If firstCard is null then return
        // Most Important Handle It
        if (firstCard == null) {
            return;
        }
        if (isPlaying) {
            // If Is Playing then Hide the First Card of Dealer
            firstCard.HideCard();
            dealButton.setVisible(false);

            hitButton.setVisible(true);
            standButton.setVisible(true);
        } else {
            // Else Show the Opponent First Card
            firstCard.ShowCard();
            dealerValueLabel.setText("Value: "
                    + String.valueOf(dealer.GetValue()));
            dealButton.setVisible(true);

            hitButton.setVisible(false);
            standButton.setVisible(false);
        }
    }

    // To Hold Reference to first Card of Opponent
    // As JPanel.countComponent() is depreciated
    CardUI firstCard = null;

    /*
	 * Helper function to Push one card from Deck to Opponent Hand
     */
    void UpdateDealerCard() {
        Card c = deck.Deal();
        dealerCardTbl.add(new CardUI(getCardPath(c)));

        dealerCardTbl.updateUI();
        dealerCardTbl.repaint();
        dealer.addCard(c);

        dealerValueLabel.setText("Value: " 
                + String.valueOf(dealer.GetDealerValue()) + "+");
    }

    /*
	 * Helper function to Push one card from Deck to Player Hand
     */
    void UpdatePlayerCard() {
        Card c = deck.Deal();
        CardUI cardUI = new CardUI(getCardPath(c));
        cardUI.setHorizontalAlignment(SwingConstants.LEFT);
        playerCardTbl.add(cardUI);
        playerCardTbl.updateUI();
        playerCardTbl.repaint();
        player.addCard(c);

        userValueLabel.setText("Value: " + String.valueOf(player.GetValue()));
    }

    /*
	 * Helper function to Empty Components of JPanel
     */
    void EmptyPanel(JPanel p) {
        p.removeAll();
        p.repaint();
        
    }

    /*
	 * Do the deal.
	 * 	-	Clears the PLayer Opponent Hand
	 *  -	Shuffles the Deck
	 *  -	Push Two Cards in hand of Opponent & Player
	 * 
	 * Remark:
	 * This function will be called by the Deal Button Click Event Listener
     */
    public void DoDeal() {
        SetNewGame(true);

        if (isPlaying) {
            // If Player is previously playing game then Update Outcome 
            UpdateOutcome(Constants.lostMessage);
            if (player != null) {
                UpdateScore(-1 * player.GetValue());
            }
        } else {
            UpdateOutcome("");
        }

        // Empty the UI Tables
        EmptyPanel(dealerCardTbl);
        EmptyPanel(playerCardTbl);
        

        // Creates the new Deck if it is null
        if (deck == null) {
            deck = new Deck();
        }
        // Shuffles the Cards
        deck.Shuffle();

        // Create New Player Object
        player = new Hand();
        UpdatePlayerCard();
        UpdatePlayerCard();

        // Create New Opponent Object
        dealer = new Hand();
        UpdateDealerCard();
        UpdateDealerCard();
        firstCard = (CardUI) dealerCardTbl.getComponent(0);

        // Set Playing State to true
        UpdatePlayState(true);
    }

    /*
	 * Push one more card from Deck to Player Hand
	 * 
	 * Remarks:
	 * This function will be called by the Event Listener
	 * of Button with label "Hit"
     */
    public void DoHit() {
        if (isPlaying) {
            UpdatePlayerCard();

            // if Player is busted the Show Outcome
            if (player.isBusted()) {
                UpdateOutcome(Constants.bustLostMessage);
                UpdateScore(-1 * (player.GetValue() - 21));
                UpdatePlayState(false);
            }
        }
    }
    
    
    
  

    /*
	 * if hand is in play, repeatedly hit dealer's hand until greater than 17
	 * 
	 * Remarks:
	 * This function will be called by the event listener of Button
	 * with label "Stand"
     */
    public void DoStand() {
        if (isPlaying) {
            // if hand is in play, repeatedly hit dealer until his hand
            // has value 17 or more
            while (dealer.GetValue() < 17) {
                UpdateDealerCard();
            }

            //assign a message to outcome, update in_play and score
            if (player.isBusted()) {
                // Player Busted
                UpdateOutcome(Constants.bustMessage);
            } else if (dealer.isBusted()) {
                // Dealer Busted
                UpdateOutcome(Constants.dealerBustMessage);
                UpdateScore(dealer.GetValue() - 21);
            } else if (dealer.GetValue() < player.GetValue()) {
                // Player Won
                UpdateOutcome(Constants.winMessage);
                UpdateScore(player.GetValue() - dealer.GetValue());
            } else {
                // Player Lost
                UpdateOutcome(Constants.lostMessage);
                UpdateScore(player.GetValue() - dealer.GetValue());
            }

            // Set Play State to false to prevent future action
            UpdatePlayState(false);
        }
    }
    

    // Starts new game
    public void DoStartOver() {
        UpdatePlayState(false);
        UpdateOutcome("Hit \"Deal Hand\" Button to Play");
        dealerScore = -1;
        userScore = -1;

        UpdateScore(-1);
        UpdateScore(1);

        EmptyPanel(dealerCardTbl);
        EmptyPanel(playerCardTbl);

        SetNewGame(false);
    }
     public void menu() {
         UpdatePlayState(false);
        Register1 re = new Register1();
        re.setVisible(true);
        this.dispose();
        
        userScore = -1;

        UpdateScore(-1);
        UpdateScore(1);

        EmptyPanel(dealerCardTbl);
        EmptyPanel(playerCardTbl);

    }
   
    

    // Sets Game Controls On/Off
    void SetNewGame(boolean v) {
        p1.setVisible(v);
        p2.setVisible(v);

        userValueLabel.setVisible(v);
        dealerValueLabel.setVisible(v);
        }
  
}
