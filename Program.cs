using System;
using MetodosMultiUso.Core;

/*
mcs -out:Program.exe Program.cs Core/SystemUtil.cs Core/ShowPrint.cs
mono Program.exe 
*/

public static class Program {
    static void Main() {
        // cleanScreen | title | separator
        Console.Clear(); // SystemUtil.cleanScreen();
        ShowPrint.title( text: "Probando todos los modulos", console: true );
        Console.WriteLine( 
            "Aca veremos como se usan los modulos locos, por ejemplo, ve como jala " +
            "`ShowPrint.inputContinue`:"
        );

        bool go = ShowPrint.inputContinue( message_error: true );
        if (go == true) {
            Console.WriteLine( "Continuamos...");
        }
        else {
            Console.WriteLine( "Igualmente vamos a continuar...");
        }
        
        ShowPrint.separator( console: true );
        



        // Usando "title"
        ShowPrint.title( "Como se muestra por defecto ShowPrint.title", console: true );
        Console.WriteLine( 
            "Por defecto el metodo `title`, se muestra asi:\n    " +
            ShowPrint.title( console: false ) + "\n" +
            
            "Tambien se le pueden cambiar su diseño:\n    "+
            ShowPrint.title(
                text: "Espacio", 
                character: "@", space: 8, console: false
            ) + "\n\n" +
            
            "No te dites cuenta pero ya se esta usando otro metodo, se llama `ShowPrint.separator` " +
            "este sirve para mostrar dar sparaciones visuales, mira esta sparación, " +
            "usando el caracter `^`(con 100 de estos caracteres):\n" +
            
            ShowPrint.separator( character: "^", number: 100, console:false ) + 
            
            "Bueno, ahora veremos como funcan otras funciones/metodos."
        );
        Console.Write( "Preciona enter para continuar..." );
        Console.ReadLine();
        
        
        // ...
        //ShowPrint.separator(console: true);
        Console.Clear(); //SystemUtil.cleanScreen();
        
        ShowPrint.title( "Usando `SystemUtil`", console:true );
        Console.WriteLine(
            $"El sistema operativo que estas usando es: {SystemUtil.getSystem()}.\n" +
            "El metodo que se uso para saber el OS, es `SystemUtil.getSystem`."
        );
    }
}