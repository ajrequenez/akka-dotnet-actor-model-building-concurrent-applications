using Akka.Actor;
using MovieStreaming.Common;

namespace MovieStreaming.Remote
{
    internal class Program
    {
        public static ActorSystem? MovieStreamingActorSystem;

        static void Main(string[] args)
        {
            Console.WriteLine("Application Starting...");

            ColorConsole.WriteLineGray("Creating Remote MovieStreamingActorSystem");
            MovieStreamingActorSystem = ActorSystem.Create("MovieStreamingActorSystem");

            Console.ReadLine();
            MovieStreamingActorSystem.Terminate();
        }
    }
}