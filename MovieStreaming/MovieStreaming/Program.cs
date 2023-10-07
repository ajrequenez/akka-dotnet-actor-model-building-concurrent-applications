using Akka.Actor;
using MovieStreaming.Actors;
using MovieStreaming.Messages;

namespace MovieStreaming
{
    internal class Program
    {
        public static ActorSystem? MovieStreamingActorSystem;
        static void Main(string[] args)
        {
            Console.WriteLine("Application Starting...");

            Console.ReadLine();
            MovieStreamingActorSystem = ActorSystem.Create("MovieStreamingActorSystem");
            Console.WriteLine("ActorSystem Created...");

            Console.ReadLine();
            IActorRef userActorRef = MovieStreamingActorSystem.ActorOf(UserActor.Props(), "UserActor");

            userActorRef.Tell(new PlayMovieMessage("Akka.NET: The Movie", 42));

            Console.ReadLine();
            Console.WriteLine("ActorSystem shutting down...");
            MovieStreamingActorSystem.Terminate();
        }
    }
}