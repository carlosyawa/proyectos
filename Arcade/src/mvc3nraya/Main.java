package mvc3nraya;

import TresRaya_Vista.interfaz;
import TresRaya_Controlador.controlador;
import TresRaya_Modelo.juego;
/**
 * @web www.jc-mouse.net/
 * @author Mouse
 */
public class Main {

    public static void main(String[] args) {
         //nuevas instancias de clase
        juego modelo = new juego();
        interfaz vista = new interfaz();
        controlador controlador = new controlador( vista , modelo );
        controlador.iniciar_vista();
        vista.setVisible(true);
    }

}
