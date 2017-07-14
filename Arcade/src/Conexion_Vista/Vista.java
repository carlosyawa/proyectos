/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Conexion_Vista;

import Conexion_Entidades.Persona;
import Conexion_Logico.PersonaLog;
import Conexion_ModeloTabla.ModeloTablaPersona;
import arcade.Register1;
import java.awt.Color;
import java.util.List;
import javax.swing.ImageIcon;
import javax.swing.JOptionPane;

/**
 *
 * @author Aniquila
 */
public class Vista extends javax.swing.JFrame {

    PersonaLog personas;
    Persona per;
    
   

    public Vista() {
        initComponents();
      setSize(477, 534);
        this.setLocationRelativeTo(null);
        this.setResizable(false);
        this.getContentPane().setBackground(Color.RED);
        setTitle("REGISTER");
        setIconImage(new ImageIcon(getClass().getResource("/arcade/ICONO.png")).getImage());//icon for the aplication
        JB_Actualizar.setVisible(false);
         JB_Eleminar.setVisible(false);
        personas = new PersonaLog();
        ListarTabla();
    }

    private void ListarTabla() {
        List<Persona> listas = personas.listado();
        jTable1.setModel(new ModeloTablaPersona(listas));
        jTable1.getRowSorter();
    }

    public void Limpiar() {
        jTextField1.setText("");
        jTextField2.setText("");
        jTextField3.setText("");
    }

    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        jLabel1 = new javax.swing.JLabel();
        jLabel2 = new javax.swing.JLabel();
        jLabel3 = new javax.swing.JLabel();
        jTextField1 = new javax.swing.JTextField();
        jTextField2 = new javax.swing.JTextField();
        jTextField3 = new javax.swing.JTextField();
        jScrollPane1 = new javax.swing.JScrollPane();
        jTable1 = new javax.swing.JTable();
        JB_aGREGAR = new javax.swing.JButton();
        JB_Actualizar = new javax.swing.JButton();
        JB_Eleminar = new javax.swing.JButton();
        jLabel4 = new javax.swing.JLabel();
        jButton1 = new javax.swing.JButton();
        ErrorDisplay = new javax.swing.JLabel();

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);
        setBackground(new java.awt.Color(255, 0, 51));
        getContentPane().setLayout(null);

        jLabel1.setFont(new java.awt.Font("Jokerman", 0, 36)); // NOI18N
        jLabel1.setForeground(new java.awt.Color(255, 153, 0));
        jLabel1.setText("Name: ");
        getContentPane().add(jLabel1);
        jLabel1.setBounds(10, 80, 180, 55);

        jLabel2.setFont(new java.awt.Font("Jokerman", 0, 36)); // NOI18N
        jLabel2.setForeground(new java.awt.Color(255, 153, 0));
        jLabel2.setText("NickName:");
        getContentPane().add(jLabel2);
        jLabel2.setBounds(10, 130, 200, 55);

        jLabel3.setFont(new java.awt.Font("Jokerman", 0, 36)); // NOI18N
        jLabel3.setForeground(new java.awt.Color(255, 153, 0));
        jLabel3.setText("Age:");
        getContentPane().add(jLabel3);
        jLabel3.setBounds(10, 180, 180, 55);
        getContentPane().add(jTextField1);
        jTextField1.setBounds(220, 90, 240, 40);
        getContentPane().add(jTextField2);
        jTextField2.setBounds(220, 140, 240, 40);
        getContentPane().add(jTextField3);
        jTextField3.setBounds(220, 190, 240, 40);

        jTable1.setModel(new javax.swing.table.DefaultTableModel(
            new Object [][] {

            },
            new String [] {

            }
        ));
        jTable1.addMouseListener(new java.awt.event.MouseAdapter() {
            public void mouseClicked(java.awt.event.MouseEvent evt) {
                jTable1MouseClicked(evt);
            }
        });
        jScrollPane1.setViewportView(jTable1);

        getContentPane().add(jScrollPane1);
        jScrollPane1.setBounds(10, 323, 452, 190);

        JB_aGREGAR.setBackground(new java.awt.Color(255, 153, 0));
        JB_aGREGAR.setFont(new java.awt.Font("OCR A Extended", 0, 14)); // NOI18N
        JB_aGREGAR.setText("SAVE");
        JB_aGREGAR.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                JB_aGREGARActionPerformed(evt);
            }
        });
        getContentPane().add(JB_aGREGAR);
        JB_aGREGAR.setBounds(100, 260, 70, 30);

        JB_Actualizar.setBackground(new java.awt.Color(51, 153, 0));
        JB_Actualizar.setFont(new java.awt.Font("OCR A Extended", 0, 14)); // NOI18N
        JB_Actualizar.setText("UPDATE");
        JB_Actualizar.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                JB_ActualizarActionPerformed(evt);
            }
        });
        getContentPane().add(JB_Actualizar);
        JB_Actualizar.setBounds(20, 260, 81, 30);

        JB_Eleminar.setBackground(new java.awt.Color(255, 0, 0));
        JB_Eleminar.setFont(new java.awt.Font("OCR A Extended", 0, 14)); // NOI18N
        JB_Eleminar.setText("DELETE");
        JB_Eleminar.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                JB_EleminarActionPerformed(evt);
            }
        });
        getContentPane().add(JB_Eleminar);
        JB_Eleminar.setBounds(190, 260, 81, 30);

        jLabel4.setFont(new java.awt.Font("Rockwell Condensed", 1, 40)); // NOI18N
        jLabel4.setForeground(new java.awt.Color(255, 255, 255));
        jLabel4.setText("R E G I S T E R");
        getContentPane().add(jLabel4);
        jLabel4.setBounds(110, 10, 260, 48);

        jButton1.setBackground(new java.awt.Color(0, 0, 255));
        jButton1.setFont(new java.awt.Font("OCR A Extended", 0, 14)); // NOI18N
        jButton1.setText("PLAY ANYWAY");
        jButton1.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jButton1ActionPerformed(evt);
            }
        });
        getContentPane().add(jButton1);
        jButton1.setBounds(250, 260, 140, 30);

        ErrorDisplay.setFont(new java.awt.Font("Onyx", 0, 24)); // NOI18N
        ErrorDisplay.setForeground(new java.awt.Color(255, 255, 255));
        ErrorDisplay.setText(". . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . .");
        getContentPane().add(ErrorDisplay);
        ErrorDisplay.setBounds(10, 50, 446, 23);

        pack();
    }// </editor-fold>//GEN-END:initComponents

    private void JB_aGREGARActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_JB_aGREGARActionPerformed

        if (jTextField1.getText().isEmpty()||jTextField2.getText().isEmpty()) {
        JOptionPane.showMessageDialog(null, "Please complete the information"); 
    }else{

        Persona person = new Persona(jTextField1.getText(), jTextField2.getText(), jTextField3.getText());
        boolean resp = personas.AgregarPersona(person);
        if (resp == false) {
            JOptionPane.showMessageDialog(null, "Added Data");
            
            ListarTabla();
            Limpiar();
            Register1 re = new Register1();
        re.setVisible(true);
        this.dispose();
        } else {
            JOptionPane.showMessageDialog(null, "Non-Aggregated Data");
            
        }
        
}

    }//GEN-LAST:event_JB_aGREGARActionPerformed

    private void JB_ActualizarActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_JB_ActualizarActionPerformed
        per.setNombre(jTextField1.getText());
        per.setApellidoP(jTextField2.getText());
        per.setApellidoM(jTextField3.getText());
        boolean resp = personas.UpdatePersona(per);
        if (resp == false) {
            JOptionPane.showMessageDialog(null, "Updated Data");
            ListarTabla();
            Limpiar();
        } else {
            JOptionPane.showMessageDialog(null, "Data not updated");
        }
    }//GEN-LAST:event_JB_ActualizarActionPerformed

    private void JB_EleminarActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_JB_EleminarActionPerformed
        boolean resp = personas.DeletePersona(per);
        if (resp == false) {
            JOptionPane.showMessageDialog(null, "Deleted Data");
            ListarTabla();
            Limpiar();
        } else {
            JOptionPane.showMessageDialog(null, "Data Not Deleted");
        }
    }//GEN-LAST:event_JB_EleminarActionPerformed

    private void jTable1MouseClicked(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_jTable1MouseClicked
        per = ((ModeloTablaPersona) jTable1.getModel()).DamePersona(jTable1.getSelectedRow());
        jTextField1.setText(per.getNombre());
        jTextField2.setText(per.getApellidoP());
        jTextField3.setText(per.getApellidoM());
    }//GEN-LAST:event_jTable1MouseClicked

    private void jButton1ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jButton1ActionPerformed
          Register1 re = new Register1();
        re.setVisible(true);
        this.dispose();
    }//GEN-LAST:event_jButton1ActionPerformed

    /**
     * @param args the command line arguments
     */
    public static void main(String args[]) {
        /* Set the Nimbus look and feel */
        //<editor-fold defaultstate="collapsed" desc=" Look and feel setting code (optional) ">
        /* If Nimbus (introduced in Java SE 6) is not available, stay with the default look and feel.
         * For details see http://download.oracle.com/javase/tutorial/uiswing/lookandfeel/plaf.html 
         */
        try {
            for (javax.swing.UIManager.LookAndFeelInfo info : javax.swing.UIManager.getInstalledLookAndFeels()) {
                if ("Nimbus".equals(info.getName())) {
                    javax.swing.UIManager.setLookAndFeel(info.getClassName());
                    break;
                }
            }
        } catch (ClassNotFoundException ex) {
            java.util.logging.Logger.getLogger(Vista.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (InstantiationException ex) {
            java.util.logging.Logger.getLogger(Vista.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (IllegalAccessException ex) {
            java.util.logging.Logger.getLogger(Vista.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (javax.swing.UnsupportedLookAndFeelException ex) {
            java.util.logging.Logger.getLogger(Vista.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        }
        //</editor-fold>

        /* Create and display the form */
        java.awt.EventQueue.invokeLater(new Runnable() {
            public void run() {
                new Vista().setVisible(true);
            }
        });
    }

    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JLabel ErrorDisplay;
    private javax.swing.JButton JB_Actualizar;
    private javax.swing.JButton JB_Eleminar;
    private javax.swing.JButton JB_aGREGAR;
    private javax.swing.JButton jButton1;
    private javax.swing.JLabel jLabel1;
    private javax.swing.JLabel jLabel2;
    private javax.swing.JLabel jLabel3;
    private javax.swing.JLabel jLabel4;
    private javax.swing.JScrollPane jScrollPane1;
    private javax.swing.JTable jTable1;
    private javax.swing.JTextField jTextField1;
    private javax.swing.JTextField jTextField2;
    private javax.swing.JTextField jTextField3;
    // End of variables declaration//GEN-END:variables
}
