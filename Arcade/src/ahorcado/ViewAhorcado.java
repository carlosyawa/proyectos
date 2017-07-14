/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ahorcado;

import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.JTextField;

/**
 *
 * @author Luis Trinidad
 */
public class ViewAhorcado extends JFrame implements ActionListener{
    public Controller graphicPanel;
    public JPanel panelComponents;
    public JButton buttonReset;
    public JButton buttonStart;
    public JButton buttonTry;
    public JButton buttonExit;
    public JLabel label;
    public JTextField letter;
    public JTextField word;
    public ModelAhorcado p;
    public int tries;
    
    public ViewAhorcado(){
        super("H A N G M A N 2.0");
        setLayout(new BorderLayout(1,1));
        setSize(600,600);
        this.setLocationRelativeTo(null);
        agregarElementos();
        setVisible(true);
        setResizable(false);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE); 
        tries = 0;
    }
    
    public void agregarElementos(){
        //Panel where its gon to be drawing the hangman
        graphicPanel = new Controller();
        graphicPanel.setBackground(Color.LIGHT_GRAY);
        add(graphicPanel,BorderLayout.CENTER);
        
        //Panel where all components will be set
        panelComponents = new JPanel();
        panelComponents.setBackground(Color.CYAN);
        panelComponents.setLayout(null);
        
        buttonReset = new JButton("R E S E T");
        buttonStart = new JButton("S T A R T");
        buttonTry = new JButton("TRY");
        buttonExit = new JButton(" E X I T");
        
        label = new JLabel("W O R D");
        
        word = new JTextField("");
        letter = new JTextField("");
        
        //Constructing 
        buttonReset.setBounds(30,400,150,30);
        label.setBounds(250,400,100,30);
        word.setBounds(300,400,150,30);
        buttonStart.setBounds(30,450,150,30);
        buttonTry.setBounds(30,500,150,30);
        letter.setBounds(200,500,50,30);
        buttonExit.setBounds(430,500,150,30);
        
        buttonReset.addActionListener(this);
        buttonStart.addActionListener(this);
        buttonTry.addActionListener(this);
        buttonExit.addActionListener(this);
        
        panelComponents.add(buttonReset);
        panelComponents.add(buttonStart);
        panelComponents.add(buttonTry);
        panelComponents.add(buttonExit);
        panelComponents.add(letter);
        panelComponents.add(label);
        panelComponents.add(word);
        
        add(panelComponents,BorderLayout.CENTER);        
    }
    

    public void actionPerformed(ActionEvent evento) {
        if(evento.getSource() == buttonReset){
            graphicPanel.error(0);
            word.setText("");
            letter.setText("");
            tries = 0;
        } else if(evento.getSource() == buttonStart){
            graphicPanel.error(0);
            p = new ModelAhorcado();
            String aux="";
            int counter =0;
            while(counter < p.getChosenWord().length()){
                aux+="*";
                counter++;
            }
            word.setText(aux);
        }
        else if(evento.getSource() == buttonTry){
            String l="";
            l = letter.getText();
            char c = l.charAt(0);
            if(p.comparing(c).equals(p.getChosenWord())){
                word.setText(p.comparing(c));
                JOptionPane.showMessageDialog(null,"YOU WIN");
            }
            else if(tries == 6){
                JOptionPane.showMessageDialog(null,"YOU LOSE");
            }
            else if(p.getFlag() == 1){
                word.setText(p.comparing(c));
            }
            else if(p.getFlag() == 0){
                tries = tries + 1;
                graphicPanel.error(tries);
            }
        }
        else if(evento.getSource() == buttonExit){
            System.exit(0);
        }
    }
    
}
