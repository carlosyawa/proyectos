
package mvc_memory;

import arcade.Register1;
import javax.swing.ImageIcon;

/**
 *
 * @author Paulina Mendoza
 */
public class principal extends javax.swing.JFrame {
tablero tabla = new tablero();//call class called tablero using the name tabla 
    /**
     * Creates new form principal
     */
    public principal() {
        initComponents();
       this.contenedor.add( tabla );//add the images in the panel
        this.contenedor.repaint();//repaint the images in the panel 
        setResizable(false);//you can-t  maximize the window
        setTitle("Game");//title of the window
        setIconImage(new ImageIcon(getClass().getResource("../images_Memory/memory.png")).getImage());//icon for the aplication
        setLocationRelativeTo(null);//located in the center of the screen
        
    }

    /**
     * This method is called from within the constructor to initialize the form.
     * WARNING: Do NOT modify this code. The content of this method is always
     * regenerated by the Form Editor.
     */
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        contenedor = new javax.swing.JPanel();
        jMenuBar1 = new javax.swing.JMenuBar();
        jMenu1 = new javax.swing.JMenu();
        juego = new javax.swing.JMenuItem();
        exit = new javax.swing.JMenuItem();

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);

        contenedor.setBackground(new java.awt.Color(255, 204, 51));
        contenedor.setMinimumSize(new java.awt.Dimension(0, 0));
        contenedor.setPreferredSize(new java.awt.Dimension(560, 560));

        javax.swing.GroupLayout contenedorLayout = new javax.swing.GroupLayout(contenedor);
        contenedor.setLayout(contenedorLayout);
        contenedorLayout.setHorizontalGroup(
            contenedorLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGap(0, 560, Short.MAX_VALUE)
        );
        contenedorLayout.setVerticalGroup(
            contenedorLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGap(0, 560, Short.MAX_VALUE)
        );

        jMenu1.setText("Game");

        juego.setText("Start");
        juego.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                juegoActionPerformed(evt);
            }
        });
        jMenu1.add(juego);

        exit.setText("Menu");
        exit.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                exitActionPerformed(evt);
            }
        });
        jMenu1.add(exit);

        jMenuBar1.add(jMenu1);

        setJMenuBar(jMenuBar1);

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addComponent(contenedor, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addComponent(contenedor, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
        );

        pack();
    }// </editor-fold>//GEN-END:initComponents

    private void juegoActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_juegoActionPerformed
     tabla.juego();   // Call the method juego in tabla
    }//GEN-LAST:event_juegoActionPerformed

    private void exitActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_exitActionPerformed
     Register1 view = new Register1();
        view.setVisible(true);
        this.dispose();   // Menu Interface
    }//GEN-LAST:event_exitActionPerformed

    /**
     * @param args the command line arguments
     */
    

    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JPanel contenedor;
    private javax.swing.JMenuItem exit;
    private javax.swing.JMenu jMenu1;
    private javax.swing.JMenuBar jMenuBar1;
    private javax.swing.JMenuItem juego;
    // End of variables declaration//GEN-END:variables
}