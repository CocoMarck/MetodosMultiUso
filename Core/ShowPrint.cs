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
            return text_return;
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
            string text="¿Continuar?", string[] yn=null, bool message_error=DEFAULT_CONSOLE
        ) {
            // Establecer valor default de "y" "n"
            if (yn == null) {
                yn = new string[] {"y", "n"};
            }
            
            // Declarar opcion selecionada
            string option = null;
            
            // Bucle | Retornar true o false
            while (true) {
                // Input
                Console.Write( $"{text} ({yn[0]}/{yn[1]}): " );
                option = Console.ReadLine()?.ToLower().Trim();
                
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

    }

}