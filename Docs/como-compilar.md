# Como compilar con mono | Pruebas rapidas, sin depender de NET

**Añade todo lo las libs/archivos.cs necesarios al compilar**  
```bash
mcs -out:Program.exe Program.cs Core/SystemUtil.cs Core/ShowPrint.cs
mono Program.exe 
```



# Usar dotnet | NET | Compilar con el dotnet

```bash
dotnet publish -c Release -r linux-x64 --self-contained true -o bin
```  
*Necesitas del `archivo.csproj` para el dotnet*


## Porque ese necesario el .csproj  
- Define el tipo de aplicación (console, web, librery)  
- Especifica la versión de .NET que se usará.  
- Permite agregar dependencias (como System.Text.Json)  
- Facilita la compilación con dotnet publish para generar binarios sin necesidad de Mono.




# Inicializar el csproj
Establecer el Program.csproj
```xml
<Project Sdk="Microsoft.NET.Sdk">
 <PropertyGroup>
   <OutputType>Exe</OutputType>
   <TargetFramework>net8.0</TargetFramework>
   <RootNamespace>nombreCarpetaRaiz</RootNamespace>
   <Nullable>enable</Nullable>
   <ImplicitUsings>enable</ImplicitUsings>
  </PropertyGroup>
  
  <!-- Aca se agregar paquetes, libs, frameworks -->
  <ItemGroup>
   <PackageReference Include="System.Data.SQLite" Version="1.0.117" />
  </ItemGroup>

</Project>
```

El item group permite agregar mas libs adicionales.  
Mira la versión del `TargetFramework`, en este caso se pus la versión ocho `net8.0`. Dependera de lo que tu programa use.

## Probando dotnet
Primero ejecuta `restore`, este te servira para meter todo lo necesario para poder compilar chido.
```bash
dotnet restore
```

Ahora lo puedes ejecuta con `run`. Para probarlo.
```bash
dotnet run
```

Y finalmente ya pos cuando te listo el programilla, lo compilas. Puede que te jale nomas el `build` pelon. El build compila tu proyecto y deja los binarios listos **para desarrollo**
```bash
dotnet build
```