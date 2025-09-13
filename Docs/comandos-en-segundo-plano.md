# Ejecutar metódo en segundo plano

[Task Run](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task.run?view=net-9.0)

Necesitas net, nomas con usar `Task.Run( () => { //func; } );`, es suficiente.
```csharp
Task.Run(() => {
    SystemUtil.runCommand( command:"fastfetch", external:true );
});
```
