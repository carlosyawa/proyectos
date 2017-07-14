/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Conexion_Entidades;

/**
 *
 * @author Aniquila
 */
public class Persona {

    int idpers;
    String nombre;
    String genero;
    String edad;
    boolean estado;

    public Persona() {
    }

    public Persona(String nombre, String apellidoP, String apellidoM) {
        this.nombre = nombre;
        this.genero = apellidoP;
        this.edad = apellidoM;
    }

    public int getIdpers() {
        return idpers;
    }

    public void setIdpers(int idpers) {
        this.idpers = idpers;
    }

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public String getApellidoP() {
        return genero;
    }

    public void setApellidoP(String apellidoP) {
        this.genero = apellidoP;
    }

    public String getApellidoM() {
        return edad;
    }

    public void setApellidoM(String apellidoM) {
        this.edad = apellidoM;
    }

    public boolean isEstado() {
        return estado;
    }

    public void setEstado(boolean estado) {
        this.estado = estado;
    }

}
