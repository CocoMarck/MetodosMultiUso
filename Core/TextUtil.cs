using System.IO;
using System.Text;
using System.Collections.Generic; // Para List y Dict | TextUtil
using System.Text.RegularExpressions; // Para concidencias en texto | IgnoreComment

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
        // Constantes
        public const string FILTER_ABC = "abcdefghijklmnñopqrstuvwxyz";
        public const string FILTER_NUMBER = "1234567890";
        public static readonly Dictionary<char, int> DICT_ABC = new Dictionary<char, int>();
        
        // Constructor
        static TextUtil(){
            for( int index=0; index<FILTER_ABC.Length; index++ ){
                char character = FILTER_ABC[index]; 
                DICT_ABC.Add( character, index );
            }
        }

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
    
    


        /// Ignorar cometario
        /// Necesita que el texto si o si sea un string, acepta saltos de linea `/n`
        public static string ignoreComment( string text="Ejemplo # Comentario", string comment="#" ){
            string text_ready = "";
            
            // Cuando son multiples lineas
            if ( Regex.IsMatch(text, "\n") ) {
                //Console.WriteLine("Saltos de linea");
                string[] split_text = text.Split("\n");
                string ready_line = "";
                foreach (string line in split_text){
                    ready_line = ignoreComment( text:line, comment:comment );
                    text_ready += ready_line;
                    if (ready_line != "") {
                        text_ready += "\n";
                    }
                }
                text_ready = text_ready.Remove(text_ready.Length -1);
            }
            // Cuando es una sola lineas
            else if ( Regex.IsMatch(text, comment) ){
                //Console.WriteLine("Una sola linea");
                string[] split_text = text.Split(comment);
                text_ready = split_text[0];
            }
            else {
                //Console.WriteLine("Sin comentarios");
                text_ready = text;
            }
            
            // Se retorna el texto sin comentarios
            return text_ready;
        }
        
        
        
        
        /// Detectar si un texto tiene saltos de linea, y devolver si o si array con strings
        public static string[] matixLineBreaks( string text="Ejemplo\nChido", string line_break="\n" ){
            // Array vacio.
            string[] array_text = {};

            // Agregar lineas de texto
            if ( Regex.IsMatch(text, line_break) ) {
                array_text = text.Split(line_break);

            // Agregar el texto, solo si es que no es nulo o vacio
            } else {
                if ( string.IsNullOrEmpty(text) == false ){
                    array_text = new string[1];
                    array_text[0] = text;
                }
            }
            return array_text;
        }
        
        
        
        
        /// Para separar el texto en dos, y almacenarlo en un diccionario.
        public static Dictionary<string, string> separeText( 
            string text="variable=Valor", string separator="="
        ){
            Dictionary<string, string> dict_text = new Dictionary<string, string>();
            
            if ( Regex.IsMatch(text, separator) ) {
                string[] split_text = text.Split( separator );
                dict_text.Add( split_text[0], split_text[1] );
            }
            
            return dict_text;
        }




        // Solo los comentarios
        public static string onlyTheComment( string text="# Comentario\nTexto normal", string comment="#" ) {
            string text_ready = "";
            
            // Cuando son multiples lineas
            if ( Regex.IsMatch(text, "\n") ) {
                string[] split_text = text.Split("\n");
                string ready_line = "";
                foreach( string line in split_text ) {
                    ready_line = onlyTheComment( text:line, comment:comment );
                    text_ready += ready_line;
                    if ( ready_line != "" ) {
                        text_ready += "\n";
                    }
                }
                text_ready = text_ready.Remove( text_ready.Length -1 );
            }
            // Establecer texto de comentarios
            else if ( Regex.IsMatch(text, comment) ) {
                string[] split_text = text.Split(comment);
                int index = 0;
                foreach( string comment_text in split_text ){
                    if ( 
                     (index > 0) && (string.IsNullOrEmpty(comment_text) == false) 
                    ) {
                        text_ready += comment_text.Trim();
                    }
                    index += 1;
                }    
            }
            
            return text_ready;
        }
        
        
        
        /// Diccionario con texto filtrado
        // QUE EL KEY SEA UN NUMERO, Y EL VALUE SEAN `char, bool`
        public static Dictionary<int, (char, bool)> filteredTextDictionary(
            string text="Hola 2", string filter="123" 
        ) {
            Dictionary<int, (char, bool)> dict_text = new Dictionary<int, (char, bool)>();
            
            // Recorrer caracteres de string | Bucle uno
            for( int index=0; index < text.Length; index++ ) {
                char character = text[index];
                
                // Determinar si el string pasa el filtro o no | Bucle dos
                // Establecer en if, el char en minusculas
                bool pass = false;
                for(int index_filter=0; index_filter < filter.Length; index_filter++){
                    char character_filter = filter[index_filter];
                    if ( char.ToLower(character) == character_filter) { pass = true; }
                }
                dict_text.Add( index, (character, pass) );
            }
            
            return dict_text;
        }
        
        
        /// Devolver si el texto pasa el filtro
        public static bool passTextFilter( string text="123133", string filter="123" ){
            bool pass = true;
            Dictionary<int, (char, bool)> dict_text = (Dictionary<int, (char, bool)>)filteredTextDictionary(
                text:text, filter:filter
            );
            
            // Bucle para determinar si algun value es falso, y si lo es romper bucle y pos no pasa el filtro.
            foreach (var element in dict_text ) {
                var (character, good_character) = element.Value;
                if (good_character == false) { 
                    pass = false; 
                    break;
                }
            }
            
            return pass;
        }
        
        /// Ignorar texto que no cumpla el filtro
        public static string ignoreTextFilter( string text, string filter ) {
            Dictionary<int,(char, bool)> dict_text = (Dictionary<int,(char, bool)>)filteredTextDictionary(
                text:text, filter:filter 
            );
            string final_text = "";
            
            // Bucle para agregar solo el caracteres bonitos. Que pasen el filtro.
            foreach(var element in dict_text) {
                var (character, good_character) = element.Value;
                if (good_character) {
                    final_text += character.ToString();
                }
            }
            
            return final_text;
        }
        
        
        
        
        /// Ordenar array de string por abecedario
        public static string[] arrayAlphabet( string[] array ) {
            // Ordenar cada letar del abecedario en un diccionario. `DICT_ABC`
            
            // Diccionario abc vacio. Para ordenar los textos por medio del abecedario
            Dictionary<int, List<string> > dict_position = new Dictionary<int, List<string> >();
            foreach( var element in DICT_ABC ){
                List<string> list = new List<string>();
                dict_position.Add( element.Value, list );
            }
            
            // Textos
            foreach( string text in array ) {
                // Establecer texto para analizar. Texto con filtros, sin mayusculas y sin espacios.
                string text_to_analize = text.Trim().ToLower();
            
                // Obtener posición del texto. Donde estara segun `DICT_ABC`
                // Si no encuentra nadota en `DICT_ABC`, el texto se pondra al ultimo.
                int position = DICT_ABC.Count-1;

                for( int index=0; index<text_to_analize.Length; index++ ){ 
                    char character = text_to_analize[index]; 
                    if ( DICT_ABC.ContainsKey(character) ) {
                        position = DICT_ABC[character];
                        break;
                    }
                }
                
                // Agregar texto en posicion indicada
                dict_position[position].Add(text);
            }
            
            // Lista final
            List<string> final_list = new List<string>();
            foreach( var element in dict_position ){
                final_list.AddRange( element.Value );
            }
            
            // Array a retornar
            string[] final_array = final_list.ToArray();
            
            return final_array;
        }
        
        
        
        
        /// Eliminar los items repetidos en un array
        public static string[] arrayNotRepeatItem( string[] array ){
            string[] final_array = {};
            
            return final_array;
        }

    }
}