using Akka.Actor;
using MovieStreaming.Actors;
using MovieStreaming.Messages;

namespace MovieStreaming.Actors
{
    public class UserActor : ReceiveActor
    {
        private string? _currentlyWatching;

        public UserActor()
        {
            Console.WriteLine("Creating User Actor...");
            ColorConsole.WriteLineCyan("Setting user actor to initial state of Stopped");

            Stopped();
        }

        private void Playing()
        {
            Receive<PlayMovieMessage>(message => StartPlayingMovie(message.MovieTitle));
            Receive<StopPlaybackMessage>(_ => StopPlayingMovie());
        }

        private void Stopped()
        {
            Receive<PlayMovieMessage>(message => StartPlayingMovie(message.MovieTitle));
            Receive<StopPlaybackMessage>(_ => ColorConsole.WriteLineRed("Error: cannot stop if nothing is currenlty playing"));
        }
        private void StartPlayingMovie(string title)
        {
            _currentlyWatching = title;

            ColorConsole.WriteLineYellow(
                string.Format("User is currently watching: {0}", title));

            Become(Stopped);
        }

        private void StopPlayingMovie()
        {
            ColorConsole.WriteLineYellow(
                string.Format("User stopped watching {0}", _currentlyWatching));

            _currentlyWatching = null;

            Become(Playing);
        }
        protected override void PreStart()
        {
            ColorConsole.WriteLineGreen("User Actor Prestart");
        }

        protected override void PostStop()
        {
            ColorConsole.WriteLineGreen("User Actor PostStop");
        }

        protected override void PreRestart(Exception reason, object message)
        {
            ColorConsole.WriteLineGreen(
                string.Format("User Actor PreRestart because: {0}", reason));
            base.PreRestart(reason, message);
        }
        protected override void PostRestart(Exception reason)
        {
            ColorConsole.WriteLineGreen(
                string.Format("User Actor PostRestart because: {0}", reason));
            base.PostRestart(reason);
        }

        public static Props Props() => Akka.Actor.Props.Create(() =>  new UserActor());
    }
}
