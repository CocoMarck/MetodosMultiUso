# Notas sobre que seguir para escalar bibloteca

Es que el MetodosMultiUso, tendra cosas como; Models/StandarDataBase.cs, Views/Interface/CssUtil.cs, Models/Language.cs, Controller/DataBaseController.cs. Al final el MetodosMultiUso si tendra una app gui para usar los modulos como CssUtil.cs. Pero todavia falta tiempo para eso.



## Importación mas chida

Lo mejor es importar las func/metodos lo mas directo posible, para evitar despues cambiar el nombre las funcs

**Así no**  
```cs
MetodosMultiUso.ShowPrint.title();
```

**Así SI**  
```cs
title();
```

### ¿Como lograr esto?
**Usando static:** De esta manera logramos importar todos los metodos del modulo de manera directa.
```cs
using static MetodosMultiUso.Core.ShowPrint;

title();
```

**Antes**  
```cs
using MetodosMultiUso.Core;

ShowPrint.title();
```
*No puedes hacer que un archivo .cs sea estático, porque static es un modificador de clases, métodos y atributos, no de archivos.*