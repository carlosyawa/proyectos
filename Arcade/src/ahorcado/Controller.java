/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ahorcado;

import java.awt.Color;
import java.awt.Graphics;
import javax.swing.JPanel;

/**
 *
 * @author Luis Trinidad
 */
public class Controller extends JPanel{
    public int flag = 0;
    
    public Controller(){
         setSize(600,300); //constructor call class with sizes
    }
    
    public void paintComponent(Graphics g){
        super.paintComponent(g);
        g.setColor(Color.GRAY);
        g.fillRect(0, 250, 300, 50);
        g.fillRect(0, 10, 10, 350);
        g.fillRect(10, 10, 150, 10);
        g.drawLine(150, 10, 150, 50);
        
        if(flag == 0){
        //    
        }
        if(flag == 1){
            //to paint head
            g.drawOval(125, 50, 50, 50);
        }
        else if(flag == 2){
            //to paint head
            g.drawOval(125, 50, 50, 50);
            //to paint Chest
            g.drawLine(150, 100, 150, 160);
        }
        else if(flag == 3){
            //to paint Head
            g.drawOval(125, 50, 50, 50);
            //to paint chest
            g.drawLine(150, 100, 150, 160);
            //to paint right arm
            g.drawLine(150, 100, 100, 130);
        }
        else if(flag == 4){
            //to paint head
            g.drawOval(125, 50, 50, 50);
            //to paint chest
            g.drawLine(150, 100, 150, 160);
            //to paint right arm
            g.drawLine(150, 100, 100, 130);
            //to paint left arm
            g.drawLine(150, 100, 200, 130);
        }
        else if(flag == 5){
            //head
            g.drawOval(125, 50, 50, 50);
            //chest
            g.drawLine(150, 100, 150, 160);
            //right arm
            g.drawLine(150, 100, 100, 130);
            //left arm
            g.drawLine(150, 100, 200, 130);
            //right arm
            g.drawLine(150, 160, 100, 200);
        }
        else if(flag == 6){
             //head
            g.drawOval(125, 50, 50, 50);
            //chest
            g.drawLine(150, 100, 150, 160);
            //right arm
            g.drawLine(150, 100, 100, 130);
            //left arm
            g.drawLine(150, 100, 200, 130);
            //right leg
            g.drawLine(150, 160, 100, 200);
            //left leg
            g.drawLine(150, 160, 200, 200);
        }
    }
    
    public void error(int error){
        flag=error;
        this.repaint();
    }
}
