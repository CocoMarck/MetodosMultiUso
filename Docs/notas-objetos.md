# Notas relacionadas con como manejar objetos en C#

Comunmente se pueden delcarar los parametros de los objetos de esta manera:  
```csharp
ObjChido obj_chido = new ObjChido();
ObjChido.parametro_str = "hello";
ObjChido.parametro_bool = true;
```

Pero tambien se puede así:
```csharp
ObjChido obj_chido = new ObjChido() {
    parametro_str = "hello", parametro_bool = true
};
```