/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Conexion_Logico;

import Conexion_DAO.PersonaDao;
import Conexion_Entidades.Persona;
import java.util.List;

/**
 *
 * @author Aniquila
 */
public class PersonaLog {

    PersonaDao personas = new PersonaDao();

    public boolean AgregarPersona(Persona per) {
        return personas.AgregarPersona(per);
    }

    public boolean UpdatePersona(Persona per) {
        return personas.UpdatePersona(per);
    }

    public boolean DeletePersona(Persona per) {
        return personas.DeletePersona(per);
    }

    public List<Persona> listado() {
      return personas.listado();
    }

}
