# Datetime

# Formatear datatime
[Comillas dentro de comillas](https://www.delftstack.com/es/howto/csharp/escape-double-quotes-in-csharp/)
[Tutorial numero a 01](https://stackoverflow.com/questions/5972949/number-formatting-how-to-convert-1-to-01-2-to-02-etc)

```csharp
number.ToString("D2");
```

```csharp
public static string getDateTimeFormatted( DateTime datetime ) {
    string month_text = datetime.Month.ToString("D2");
    string day_text = datetime.Day.ToString("D2");
    string hour_text = datetime.Hour.ToString("D2");
    string minute_text = datetime.Minute.ToString("D2");
    string second_text = datetime.Second.ToString("D2");

    string datetime_text = (
        $"{datetime.Year}-{month_text}-{day_text}T" +
        $"{hour_text}:{minute_text}:{second_text}"
    );
    return datetime_text;
}
```


[tutorial get last day of the month](https://makolyte.com/csharp-get-the-last-day-of-the-month/)
