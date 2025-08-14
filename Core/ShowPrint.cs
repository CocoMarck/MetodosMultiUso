using System;
using System.Text;

/*
Probar:
mcs -out:ShowPrint.exe ShowPrint.cs

mono ShowPrint.exe 

Usar docfx para documentar todo todito.
*/
// En SystemUtil.cs
namespace MetodosMultiUso.Core {

    /// Esta clase es para mostrar texto en terminal. El estilo del texto sera tipo Markdown
    public static class ShowPrint {
        // Constantes de la clase
        private const bool DEFAULT_CONSOLE = true;
    
        /// <summary>
        /// Este método genera un titulo en medio de espacio y caracteres en los lados.
        /// </summary>
        /// <param name="text">
        /// El texto que se va a mostrar como título. (por defecto "text")
        /// </param>
        /// <param name="character">
        /// El caracter que estara en los lados del text. (por defcto "#")
        /// </param>
        /// <param name="space">
        /// Cantidad de espacio para centrar texto. Minimo 1. (por defecto 4)
        /// </param>
        /// <param name="console">
        /// Valor boleano que establece si se mostrara el texto en consola. (por defecto false)
        /// </param>
        /// <returns>Devuelve un string</returns>
        public static string title( 
            string text="text", string character="#", int space=4, bool console=DEFAULT_CONSOLE
        ) {
            // Establecer espaciado | Estilo de titulo
            // Determinar que el espacio sea mayor que cero.
            if ( !(space > 0) ) {
                space = 1;
            }

            string text_space = new string(' ', space);

            // Texto a retornar
            string text_return = $"{character}{text_space}{text}{text_space}{character}";

            // Imprimir en consola
            if (console == true) {
                Console.WriteLine( text_return );
            }
            return text_return += "\n";
        }
        
        
        
        
        /// <summary>
        /// Este método es para obetner info del usuario por consola.
        /// </summary>
        /// <param name="text">Texto a mostrar</param>
        public static string input( string text="texto", string type="string" ) {
            Console.Write( text );
            string? input_value = Console.ReadLine();
            if (input_value == null) {
                input_value = "";
            }
            return input_value;
        }
        
        
        
        
        /// <summary>
        /// Este método determina si se desea continuar o no. Se usa un clasico "Input de Consola"
        /// </summary>
        /// <param name="text">
        /// El texto que se mostrara como pregunta de ¿Continuar?
        /// </param>
        /// <param name="yn">
        /// Lista de dos valores string, el indice0 indica el si, y el indice1 indica el no
        /// </param>
        /// <param name="message_error">
        /// Mostrar o no el error del input.
        /// </param>
        /// <returns>bool</returns>
        public static bool inputContinue(
            string text="¿Continuar?", string[]? yn=null, bool message_error=DEFAULT_CONSOLE
        ) {
            // Establecer valor default de "y" "n"
            if (yn == null) {
                yn = new string[] {"y", "n"};
            }
            
            // Declarar opcion selecionada
            string? option = null;
            
            // Bucle | Retornar true o false
            while (true) {
                // Input
                option = input($"{text} ({yn[0]}/{yn[1]}): ")?.ToLower().Trim();
                
                // Parar o no bucle | Retornar true o false
                if (option == yn[0]){
                    return true;
                }
                else if (option == yn[1]){
                    return false;
                }
                else {
                    if (message_error){
                        Console.WriteLine("error");
                    }
                }
            }
        }
        
        
        
        /// <summary>
        /// Muestra una serie de un solo caracter, tiene la funcion de separar textos.
        /// </summary>
        /// <param name="character">
        ///  Un simbolo/caracter, que se repetira por smb_number
        /// </param>
        /// <param name="number">
        /// Catidad de simbolos/caracteres.
        /// </param>
        /// <param name="console">
        /// Mostrar con print o no.
        /// </param>
        /// <returns>string</returns>
        public static string separator (
            string character="-", int number=128, bool console=DEFAULT_CONSOLE
        ) {
            // Establecer Separador
            string text_separator = (
                new StringBuilder(character.Length * number).Insert(0, character, number).ToString()
            );
            
            // Añadir saltos de lina a separador
            string text_return = $"\n\n{text_separator}\n\n";
            
            // Mostrar o no el separador en pantalla
            if (console == true) {
                Console.WriteLine(text_return);
            }
            
            // Retornar texto
            return text_return;
        }
        
        
        
        
        
        public static string textBox(
            string text="", string character="```", string text_type="", bool console=DEFAULT_CONSOLE
        ) {
            // Cuando un string es null, y se muestra en un `$"{null}"`, no se vera nada. Como debe ser. ¡Siuu!
            string final_text = $"\n{character}{text_type}\n{text}\n{character}\n";
            if (console == true) { Console.Write(final_text); }
            
            return final_text;
        }
        
        


        /// <summary>
        /// Muestra un comando encerrado en ```/
        /// </summary>
        /// <returns>string</returns>
        public static string codeText( 
            string text="Nothing", string? text_type=null, bool console=DEFAULT_CONSOLE 
        ) {
            // Establecer que tipo de caja de código sera
            string character = "```";
            if (text_type == null) { 
                character = "~~~" ;
                text_type = ""; // No se necesita, pero es para evitar errores con textBox
            }
            
            string final_text = textBox( 
                text:text, character:character, text_type:text_type, console:console
            );

            return final_text;
        }
        



        /// <sumary>Mostrar y devolver texto<sumary>
        public static string printAndReturn( string text="", bool console=DEFAULT_CONSOLE){
            if ( console ){
                Console.WriteLine( text );
            }
            return text + "\n";
        }

    }
}