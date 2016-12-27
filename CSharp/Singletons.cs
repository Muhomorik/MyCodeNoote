// Code from article:
// http://sergeyteplyakov.blogspot.se/2016/12/singleton-implementation-in-net-field.html

// Реализация синглтонов в .NET: Field-like vs. Lazy 

public class FieldLikeSingleton
{
    // Вариант C# 6
    public static FieldLikeSingleton Instance { get; } = new FieldLikeSingleton();
 
    private FieldLikeSingleton() {}
}
 
public class FieldLikeLazySingleton
{
    private static readonly Lazy<FieldLikeLazySingleton> _instance = new Lazy<FieldLikeLazySingleton>(() => new FieldLikeLazySingleton());
 
    public static FieldLikeLazySingleton Instance => _instance.Value;
 
    private FieldLikeLazySingleton() {}
}

Исключение, завернутое в TypeLoadException, по сути, становится необрабатываемым. Мы можем перехватить его в высокоуровневом catch(Exception), но там мы точно ничего не сможем с ним сделать. Наш тип является невалидным и любое обращение даже к любому статическому члену приведет к исключению. По сути, исключение в конструкторе такого синглтона должно приводить к прекращению работы приложения, поскольку его нормальная работа невозможна. 
Ленивый синглтон этой проблемой не обладает: если конструктор такого синглтона упадет в первый раз, то поле _instance останется непроинициализированным и при следующем обращении к синглтону будет еще одна попытка инициализации. 
