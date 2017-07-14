package Conexion_ModeloTabla;

import Conexion_Entidades.Persona;
import java.util.ArrayList;
import java.util.List;
import javax.swing.table.AbstractTableModel;

/**
 *
 * @author Aniquila
 */
public class ModeloTablaPersona extends AbstractTableModel {

    String[] columnas = {"Name", "Gender", "Age"};
    public List<Persona> personas = new ArrayList<>();

    public ModeloTablaPersona(List<Persona> personas) {
        this.personas = personas;
    }

    @Override
    public String getColumnName(int column) {
        return columnas[column];
    }

    @Override
    public int getRowCount() {
        return personas.size();
    }

    @Override
    public int getColumnCount() {
        return columnas.length;
    }

    @Override
    public Object getValueAt(int rowIndex, int columnIndex) {
        Object resp = null;
        if (columnIndex == 0) {
            resp = personas.get(rowIndex).getNombre();
        } else {
            if (columnIndex == 1) {
                resp = personas.get(rowIndex).getApellidoP();
            } else {
                resp = personas.get(rowIndex).getApellidoM();
            }
        }
        return resp;
    }

    public Persona DamePersona(int fila) {
        return personas.get(fila);
    }
}
