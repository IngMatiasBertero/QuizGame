using Quiz_Game;
using System.Collections.Immutable;
using System.IO.Pipes;

Console.WriteLine("Quiz Game");

 
var preguntas = new List<Preguntas>();
var respuestas = new List<Respuestas>();


PreguntasYopciones();
StartGame();

void StartGame()
{
    Console.WriteLine("Hola, introduce tu nombre");

    var usuario = Console.ReadLine();

    Console.WriteLine($"Hola {usuario} que empieze el juego ");

    foreach (var item in preguntas)
    {
        Console.WriteLine(item.Pregunta);
        Console.WriteLine("Porfavor elige una de la siguientes opciones:");

        foreach (var opcion in item.opcion)
        {
            Console.WriteLine($"{opcion.id}. {opcion.Texto}");
        }

        var respuesta = Seleccion();
        AgregarRespuestaAlaLista(respuesta,item);
    }
}

string Seleccion()
{
   var respuesta = Console.ReadLine();

    if (respuesta != null && respuesta == "1" || respuesta == "2" || respuesta == "3" || respuesta == "4")
    {
        return respuesta;
    }
    else
    {
        Console.WriteLine("La opcion no es valida");
        respuesta = Seleccion();
    }
    return respuesta;

}

void AgregarRespuestaAlaLista(string respuesta, Preguntas preguntas)
{
    respuestas.Add(new Respuestas
    {
        PreguntaId = preguntas.id,
        Seleccion = TomarSeleccion(respuesta,preguntas)

    });
}

Opciones TomarSeleccion(string respuesta, Preguntas preguntas)
{
    var Seleccion = new Opciones();

    foreach (var item in preguntas.opcion)
    {
        if (item.id == int.Parse(respuesta))
            Seleccion = item;

    }

    return Seleccion;
}

void PreguntasYopciones()
{
    preguntas.Add(new Preguntas
    {

        id = 1,
        Pregunta = "Cual es el pais mas grande del planeta?",
        opcion = new List<Opciones>()
        {
            new Opciones() {id=1,Texto="Australia"},
            new Opciones() {id=2,Texto="China"},
            new Opciones() {id=3,Texto="Canada"},
            new Opciones() {id=4,Texto="Rusia", Correcto = true}
        }
    });


    preguntas.Add(new Preguntas
    {
        id = 2,
        Pregunta = "Cual pais tiene mayor cantidad de habitantes?",
        opcion = new List<Opciones>() 
        {
            new Opciones() {id=1,Texto="India"},
            new Opciones() {id=2,Texto="China",Correcto = true},
            new Opciones() {id=3,Texto="Estados Unidos"},
            new Opciones() {id=4,Texto="Indonesia"}
        }

    });

    preguntas.Add(new Preguntas
    {
        id = 3,
        Pregunta = "Cual fue el pais menos corrupto en el 2021?",
        opcion = new List<Opciones>()
        {
            new Opciones() {id=1,Texto="Finlandia"},
            new Opciones() {id=2,Texto="Nueva Zelanda"},
            new Opciones() {id=3,Texto="Dinamarca",Correcto=true},
            new Opciones() {id=4,Texto="Noruega"}
        }

    });

    preguntas.Add(new Preguntas
    {
        id = 4,
        Pregunta = "Cual es el pais con mejor calidad de vida en 2021?",
        opcion = new List<Opciones>()
        {
            new Opciones() {id=1,Texto="Noruega",Correcto=true},
            new Opciones() {id=2,Texto="Belgica"},
            new Opciones() {id=3,Texto="Suiza"},
            new Opciones() {id=4,Texto="Inglaterra"}
        }

    });

}