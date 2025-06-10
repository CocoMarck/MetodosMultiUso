# Como compilar

**Añade todo lo las libs/archivos.cs necesarios al compilar**  
```bash
mcs -out:Program.exe Program.cs Core/SystemUtil.cs Core/ShowPrint.cs
mono Program.exe 
```



## Con el dotnet

```bash
dotnet publish -c Release -r linux-x64 --self-contained true -o bin
```  
*Necesitas del `archivo.csproj` para el dotnet*


### Porque ese necesario el .csproj  
- Define el tipo de aplicación (console, web, librery)  
- Especifica la versión de .NET que se usará.  
- Permite agregar dependencias (como System.Text.Json)  
- Facilita la compilación con dotnet publish para generar binarios sin necesidad de Mono.