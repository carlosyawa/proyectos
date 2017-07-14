package Conexion_DAO;

import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import javax.swing.JOptionPane;

/**
 *
 * @author Aniquila
 */
public class Conexion {
  Connection con = null;
    String user="sa";
    String pass="123456789";
    String driver="com.microsoft.sqlserver.jdbc.SQLServerDriver";
    String url="jdbc:sqlserver://localhost:1433;databaseName=prueba1";
    

    public Connection getConecion() {
      
        try {
            Class.forName(driver);
            con = DriverManager.getConnection(url, user, pass);
        } catch (ClassNotFoundException | SQLException e) {
            e.printStackTrace();
        }
        return con;
    }
   public boolean insert(String table, String fields, String values) {
        boolean res = false;
        String a = "INSERT INTO " + table + " ( " + fields + " ) VALUES (" + values + " ) ";
        System.out.println(a);
        try {
            PreparedStatement rox = con.prepareStatement(a);
            rox.execute();
            rox.close();
            res = true;
            JOptionPane.showMessageDialog(null, "Product has been added succesfuly", "Added", JOptionPane.INFORMATION_MESSAGE);
        } catch (SQLException e) {
            System.out.println(e);
        }
        return res;
    }

    public void Cerrar1(Connection con, CallableStatement cstm) {
        try {
            if (con != null) {
                con.close();
            }
            if (cstm != null) {
                cstm.close();
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    public void Cerrar2(CallableStatement cstm, ResultSet rs) {
        try {
            if (rs != null) {
                rs.close();
            }
            if (cstm != null) {
                cstm.close();
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

}
