using System.IO;
using System.Text;
using System.Collections.Generic;

/*
Esta clase servira para obtener información del texto.

Por ejemplo sacar de `valor=1`, el `1`

Leer un texto y devolverlo como un string normalon, o como una lista por cada salto de line adetecatdo.

Dejas los multiples espacios como uno solo. O evitar la repeticion de cualquier otro caracter.
De `cccc` a `c`

Filtrar texto. Solo permitir en el texto caracteres especificados, como:
`filtro="12345678910"` `texto="hola1"`, resultado: `1`.
*/
namespace MetodosMultiUso.Core {
    public static class TextUtil {

        // Leer archivo de texto
        // Por defecto solo se devuelve el texto pelon.
        // tipos de valor con este formato: `nombre-chido`
        // No espacios, no mayusculas, solo minusculas y menos.
        // Como usar `string[] variable = (string[])readTextFile( file, "array");
        public static object readTextFile( string file, string return_type="default"){
            string text = File.ReadAllText( file );
            
            string[] text_array = {};
            
            // Establecer lista o no
            if ( 
                return_type == "list" || return_type == "array" || return_type == "dictionary"
            ){
                text_array = text.Split( '\n' );
            }
            
            // Devolver lo correcto
            if ( return_type == "list" ){
                List<string> text_list = new List<string>();
                foreach (string line in text_array ){
                    text_list.Add(line);
                }
                return text_list;
            }
            // Array
            else if ( return_type == "array" ){
                return text_array;
            }
            // Diccionario
            else if ( return_type == "dictionary" ){
                Dictionary<int, string> text_dict = new Dictionary<int, string>();
                int count = 0;
                foreach ( string line in text_array ) {
                    text_dict.Add(count, line);
                    count += 1;
                }
                return text_dict;
            }
            // Por defecto se devuelve el textillo. Tambien si se pone una opcion que no exite.
            else {
                return text;
            }
            
            
        }
    }
}