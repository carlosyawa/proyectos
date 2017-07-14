/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ahorcado;

import javax.swing.JOptionPane;

/**
 *
 * @author Luis Trinidad
 */
public class ModelAhorcado {
    private String[] array, array1, array2, ChosenArray;
    private String ChosenWord;
    private String[] FormedWord;
    private int flag;
    
    public ModelAhorcado(){
        array = new String[10];
        array[0] = "dog";
        array[1] = "cat";
        array[2] = "leon";
        array[3] = "elephant";
        array[4] = "rooster";
        array[5] = "wolf";
        array[6] = "jaguar";
        array[7] = "rabbit";
        array[8] = "squirrel";
        array[9] = "horse";
        
        array1 = new String[10];
        array1[0] = "juan";
        array1[1] = "luis";
        array1[2] = "fernando";
        array1[3] = "carlos";
        array1[4] = "ana";
        array1[5] = "gerardo";
        array1[6] = "paulina";
        array1[7] = "jorge";
        array1[8] = "martha";
        array1[9] = "iveth";
        
        array2 = new String[10];
        array2[0] = "armchair";
        array2[1] = "bed";
        array2[2] = "chair";
        array2[3] = "bookshelf";
        array2[4] = "clock";
        array2[5] = "desk";
        array2[6] = "table";
        array2[7] = "mirror";
        array2[8] = "iron";
        array2[9] = "lamp";
        
        ChosenWord = ChoosingWord();
        FormedWord = new String[ChosenWord.length()];
        FullfulingWord();
        flag = 0;
    }
    
    public String ChoosingWord(){
        int randomArray=(int)((Math.random()*3)); 
        //random for select the array which is going to provide the word
        if (randomArray==1){
            ChosenArray = array;
            JOptionPane.showMessageDialog(null,"Clue: Animals");
        }else if (randomArray==2){
            ChosenArray = array1;
            JOptionPane.showMessageDialog(null,"Clue: Proper Names");
        }else if (randomArray==2){
            ChosenArray = array2;
            JOptionPane.showMessageDialog(null,"Clue: Furniture");
        }
        //randon for selecting the correct word
        int randomWord=(int)((Math.random()*10));
        return ChosenArray[randomWord]; 
    }
    
    public void FullfulingWord(){
        for(int i=0;i<FormedWord.length; i++){
            FormedWord[i] = "*";
        }
    }
    
    public String comparing(char word){
        //System.out.println(elegida);
        String aux = "";
        String newWord = "";
        int counter = 0;
        flag = 0;
        
        while(counter<ChosenWord.length()){
            if((word==ChosenWord.charAt(counter)) && (FormedWord[counter].equals("*"))){
                aux += word;
                FormedWord[counter] = aux;
                aux = "";
                counter++;
                flag = 1;
            }
            else{
                counter++;
            }
        }
        
        for(int i=0; i<FormedWord.length;i++){
            newWord+=FormedWord[i];
        }
        return newWord;
    }
    
    public String getChosenWord(){
        return ChosenWord;
    }
    
    public int getFlag()
    {
        return flag;
    }
    
}
