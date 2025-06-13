# Estructura C#
Se usara la estructura MVC.
Aca solo abra modulos, y el Program.cs para probar los modulos. Has de cuenta el main.


```bash
Raiz: Metodos Multi Uso
Data/
    # Base de datos. Archivos con datos para el programa
    # NO ARCHIVOS de texto UTF

Models/
    # Objetos tipo modelo

Controllers/
    # Objetos que controlen los modelos de manera segura. Objetos para usar en la app.

Views/
    Interface/
        # Modulos de uso general relacionados con la interfaz
    # Programa visual. (Aca no abra programa visual, pero si existiera aca estaria)

Core/
    Config/
        # Funciones logica que usan archivos de texto UTF con configuraciones.
        # De preferencia JSON o XML
        SystemUtilConf.cs
    # Funciones logicas para uso general
    SystemUtil.cs
    ShowPrint.cs

Config/
    # Archivos de texto UTF con info para programas.
    # De preferencia JSON o XML
    runCommand.conf

Logs/
    # Archivos de registro txt de la funcionalidad del programa

Resources/
    # Archivos multimedia
    Images/
    Audio/
    Video/
    Icons/

Notas/
    # Notas de todo tipo MD, txt, pdf. No esperar mucho orden logico.
    Estructuras/
    Ejemplos/
    Conceptos/

Referencias/

Program.cs # Punto de entrada del proyecto.
```