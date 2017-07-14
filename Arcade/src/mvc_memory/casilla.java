/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package mvc_memory;

import javax.swing.JLabel;
import java.awt.Cursor;
import java.awt.Dimension;
import javax.swing.ImageIcon;

/**
 *
 * @author Pauxx Xtream Hardy
 */
public class casilla extends JLabel {
    private int ancho=140;//width of the box
    private int alto=140;//height of the box
    private ImageIcon hide = new ImageIcon(getClass().getResource("../images_Memory/hide.png"));//the cover image of the cards
    private ImageIcon game;//put an icon to the project
    private String sGame="";
    private boolean congelado=false;
    
     /** 
      * constructor de clase
      * @param name String El nomnbre de instancia
      */
    public casilla( String name ){
        super();
        Dimension d = new Dimension(ancho,alto);
        setName(name);
        setSize( d );
        setPreferredSize( d );
        setText("");                
        setIcon( hide );
        setVisible(true);        
        setOpaque(true);
        setCursor(new Cursor( Cursor.HAND_CURSOR ));
    }
    
    /** 
     * Muestra la imagen de la bandera asignada a esta casilla
     * @return no tiene
     */
    public void showGame(){
        setIcon( game );
    }
    
    /**
     * Oculta la bandera
     * @return no tiene
     */
    public void ocultarGame(){
        if( !congelado ){
            setIcon( hide );
        }
    }
    
    /**
     * Cuando una imagen es congelada, no se puede volver a ocultar hasta comenzar un nuevo juego
     * @param value boolean
     */
    public void congelarImagen(boolean value){
        this.congelado=value;
    }
    
    /**
     * Metodo que retorna el valor boolean de una casilla si este esta o no congelado
     * @return boolean 
     */
    public boolean isCongelado(){
        return this.congelado;
    }
    
    /**
     * Asigna la bandera que contendra la casilla
     * @param name nombre de la bandera
     */
    public void setGame( String name ){
        this.sGame = name;
        if( !name.equals("") ){            
            game = new ImageIcon(getClass().getResource("../images_Memory/"+name+".jpg"));        
        }        
    }
    
    /**
     * Retorna el nombre de la bandera que tenga asignada la casilla, si no tiene ninguna
     * retorna una cadena vacia
     * @return String 
     */
    public String getNameGame(){
        return sGame;
    }
    
}
    
