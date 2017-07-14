package mvc_memory;

import java.awt.Component;
import java.awt.Dimension;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;
import javax.swing.BorderFactory;
import javax.swing.ImageIcon;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.SwingWorker;
/**
 *
 * @author Paulina Mendoza Rodríguez
 */
public class tablero extends JPanel{
//array with the name of the images 8 in total for 16 pairs
    
    private String[] gme = {"link","mario","mask","sonic","pacman","teemo","resident","pikachu"};
    final ImageIcon win = new ImageIcon(getClass().getResource("../images_Memory/win.gif"));//image for the dialog at the end of the game
   
    private int fila =4;
    private int col = 4;
    private int ancho_casilla=140;
    
    public boolean play = false;
    
    int c=0;
    casilla c1;
    casilla c2;
    int aciertos=0;
    int score=0;
    
    /** Constructor de clase */
    public tablero(){
        super();
        //propiedades
        setBorder( BorderFactory.createEmptyBorder(0, 0, 0, 0));
        setLayout( new java.awt.GridLayout(fila, col) );        
        Dimension d= new Dimension( (ancho_casilla*col),(ancho_casilla*fila)  );        
        setSize(d);
        setPreferredSize(d);
        //crea instancias de casillas para crear el tablero 
        int count=0;
        for(int i=1;i<=(fila*col);i++){
            casilla p = new casilla( String.valueOf(i) );            
            p.setGame( gme[count] );
            count++;
            count = (count>=gme.length)? 0:count++;
            p.showGame();
            p.addMouseListener( new juegoMouseListener() );    
            this.add( p );
        }        
        setVisible(true);        
    }
    
    /**
     * Inicia juegos
     * - llena las casillas con pares de juegos
     * @return no tiene
     */
    public void juego(){
        aciertos=0;
        play=true;
        Component[] componentes = this.getComponents();         
        //limpia banderas
        for( int i=0; i< componentes.length ;i++){
            ((casilla)componentes[i]).congelarImagen(false);
            ((casilla)componentes[i]).ocultarGame();            
            ((casilla)componentes[i]).setGame( "" );
        }
        //coloca nuevo orden aleatorio de imagenes
        for( int i=0; i< componentes.length ;i++){
            int n = (int) (Math.random()*(gme.length));        
            if( !existe(gme[n]) ){//comprueba que la imagen no este asignada mas de 2 veces                
                ((casilla)componentes[i]).setGame( gme[n] );
            }else{
                i--;
            }
        }
        
    }
    
    
    /**
     * Metodo que comprueba que una casilla existe
     * @param int num nombre del objeto
     * @return Casilla si existe
     *         NULL si no existe
     */
    private boolean existe( String game ){  
        int count=0;
        Component[] componentes = this.getComponents(); 
        for( int i=0; i<componentes.length;i++ ) {
            if( componentes[i] instanceof casilla ) {
                if( ((casilla)componentes[i]).getNameGame().equals( game ) ) {
                    count++;
                }
            }
        }        
        return (count==2)? true:false;   
    }
    
    /**
     * Clase que implemenenta un MouseListener para la captura de eventos del mouse
     */
    class juegoMouseListener implements MouseListener{        
        
        @Override
        public void mouseClicked(MouseEvent e) {         
            
            if( play ){
                c++;//lleva la cuenta de los click realizados en las casillas            
                if( c==1 ){ //primer click
                    c1=((casilla) e.getSource()); //obtiene objeto
                    if( !c1.isCongelado() ){
                        c1.showGame();     
                            
                    }else{//no toma en cuenta
                      c=0;   
                    }                
                }else if( c==2 && !c1.getName().equals( ((casilla) e.getSource()).getName() ) ){//segundo click
                    c2=((casilla) e.getSource()); 
                    if( !c2.isCongelado() ){
                        c2.showGame();     
                           
                        //compara imagenes
                        Animacion ani = new Animacion( c1, c2 );
                        ani.execute();
                    }
                    c=0;//contador de click a 0
                }else{ //mas de 2 clic consecutivos no toma en cuenta
                    c=0; 
                }
            }else{
                
            }
            
            
        }

        @Override
        public void mousePressed(MouseEvent e) {}

        @Override
        public void mouseReleased(MouseEvent e){}

        @Override
        public void mouseEntered(MouseEvent e) {}

        @Override
        public void mouseExited(MouseEvent e) {}
        
    }
    
    /**
     * 
     */
    class Animacion extends SwingWorker<Void, Void>{
        private casilla casilla1;
        private casilla casilla2;
        
        public Animacion(casilla value1, casilla value2){
            this.casilla1= value1;
            this.casilla2= value2;
        }
        
        @Override
        protected Void doInBackground() throws Exception {
                        
            //espera 1 segundo 
            Thread.sleep( 1000 );                
            if( casilla1.getNameGame().equals( casilla2.getNameGame() ) ){//son iguales
                casilla1.congelarImagen(true);
                casilla2.congelarImagen(true);
                score=score+75;
                System.out.println(score);
                    
                aciertos++;
                if( aciertos == 8 ){//win
                      
                    JOptionPane.showMessageDialog(null, "YOU ARE THE WINNER!!! CONGRATULATIONS!!!\n YOUR SCORE WAS "+score, "WINNER", JOptionPane.INFORMATION_MESSAGE,win);
                }
            }            
            else{//no son iguales
                casilla1.ocultarGame();
                casilla2.ocultarGame();
                score=score-35;
                System.out.println(score);
                    
            }
            return null;
        }
    
    }
    
}
